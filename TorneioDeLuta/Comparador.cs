using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lutas
{
    public class Comparador : IComparer<Lutador>
    {


        int IComparer<Lutador>.Compare(Lutador x, Lutador y)
        {
            return x.Idade - y.Idade;

            throw new NotImplementedException();


        }
    }


}
