namespace MensErgerJeNiet
{
    public class Player
    {
        public Pawn[] pawns { get; set; }

        public Player()
        {
            pawns = new Pawn[4];
        }
    }
}