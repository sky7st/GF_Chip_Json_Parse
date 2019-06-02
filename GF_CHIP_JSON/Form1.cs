using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GF_CHIP_JSON
{
    public partial class Form1 : Form
    {
        private string chooseFilePath = "";
        private GFJSON gfjson;
        private List<GFChip> gfChip;
        private bool sortUp = false;
        private bool showInEquip = false;
        public Form1()
        {
            InitializeComponent();
            gfjson = new GFJSON();
        }
        private void chooseFileBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "json files (*.*)|*.json";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    chooseFilePath = dialog.FileName;
                    chooseFileLabel.Text = chooseFilePath;
                    gfjson.setPath(chooseFilePath);
                    gfChip = gfjson.parseChip();
                    if (!sortUp)
                        gfChip.Reverse();
                    string s = gfjson.getAllChips(gfChip, showInEquip);
                    showText.Text = s;
                    Clipboard.SetText(s);
                    string status = "";
                    if (sortUp)
                        status = "(升冪,";
                    else
                        status = "(降冪,";
                    if (showInEquip)
                        status += "含裝備中) ";
                    else
                        status += "不含裝備中) ";
                    statusLabel.Text = "狀態:轉換完成" + status + String.Format("共輸出{0}個晶片", gfjson.getValidCnt());
                    MessageBox.Show("轉換完成!!!\n已經複製到剪貼簿\n請直接在網頁貼上!!");
                }
                catch
                {
                    statusLabel.Text = "狀態:錯誤!請確認檔案是否正確!!";
                    MessageBox.Show("錯誤!!!\n請確認檔案是否正確!!");

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
        private void showText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
