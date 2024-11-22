using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Ensina_Mais
{
    public partial class tela_inicial : Form
    {
        private string permissao;
        public tela_inicial(string permissao)
        {
            InitializeComponent();
            this.permissao = permissao;
            
            {
      
                if (permissao == "pro")
                {
                    label1.Text = "Menu Professor";
                    button4.Visible = true;
                }
                else if (permissao == "sec")
                {
                    label1.Text = "Menu Secretaria";
                    button1.Visible = true;
                    button2.Visible = true;
                }
                else if (permissao == "adm")
                {
                    label1.Text = "Menu Admnistrador";
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlunoEditar alunoEdit = new AlunoEditar();
            alunoEdit.Show();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
