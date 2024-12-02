using OOP_Teste;
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
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox4.Visible = true;
                }
                else if (permissao == "sec")
                {                    
                    pictureBox1.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox4.Visible = false;
                }
                else if (permissao == "adm")
                {
                    //groupBox1.Visible = true;
                }
            }

        }

   

        private void tela_inicial_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AlunoEditar alunoEdit = new AlunoEditar(permissao, id_usuario);
            alunoEdit.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            formADM novoForm = new formADM();
            novoForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            formADM novoForm = new formADM();
            novoForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AulaEditar aulaEdit = new AulaEditar(permissao, id_usuario);
            aulaEdit.Show();
            this.Close();
        }

      
    }
}
