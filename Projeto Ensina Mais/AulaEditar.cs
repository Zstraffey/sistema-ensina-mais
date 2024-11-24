using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Ensina_Mais
{
    public partial class AulaEditar : Form
    {
        public string permissao, id_usuario;

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public AulaEditar(string permissao, string id_usuario)
        {
            InitializeComponent();

            this.id_usuario = id_usuario;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            this.permissao = permissao;

            // Conectando no Banco de Dados
            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =; Allow Zero Datetime=True;Convert Zero Datetime=True;";

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =;Allow Zero Datetime=True;Convert Zero Datetime=True;");
            conexao.Open();

            string comando = @" SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'ensina_mais' AND TABLE_NAME IN ('aluno', 'responsavel');";

            dataGridView1.Columns.Clear();

            try
            {
                using (var conexao2 = new MySqlConnection(cmdconexao))
                {
                    conexao2.Open();
                    MySqlCommand cmd = new MySqlCommand(comando, conexao2);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nomeDaColuna = reader["COLUMN_NAME"].ToString();
                        comboBox1.Items.Add(nomeDaColuna);
                        dataGridView1.Columns.Add(nomeDaColuna, nomeDaColuna);
                    }

                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }

            // Comando para Consultar

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT * FROM aulas";

            // Operando com o dataGridView

            dataGridView1.Rows.Clear();

            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)

            {
                while (resultado.Read())
                {

                    dataGridView1.Rows.Add(resultado["aulaId"].ToString(),
                    resultado["data_aula"].ToString(),
                    resultado["horario"].ToString(),
                    resultado["curso"].ToString(),
                    resultado["tema"].ToString(),
                    resultado["numero_aula"].ToString(),
                    resultado["prof1"].ToString(),
                    resultado["prof2"].ToString()
                    );

                }

            }

            else
            {

                MessageBox.Show("Nenhum registro foi encontrado");

            }

            conexao.Close();
        }
    }
}
