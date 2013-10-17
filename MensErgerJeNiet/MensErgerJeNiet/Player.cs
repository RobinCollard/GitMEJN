using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class Player
    {
        public Color MyColor { get; set; }
        public Player Next { get; set; }
        public Pawn[] MyPawns{ get; set; }
        public BaseField[] MyBases { get; set; }
        public HomeField[] MyHomes { get; set; }
        public StartField MyStart { get; set;  }

        public Player(Color myColor)
        {
            this.MyColor = myColor;
            MyPawns = new Pawn[4];
            MyBases = new BaseField[4];
            MyHomes = new HomeField[4];
        }

        public void AddPawn(Pawn pawn)
        {
            MyPawns[pawn.MyNumber - 1] = pawn;
        }

        public void AddBase(BaseField basef)
        {
            for (int i = 0; i < 4; i++)
            {
                if (MyBases[i] == null)
                {
                    MyBases[i] = basef;
                    break;
                }
            }
        }

        public void AddHome(HomeField homef)
        {
            for (int i = 0; i < 4; i++)
            {
                if (MyHomes[i] == null)
                {
                    MyHomes[i] = homef;
                    break;
                }
            }
        }

        public bool FullBase()
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.MyBases[i].MyPawn == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
