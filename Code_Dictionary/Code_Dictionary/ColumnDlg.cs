using Code_Dictionary.Model.Dto;
using Code_Dictionary.Model.Repository;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using static Code_Dictionary.MainForm;

namespace Code_Dictionary
{
    public partial class ColumnDlg : DevExpress.XtraEditors.XtraForm
    {
        private DB_TYPE _dB_TYPE;
        private bool _IsCreate;
        private ColumnDto _columnData;

        public ColumnDlg(DB_TYPE dB_TYPE, bool IsCreate, ColumnDto columnData)
        {
            InitializeComponent();
            _dB_TYPE = dB_TYPE;
            _IsCreate = IsCreate;
            _columnData = columnData;
        }

        public struct Button_Type
        {
            public static readonly string Save = "저장";
            public static readonly string Update = "수정";
        }

        private void ColumnDlg_Load(object sender, System.EventArgs e)
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
                textEdit_column_name.ReadOnly = true;

                var data = _columnData;

                textEdit_name1.Text = data.name1;
                textEdit_name2.Text = data.name2;
                textEdit_name3.Text = data.name3;
                textEdit_name4.Text = data.name4;
                textEdit_name5.Text = data.name5;
                textEdit_name6.Text = data.name6;
                textEdit_tb_name.Text = data.Table_name;
                textEdit_column_name.Text = data.Column_name;
                textEdit_desc.Text = data.Description;

            }
        }

        private void Text2Data()
        {
            var data = new ColumnDto();

            if (!_IsCreate)
            {
                data = _columnData;
            }

            data.name1 = this.textEdit_name1.Text;
            data.name2 = this.textEdit_name2.Text;
            data.name3 = this.textEdit_name3.Text;
            data.name4 = this.textEdit_name4.Text;
            data.name5 = this.textEdit_name5.Text;
            data.name6 = this.textEdit_name6.Text;
            data.Table_name = this.textEdit_tb_name.Text;
            data.Column_name = this.textEdit_column_name.Text;
            data.Column_name = string.Join("_", new[]
                                        {
                                            textEdit_name1.Text,
                                            textEdit_name2.Text,
                                            textEdit_name3.Text,
                                            textEdit_name4.Text,
                                            textEdit_name5.Text,
                                            textEdit_name6.Text
                                        }.Where(x => !string.IsNullOrEmpty(x)));
            data.Description = this.textEdit_desc.Text;

            _columnData = data;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var result = XtraMessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ColumnService columnService = new ColumnService();
                    var data = _columnData;

                    Text2Data(); // convert

                    WaitForm_Operation(true);
                    if (_IsCreate) // 추가
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                columnService.Create_P_Column(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                columnService.Create_C_Column(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                columnService.Create_R_Column(data);
                                break;
                        }
                    }
                    else // 수정
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                columnService.Update_P_Column(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                columnService.Update_C_Column(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                columnService.Update_R_Column(data);
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