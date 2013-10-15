namespace MensErgerJeNiet
{
    public class BaseField : Field
    {
        public Color MyColor { get; set; }

        public BaseField(Color color)
        {
            this.MyColor = color;
        }
    }
}