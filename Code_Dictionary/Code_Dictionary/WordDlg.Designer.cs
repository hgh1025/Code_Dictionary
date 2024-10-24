
namespace Code_Dictionary
{
    partial class WordDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit_desc = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_full_name = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Code_Dictionary.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_full_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "desc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 41;
            this.label5.Text = "full_name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 37;
            this.label1.Text = "name";
            // 
            // textEdit_desc
            // 
            this.textEdit_desc.Location = new System.Drawing.Point(78, 123);
            this.textEdit_desc.Name = "textEdit_desc";
            this.textEdit_desc.Size = new System.Drawing.Size(271, 20);
            this.textEdit_desc.TabIndex = 36;
            // 
            // textEdit_full_name
            // 
            this.textEdit_full_name.Location = new System.Drawing.Point(261, 54);
            this.textEdit_full_name.Name = "textEdit_full_name";
            this.textEdit_full_name.Size = new System.Drawing.Size(100, 20);
            this.textEdit_full_name.TabIndex = 33;
            // 
            // textEdit_name
            // 
            this.textEdit_name.Location = new System.Drawing.Point(78, 54);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Size = new System.Drawing.Size(100, 20);
            this.textEdit_name.TabIndex = 29;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(203, 185);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 28;
            this.simpleButton2.Text = "취소";
            this.simpleButton2.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(92, 185);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 27;
            this.simpleButton1.Text = "저장";
            this.simpleButton1.Click += new System.EventHandler(this.Save_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // WordDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 230);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit_desc);
            this.Controls.Add(this.textEdit_full_name);
            this.Controls.Add(this.textEdit_name);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "WordDlg";
            this.Text = "TableDlg";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_full_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit_desc;
        private DevExpress.XtraEditors.TextEdit textEdit_full_name;
        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}