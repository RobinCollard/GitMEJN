namespace MensErgerJeNiet
{
    public class Field
    {
        public Field Next { get; set; }
        public Field Previous { get; set; }
        public HomeField NextHome { get; set; }
        public Pawn MyPawn { get; set; }

        public Field()
        {

        }
    }
}