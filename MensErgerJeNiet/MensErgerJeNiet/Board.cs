using System.IO;
using System.Text.RegularExpressions;
namespace MensErgerJeNiet
{
    public class Board
    {
        public BaseField OriginBaseField { get; set; }
        public Field Origin { get; set; }
        public Color CurrentColor { get; set; }

        public Board()
        {

        }

        public void StartNewGame(int amountOfPlayers)
        {
            if (amountOfPlayers == 4)
            {
                string pathString = "";
                string[] fileStrings = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + @"\..\..\..\MEJN-Levels", "*.mejn");
                foreach (string s in fileStrings)
                {
                    if (s.Contains("std.mejn"))
                    {
                        pathString = s;
                        buildLevel(pathString);
                    }
                }
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

        } // end BuildLevel

        public void BuildBaseFields(string[] lines)
        {
            Field currentField = null;
            Field previousField = null;
            for (int y = 0; y < 2; y++)
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
                            currentField.MyPawn = new Pawn(currentField, Color.Yellow);
                            break;
                        case 'G': currentField = new BaseField(Color.Green);
                            currentField.MyPawn = new Pawn(currentField, Color.Green);
                            break;
                        case 'R': currentField = new BaseField(Color.Red);
                            currentField.MyPawn = new Pawn(currentField, Color.Red);
                            break;
                        case 'B': currentField = new BaseField(Color.Blue);
                            currentField.MyPawn = new Pawn(currentField, Color.Blue);
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
            // Klopt nog niet
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
                        switch(lines[x][y])
                        {
                            case 'y': CurrentColor = Color.Yellow; break;
                            case 'g': CurrentColor = Color.Green; break;
                            case 'b': CurrentColor = Color.Blue; break;
                            case 'r': CurrentColor = Color.Red; break;
                            default: break;
                        }
                        while(current.Next != null)
                        {
                            if(current.MyColor == CurrentColor && current.MyPawn == null)
                            {
                                break;
                            }
                            current = (BaseField) current.Next;
                        }
                        currentField.MyPawn = new Pawn(current, CurrentColor);
                    }
                }
            }
            Origin.Previous = currentField;
            currentField.Next = Origin;
        }
    }
}
