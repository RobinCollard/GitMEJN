using System.IO;
using System.Text.RegularExpressions;
namespace MensErgerJeNiet
{
    public class Board
    {
        public BaseField OriginBaseField { get; set; }
        public Field Origin { get; set; }
        public Color CurrentColor { get; set; }
        public BoardView MyView { get; set; }
        public GameController GameControl { get; set; }
        public Player OriginPlayer { get; set; }

        public Board(int amountOfPlayers)
        {
            StartNewGame(amountOfPlayers);
            GameControl = new GameController(this);
        }

        public void StartNewGame(int amountOfPlayers)
        {
            
                string pathString = "";
                string[] fileStrings = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + @"\..\..\..\MEJN-Levels", "*.mejn");
                foreach (string s in fileStrings)
                {
                    OriginPlayer = new Player(Color.Blue);
                    Player currentPlayer = OriginPlayer;
                    if (amountOfPlayers == 4)
                    {
                        if (s.Contains("std.mejn"))
                        {
                            pathString = s;
                            buildLevel(pathString);
                        }
                        currentPlayer.Next = new Player(Color.Yellow);
                        currentPlayer = currentPlayer.Next;
                        currentPlayer.Next = new Player(Color.Green);
                        currentPlayer = currentPlayer.Next;
                        currentPlayer.Next = new Player(Color.Red);
                        currentPlayer = currentPlayer.Next;
                        currentPlayer.Next = OriginPlayer;
                    }
                    if (amountOfPlayers == 3)
                    {
                        if (s.Contains("std3.mejn"))
                        {
                            pathString = s;
                            buildLevel(pathString);
                        }
                        currentPlayer.Next = new Player(Color.Yellow);
                        currentPlayer = currentPlayer.Next;
                        currentPlayer.Next = new Player(Color.Green);
                        currentPlayer = currentPlayer.Next;
                        currentPlayer.Next = OriginPlayer;
                    }
                    if (amountOfPlayers == 2)
                    {
                        if (s.Contains("std2.mejn"))
                        {
                            pathString = s;
                            buildLevel(pathString);
                        }
                        OriginPlayer.Next = new Player(Color.Green);
                        currentPlayer = currentPlayer.Next;
                        currentPlayer.Next = OriginPlayer;
                    }
                    OriginPlayer.MyTurn = true;
            }
        }

        public void buildLevel(string pathString)
        {
            System.IO.StreamReader myFile =
            new System.IO.StreamReader(pathString);
            string myString = myFile.ReadToEnd();
            myFile.Close();

            string[] lines = Regex.Split(myString, "\r\n");

            BuildBaseFields(lines);
            BuildBoardFields(lines);
            MyView = new BoardView(this);
            MyView.Show();

        } // end BuildLevel

        public void BuildBaseFields(string[] lines)
        {
            Field currentField = null;
            Field previousField = null;
            int numberY = 1, numberG = 1, numberR = 1, numberB = 1;
            for (int y = 0; y < 1; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (OriginBaseField != null)
                    {
                        previousField = currentField;
                    }
                    switch (lines[y][x])
                    {
                        case 'Y': currentField = new BaseField(Color.Yellow);
                            currentField.MyPawn = new Pawn(currentField, Color.Yellow, numberY);
                            numberY++;
                            break;
                        case 'G': currentField = new BaseField(Color.Green);
                            currentField.MyPawn = new Pawn(currentField, Color.Green, numberG);
                            numberG++;
                            break;
                        case 'R': currentField = new BaseField(Color.Red);
                            currentField.MyPawn = new Pawn(currentField, Color.Red, numberR);
                            numberR++;
                            break;
                        case 'B': currentField = new BaseField(Color.Blue);
                            currentField.MyPawn = new Pawn(currentField, Color.Blue, numberB);
                            numberB++;
                            break;
                        case '5': currentField = new BaseField(Color.Yellow);
                            break;
                        case '6': currentField = new BaseField(Color.Green);
                            break;
                        case '7': currentField = new BaseField(Color.Red);
                            break;
                        case '8': currentField = new BaseField(Color.Blue);
                            break;
                        default:
                            break;
                    }
                    if (x == 0 && y == 0) { OriginBaseField = (BaseField)currentField; }
                    if (x > 0) { currentField.Previous = previousField; previousField.Next = currentField; }

                }
            }
        }

        public void BuildBoardFields(string[] lines)
        {
            Field currentField = null;
            Field previousField = null;
            Field continueOn = null;
            for (int y = 1; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (Origin != null)
                    {
                        previousField = currentField;
                    }
                    switch (y)
                    {
                        case 1: CurrentColor = Color.Yellow; break;
                        case 2: CurrentColor = Color.Green; break;
                        case 3: CurrentColor = Color.Red; break;
                        case 4: CurrentColor = Color.Blue; break;
                    }
                    if (x == 0)
                    {
                        currentField = new StartField(CurrentColor);
                        if (y == 1) { Origin = currentField; }
                        if (y > 1) { previousField = continueOn; previousField.Next = currentField; currentField.Previous = previousField; }

                    }
                    if (x > 0 && x < 9)
                    {
                        currentField = new Field();
                        currentField.Previous = previousField;
                        previousField.Next = currentField;
                    }
                    if (x == 9)
                    {
                        currentField = new EndField();
                        currentField.Previous = previousField;
                        previousField.Next = currentField;
                        continueOn = currentField;
                    }
                    if (x > 9)
                    {
                        currentField = new HomeField(CurrentColor);
                        currentField.Previous = previousField;
                        previousField.NextHome = (HomeField)currentField;
                    }
                    if (lines[y][x] != 'o')
                    {
                        BaseField current = OriginBaseField;
                        switch(lines[y][x])
                        {
                            case 'y': CurrentColor = Color.Yellow; break;
                            case 'g': CurrentColor = Color.Green; break;
                            case 'b': CurrentColor = Color.Blue; break;
                            case 'r': CurrentColor = Color.Red; break;
                            default: break;
                        }
                        int amount = 0;
                        while (current.MyColor == CurrentColor)
                        {
                            if (current.MyPawn != null)
                                amount++;
                            current = (BaseField)current.Next;
                        }
                        current = OriginBaseField;
                        while(current.Next != null)
                        {
                            if(current.MyColor == CurrentColor && current.MyPawn == null)
                            {
                                break;
                            }
                            current = (BaseField) current.Next;
                        }
                        currentField.MyPawn = new Pawn(current, CurrentColor, (amount + 1));
                    }
                }
            }
            Origin.Previous = continueOn;
            continueOn.Next = Origin;
        }
    }
}
