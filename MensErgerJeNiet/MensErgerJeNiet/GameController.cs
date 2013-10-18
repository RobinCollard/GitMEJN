using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool SpaceToRethrow { get; set; }
        private GameEvent myEvent;
        private int prevKey;
        private int amountOfTurns;
        private int highest;
        private bool twoHighest;
        private Player highestPlayer;

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

        public void FirstTurns(int key)
        {
            if (eyes > highest)
            {
                highest = eyes;
                highestPlayer = myBoard.CurrentTurn;
            }
            if (eyes == highest)
            {
                twoHighest = true;
            }
            if (amountOfTurns == 4)
            {
                myBoard.CurrentTurn = highestPlayer;
                eyes = 0;
                myBoard.MyView.Dice.Content = " ";
                myBoard.MyView.UpdateDice();
            }
            if (twoHighest && amountOfTurns == 3)
            {
                myBoard.CurrentTurn = myBoard.OriginPlayer;
                highest = 0;
                amountOfTurns = 0;
            }
            if (twoHighest == false && amountOfTurns != 3)
            {
                amountOfTurns++;
            }
        }

        public void PlayTurn(int key)
        {
            if (amountOfTurns < 5)
            {
                myEvent = GameEvent.firstTurns;
                FirstTurns(key);
                myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
            }
            else
            {

            }
            Field current;
            Pawn pawnToMove;
            
        }
    }
}
