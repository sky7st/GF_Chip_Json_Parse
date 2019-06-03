namespace GF_Chip_Json_Parse_excel
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chooseFileButJson = new System.Windows.Forms.Button();
            this.radioChooseRed = new System.Windows.Forms.RadioButton();
            this.radioChooseBlue = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseFileButExcel = new System.Windows.Forms.Button();
            this.show34Check = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.excelBgWorker = new System.ComponentModel.BackgroundWorker();
            this.jsonFileLabel = new System.Windows.Forms.Label();
            this.excelFileLabel = new System.Windows.Forms.Label();
            this.excelProgressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.stopExcelWrite = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(133, 68);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(226, 22);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "顯示裝備中(預設不顯示)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(133, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 22);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "升冪(預設是降冪)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chooseFileButJson
            // 
            this.chooseFileButJson.Location = new System.Drawing.Point(136, 172);
            this.chooseFileButJson.Name = "chooseFileButJson";
            this.chooseFileButJson.Size = new System.Drawing.Size(152, 42);
            this.chooseFileButJson.TabIndex = 6;
            this.chooseFileButJson.Text = "選擇檔案";
            this.chooseFileButJson.UseVisualStyleBackColor = true;
            this.chooseFileButJson.Click += new System.EventHandler(this.chooseFileButJson_Click);
            // 
            // radioChooseRed
            // 
            this.radioChooseRed.AutoSize = true;
            this.radioChooseRed.Location = new System.Drawing.Point(60, 3);
            this.radioChooseRed.Name = "radioChooseRed";
            this.radioChooseRed.Size = new System.Drawing.Size(51, 22);
            this.radioChooseRed.TabIndex = 10;
            this.radioChooseRed.Text = "紅";
            this.radioChooseRed.UseVisualStyleBackColor = true;
            // 
            // radioChooseBlue
            // 
            this.radioChooseBlue.AutoSize = true;
            this.radioChooseBlue.Checked = true;
            this.radioChooseBlue.Location = new System.Drawing.Point(3, 3);
            this.radioChooseBlue.Name = "radioChooseBlue";
            this.radioChooseBlue.Size = new System.Drawing.Size(51, 22);
            this.radioChooseBlue.TabIndex = 9;
            this.radioChooseBlue.TabStop = true;
            this.radioChooseBlue.Text = "藍";
            this.radioChooseBlue.UseVisualStyleBackColor = true;
            this.radioChooseBlue.CheckedChanged += new System.EventHandler(this.radioChooseBlue_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioChooseBlue);
            this.panel1.Controls.Add(this.radioChooseRed);
            this.panel1.Location = new System.Drawing.Point(133, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 30);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9F);
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "1.選擇選項";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 9F);
            this.label2.Location = new System.Drawing.Point(34, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "2.選擇JSON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 9F);
            this.label3.Location = new System.Drawing.Point(34, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "3.選擇Excel";
            // 
            // chooseFileButExcel
            // 
            this.chooseFileButExcel.Enabled = false;
            this.chooseFileButExcel.Location = new System.Drawing.Point(136, 299);
            this.chooseFileButExcel.Name = "chooseFileButExcel";
            this.chooseFileButExcel.Size = new System.Drawing.Size(152, 42);
            this.chooseFileButExcel.TabIndex = 15;
            this.chooseFileButExcel.Text = "選擇檔案";
            this.chooseFileButExcel.UseVisualStyleBackColor = true;
            this.chooseFileButExcel.Click += new System.EventHandler(this.chooseFileButExcel_Click);
            // 
            // show34Check
            // 
            this.show34Check.AutoSize = true;
            this.show34Check.Location = new System.Drawing.Point(371, 28);
            this.show34Check.Name = "show34Check";
            this.show34Check.Size = new System.Drawing.Size(135, 22);
            this.show34Check.TabIndex = 16;
            this.show34Check.Text = "加入5星3 4格";
            this.show34Check.UseVisualStyleBackColor = true;
            this.show34Check.CheckedChanged += new System.EventHandler(this.show34Check_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 9F);
            this.label4.Location = new System.Drawing.Point(391, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "(預設不加入)";
            // 
            // excelBgWorker
            // 
            this.excelBgWorker.WorkerReportsProgress = true;
            this.excelBgWorker.WorkerSupportsCancellation = true;
            this.excelBgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excelBgWorker_DoWork);
            this.excelBgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.excelBgWorker_ProgressChanged);
            this.excelBgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excelBgWorker_RunWorkerCompleted);
            // 
            // jsonFileLabel
            // 
            this.jsonFileLabel.AutoSize = true;
            this.jsonFileLabel.Location = new System.Drawing.Point(41, 245);
            this.jsonFileLabel.Name = "jsonFileLabel";
            this.jsonFileLabel.Size = new System.Drawing.Size(0, 18);
            this.jsonFileLabel.TabIndex = 18;
            // 
            // excelFileLabel
            // 
            this.excelFileLabel.AutoSize = true;
            this.excelFileLabel.Location = new System.Drawing.Point(41, 359);
            this.excelFileLabel.Name = "excelFileLabel";
            this.excelFileLabel.Size = new System.Drawing.Size(0, 18);
            this.excelFileLabel.TabIndex = 19;
            // 
            // excelProgressBar
            // 
            this.excelProgressBar.Location = new System.Drawing.Point(37, 420);
            this.excelProgressBar.Name = "excelProgressBar";
            this.excelProgressBar.Size = new System.Drawing.Size(469, 30);
            this.excelProgressBar.TabIndex = 20;
            this.excelProgressBar.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(117, 392);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(85, 18);
            this.statusLabel.TabIndex = 22;
            this.statusLabel.Text = "目前狀態:";
            this.statusLabel.Visible = false;
            // 
            // stopExcelWrite
            // 
            this.stopExcelWrite.Enabled = false;
            this.stopExcelWrite.Location = new System.Drawing.Point(323, 299);
            this.stopExcelWrite.Name = "stopExcelWrite";
            this.stopExcelWrite.Size = new System.Drawing.Size(152, 42);
            this.stopExcelWrite.TabIndex = 23;
            this.stopExcelWrite.Text = "停止寫入";
            this.stopExcelWrite.UseVisualStyleBackColor = true;
            this.stopExcelWrite.Visible = false;
            this.stopExcelWrite.Click += new System.EventHandler(this.stopExcelWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 462);
            this.Controls.Add(this.stopExcelWrite);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.excelProgressBar);
            this.Controls.Add(this.excelFileLabel);
            this.Controls.Add(this.jsonFileLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.show34Check);
            this.Controls.Add(this.chooseFileButExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chooseFileButJson);
            this.Name = "Form1";
            this.Text = "GF_Chip_Json_Excel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button chooseFileButJson;
        private System.Windows.Forms.RadioButton radioChooseRed;
        private System.Windows.Forms.RadioButton radioChooseBlue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseFileButExcel;
        private System.Windows.Forms.CheckBox show34Check;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker excelBgWorker;
        private System.Windows.Forms.Label jsonFileLabel;
        private System.Windows.Forms.Label excelFileLabel;
        private System.Windows.Forms.ProgressBar excelProgressBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button stopExcelWrite;
    }
}

