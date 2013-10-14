namespace MensErgerJeNiet
{
    public class Pawn
    {
        public Field MyField { get; set; }
        public Color MyColor { get; set; }

        public Pawn(Field myField, Color myColor)
        {
            this.MyField = myField;
            this.MyColor = myColor;
        }
    }
}