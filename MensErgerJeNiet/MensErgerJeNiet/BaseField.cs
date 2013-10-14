namespace MensErgerJeNiet
{
    public class BaseField : Field
    {
        public Color myColor { get; set; }

        public BaseField(Color color)
        {
            this.myColor = color;
        }
    }
}