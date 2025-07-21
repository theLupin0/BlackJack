using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    public class LogService
    {
        private readonly string blackjackPath = Path.Combine(Application.StartupPath, "Data", "UserBlackjackData.txt");

        public void gameBlackjackLog(string message)
        {
            string? directory = Path.GetDirectoryName(blackjackPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);   
            }
            string log = $"\n{DateTime.Now} - {message}";
            File.AppendAllText(blackjackPath, log + " " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }
}
