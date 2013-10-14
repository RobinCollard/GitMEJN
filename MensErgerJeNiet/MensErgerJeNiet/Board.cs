using System.IO;
using System.Text.RegularExpressions;
namespace MensErgerJeNiet
{
    public class Board
    {
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
        }
    }
}