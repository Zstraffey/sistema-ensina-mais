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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tela_inicial_secretaria tela_inicial_teste = new tela_inicial_secretaria();
            tela_inicial_teste.Show();
        }
    }
}
