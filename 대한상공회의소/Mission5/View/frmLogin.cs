using Mission5Lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission5
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var lib = LibrarianDAO.GetInstance();
            var emp = lib.Get(txtEmpNo.Text);
            if (emp != null && txtPassword.Text == emp.Password)
            {
                var form = new frmMain(emp);
                form.Show();
                this.Hide();
            }
            else MessageBox.
                    Show("아이디 혹은 비밀번호를 잘못 입력하셨습니다.", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
