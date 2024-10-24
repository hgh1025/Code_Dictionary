using Code_Dictionary.Model.Model;
using Code_Dictionary.Model.Repository;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using static Code_Dictionary.MainForm;

namespace Code_Dictionary
{
    public partial class SpDlg : DevExpress.XtraEditors.XtraForm
    {
        private DB_TYPE _dB_TYPE;
        private bool _IsCreate;
        private StoreProcedureDto _spData;

        public SpDlg(DB_TYPE dB_TYPE, bool IsCreate, StoreProcedureDto spData)
        {
            InitializeComponent();

            _dB_TYPE = dB_TYPE;
            _IsCreate = IsCreate;
            _spData = spData;
        }

        public struct Button_Type
        {
            public static readonly string Save = "저장";
            public static readonly string Update = "수정";
        }

        private void SpDlg_Load(object sender, System.EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            simpleButton1.Text = Button_Type.Save;

            if (!_IsCreate)
            {
                simpleButton1.Text = Button_Type.Update;
                textEdit_sp_name.ReadOnly = true;

                var data = _spData;

                textEdit_name1.Text = data.name1;
                textEdit_name2.Text = data.name2;
                textEdit_name3.Text = data.name3;
                textEdit_name4.Text = data.name4;
                textEdit_name5.Text = data.name5;
                textEdit_name6.Text = data.name6;
                textEdit_sp_name.Text = data.Sp_name;
                textEdit_desc.Text = data.Description;

            }
        }

        private void Text2Data()
        {
            var data = new StoreProcedureDto();

            if (!_IsCreate)
            {
                data = _spData;
            }

            data.name1 = this.textEdit_name1.Text;
            data.name2 = this.textEdit_name2.Text;
            data.name3 = this.textEdit_name3.Text;
            data.name4 = this.textEdit_name4.Text;
            data.name5 = this.textEdit_name5.Text;
            data.name6 = this.textEdit_name6.Text;
            data.Sp_name = string.Join("_", new[]
                                        {
                                            textEdit_name1.Text,
                                            textEdit_name2.Text,
                                            textEdit_name3.Text,
                                            textEdit_name4.Text,
                                            textEdit_name5.Text,
                                            textEdit_name6.Text
                                        }.Where(x => !string.IsNullOrEmpty(x)));
            data.Description = this.textEdit_desc.Text;

            _spData = data;
        }

        private void Save_Click(object sender, System.EventArgs e)
        {
            try
            {
                var result = XtraMessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    StoreProcedureService storeProcedureService = new StoreProcedureService();
                    var data = _spData;

                    Text2Data(); // convert

                    WaitForm_Operation(true);
                    if (_IsCreate) // 추가
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                storeProcedureService.Create_P_SP(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                storeProcedureService.Create_C_SP(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                storeProcedureService.Create_R_SP(data);
                                break;
                        }
                    }
                    else // 수정
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                storeProcedureService.Update_P_SP(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                storeProcedureService.Update_C_SP(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                storeProcedureService.Update_R_SP(data);
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

        private void Cancel_Click(object sender, EventArgs e)
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