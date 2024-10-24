using Code_Dictionary.Model.Repository;
using Code_Dictionary.Model.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace Code_Dictionary
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> Tab_Types = new List<string>()
        {
            "Table",
            "Column",
            "Sp",
            "단어"
        };

        private void InitUI()
        {
            gridColumn_TableId.Visible = false;

            InitGridControl(gridControl_Peoplecar, gridView_Peoplecar);
            InitGridControl(gridControl_Carfreecar, gridView_Carfreecar);
            InitGridControl(gridControl_Returnfree, gridView_Returnfree);

            SettingFindGridOption(gridView_Peoplecar);
            SettingFindGridOption(gridView_Carfreecar);
            SettingFindGridOption(gridView_Returnfree);

            SelectTab();
        }

        private void InitGridControl(GridControl selected_gridControl, GridView selected_gridView)
        {
            selected_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            selected_gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            selected_gridView.OptionsBehavior.Editable = false;
            selected_gridView.OptionsBehavior.ReadOnly = true;

            selected_gridView.OptionsCustomization.AllowColumnMoving = true;
            selected_gridView.OptionsCustomization.AllowFilter = true;
            selected_gridView.OptionsCustomization.AllowGroup = false;
            selected_gridView.OptionsCustomization.AllowQuickHideColumns = false;

            selected_gridView.OptionsFilter.AllowFilterEditor = false;

            selected_gridView.OptionsFind.AllowFindPanel = false;

            selected_gridView.OptionsNavigation.AutoFocusNewRow = false;
            selected_gridView.OptionsNavigation.AutoMoveRowFocus = false;

            selected_gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            selected_gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            selected_gridView.OptionsSelection.MultiSelect = false;
            selected_gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

            selected_gridView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            selected_gridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            selected_gridView.OptionsView.ColumnAutoWidth = true;
            selected_gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            selected_gridView.OptionsView.EnableAppearanceEvenRow = true;
            selected_gridView.OptionsView.ShowFooter = false;
            selected_gridView.OptionsView.ShowGroupPanel = false;
            selected_gridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            selected_gridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;

            selected_gridView.OptionsMenu.EnableFooterMenu = false;
            selected_gridView.OptionsMenu.EnableColumnMenu = false;
            selected_gridView.OptionsMenu.EnableGroupPanelMenu = false;
            selected_gridView.OptionsMenu.EnableGroupRowMenu = false;



            selected_gridControl.UseEmbeddedNavigator = true;
            selected_gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            selected_gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            selected_gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            selected_gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            selected_gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;


        }

        private void SettingFindGridOption(GridView gridView)
        {
            gridView.OptionsFind.AllowFindPanel = true;
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsFind.ShowCloseButton = false;
            gridView.OptionsFind.ShowFindButton = true;
            gridView.OptionsFind.ShowClearButton = true;
            gridView.OptionsFind.ShowSearchNavButtons = true;
            gridView.OptionsFind.FindNullPrompt = "찾기...";
            gridView.OptionsFind.FindPanelLocation = GridFindPanelLocation.Default;
        }

        private void tileBar_SelectedItemChanged(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            navigationFrame1.SelectedPageIndex = tileBarGroup2.Items.IndexOf(e.Item);
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            //var members = memberService.GetUsers();
            //ds = ExcelDataSourceExtensions.DtoToDataSet(members);


            InitUI();

        }


        private void SelectTab()
        {
            comboBoxEdit_Type.Properties.Items.Clear();

            foreach (string model in Tab_Types)
            {
                comboBoxEdit_Type.Properties.Items.Add(model).ToString();
            }
        }

        private void Form1_Shown(object sender, System.EventArgs e)
        {

            if (backgroundWorker_main.IsBusy is false)
                backgroundWorker_main.RunWorkerAsync(0);
        }



        private void backgroundWorker_main_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DataTable dbTable = null;
            if (e.Argument.Equals(0))
            {
                // Peoplcar
                int current_rowhandle = gridView_Peoplecar.FocusedRowHandle;

                if (GetPeoplecarData(this, out dbTable) is false)
                {
                    backgroundWorker_main.CancelAsync();
                }

                if (current_rowhandle >= 0)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        gridView_Peoplecar.FocusedRowHandle = current_rowhandle;
                        gridView_Peoplecar.SelectRow(current_rowhandle);
                        gridControl_Peoplecar.DataSource = dbTable;
                    }));

                }
            }
            else if (e.Argument.Equals(1))
            {
                // Carfreecar
                int current_rowhandle = gridView_Carfreecar.FocusedRowHandle;

                if (GetCarfreecarData(this, out dbTable) is false)
                {
                    backgroundWorker_main.CancelAsync();
                }

                if (current_rowhandle >= 0)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        gridView_Carfreecar.FocusedRowHandle = current_rowhandle;
                        gridView_Carfreecar.SelectRow(current_rowhandle);
                        gridControl_Carfreecar.DataSource = dbTable;

                    }));
                }
            }
            else if (e.Argument.Equals(2))
            {
                // Returnfree
                int current_rowhandle = gridView_Returnfree.FocusedRowHandle;

                if (GetReturnfreeData(this, out dbTable) is false)
                {
                    backgroundWorker_main.CancelAsync();
                }
                if (current_rowhandle >= 0)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        gridView_Returnfree.FocusedRowHandle = current_rowhandle;
                        gridView_Returnfree.SelectRow(current_rowhandle);
                        gridControl_Returnfree.DataSource = dbTable;

                    }));
                }
            }
        }

        public bool GetReturnfreeData(Form1 payload_form, out DataTable dbTable)
        {
            TableService tableService = new TableService();
            DataSet ds = null;
            dbTable = null;

            try
            {
                //WaitForm_Operation(true);

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {

                    var tables = tableService.Get_P_Tables();

                    if (tables != null) { ds = ExcelDataSourceExtensions.DtoToDataSet(tables); }


                    gridControl_Returnfree.DataSource = ds?.Tables[0];
                }));
                dbTable = ds?.Tables[0];
                //WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                //WaitForm_Operation(false);
            }

            return true;
        }

        public bool GetCarfreecarData(Form1 payload_form, out DataTable dbTable)
        {
            TableService tableService = new TableService();
            DataSet ds = null;
            dbTable = null;

            try
            {
                //WaitForm_Operation(true);

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    var tables = tableService.Get_P_Tables();

                    if (tables != null) { ds = ExcelDataSourceExtensions.DtoToDataSet(tables); }

                    gridControl_Carfreecar.DataSource = ds?.Tables[0];
                }));

                dbTable = ds?.Tables[0];
                //WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                //WaitForm_Operation(false);
            }

            return true;
        }

        public bool GetPeoplecarData(Form1 payload_form, out DataTable dbTable)
        {
            TableService tableService = new TableService();
            DataSet ds = null;
            dbTable = null;
            try
            {
                //WaitForm_Operation(true);

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {

                    var tables = tableService.Get_P_Tables();

                    if (tables != null) { ds = ExcelDataSourceExtensions.DtoToDataSet(tables); }

                    gridControl_Peoplecar.DataSource = ds?.Tables[0];
                }));
                dbTable = ds?.Tables[0];
                // WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                // WaitForm_Operation(false);
            }

            return true;
        }

        #region WaitForm Control
        public void WaitForm_Operation(bool bShowEnable)
        {
            if (bShowEnable is true)
            {
                if (splashScreenManager.IsSplashFormVisible is false)
                    splashScreenManager.ShowWaitForm();
            }
            else
            {
                if (splashScreenManager.IsSplashFormVisible is true)
                    splashScreenManager.CloseWaitForm();
            }
        }
        #endregion

    }
}
