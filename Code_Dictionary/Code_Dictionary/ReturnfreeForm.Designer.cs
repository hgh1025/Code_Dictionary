
namespace Code_Dictionary
{
    partial class ReturnfreeForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true, typeof(System.Windows.Forms.UserControl));
            this.gridControl_Returnfree = new DevExpress.XtraGrid.GridControl();
            this.gridView_Returnfree = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Returnfree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Returnfree)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Returnfree
            // 
            this.gridControl_Returnfree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Returnfree.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Returnfree.MainView = this.gridView_Returnfree;
            this.gridControl_Returnfree.Name = "gridControl_Returnfree";
            this.gridControl_Returnfree.Size = new System.Drawing.Size(699, 440);
            this.gridControl_Returnfree.TabIndex = 0;
            this.gridControl_Returnfree.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Returnfree});
            // 
            // gridView_Returnfree
            // 
            this.gridView_Returnfree.GridControl = this.gridControl_Returnfree;
            this.gridView_Returnfree.Name = "gridView_Returnfree";
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // ReturnfreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_Returnfree);
            this.Name = "ReturnfreeForm";
            this.Size = new System.Drawing.Size(699, 440);
           // this.Load += new System.EventHandler(this.ReturnfreeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Returnfree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Returnfree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Returnfree;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Returnfree;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
