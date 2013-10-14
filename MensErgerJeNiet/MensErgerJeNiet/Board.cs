using System.IO;
using System.Text.RegularExpressions;
namespace MensErgerJeNiet
{
    public class Board
    {
        public BaseField OriginBaseField { get; set; }
        public Field Origin { get; set; }

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
                    if( s.Contains("std.mejn"))
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
                    if (x != 0 && y != 0)
                    {
                        previousField = currentField;
                    }
                    switch (lines[y][x])
                    {
                        case 'Y': currentField = new BaseField(Color.Yellow);
                            currentField.myPawn = new Pawn(currentField, Color.Yellow);
                            break;
                        case 'G': currentField = new BaseField(Color.Green);
                            currentField.myPawn = new Pawn(currentField, Color.Green);
                            break;
                        case 'R': currentField = new BaseField(Color.Red);
                            currentField.myPawn = new Pawn(currentField, Color.Red);
                            break;
                        case 'B': currentField = new BaseField(Color.Blue);
                            currentField.myPawn = new Pawn(currentField, Color.Blue);
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
                    if (x == 0 && y == 0) { OriginBaseField = (BaseField) currentField; }
                    if (x > 0) { currentField.Previous = previousField; previousField.Next = currentField;}

                }
            }
        }

        public void BuildBoardFields(string[] lines)
        {

        }
        
    }

}
