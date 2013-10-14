namespace MensErgerJeNiet
{
    public class EndField : Field
    {
        public HomeField NextHome { get; set; }

        public EndField(Field next, Field previous) : base (next, previous)
        {

        }
    }
}