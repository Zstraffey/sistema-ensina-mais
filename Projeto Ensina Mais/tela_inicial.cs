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
        public string permissao, id_usuario;

        public tela_inicial(string permissao, string id_usuario)
        {
            InitializeComponent();
            this.permissao = permissao;
            this.id_usuario = id_usuario;
            
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
                    label1.Text = "Menu Administrador";
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlunoEditar alunoEdit = new AlunoEditar(permissao, id_usuario);
            alunoEdit.Show();
            this.Close();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AulaEditar aulaEdit = new AulaEditar(permissao, id_usuario);
            aulaEdit.Show();
            this.Close();
        }
    }
}
