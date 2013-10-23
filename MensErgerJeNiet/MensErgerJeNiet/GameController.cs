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
            eyes = rand.Next(1, 7);
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
                    currentField.MyPawn = currentPawn;
                    myBoard.CurrentTurn.MyStart.MyPawn = currentPawn;
                    myBoard.MyView.UpdateView();
                    SpaceToRethrow = true;
                    WaitForSpaceInput = false;
                    amountOfTurns += 2;

                }
            }
            else
            {
                if (SpaceToRethrow && !WaitForNumberInput && !WaitForSpaceInput)
                {
                    SpaceToRethrow = false;
                    ThrowDice();
                    myBoard.MyView.UpdateDice();
                    if (eyes == 6)
                    {
                        WaitForNumberInput = true;
                    }
                    else
                    {
                        if (myBoard.CurrentTurn.FullBase())
                        {
                            myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                            WaitForSpaceInput = true;
                        }
                        else
                        {
                            WaitForNumberInput = true;
                        }
                    }
                }
                else if (WaitForSpaceInput && !SpaceToRethrow && !WaitForNumberInput)
                {
                    WaitForSpaceInput = false;
                    ThrowDice();
                    myBoard.MyView.UpdateDice();
                    if (eyes == 6)
                    {
                        WaitForNumberInput = true;
                    }
                    else
                    {
                        if (myBoard.CurrentTurn.FullBase())
                        {
                            myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                            WaitForSpaceInput = true;
                        }
                        else
                        {
                            WaitForNumberInput = true;
                        }
                    }
                }
                else if (WaitForNumberInput && !WaitForSpaceInput && !SpaceToRethrow)
                {
                    if (!myBoard.CurrentTurn.GetPawnByNumber(key).IsLocked)
                    {
                        WaitForNumberInput = false;
                        if (myBoard.CurrentTurn.GetPawnByNumber(key).MyField.GetType() == typeof(BaseField))
                        {
                            if (eyes == 6)
                            {
                                currentPawn = myBoard.CurrentTurn.GetPawnByNumber(key);
                                currentField = currentPawn.MyField;
                                currentField.MyPawn = null;
                                currentField = myBoard.CurrentTurn.MyStart;
                                CheckIfCollision(currentField);
                                currentPawn.MyField = currentField;
                                currentField.MyPawn = currentPawn;
                                myBoard.CurrentTurn.MyStart.MyPawn = currentPawn;
                                myBoard.MyView.UpdateView();
                                SpaceToRethrow = true;
                            }
                            else
                            {
                                WaitForNumberInput = true;
                                //output
                            }
                        }
                        else
                        {
                            WaitForNumberInput = false;
                            currentPawn = myBoard.CurrentTurn.GetPawnByNumber(key);
                            currentField = currentPawn.MyField;
                            currentField.MyPawn = currentPawn;
                            Move(currentPawn, eyes, currentField);
                            if (eyes == 6)
                            {
                                SpaceToRethrow = true;
                            }
                            else
                            {
                                myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                                WaitForSpaceInput = true;
                            }
                        }
                    }
                    else
                    {
                        WaitForNumberInput = true;
                    }
                }
            }
        }

        public void Move(Pawn currentPawn, int eyes, Field currentField)
        {
            bool setToPrevious = false;
            currentField.MyPawn = null;
            for (int i = 0; i < eyes; i++)
            {
                if ((currentField.GetType() == typeof(EndField) && currentField.NextHome.MyColor == currentPawn.MyColor) || (currentField.GetType() == typeof(HomeField)))
                {
                    if (currentField.NextHome.IsLocked && setToPrevious == false)
                    {
                        while (currentField.NextHome.IsLocked)
                        {
                            if (currentField.NextHome != null)
                            {
                                currentField = currentField.NextHome;
                            }
                            else
                            {
                                setToPrevious = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentField = currentField.NextHome;
                    }
                    if (setToPrevious)
                    {
                        while (currentField.Previous.IsLocked)
                        {
                            currentField = currentField.Previous;
                        }
                        currentField = currentField.Previous;
                    }
                }
                else
                {
                    currentField = currentField.Next;
                }
            }
            CheckIfCollision(currentField);
            currentPawn.MyField = currentField;
            currentField.MyPawn = currentPawn;
            if(currentField.GetType() == typeof(HomeField))
            {
                currentField.IsLocked = true;
                currentPawn.IsLocked = true;
            }
            myBoard.MyView.UpdateView();
            setToPrevious = false;
        }

        public void CheckIfCollision(Field currentField)
        {
            if (currentField.MyPawn != null)
            {
                Player currentPlayer = myBoard.CurrentTurn;
                Pawn collisionPawn = currentField.MyPawn;
                BaseField newField = null;

                for (int i = 0; i < myBoard.AmountOfPlayers; i++)
                {
                    if (currentField.MyPawn.MyColor == currentPlayer.MyColor)
                    {
                        newField = currentPlayer.GetBaseByNumber(currentField.MyPawn.MyNumber);
                        currentField.MyPawn.MyField = newField;
                        currentField.MyPawn = null;
                        currentField = newField;
                        currentField.MyPawn = collisionPawn;
                        collisionPawn.MyField = currentField;
                        break;
                    }
                    currentPlayer = currentPlayer.Next;
                }
                myBoard.MyView.UpdateView();
            }
        }

        public void SixAndBaseNotFull(Pawn currentPawn)
        {
            if (currentPawn.MyField.GetType() == typeof(BaseField))
            {

            }
            else if (currentPawn.MyField.GetType() == typeof(StartField))
            {
                Move(currentPawn, eyes, currentPawn.MyField);
            }
            else if(currentPawn.MyField.GetType() == typeof(Field))
            {
                Move(currentPawn, eyes, currentPawn.MyField);
            }
        }
    }
}
