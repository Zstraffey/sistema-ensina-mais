using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Ensina_Mais
{
    public partial class AulaExcluir : Form
    {
        public string permissao, id_usuario, id_aula;

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            { 
                string data_aula_errado = textBox1.Text;
                string hora_aula = textBox2.Text;
                string curso = textBox3.Text;
                string tema = textBox4.Text;
                string numero_aula = textBox5.Text;
                string prof1 = textBox6.Text;
                string prof2 = textBox7.Text;

                MySqlConnection conexao2 = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
                conexao2.Open();
                string excluir = "DELETE FROM aulas WHERE aulaId = " + id_aula;
                MySqlCommand comandos = new MySqlCommand(excluir, conexao2);

                comandos.ExecuteNonQuery();

                AulaEditar aulaEdit = new AulaEditar(permissao, id_usuario);
                aulaEdit.Show();
                this.Close();
            }
        }

        public AulaExcluir(string permissao, string id_usuario, string id_aula)
        {
            InitializeComponent();

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            this.permissao = permissao;
            this.id_usuario = id_usuario;
            this.id_aula = id_aula;

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
            conexao.Open();


            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT * FROM aulas WHERE aulaId = " + id_aula;


            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    textBox1.Text = resultado["aulaId"].ToString();
                    textBox2.Text = resultado["data_aula"].ToString();
                    textBox3.Text = resultado["horario"].ToString();
                    textBox4.Text = resultado["curso"].ToString();
                    textBox5.Text = resultado["tema"].ToString();
                    textBox6.Text = resultado["numero_aula"].ToString();
                    textBox7.Text = resultado["prof1"].ToString();
                    textBox8.Text = resultado["prof2"].ToString();
                }

            }

            else
            {

                MessageBox.Show("Nenhum registro foi encontrado");

            }
        }
    }
}
