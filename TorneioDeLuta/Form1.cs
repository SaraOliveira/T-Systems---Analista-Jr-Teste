using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace lutas
{
    public partial class FormLutadores : Form
    {
        List<Panel> paineis = new List<Panel>();
        List<CheckBox> caixasSelecao = new List<CheckBox>();
        List<Label> rotulos = new List<Label>();
        List<Lutador> Lutadors = new List<Lutador>();
        List<Lutador> selecionados;

        public FormLutadores()
        {
            InitializeComponent();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            GetData getData = new GetData();
            var task = await getData.Data();
            Lutadors = getData.Lutadores;

     
            addComponentes(Lutadors);
            
        }

       
        private void addComponentes(List<Lutador> lutadores)
        {
            int size = lutadores.Count();
            

            int px = 10, py=10, cx=10, cy=10, lx=10, ly=50;

            for(int i=0; i < size; i++)
            {
                Panel painel = new Panel();
                CheckBox caixaSelecao = new CheckBox();


                painel.SuspendLayout();
                painel.Location = new System.Drawing.Point(px, py);
                painel.Name = "panel"+i;
                painel.Size = new System.Drawing.Size(250, 190);
                painel.TabIndex = 0;



                paineis.Add(painel);

                px += 270;


                for (int j = 0; j < 5; j++)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Size = new System.Drawing.Size(140, 160);
                    label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.Location = new System.Drawing.Point(lx, ly);
                    label.Name = "label" + j;
                    //label.Size = new System.Drawing.Size(120, 20);
                    label.TabIndex = 0;
                    switch (j)
                    {
                        case 0:
                            label.Text = "Idade: " + lutadores[i].Idade;
                            break;
                        case 1:
                            label.Text = "Lutas: " + lutadores[i].Lutas.ToString();
                            break;
                        case 2:
                            label.Text = "Derrotas: " + lutadores[i].Derrotas.ToString();
                            break;
                        case 3:
                            
                            label.Text = "Vitórias: " + lutadores[i].Vitorias.ToString();
                            break;
                        case 4:
                            label.Text = "Artes Marciais: " + lutadores[i].ArtesMarciais.Count.ToString();
                            break;
                    }

                    ly += 30;
                    painel.Controls.Add(label);
                    
                    rotulos.Add(label);

                }


                ly = 50;

                caixaSelecao.AutoSize = true;
                caixaSelecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                caixaSelecao.Location = new System.Drawing.Point(cx, cy);
                caixaSelecao.Name = "checkBox"+i;
                caixaSelecao.Size = new System.Drawing.Size(240, 20);
                caixaSelecao.TabIndex = 0;
                caixaSelecao.Text = lutadores[i].Nome;
                caixaSelecao.UseVisualStyleBackColor = true;
                caixaSelecao.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);

                painel.Controls.Add(caixaSelecao);
                caixasSelecao.Add(caixaSelecao);
                

               // cx += 170;
                panel1.Controls.Add(painel);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Confrontos c = new Confrontos(selecionados);
            Lutador lutador = c.final();

            MessageBox.Show("O vencedor foi: " + lutador.Nome);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            lutadoresSelecionados();

        }

        private void lutadoresSelecionados()
        {
            selecionados = new List<Lutador>();
            List<string> nomes = new List<string>();
            int sel = 0;

            foreach (CheckBox c in caixasSelecao)
            {
                if (c.Checked)
                {
                    sel++;
                    nomes.Add(c.Text);
                }
            }

            labelContador.Text = sel.ToString() + " lutadores selecionados";


            for (int i = 0; i < Lutadors.Count; i++)
            {

                for (int j = 0; j < nomes.Count; j++)
                {

                    if (Lutadors[i].Nome.Equals(nomes[j]))
                    {
                        selecionados.Add(Lutadors[i]);
                    }

                }

            }

            if (sel == 16)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Confrontos c = new Confrontos(Lutadors);
        }
    }
}
