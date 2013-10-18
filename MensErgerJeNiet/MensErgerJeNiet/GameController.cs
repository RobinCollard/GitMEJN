﻿using System;
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
        private GameEvent myEvent;

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
            Field current;
            Pawn pawnToMove;
            if (WaitForSpaceInput == true && WaitForNumberInput == false)
            {

                if (myBoard.CurrentTurn.FullBase() && eyes == 6) // Als bases vol zijn
                {
                    WaitForNumberInput = true;
                    WaitForSpaceInput = false;
                    myEvent = GameEvent.newPawn;
                }
                if (myEvent == GameEvent.moveNewPawn)
                {
                    WaitForSpaceInput = false;
                    WaitForNumberInput = false;
                    myEvent = GameEvent.movePawn;
                    
                }
                else if(myBoard.CurrentTurn.FullBase() && eyes != 6)
                {
                    myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                    WaitForSpaceInput = true;
                }
            }
            else if (WaitForNumberInput == true && WaitForSpaceInput == false)
            {
                if (myEvent == GameEvent.newPawn)
                {
                    pawnToMove = myBoard.CurrentTurn.GetPawnByNumber(key);
                    myBoard.CurrentTurn.GetBaseByNumber(key).MyPawn = null;
                    myBoard.CurrentTurn.MyStart.MyPawn = pawnToMove;
                    pawnToMove.MyField = myBoard.CurrentTurn.MyStart;
                    myBoard.MyView.UpdateView();
                    myEvent = GameEvent.moveNewPawn;
                    
                    WaitForNumberInput = false;
                    WaitForSpaceInput = true;
                }
                if (myEvent == GameEvent.movePawn)
                {
                    // bij 6 numberinput true laten
                    current = myBoard.CurrentTurn.GetPawnByNumber(key).MyField;
                    pawnToMove = myBoard.CurrentTurn.GetPawnByNumber(key);
                    if (current.GetType() != typeof(BaseField))
                    {
                        WaitForNumberInput = false;
                        current.MyPawn = null;
                        for (int i = 0; i < eyes; i++)
                        {
                            current = current.Next;
                        }
                        current.MyPawn = pawnToMove;
                        myBoard.MyView.UpdateView();
                    }

                    myBoard.CurrentTurn = myBoard.CurrentTurn.Next;
                    WaitForSpaceInput = true;
                }
            }

        }
    }
}
