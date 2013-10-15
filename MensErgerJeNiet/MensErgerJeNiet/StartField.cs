using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet
{
    public class StartField : Field
    {
        public Color MyColor { get; set; }

        public StartField(Color color)
        {
            this.MyColor = color;
        }
    }
}
