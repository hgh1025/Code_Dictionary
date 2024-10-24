using Code_Dictionary.Model.Model;
using Code_Dictionary.Model.Repository;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using static Code_Dictionary.MainForm;

namespace Code_Dictionary
{
    public partial class WordDlg : DevExpress.XtraEditors.XtraForm
    {
        private DB_TYPE _dB_TYPE;
        private bool _IsCreate;
        private WordDto _wordData;

        public WordDlg(DB_TYPE dB_TYPE, bool IsCreate, WordDto wordData)
        {
            InitializeComponent();

            _dB_TYPE = dB_TYPE;
            _IsCreate = IsCreate;
            _wordData = wordData;
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

                var data = _wordData;

                textEdit_name.Text = data.name;
                textEdit_full_name.Text = data.full_Name;
                textEdit_desc.Text = data.Description;

            }
        }

        private void Text2Data()
        {
            var data = new WordDto();

            if (!_IsCreate)
            {
                data = _wordData;
            }

            data.name = this.textEdit_name.Text;
            data.full_Name = this.textEdit_full_name.Text;
            data.Description = this.textEdit_desc.Text;

            _wordData = data;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var result = XtraMessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WordService wordService = new WordService();
                    var data = _wordData;

                    Text2Data(); // convert

                    WaitForm_Operation(true);
                    if (_IsCreate) // 추가
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                wordService.Create_P_Word(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                wordService.Create_C_Word(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                wordService.Create_R_Word(data);
                                break;
                        }
                    }
                    else // 수정
                    {
                        switch (_dB_TYPE)
                        {
                            case DB_TYPE.PEOPLECAR:
                                wordService.Update_P_Word(data);
                                break;
                            case DB_TYPE.CARFREECAR:
                                wordService.Update_C_Word(data);
                                break;
                            case DB_TYPE.RETURNFREE:
                                wordService.Update_R_Word(data);
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