using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet
{
    public class StartField : Field
    {
        public Color myColor { get; set; }

        public StartField(Color color)
        {
            this.myColor = color;
        }
    }
}
