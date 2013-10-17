using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class GameController
    {
        private Board myBoard;
        private Random rand = new Random();
        private int eyes;
        public bool WaitForSpaceInput { get; set; }
        public bool WaitForNumberInput { get; set; }

        public GameController(Board board)
        {
            this.myBoard = board;
            WaitForSpaceInput = true;
        }

        public void ThrowDice()
        {
            eyes = rand.Next(6);
            eyes++;
            myBoard.MyView.Dice.Content = " " + eyes;
        }

        public void PlayTurn()
        {
            WaitForSpaceInput = false;

           // if(myBoard.CurrentTurn.MyColor = 
        }
    }
}
