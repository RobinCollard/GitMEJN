using System.IO;
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
                string[] filePaths = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + @"\..\..\..\MEJN-Levels", "*.mejn");
            }   
        }
    }
}