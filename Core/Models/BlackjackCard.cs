using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core.Models
{
    public class BlackjackCard
    {
        public string Suit {  get; set; }
        public string Rank { get; set; }

        public int Value
        {
            get
            {
                if(Rank == "A") return 1|11;
                if (Rank == "J" || Rank == "Q" || Rank == "K") return 10;
                return int.Parse(Rank);
            }
        }
    }
}
