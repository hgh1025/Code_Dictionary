
namespace Code_Dictionary
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textUserPassword = new DevExpress.XtraEditors.TextEdit();
            this.textUserID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonLogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(90, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 35);
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // textUserPassword
            // 
            this.textUserPassword.EditValue = "";
            this.textUserPassword.Location = new System.Drawing.Point(140, 124);
            this.textUserPassword.Name = "textUserPassword";
            this.textUserPassword.Properties.PasswordChar = '●';
            this.textUserPassword.Size = new System.Drawing.Size(155, 20);
            this.textUserPassword.TabIndex = 51;
            // 
            // textUserID
            // 
            this.textUserID.EditValue = "";
            this.textUserID.Location = new System.Drawing.Point(140, 96);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(155, 20);
            this.textUserID.TabIndex = 50;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("굴림", 9F);
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(68, 128);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 12);
            this.labelControl2.TabIndex = 49;
            this.labelControl2.Text = "비밀번호";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("굴림", 9F);
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(68, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 12);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "아이디";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Appearance.Font = new System.Drawing.Font("굴림", 9F);
            this.buttonLogin.Appearance.Options.UseFont = true;
            this.buttonLogin.Location = new System.Drawing.Point(192, 183);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(103, 23);
            this.buttonLogin.TabIndex = 52;
            this.buttonLogin.Text = "로그인";
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 233);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textUserPassword);
            this.Controls.Add(this.textUserID);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraEditors.TextEdit textUserPassword;
        private DevExpress.XtraEditors.TextEdit textUserID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton buttonLogin;
    }
}