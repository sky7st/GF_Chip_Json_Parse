using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GF_Chip_Json_Parse_excel
{
    public partial class Form1 : Form
    {
        private string chooseJsonFilePath = "";
        private string chooseExcelFilePath = "";
        private bool isSetJson = false;

        private bool sortUp = false;
        private bool showInEquip = false;
        private bool colorBlue = true;
        private bool isShow34 = false;

        private GFJSON gfjson;
        private List<GFChip> gfChip;
        private ExcelReader excel;
        private List<string[]> output;
        private bool isInterrupt = false;

        public Form1()
        {        
            InitializeComponent();
            init();
        }
        public void init()
        {
            chooseFileButExcel.Enabled = false;
            isSetJson = false;
            isShow34 = false;
            gfjson = new GFJSON();
        }

        private void chooseFileButJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "json files (*.*)|*.json";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    chooseJsonFilePath = dialog.FileName;
                    jsonFileLabel.Text = chooseJsonFilePath;
                    gfjson.setPath(chooseJsonFilePath);
                    gfChip = gfjson.parseChip();
                    if (!sortUp)
                        gfChip.Reverse();
                    output = gfjson.getExcelChip(gfChip, showInEquip, colorBlue, isShow34);
                    int cnt = output.Count;
                    isSetJson = true;

                    MessageBox.Show(String.Format("辨識完成!!!\n共輸出{0}個晶片\n請選擇Excel檔案!!", cnt));
                    chooseFileButExcel.Enabled = true;
                    statusLabel.Visible = true;
                    statusLabel.Text = "目前狀態:等待Excel檔案";
                }
                catch
                {
                    jsonFileLabel.Text = "狀態:錯誤!請確認檔案是否正確!!";
                    MessageBox.Show("錯誤!!!\n請確認檔案是否正確!!");
                    isSetJson = false;
                    chooseFileButExcel.Enabled = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sortUp = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            showInEquip = checkBox2.Checked;
        }

        private void radioChooseBlue_CheckedChanged(object sender, EventArgs e)
        {
            colorBlue = radioChooseBlue.Checked;
        }

        private void chooseFileButExcel_Click(object sender, EventArgs e)
        {
            if (isSetJson)
            {
                isInterrupt = false;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select file";
                dialog.InitialDirectory = ".\\";
                dialog.Filter = "excel files (*.*)|*.xlsm";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    chooseExcelFilePath = dialog.FileName;
                    excelFileLabel.Text = chooseExcelFilePath;
                    excelProgressBar.Visible = true;
                    stopExcelWrite.Visible = true;
                    stopExcelWrite.Enabled = true;
                    chooseFileButExcel.Enabled = false;
                    excelBgWorker.RunWorkerAsync();
                }
            }
        }

        private void excelBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            excelBgWorker.ReportProgress(0);
            excel = new ExcelReader();

            statusLabel.Invoke((MethodInvoker)delegate {
                statusLabel.Text = "目前狀態:正在開啟Excel檔案";
            });
            bool isExcelOpen = excel.openExcelFile(chooseExcelFilePath);
            if (excelBgWorker.CancellationPending)
            {
                cancel();
                return;
            }
            int cnt = output.Count;
            double percentage = 0;
            string[] empty = { "", "", "", "", "", "" };
            if (isExcelOpen)
            {
                if (excelBgWorker.CancellationPending)
                {
                    cancel();
                    return;
                }
                excelBgWorker.ReportProgress(20);
                statusLabel.Invoke((MethodInvoker)delegate
                {
                    statusLabel.Text = String.Format("目前狀態:正在清空所有欄位");
                });
                excel.clearRangeRow();
                excelBgWorker.ReportProgress(30);
                for (int i = 0; i < cnt; i++)
                {
                    if (excelBgWorker.CancellationPending)
                    {
                        cancel();
                        return;
                    }
                    excel.writeRow(output[i], i + 1);
                    statusLabel.Invoke((MethodInvoker)delegate {
                        statusLabel.Text = String.Format("目前狀態:正在寫入晶片({0}/{1})", i + 1, cnt);
                    });
                    percentage = 30 + 60 * (double)i / cnt;
                    excelBgWorker.ReportProgress((int)percentage);
                }
            }
            else
            {
                statusLabel.Text = "Excel 檔案錯誤!!";
            }
            excelBgWorker.ReportProgress(100);
        }

        private void cancel()
        {
            isInterrupt = true;
            stopExcelWrite.Invoke((MethodInvoker)delegate {
                stopExcelWrite.Enabled = false;
            });
            chooseFileButExcel.Invoke((MethodInvoker)delegate {
                chooseFileButExcel.Enabled = false;
            });
            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = String.Format("目前狀態:手動停止寫入，正在關閉excel檔案");
            });
            excel.exitAll(false);
            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = String.Format("目前狀態:手動停止寫入，已關閉excel檔案");
            });
            stopExcelWrite.Invoke((MethodInvoker)delegate {
                stopExcelWrite.Enabled = false;
            });
            chooseFileButExcel.Invoke((MethodInvoker)delegate {
                chooseFileButExcel.Enabled = true;
            });
            return;
        }

        private void excelBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            excelProgressBar.Value = e.ProgressPercentage;
        }

        private void excelBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!isInterrupt)
            {
                statusLabel.Invoke((MethodInvoker)delegate {
                    statusLabel.Text = "目前狀態:晶片寫入完成，正在關閉Excel檔案";
                });
                excel.exitAll();
                statusLabel.Invoke((MethodInvoker)delegate {
                    statusLabel.Text = "目前狀態:晶片寫入完成，已關閉Excel檔案";
                });
                MessageBox.Show("完成輸入!");
            }
            isInterrupt = false;
            chooseFileButExcel.Enabled = true;

        }

        private void stopExcelWrite_Click(object sender, EventArgs e)
        {
            excelBgWorker.CancelAsync();
        }

        private void show34Check_CheckedChanged(object sender, EventArgs e)
        {
            isShow34 = show34Check.Checked;
        }
    }
}
