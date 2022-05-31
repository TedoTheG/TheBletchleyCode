using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheBletchleyCode.Controllers;

namespace TheBletchleyCode.Views
{
    public partial class LoginForm : Form
    {
        LoginController loginController = new LoginController();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterView register = new RegisterView();
            register.Show();
            register.Text = "Register";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var message = loginController.ShowMessage(txtLogin.Text, txtPassword.Text);
            if (message != null)
            {
                MessageBox.Show(message);
            }
            else
            {
                GameView gv = new GameView();
                this.Hide();
                gv.Show();
            }
        }
    }
}
