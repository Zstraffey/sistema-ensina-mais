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
        public tela_inicial(string permissao, string permissao2)
        {
            InitializeComponent();
            this.permissao = permissao;
            {
                // Exibe a permissão na tela inicial ou utiliza para ajustar o comportamento da aplicação
                MessageBox.Show("Bem-vindo(a)");

                // Ajuste o comportamento da aplicação conforme a permissão
                if (permissao == "pro")
                {
                    
                }
                else if (permissao == "sec")
                {
                   
                }
                else if (permissao == "adm")
                {
                    

                }
            }

            label1.Text = permissao2;
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
