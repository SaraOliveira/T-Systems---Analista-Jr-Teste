using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace lutas
{
    class GetData
    {

        public List<Lutador> Lutadores { get; set; }
        

        public async Task<string> Data()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://177.36.237.87/lutadores/api/competidores");
                var resposta = await client.GetAsync("");


                string dados = await resposta.Content.ReadAsStringAsync();

                List<Lutador> lutadores = new JavaScriptSerializer().Deserialize<List<Lutador>>(dados);
                this.Lutadores = lutadores;

                //foreach(Lutador l in lutadores)
                //{
                //    int x = l.Lutas;
                //    int y = l.Vitorias;
                //    if (x != 0)
                //    {
                //        double res = (double)y / (double)x * 100;
                //        int r = (int)res;
                //        MessageBox.Show(r.ToString());
                //    }
                //}

                return dados;


            }

        }


    }
}
