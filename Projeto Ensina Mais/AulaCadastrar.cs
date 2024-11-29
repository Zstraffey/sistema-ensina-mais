using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Ensina_Mais
{
    
    public partial class AulaCadastrar : Form
    {
        public string permissao, id_usuario;
        public AulaCadastrar(string permissao, string id_usuario)
        {
            InitializeComponent();
            this.permissao = permissao;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            dateTimePicker3.CustomFormat = "'hh:mm'";
            this.id_usuario = id_usuario;

            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=ensina_mais; UID= root ; PASSWORD = ; ");
            using (conexao)
            {
                try
                {
                    // Abrir a conexão
                    conexao.Open();

                    // Preencher ComboBox1 com nomes dos cursos
                    string query1 = "SELECT nome FROM curso";
                    MySqlCommand comando1 = new MySqlCommand(query1, conexao);
                    MySqlDataReader leitor1 = comando1.ExecuteReader();

                    while (leitor1.Read())
                    {
                        comboBox1.Items.Add(leitor1["nome"].ToString());
                    }
                    leitor1.Close();

                    // Preencher ComboBox2 e ComboBox3 com usuários de permissao 'pro'
                    string query2 = "SELECT nome FROM usuario WHERE permissao = 'pro'";
                    MySqlCommand comando2 = new MySqlCommand(query2, conexao);
                    MySqlDataReader leitor2 = comando2.ExecuteReader();

                    while (leitor2.Read())
                    {
                        comboBox2.Items.Add(leitor2["nome"].ToString());
                        comboBox3.Items.Add(leitor2["nome"].ToString());
                    }
                    leitor2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}");
                }
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

            string data_aula_errado = dateTimePicker1.Text;
            string hora_aula = dateTimePicker3.Text;
            string curso = comboBox1.Text;
            string tema = textBox3.Text;
            string numero_aula = Convert.ToString(numericUpDown1.Value);
            string prof1 = comboBox2.Text;
            string prof2 = comboBox3.Text;

            DateTime dataConvertida = DateTime.ParseExact(data_aula_errado, "dd/MM/yyyy", null);
            string data_aula = dataConvertida.ToString("yyyy-MM-dd");

            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=ensina_mais; UID= root ; PASSWORD = ; ");

            using (conexao)
            {
                conexao.Open();

                // Obter ID do curso
                string id_curso = "";
                string pegaid = "SELECT cursoId FROM curso WHERE nome = @curso";
                using (MySqlCommand cmd = new MySqlCommand(pegaid, conexao))
                {
                    cmd.Parameters.AddWithValue("@curso", curso);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            id_curso = reader["cursoId"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum curso encontrado com o nome: " + curso);
                            return;
                        }
                    }
                }

                // Inserir a aula
                string inserir = "INSERT INTO aula (data_aula, horario, tema, numero_aula, prof1, prof2, FK_usuario_userId, FK_curso_cursoId) " +
                                 "VALUES (@data_aula, @horario, @tema, @numero_aula, @prof1, @prof2, @id_usuario, @id_curso);";

                using (MySqlCommand comandos = new MySqlCommand(inserir, conexao))
                {
                    comandos.Parameters.AddWithValue("@data_aula", data_aula);
                    comandos.Parameters.AddWithValue("@horario", hora_aula);
                    comandos.Parameters.AddWithValue("@tema", tema);
                    comandos.Parameters.AddWithValue("@numero_aula", numero_aula);
                    comandos.Parameters.AddWithValue("@prof1", prof1);
                    comandos.Parameters.AddWithValue("@prof2", prof2);
                    comandos.Parameters.AddWithValue("@id_usuario", id_usuario);
                    comandos.Parameters.AddWithValue("@id_curso", id_curso);

                    comandos.ExecuteNonQuery();
                }

                // Limpar os campos
                dateTimePicker1.Text = "";
                dateTimePicker3.Text = "";
                comboBox1.Text = "";
                textBox3.Text = "";
                numericUpDown1.Value = 0;
                comboBox2.Text = "";
                comboBox3.Text = "";

                MessageBox.Show("Aula cadastrada com sucesso!");
            }
        }
    }
}
