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
        private String myEvent;

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

        public void PlayTurn(int key)
        {
            if (WaitForSpaceInput == true && WaitForNumberInput == false)
            {
                WaitForSpaceInput = false;

                if (myBoard.CurrentTurn.FullBase() && eyes == 6) // Als bases vol zijn
                {
                    WaitForNumberInput = true;
                    myEvent = "newPawn";
                }
                else
                {
                    myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                    WaitForSpaceInput = true;
                }
            }
            else if (WaitForNumberInput == true && WaitForSpaceInput == false)
            {
                if (myEvent == "newPawn")
                {
                    Pawn pawnToMove = myBoard.CurrentTurn.getBaseByNumber(key).MyPawn;
                    myBoard.CurrentTurn.getBaseByNumber(key).MyPawn = null;
                    myBoard.CurrentTurn.MyStart.MyPawn = pawnToMove;
                    myBoard.MyView.UpdateView();
                    myEvent = "movePawn";
                }
                if (myEvent == "movePawn")
                {
                    // bij 6 numberinput true laten
                    WaitForNumberInput = false;
                    WaitForSpaceInput = true;
                }
            }

        }
    }
}
