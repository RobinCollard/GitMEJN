namespace MensErgerJeNiet
{
    public class BaseField : Field
    {
        public int MyNumber { get; set; }

        public BaseField(Color color, int number)
        {
            this.MyColor = color;
            this.MyNumber = number;
        }
    }
}