using Code_Dictionary.Model.Data;
using Code_Dictionary.Model.Dto;
using Code_Dictionary.Model.Model;
using Code_Dictionary.Model.Repository;
using Code_Dictionary.Model.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using static Code_Dictionary.Model.Model.Column;
using static Code_Dictionary.Model.Model.StoreProcedure;
using static Code_Dictionary.Model.Model.Table;
using static Code_Dictionary.Model.Model.Word;

namespace Code_Dictionary
{

    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<string> Tab_Types = new List<string>()
        {
            "Table",
            "Column",
            "Sp",
            "Word"
        };

        private void InitUI()
        {
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

        // 디자인에서 allow select item을 꼭 체크해야 한다.
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            // 선택된 페이지의 인덱스
            int selectedIndex = tileBarGroup2.Items.IndexOf(e.Item);
            navigationFrame1.SelectedPageIndex = selectedIndex;

            // 해당 페이지에 맞는 데이터를 로드하도록 backgroundWorker 호출
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync(selectedIndex);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;

            // 작업 시작
            if (backgroundWorker1.IsBusy is false)
                backgroundWorker1.RunWorkerAsync(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            InitUI();
            this.WindowState = FormWindowState.Maximized;
        }

        private void SelectTab()
        {
            P_comboBoxEdit.Properties.Items.Clear();
            C_comboBoxEdit.Properties.Items.Clear();
            R_comboBoxEdit.Properties.Items.Clear();

            foreach (string model in Tab_Types)
            {
                P_comboBoxEdit.Properties.Items.Add(model).ToString();
                C_comboBoxEdit.Properties.Items.Add(model).ToString();
                R_comboBoxEdit.Properties.Items.Add(model).ToString();
            }
        }

        private bool LoadApiData(GridView gridView)
        {
            int current_rowhandle = gridView.FocusedRowHandle;

            if (current_rowhandle >= 0)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    gridView.FocusedRowHandle = current_rowhandle;
                    gridView.SelectRow(current_rowhandle);
                }));
            }

            return true;
        }

        private void backgroundWorker_main_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument.Equals(0))
            {
                string selectedText = P_GetSelectedText(); // ComboBox에서 선택된 텍스트 가져오기

                // PEOPLECAR
                if (Module_PeoplecarClass.GetPeoplecar(this, selectedText) is false)
                {
                    backgroundWorker1.CancelAsync();
                }

                LoadApiData(gridView_Peoplecar);
            }
            else if (e.Argument.Equals(1))
            {
                string selectedText = C_GetSelectedText(); // ComboBox에서 선택된 텍스트 가져오기

                //CARFREECAR
                if (Module_CarfreecarClass.GetCarfreecar(this, selectedText) is false)
                {
                    backgroundWorker1.CancelAsync();
                }

                LoadApiData(gridView_Carfreecar);
            }
            else if (e.Argument.Equals(2))
            {

                string selectedText = R_GetSelectedText(); // ComboBox에서 선택된 텍스트 가져오기

                //RETURNFREE
                if (Module_ReturnfreeClass.GetReturnfree(this, selectedText) is false)
                {
                    backgroundWorker1.CancelAsync();
                }

                //LoadApiData(() => Module_ReturnfreeClass.GetReturnfree_TB_Data(this), gridView_Returnfree);
                LoadApiData(gridView_Returnfree);
            }
        }

        #region WaitForm Control
        public void WaitForm_Operation(bool bShowEnable)
        {
            if (bShowEnable is true)
            {
                if (splashScreenManager1.IsSplashFormVisible is false)
                    splashScreenManager1.ShowWaitForm();
            }
            else
            {
                if (splashScreenManager1.IsSplashFormVisible is true)
                    splashScreenManager1.CloseWaitForm();
            }
        }
        #endregion

        #region combobox text
        private string P_GetSelectedText()
        {
            // 선택된 항목이 null이 아닌 경우 선택된 텍스트를 반환
            return P_comboBoxEdit.SelectedItem?.ToString() ?? string.Empty;
        }
        private string C_GetSelectedText()
        {
            // 선택된 항목이 null이 아닌 경우 선택된 텍스트를 반환
            return C_comboBoxEdit.SelectedItem?.ToString() ?? string.Empty;
        }
        private string R_GetSelectedText()
        {
            // 선택된 항목이 null이 아닌 경우 선택된 텍스트를 반환
            return R_comboBoxEdit.SelectedItem?.ToString() ?? string.Empty;
        }
        #endregion

        private void dataTypeEdit_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 작업 시작
            if (navigationFrame1.SelectedPage.Equals(P_navigationPage))
            {
                // PEOPLECAR
                if (backgroundWorker1.IsBusy is false)
                    backgroundWorker1.RunWorkerAsync(0);
            }
            else if (navigationFrame1.SelectedPage.Equals(C_navigationPage))
            {
                // CARFREECAR
                if (backgroundWorker1.IsBusy is false)
                    backgroundWorker1.RunWorkerAsync(1);
            }
            else if (navigationFrame1.SelectedPage.Equals(R_navigationPage))
            {
                // RETURNFREE
                if (backgroundWorker1.IsBusy is false)
                    backgroundWorker1.RunWorkerAsync(2);
            }
        }

        #region Peoplecar Button
        private void P_TB_Button_CREATE_Click(object sender, EventArgs e)
        {
            string selected_comboBox = this.P_comboBoxEdit.SelectedItem.ToString();

            // table일 경우
            if (selected_comboBox == ComboBox_TYPE.Table)
            {
                var convert_Dto = Load_Update<TableDto>(ComboBox_TYPE.Table);

                using (TableDlg dialog = new TableDlg(DB_TYPE.PEOPLECAR, true, convert_Dto)) // tableDlg에서 는 combo type을 전달하고 dlg에서 처리
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
            else if (selected_comboBox == ComboBox_TYPE.Column)
            {
                // column일 경우
                var convert_Dto = Load_Update<ColumnDto>(ComboBox_TYPE.Column);

                using (ColumnDlg dialog = new ColumnDlg(DB_TYPE.PEOPLECAR, true, convert_Dto))
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
            else if (selected_comboBox == ComboBox_TYPE.Sp)
            {
                // sp 경우
                var convert_Dto = Load_Update<StoreProcedureDto>(ComboBox_TYPE.Sp);
                using (SpDlg dialog = new SpDlg(DB_TYPE.PEOPLECAR, true, convert_Dto))
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
            else if (selected_comboBox == ComboBox_TYPE.Word)
            {
                // word 경우
                var convert_Dto = Load_Update<WordDto>(ComboBox_TYPE.Word);
                using (WordDlg dialog = new WordDlg(DB_TYPE.PEOPLECAR, true, convert_Dto))
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
        }

        private void P_TB_Button_UPDATE_Click(object sender, EventArgs e)
        {
            DataRow focusRow = gridView_Peoplecar.GetFocusedDataRow();

            if (focusRow == null)
            {
                XtraMessageBox.Show("선택된 테이블이 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected_comboBox = this.P_comboBoxEdit.SelectedItem.ToString();

            // table일 경우
            if (selected_comboBox == ComboBox_TYPE.Table)
            {
                var convert_Dto = Load_Update<TableDto>(ComboBox_TYPE.Table);

                using (TableDlg dialog = new TableDlg(DB_TYPE.PEOPLECAR, false, convert_Dto))
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
            else if (selected_comboBox == ComboBox_TYPE.Column)
            {
                // column일 경우
                var convert_Dto = Load_Update<ColumnDto>(ComboBox_TYPE.Column);

                using (ColumnDlg dialog = new ColumnDlg(DB_TYPE.PEOPLECAR, false, convert_Dto))
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
            else if (selected_comboBox == ComboBox_TYPE.Sp)
            {
                // sp 경우
                var convert_Dto = Load_Update<StoreProcedureDto>(ComboBox_TYPE.Sp);
                using (SpDlg dialog = new SpDlg(DB_TYPE.PEOPLECAR, false, convert_Dto))
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
            else if (selected_comboBox == ComboBox_TYPE.Word)
            {
                // word 경우
                var convert_Dto = Load_Update<WordDto>(ComboBox_TYPE.Word);
                using (WordDlg dialog = new WordDlg(DB_TYPE.PEOPLECAR, false, convert_Dto)) // tableDlg에서 는 combo type을 전달하고 dlg에서 처리
                {
                    DialogResult = dialog.ShowDialog(this);

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        simpleButton_Refresh_Click(sender, e);
                    }
                }
            }
        }

        private void P_TB_Button_DELETE_Click(object sender, EventArgs e)
        {
            DataRow focusRow = gridView_Peoplecar.GetFocusedDataRow();

            if (focusRow == null)
            {
                XtraMessageBox.Show("선택된 테이블이 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TableService tableService = new TableService();

            var tableId = Convert.ToInt32(gridView_Peoplecar.GetFocusedRowCellValue("TableId"));

            if (XtraMessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tableService.Delete_P_Table(tableId);
            }
        }
        #endregion

        #region Carfreecar Button
        private void C_TB_Button_CREATE_Click(object sender, EventArgs e)
        {
            TableDlg tableDlg = new TableDlg(DB_TYPE.CARFREECAR, true, null);
            tableDlg.Show();
        }

        private void C_TB_Button_UPDATE_Click(object sender, EventArgs e)
        {
            DataRow focusRow = gridView_Carfreecar.GetFocusedDataRow();

            if (focusRow == null)
            {
                XtraMessageBox.Show("선택된 테이블이 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TableDlg tableDlg = new TableDlg(DB_TYPE.PEOPLECAR, false, null);
            tableDlg.Show();
        }

        private void C_TB_Button_DELETE_Click(object sender, EventArgs e)
        {
            DataRow focusRow = gridView_Carfreecar.GetFocusedDataRow();

            if (focusRow == null)
            {
                XtraMessageBox.Show("선택된 테이블이 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TableService tableService = new TableService();

            var tableId = Convert.ToInt32(gridView_Carfreecar.GetFocusedRowCellValue("TableId"));

            if (XtraMessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tableService.Delete_C_Table(tableId);
            }
        }
        #endregion

        #region Returnfree Button
        private void R_TB_Button_CREATE_Click(object sender, EventArgs e)
        {
            TableDlg tableDlg = new TableDlg(DB_TYPE.RETURNFREE, true, null);
            tableDlg.Show();
        }

        private void R_TB_Button_UPDATE_Click(object sender, EventArgs e)
        {
            DataRow focusRow = gridView_Returnfree.GetFocusedDataRow();

            if (focusRow == null)
            {
                XtraMessageBox.Show("선택된 테이블이 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TableDlg tableDlg = new TableDlg(DB_TYPE.PEOPLECAR, false, null);
            tableDlg.Show();
        }

        private void R_TB_Button_DELETE_Click(object sender, EventArgs e)
        {
            DataRow focusRow = gridView_Returnfree.GetFocusedDataRow();

            if (focusRow == null)
            {
                XtraMessageBox.Show("선택된 테이블이 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TableService tableService = new TableService();

            var tableId = Convert.ToInt32(gridView_Peoplecar.GetFocusedRowCellValue("TableId"));

            if (XtraMessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tableService.Delete_P_Table(tableId);
            }
        }
        #endregion

        #region Refresh Button , Double Click
        private void simpleButton_Refresh_Click(object sender, EventArgs e)
        {
            // 작업 시작
            if (navigationFrame1.SelectedPage.Equals(P_navigationPage))
            {
                // PEOPLECAR
                if (backgroundWorker1.IsBusy is false)
                    backgroundWorker1.RunWorkerAsync(0);
            }
            else if (navigationFrame1.SelectedPage.Equals(C_navigationPage))
            {
                // CARFREECAR
                if (backgroundWorker1.IsBusy is false)
                    backgroundWorker1.RunWorkerAsync(1);
            }
            else if (navigationFrame1.SelectedPage.Equals(R_navigationPage))
            {
                // RETURNFREE
                if (backgroundWorker1.IsBusy is false)
                    backgroundWorker1.RunWorkerAsync(2);
            }
        }

        private void GridControl_DbClick(object sender, EventArgs e)
        {
            P_TB_Button_UPDATE_Click(sender, e);
        }
        #endregion

        private T Load_Update<T>(string comboBox_TYPE)
        {
            switch (comboBox_TYPE)
            {
                case "Table": // P_comboBoxEdit.SelectedItem를 사용하지 않는 이유는  P, C , R  3개가 독립적이기 때문에 
                    TableService tableService = new TableService();
                    var tableId = Convert.ToInt32(gridView_Peoplecar.GetFocusedRowCellValue("TableId"));

                    P_Table getTable = tableService.Get_P_Table(tableId);
                    return (T)(object)AutoMapperUtil<P_Table, TableDto>.ToConvert(getTable);

                case "Column":
                    ColumnService columnService = new ColumnService();
                    var columnId = Convert.ToInt32(gridView_Peoplecar.GetFocusedRowCellValue("ColumnId"));

                    P_Column getColumn = columnService.Get_P_Column(columnId);
                    return (T)(object)AutoMapperUtil<P_Column, ColumnDto>.ToConvert(getColumn);

                case "Sp":
                    StoreProcedureService storeProcedureService = new StoreProcedureService();
                    var SpId = Convert.ToInt32(gridView_Peoplecar.GetFocusedRowCellValue("SpId"));

                    P_StoreProcedure getSp = storeProcedureService.Get_P_SP(SpId);
                    return (T)(object)AutoMapperUtil<P_StoreProcedure, StoreProcedureDto>.ToConvert(getSp);
                case "Word":
                    WordService wordService = new WordService();
                    var WordId = Convert.ToInt32(gridView_Peoplecar.GetFocusedRowCellValue("WordId"));

                    P_Word getWord = wordService.Get_P_Word(WordId);
                    return (T)(object)AutoMapperUtil<P_Word, WordDto>.ToConvert(getWord);
                default:
                    throw new InvalidOperationException("Unknown selection.");
            }
        }

        public enum DB_TYPE
        {
            PEOPLECAR,
            CARFREECAR,
            RETURNFREE
        }

        public struct ComboBox_TYPE
        {
            public static readonly string Table = "Table";
            public static readonly string Column = "Column";
            public static readonly string Sp = "Sp";
            public static readonly string Word = "Word";
        }


    }
}
