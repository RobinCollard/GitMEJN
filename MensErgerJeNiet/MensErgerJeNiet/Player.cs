using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class Player
    {
        public bool MyTurn { get; set; }
        public Color MyColor { get; set; }
        public Player Next { get; set; }

        public Player(Color myColor)
        {
            this.MyColor = myColor;
        }
    }
}
