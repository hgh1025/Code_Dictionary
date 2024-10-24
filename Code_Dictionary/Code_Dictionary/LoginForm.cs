using Code_Dictionary.Model.Repository;
using System.Windows.Forms;

namespace Code_Dictionary
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        MemberService memberService = new MemberService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, System.EventArgs e)
        {
            string userId = textUserID.Text;
            string pw = textUserPassword.Text;

            var model = memberService.GetLoginUser(userId, pw);
            try
            {
                if (model != null)
                {
                    // Form1을 모달로 열지 않고 그냥 열어서 LoginForm을 닫을 수 있도록 처리
                    MainForm dlg = new MainForm();
                    dlg.Show();  // ShowDialog() 대신 Show()를 사용하여 모달이 아닌 일반 폼으로 열기

                    // 현재 로그인 폼을 닫음
                    this.Hide();  // Close() 대신 Hide()를 사용하여 LoginForm을 숨김
                }
                else
                {
                    MessageBox.Show("회원정보가 다릅니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("로그인 처리 중 오류가 발생했습니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
