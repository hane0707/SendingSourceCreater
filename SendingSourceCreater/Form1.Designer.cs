namespace SendingSourceCreater
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TargetDateFrom = new System.Windows.Forms.DateTimePicker();
            this.FileGetButton = new System.Windows.Forms.Button();
            this.OriginDirectory = new System.Windows.Forms.TextBox();
            this.OriginFolderDirectoryGetButton = new System.Windows.Forms.Button();
            this.TargetDirectory = new System.Windows.Forms.TextBox();
            this.TargetFolderDirectoryGetButton = new System.Windows.Forms.Button();
            this.MsgLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ErrorMsgLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TargetDateTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.UsePasswordCheck = new System.Windows.Forms.CheckBox();
            this.GetZipFileCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TargetDateFrom
            // 
            this.TargetDateFrom.CalendarForeColor = System.Drawing.Color.Lavender;
            this.TargetDateFrom.CalendarMonthBackground = System.Drawing.Color.LightSteelBlue;
            this.TargetDateFrom.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.TargetDateFrom.Location = new System.Drawing.Point(34, 208);
            this.TargetDateFrom.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.TargetDateFrom.Name = "TargetDateFrom";
            this.TargetDateFrom.Size = new System.Drawing.Size(172, 25);
            this.TargetDateFrom.TabIndex = 5;
            this.TargetDateFrom.Value = new System.DateTime(2020, 2, 17, 0, 0, 0, 0);
            // 
            // FileGetButton
            // 
            this.FileGetButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.FileGetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileGetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FileGetButton.Location = new System.Drawing.Point(451, 208);
            this.FileGetButton.Name = "FileGetButton";
            this.FileGetButton.Size = new System.Drawing.Size(122, 102);
            this.FileGetButton.TabIndex = 100;
            this.FileGetButton.Text = "ファイル取得";
            this.FileGetButton.UseVisualStyleBackColor = false;
            this.FileGetButton.Click += new System.EventHandler(this.FileGetButton_Click);
            // 
            // OriginDirectory
            // 
            this.OriginDirectory.BackColor = System.Drawing.Color.GhostWhite;
            this.OriginDirectory.Location = new System.Drawing.Point(34, 84);
            this.OriginDirectory.Name = "OriginDirectory";
            this.OriginDirectory.Size = new System.Drawing.Size(492, 25);
            this.OriginDirectory.TabIndex = 1;
            // 
            // OriginFolderDirectoryGetButton
            // 
            this.OriginFolderDirectoryGetButton.BackColor = System.Drawing.Color.GhostWhite;
            this.OriginFolderDirectoryGetButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.OriginFolderDirectoryGetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OriginFolderDirectoryGetButton.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OriginFolderDirectoryGetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OriginFolderDirectoryGetButton.Location = new System.Drawing.Point(532, 82);
            this.OriginFolderDirectoryGetButton.Name = "OriginFolderDirectoryGetButton";
            this.OriginFolderDirectoryGetButton.Size = new System.Drawing.Size(41, 32);
            this.OriginFolderDirectoryGetButton.TabIndex = 2;
            this.OriginFolderDirectoryGetButton.Text = "🔍";
            this.OriginFolderDirectoryGetButton.UseVisualStyleBackColor = false;
            this.OriginFolderDirectoryGetButton.Click += new System.EventHandler(this.OriginDirectoryGetButton_Click);
            // 
            // TargetDirectory
            // 
            this.TargetDirectory.BackColor = System.Drawing.Color.GhostWhite;
            this.TargetDirectory.Location = new System.Drawing.Point(34, 142);
            this.TargetDirectory.Name = "TargetDirectory";
            this.TargetDirectory.Size = new System.Drawing.Size(492, 25);
            this.TargetDirectory.TabIndex = 3;
            // 
            // TargetFolderDirectoryGetButton
            // 
            this.TargetFolderDirectoryGetButton.BackColor = System.Drawing.Color.GhostWhite;
            this.TargetFolderDirectoryGetButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.TargetFolderDirectoryGetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TargetFolderDirectoryGetButton.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TargetFolderDirectoryGetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TargetFolderDirectoryGetButton.Location = new System.Drawing.Point(532, 141);
            this.TargetFolderDirectoryGetButton.Name = "TargetFolderDirectoryGetButton";
            this.TargetFolderDirectoryGetButton.Size = new System.Drawing.Size(41, 32);
            this.TargetFolderDirectoryGetButton.TabIndex = 4;
            this.TargetFolderDirectoryGetButton.Text = "🔍";
            this.TargetFolderDirectoryGetButton.UseVisualStyleBackColor = false;
            this.TargetFolderDirectoryGetButton.Click += new System.EventHandler(this.TargetDirectoryGetButton_Click);
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.MsgLabel.Location = new System.Drawing.Point(31, 22);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(78, 18);
            this.MsgLabel.TabIndex = 6;
            this.MsgLabel.Text = "MsgLabel";
            this.MsgLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(31, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "取得元フォルダ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(31, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "保存先フォルダ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(31, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "取得ファイル更新日付";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 11;
            // 
            // ErrorMsgLabel
            // 
            this.ErrorMsgLabel.AutoSize = true;
            this.ErrorMsgLabel.Location = new System.Drawing.Point(41, 415);
            this.ErrorMsgLabel.Name = "ErrorMsgLabel";
            this.ErrorMsgLabel.Size = new System.Drawing.Size(0, 18);
            this.ErrorMsgLabel.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(34, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(539, 1);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            // 
            // TargetDateTo
            // 
            this.TargetDateTo.CalendarForeColor = System.Drawing.Color.Lavender;
            this.TargetDateTo.CalendarMonthBackground = System.Drawing.Color.LightSteelBlue;
            this.TargetDateTo.CalendarTitleBackColor = System.Drawing.Color.LightSteelBlue;
            this.TargetDateTo.Location = new System.Drawing.Point(244, 208);
            this.TargetDateTo.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.TargetDateTo.Name = "TargetDateTo";
            this.TargetDateTo.Size = new System.Drawing.Size(172, 25);
            this.TargetDateTo.TabIndex = 6;
            this.TargetDateTo.Value = new System.DateTime(2020, 2, 17, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "～";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(160, 285);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(256, 25);
            this.Password.TabIndex = 9;
            this.Password.UseSystemPasswordChar = true;
            // 
            // UsePasswordCheck
            // 
            this.UsePasswordCheck.AutoSize = true;
            this.UsePasswordCheck.Location = new System.Drawing.Point(34, 288);
            this.UsePasswordCheck.Name = "UsePasswordCheck";
            this.UsePasswordCheck.Size = new System.Drawing.Size(105, 22);
            this.UsePasswordCheck.TabIndex = 8;
            this.UsePasswordCheck.Text = "パスワード";
            this.UsePasswordCheck.UseVisualStyleBackColor = true;
            this.UsePasswordCheck.CheckedChanged += new System.EventHandler(this.UsePasswordCheck_CheckedChanged);
            // 
            // GetZipFileCheck
            // 
            this.GetZipFileCheck.AutoSize = true;
            this.GetZipFileCheck.Location = new System.Drawing.Point(34, 260);
            this.GetZipFileCheck.Name = "GetZipFileCheck";
            this.GetZipFileCheck.Size = new System.Drawing.Size(222, 22);
            this.GetZipFileCheck.TabIndex = 7;
            this.GetZipFileCheck.Text = "ファイルコピー後に圧縮する";
            this.GetZipFileCheck.UseVisualStyleBackColor = true;
            this.GetZipFileCheck.CheckedChanged += new System.EventHandler(this.GetZipFileCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(608, 649);
            this.Controls.Add(this.GetZipFileCheck);
            this.Controls.Add(this.UsePasswordCheck);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TargetDateTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ErrorMsgLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MsgLabel);
            this.Controls.Add(this.TargetFolderDirectoryGetButton);
            this.Controls.Add(this.TargetDirectory);
            this.Controls.Add(this.OriginFolderDirectoryGetButton);
            this.Controls.Add(this.OriginDirectory);
            this.Controls.Add(this.FileGetButton);
            this.Controls.Add(this.TargetDateFrom);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ファイル収集ツール";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker TargetDateFrom;
        private System.Windows.Forms.Button FileGetButton;
        private System.Windows.Forms.TextBox OriginDirectory;
        private System.Windows.Forms.Button OriginFolderDirectoryGetButton;
        private System.Windows.Forms.TextBox TargetDirectory;
        private System.Windows.Forms.Button TargetFolderDirectoryGetButton;
        private System.Windows.Forms.Label MsgLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ErrorMsgLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TargetDateTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.CheckBox UsePasswordCheck;
        private System.Windows.Forms.CheckBox GetZipFileCheck;
    }
}

