using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Ensina_Mais
{
    public partial class AulaAlterar : Form
    {
        public string permissao, id_usuario, id_aula;
        public AulaAlterar(string permissao, string id_usuario, string id_aula)
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
                    dateTimePicker1.Text = resultado["data_aula"].ToString();
                    dateTimePicker3.Text = resultado["horario"].ToString();
                    comboBox1.Text = resultado["curso"].ToString();
                    textBox3.Text = resultado["tema"].ToString();
                    if (decimal.TryParse(resultado["numero_aula"].ToString(), out decimal numeroAula))
                    {
                        numericUpDown1.Value = numeroAula;
                    }
                    else
                    {
                        MessageBox.Show("O valor de 'numero_aula' não é válido para o NumericUpDown.");
                    }
                    comboBox2.Text  = resultado["prof1"].ToString();
                    comboBox3.Text = resultado["prof2"].ToString();
                }

            }

            else
            {

                MessageBox.Show("Nenhum registro foi encontrado");

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja alterar as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                string data_aula_errado = dateTimePicker1.Text;
                string hora_aula = dateTimePicker3.Text;
                string curso = comboBox1.Text;
                string tema = textBox3.Text;
                string numero_aula = Convert.ToString(numericUpDown1.Value);
                string prof1 = comboBox2.Text;
                string prof2 = comboBox3.Text;

                DateTime dataConvertida = DateTime.ParseExact(data_aula_errado, "dd/MM/yyyy", null);
                string data_aula = dataConvertida.ToString("yyyy-MM-dd");

                MySqlConnection conexao2 = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
                conexao2.Open();
                string alterar = "UPDATE aulas SET aulas.data_aula = '" + data_aula + "', aulas.horario = '" + hora_aula + "'," +
                        " aulas.curso = '" + curso + "', aulas.tema = '" + tema + "', aulas.prof1 = '" + prof1 + "', aulas.prof2 = '" + prof2 + "' WHERE aulas.aulaId = " + id_aula;
                MySqlCommand comandos = new MySqlCommand(alterar, conexao2);

                comandos.ExecuteNonQuery();

                AulaEditar aulaEdit = new AulaEditar(permissao, id_usuario);
                aulaEdit.Show();
                this.Close();
             }
        }
    }
}
