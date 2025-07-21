using BlackJack.Services;

namespace BlackJack
{
    public partial class Login : Form
    {
        private UserService user;
        Blackjack blackjack = new Blackjack();
        public Login()
        {
            InitializeComponent();
            user = new UserService();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            while (check==false)
            {
                string username = textBox1.Text.ToString().Trim();
                string pass = textBox2.Text.ToString().Trim();

                check = user.FindUser(username, pass);

                if (check == false)
                    MessageBox.Show("Bilgiler Hatalý!");
                else
                {
                    blackjack.Show();
                    this.Hide();
                }
                    
            }
        }
    }
}
