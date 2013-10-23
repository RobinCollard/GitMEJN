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
        private Pawn currentPawn;
        private Field currentField;

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
            ThrowDice();
            myBoard.MyView.UpdateDice();
            if (amountOfTurns == myBoard.AmountOfPlayers)
            {
                myBoard.CurrentTurn = highestPlayer;
                eyes = 0;
                myBoard.MyView.Dice.Content = " ";
                myBoard.MyView.UpdateDice();
            }
            if (eyes == highest)
            {
                twoHighest = true;
            }
            if (eyes > highest)
            {
                highest = eyes;
                twoHighest = false;  
                highestPlayer = myBoard.CurrentTurn;

            }
            if (twoHighest == false)
            {
                amountOfTurns++;
            }
            if (twoHighest)
            {
                myBoard.CurrentTurn = myBoard.OriginPlayer;
                highest = 0;
                highestPlayer = null;
                amountOfTurns = 0;
                twoHighest = false;
            }           
        }

        public void PlayTurn(int key)
        {
            if (amountOfTurns < myBoard.AmountOfPlayers + 1)
            {
                Debug.WriteLine(amountOfTurns + " " + myBoard.AmountOfPlayers);
                myEvent = GameEvent.firstTurns;
                FirstTurns(key);
                if (amountOfTurns != 0 && amountOfTurns != myBoard.AmountOfPlayers + 1) { myBoard.CurrentTurn = myBoard.CurrentTurn.Next; }
                if (amountOfTurns == myBoard.AmountOfPlayers + 1)
                {
                    currentPawn = myBoard.CurrentTurn.GetPawnByNumber(1);
                    prevKey = 1;
                    currentField = currentPawn.MyField;
                    currentField.MyPawn = null;
                    currentField = myBoard.CurrentTurn.MyStart;
                    currentPawn.MyField = currentField;
                    myBoard.CurrentTurn.MyStart.MyPawn = currentPawn;
                    myBoard.MyView.UpdateView();
                    SpaceToRethrow = true;
                    WaitForSpaceInput = false;
                    amountOfTurns += 2;

                }
            }
            else
            {
                if (SpaceToRethrow)
                {
                    ThrowDice();
                    myBoard.MyView.UpdateDice();
                    if (eyes == 6)
                    {
                        if (!myBoard.CurrentTurn.FullBase())
                        {
                            SixAndBaseNotFull(currentPawn);
                        }
                    }
                    else
                    {
                        Move(currentPawn, eyes, currentField);
                        myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                        SpaceToRethrow = false;
                        WaitForSpaceInput = true;
                    }
                }
                if (WaitForSpaceInput)
                {

                }
            }
        }

        public void Move(Pawn currentPawn, int eyes, Field currentField)
        {
            currentField.MyPawn = null;
            for (int i = 0; i < eyes; i++)
            {
                currentField = currentField.Next;
            }
            currentPawn.MyField = currentField;
            currentField.MyPawn = currentPawn;
            myBoard.MyView.UpdateView();
        }

        public void SixAndBaseNotFull(Pawn currentPawn)
        {
            if (currentPawn.MyField.GetType() == typeof(BaseField))
            {

            }
            else
            {
                if (currentPawn.MyField.GetType() == typeof(StartField))
                {
                    Move(currentPawn, eyes, currentPawn.MyField);
                }
            }
        }
    }
}
