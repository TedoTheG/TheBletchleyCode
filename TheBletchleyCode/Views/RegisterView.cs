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
using TheBletchleyCode.Models;

namespace TheBletchleyCode.Views
{
    public partial class RegisterView : Form
    {
        RegisterController registerController = new RegisterController();
        public RegisterView()
        {
            InitializeComponent();
        }

        private void lblLogInBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
            login.Text = "Login";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PlayerInfoTable user = new PlayerInfoTable();
            if (txtRegisterName.Text == string.Empty)
            {
                MessageBox.Show("Please fill in your name!");
            }
            else if (txtPassword.Text != txtConfirmPass.Text || txtPassword.Text == string.Empty || txtConfirmPass.Text ==string.Empty)
            {
                MessageBox.Show("Password don't match!");
            }
            else
            {
                user.Name = txtRegisterName.Text;
                user.Password = txtPassword.Text;
                registerController.AddUser(user);
                MessageBox.Show("User has been registered!");
                LoginForm login = new LoginForm();
                this.Hide();
                login.Show();
            }
            
        }
    }
}
