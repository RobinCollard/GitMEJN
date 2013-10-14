using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class HomeField : Field
    {
        public Color myColor { get; set; }

        public HomeField(Color color)
        {
            this.myColor = color;
        }
    }
}
