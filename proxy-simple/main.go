package main

import (
	"bytes"
	"fmt"
	"io/ioutil"
	"net"
	"net/http"
	"strings"
	"github.com/elazarl/goproxy"
	"github.com/pkg/errors"
)
// import "C"

func main() {
	StartProxy()
}

//export StartProxy 
func StartProxy(){
	rsyars := &rsyars{
		ch:   make(chan response, 128),
	}
	if err := rsyars.Run(); err != nil {
		fmt.Printf("Proxy Error -> %+v\n\r", err)
	}
}

type NilLogger struct{}
func (NilLogger) Printf(format string, v ...interface{}) {}


type response struct {
	Host string
	Path string
	Body []byte
}

type rsyars struct {
	ch   chan response
}

func (rs *rsyars) Run() error {
	go rs.loop()

	localhost, err := rs.getLocalhost()
	if err != nil {
		fmt.Printf("Get Proxy IP Failed -> %+v\n\r", err)
	}

	fmt.Printf("Proxy IP -> %s:%d\n\r", localhost, 8080)
	fmt.Printf("在瀏覽器輸入 -> %s:%d下載憑證\n\r", localhost, 8080)

	srv := goproxy.NewProxyHttpServer()
	srv.Logger = new(NilLogger)
	srv.OnRequest().HandleConnect(goproxy.AlwaysMitm)
	srv.OnRequest(goproxy.DstHostIs(localhost+":8080")).DoFunc(
		func(r *http.Request, ctx *goproxy.ProxyCtx) (*http.Request, *http.Response) {
			if strings.HasSuffix(r.URL.Path, "ca.crt"){
				b, err := ioutil.ReadFile("ca.crt")
				if err != nil {
					fmt.Print(err)
				}
				str := string(b)
				return r, goproxy.NewResponse(r,
					"application/x-x509-ca-cert", http.StatusOK, str)
			}else{
				variant := fmt.Sprintf("%s:%d/ca.crt", localhost, 8080)
				str := "<!DOCTYPE html>" +
					"<html><body><h1>" +
					"Click the URL" +
					"</h1>" +
					"<a href=\"http://" + variant + "\" download=\"ca\">Click Me</a>" +
					"</body>" +
					"</html>"
				return r, goproxy.NewResponse(r,
					"text/html", http.StatusOK, str)
			}
		})
	srv.OnResponse(rs.condition()).DoFunc(rs.onResponse)
	if err := http.ListenAndServe(":8080", srv); err != nil {
		fmt.Printf("Start Proxy Server Error -> %+v\n\r", err)
	}
	return nil
}

func (rs *rsyars) build(body response) {
	_ = ioutil.WriteFile(fmt.Sprintf("response.json"), body.Body, 0)
	fmt.Printf("Write File response.json\n\r", )
}

func (rs *rsyars) loop() {
	for body := range rs.ch {
		fmt.Printf("Get Response\n\r")
		if body.Body == nil {
			fmt.Printf("Response is empty end\n\r")
			break
		}
		go rs.build(body)
	}
}

func (rs *rsyars) onResponse(resp *http.Response, ctx *goproxy.ProxyCtx) *http.Response {
	fmt.Printf("Response processing -> %s\n\r", path(ctx.Req))

	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		fmt.Printf("Response process failed -> %+v\n\r", err)
		return resp
	}
	resp.Body = ioutil.NopCloser(bytes.NewBuffer(body))

	rs.ch <- response{
		Host: ctx.Req.Host,
		Path: ctx.Req.URL.Path,
		Body: body,
	}

	return resp
}

func (rs *rsyars) condition() goproxy.ReqConditionFunc {
	return func(req *http.Request, ctx *goproxy.ProxyCtx) bool {
		fmt.Printf("Request -> %s\n\r", path(req))
		if strings.HasSuffix(req.Host, "ppgame.com") || strings.HasSuffix(req.Host, "sn-game.txwy.tw") {
			if strings.HasSuffix(req.URL.Path, "/Index/index") {
				fmt.Printf("Request pass -> %s\n\r", path(req))
				return true
			}
		}
		return false
	}
}

func (rs *rsyars) getLocalhost() (string, error) {
	conn, err := net.Dial("tcp", "www.baidu.com:80")
	if err != nil {
		return "", errors.WithMessage(err, "Connect www.baidu.com:80 Failed")
	}
	host, _, err := net.SplitHostPort(conn.LocalAddr().String())
	if err != nil {
		return "", errors.WithMessage(err, "Get Local Host Failed")
	}
	return host, nil
}

func path(req *http.Request) string {
	if req.URL.Path == "/" {
		return req.Host
	}
	return req.Host + req.URL.Path
}
