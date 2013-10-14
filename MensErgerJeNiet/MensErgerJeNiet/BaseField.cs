namespace MensErgerJeNiet
{
    public class BaseField : Field
    {
        public Color myColor { get; set; }

        public BaseField(Field next, Field previous, Color color) : base(next, previous)
        {
            this.myColor = color;
        }
    }
}