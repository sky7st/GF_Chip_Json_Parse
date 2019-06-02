namespace GF_CHIP_JSON
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
            this.chooseFileBut = new System.Windows.Forms.Button();
            this.chooseFileLabel = new System.Windows.Forms.Label();
            this.showText = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chooseFileBut
            // 
            this.chooseFileBut.Location = new System.Drawing.Point(45, 42);
            this.chooseFileBut.Name = "chooseFileBut";
            this.chooseFileBut.Size = new System.Drawing.Size(106, 42);
            this.chooseFileBut.TabIndex = 0;
            this.chooseFileBut.Text = "選擇檔案";
            this.chooseFileBut.UseVisualStyleBackColor = true;
            this.chooseFileBut.Click += new System.EventHandler(this.chooseFileBut_Click);
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.AutoSize = true;
            this.chooseFileLabel.Location = new System.Drawing.Point(42, 106);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(98, 18);
            this.chooseFileLabel.TabIndex = 1;
            this.chooseFileLabel.Text = "請選擇檔案";
            // 
            // showText
            // 
            this.showText.Location = new System.Drawing.Point(33, 185);
            this.showText.Multiline = true;
            this.showText.Name = "showText";
            this.showText.ReadOnly = true;
            this.showText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.showText.Size = new System.Drawing.Size(494, 247);
            this.showText.TabIndex = 2;
            this.showText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.showText_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(167, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 22);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "升冪(預設是降冪)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(45, 146);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(49, 18);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "狀態:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(167, 62);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(226, 22);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "顯示裝備中(預設不顯示)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 453);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.showText);
            this.Controls.Add(this.chooseFileLabel);
            this.Controls.Add(this.chooseFileBut);
            this.Name = "Form1";
            this.Text = "GF_CHIP_JSON";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFileBut;
        private System.Windows.Forms.Label chooseFileLabel;
        private System.Windows.Forms.TextBox showText;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

