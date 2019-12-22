using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lutas
{
    class Confrontos
    {

        private List<Lutador> l;

        public Confrontos(List<Lutador> l)
        {
            Comparador c = new Comparador();
            l.Sort(c);

            this.l = l;

        }

        public void Oitavas()
        { 
            action(16);
       
        }

        public void Quartas()
        {
            action(8);
            
        }

        public void SemFinal()
        {
            action(4);
        }

        public Lutador final()
        {
            Oitavas();
            Quartas();
            SemFinal();
            action(2);
            return this.l[0];
        }

        public void action(int minimo)
        {
            List<Lutador> vencedores = new List<Lutador>();

            for (int i = 0; i < minimo; i += 2)
            {
                int v1 = this.l[i].Vitorias;
                int l1 = this.l[i].Lutas;
                int v2 = this.l[i+1].Vitorias;
                int l2 = this.l[i+1].Lutas;
                int r1 = 100;
                int r2 = 100;

                if(l1 != 0)
                {
                    double t1 = (double)v1 / (double)l1 * 100;
                    r1 = (int)t1;
                }

                if(l2 != 0)
                {
                    double t2 = (double)v2 / (double)l2 * 100;
                    r2 = (int)t2;

                }


                if (r1 > r2)
                {
                    vencedores.Add(this.l[i]);
                }
                else if (r2 > r1)
                {
                    vencedores.Add(this.l[i + 1]);
                }
                else
                {
                    vencedores.Add(desempata(this.l[i], this.l[i + 1]));
                }
            }

            this.l = vencedores;
        }

        public Lutador desempata(Lutador l1, Lutador l2)
        {
            if(l1.ArtesMarciais.Count > l2.ArtesMarciais.Count)
            {
                return l1;
            }
            else if(l2.ArtesMarciais.Count > l1.ArtesMarciais.Count)
            {
                return l2;
            }
            else if(l1.Lutas > l2.Lutas)
            {
                return l1;
            }
            else
            {
                return l2;
            }

        }

        
    }

    
}
