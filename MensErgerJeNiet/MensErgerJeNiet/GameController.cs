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
        private int eyes;

        public GameController(Board board)
        {
            this.board = board;
        }

        public int ThrowDice()
        {
            eyes = rand.Next(6);
            eyes++;
            board.MyView.Dice.Content = " " + eyes;
            return eyes;
        }

        public void PlayTurn()
        {

        }
    }
}
