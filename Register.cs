using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJack.Services;

namespace BlackJack 
{
    public partial class Register : Form
    {
        private UserService userService;
        public Register()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Register_Load);
        }

        private void Register_Load(object sender, EventArgs e)
        {
            userService = new UserService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString().Trim();
            string password = textBox2.Text.ToString().Trim();
            string email = textBox3.Text.ToString().Trim();

            userService.RegisterUser(username, password, email);

            Login login = new Login();
            login.Show();
            this.Hide();
        }

        
    }


}
