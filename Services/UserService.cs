using BlackJack.Repositories;
using BlackJack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace BlackJack.Services
{
    public class UserService
    {
        private readonly JsonUserRepositories _repository;

        public UserService()
        {
            _repository = new JsonUserRepositories();   
        }

        public void RegisterUser(string username, string pass ,string email)
        {

            var user = new User
            {
                Date = DateTime.Now,
                Username = username,
                Password = pass,
                Email = email
            };

            _repository.Add(user);
            Console.WriteLine($"Kullanıcı Kaydedildi: {username}");
        }

        public bool FindUser(string username, string pass)
        {
            foreach(var user in _repository.GetAll())
            {
                if(user.Username == username && user.Password == pass)
                {
                    return true;
                }
            }
            return false;
        }

        public string Password_Hash(string p)
        {
            if( p == "" ||p == null)
            {
                MessageBox.Show("Şifre Boş Bırakılamaz!");
                return null;
            }
            else
            {
                return MyPass(p);
            }
        }

        public string MyPass(string p)
        {
            p = p.Trim();
            int length = p.Length;

            if (length < 2)
                return "ERR_SHORT_INPUT";

            string my_new_pass = "";

            if (char.IsDigit(p[0]))
            {
                my_new_pass += "0x0" + p.Substring(0, 2);
            }
            else
            {
                my_new_pass += "1x1" + p.Substring(0, 2);
            }

            if (length <= 4)
            {
                my_new_pass += "058bneoq";
                if (length >= 4)
                    my_new_pass += p.Substring(2, 2);
                else if (length > 2)
                    my_new_pass += p.Substring(2);  // kalan kısmı ekle
            }
            else if (length <= 7)
            {
                my_new_pass += "2478adjaa";
                if (length >= 7)
                    my_new_pass += p.Substring(2, 5);
                else
                    my_new_pass += p.Substring(2);  // ne varsa ekle
            }
            else
            {
                my_new_pass += "daoqf85ncn1n";
                if (length >= 2)
                    my_new_pass += p.Substring(2);
            }

            if (my_new_pass.Length >= 5)
                my_new_pass += my_new_pass.Substring(2, 3);
            else
                my_new_pass += "xyz";  // Güvenlik için fallback

            return my_new_pass;
        }

    }
}
