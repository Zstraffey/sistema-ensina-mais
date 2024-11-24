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
    public partial class tela_inicial_secretaria : Form
    {
        public tela_inicial_secretaria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlunoCadastrar cadAluno = new AlunoCadastrar();
            cadAluno.Show();
        }
    }
}
