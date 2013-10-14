namespace MensErgerJeNiet
{
    public class Field
    {
        public Field Next { get; set; }
        public Field Previous { get; set; }
        public Pawn myPawn { get; set; }

        public Field(Field next, Field previous)
        {
            this.Next = next;
            this.Previous = previous;
        }
    }
}