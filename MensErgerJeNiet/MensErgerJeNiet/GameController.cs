using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class GameController
    {
        private Board board;
        private Random rand = new Random();

        public GameController(Board board)
        {
            this.board = board;
        }

        public int ThrowDice()
        {
            int eyes = rand.Next(7);
            board.MyView.Dice.Content = eyes;
            return eyes;
        }
    }
}
