using Code_Dictionary.Model.Dto;
using Code_Dictionary.Model.Repository;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

using static Code_Dictionary.MainForm;

namespace Code_Dictionary
{
    public partial class TableDlg : XtraForm
    {
        private DB_TYPE _dB_TYPE;
        private bool _IsCreate;
        private TableDto _tableData;

        public TableDlg(DB_TYPE dB_TYPE, bool IsCreate, TableDto tableData)
        {
            InitializeComponent();

            _dB_TYPE = dB_TYPE;
            _IsCreate = IsCreate;
            _tableData = tableData;
        }

        public struct Button_Type
        {
            public static readonly string Save = "저장";
            public static readonly string Update = "수정";
        }

        private void TableDlg_Load(object sender, System.EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            simpleButton1.Text = Button_Type.Save;

            if (!_IsCreate)
            {
                simpleButton1.Text = Button_Type.Update;
                textEdit_tb_name.ReadOnly = true;

                var data = _tableData;

                textEdit_name1.Text = data.name1; // 첫 문자가 대문자인지 체크 필요?
                textEdit_name2.Text = data.name2;
                textEdit_name3.Text = data.name3;
                textEdit_name4.Text = data.name4;
                textEdit_name5.Text = data.name5;
                textEdit_name6.Text = data.name6;
                textEdit_tb_name.Text = data.Table_name;
                textEdit_desc.Text = data.Description;
            }
        }

        private void Text2Data()
        {
            var data = new TableDto();

            if (!_IsCreate)
            {
                data = _tableData;
            }

            data.name1 = this.textEdit_name1.Text;
            data.name2 = this.textEdit_name2.Text;
            data.name3 = this.textEdit_name3.Text;
            data.name4 = this.textEdit_name4.Text;
            data.name5 = this.textEdit_name5.Text;
            data.name6 = this.textEdit_name6.Text;

            if (_dB_TYPE == DB_TYPE.PEOPLECAR)
            {
                data.Table_name = string.Join("", new[]
                                       {
                                            textEdit_name1.Text,
                                            textEdit_name2.Text,
                                            textEdit_name3.Text,
                                            textEdit_name4.Text,
                                            textEdit_name5.Text,
                                            textEdit_name6.Text
                                        }.Where(x => !string.IsNullOrEmpty(x)));//peoplecar db는 _로 결합이 아니기 때문에 추후 고려대상
                data.Description = this.textEdit_desc.Text;
            }
            else
            {
                data.Table_name = string.Join("_", new[]
                                        {
                                            textEdit_name1.Text,
                                            textEdit_name2.Text,
                                            textEdit_name3.Text,
                                            textEdit_name4.Text,
                                            textEdit_name5.Text,
                                            textEdit_name6.Text
                                        }.Where(x => !string.IsNullOrEmpty(x)));
            }

            data.Description = this.textEdit_desc.Text;

            _tableData = data;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var result = XtraMessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    TableService tableService = new TableService();
                    var data = _tableData;

                    Text2Data(); // convert

                    WaitForm_Operation(true);

                    if (_IsCreate) // 추가
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                tableService.Create_P_Table(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                tableService.Create_C_Table(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                tableService.Create_R_Table(data);
                                break;
                        }
                    }
                    else // 수정
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                tableService.Update_P_Table(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                tableService.Update_C_Table(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                tableService.Update_R_Table(data);
                                break;
                        }
                    }

                    WaitForm_Operation(false);

                    // 작업 성공 후 DialogResult를 OK로 설정하고 폼을 닫음
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
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
    }
}