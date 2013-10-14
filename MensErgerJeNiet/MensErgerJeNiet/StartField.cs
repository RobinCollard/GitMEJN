using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet
{
    public class StartField : Field
    {
        public StartField(Field next, Field previous)
            : base(next, previous)
        {

        }
    }
}
