using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class HomeField : Field
    {
        public HomeField(Field next, Field previous)
            : base(next, previous)
        {

        }
    }
}
