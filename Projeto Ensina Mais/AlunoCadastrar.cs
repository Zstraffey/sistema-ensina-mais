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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Ensina_Mais
{
    public partial class AlunoCadastrar : Form
    {
        public string permissao, id_usuario;
        string caminhoNoServidor;
        string nomeArquivo;

        public AlunoCadastrar(string permissao, string id_usuario)
        {
            InitializeComponent();

            this.permissao = permissao;

            dateTimePicker3.CustomFormat = "'hh:mm'";
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.id_usuario = id_usuario;

            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =;";

            string comando = @"SELECT nome FROM curso";

            try
            {
                using (var conexao2 = new MySqlConnection(cmdconexao))
                {
                    conexao2.Open();
                    MySqlCommand cmd = new MySqlCommand(comando, conexao2);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nomeDaColuna = reader["nome"].ToString();
                        comboBox1.Items.Add(nomeDaColuna);
                    }

                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            string nome = textBox1.Text;
            string data_nasc_errado = dateTimePicker1.Text;
            string rg = maskedTextBox1.Text;
            string data_mat_errado = dateTimePicker2.Text;
            string nome_responsavel = textBox2.Text;
            string email_responsavel = textBox3.Text;
            string cpf_responsavel = maskedTextBox2.Text;
            string contato_resp_1 = maskedTextBox3.Text;
            string contato_resp_2 = maskedTextBox4.Text;
            string valor = textBox6.Text.Replace("R$", "").Replace(",", ".").Trim();
            string hora = dateTimePicker3.Text;
            string curso = comboBox1.Text;

            DateTime dataConvertida = DateTime.ParseExact(data_nasc_errado, "dd/MM/yyyy", null);
            string data_nasc = dataConvertida.ToString("yyyy-MM-dd");

            DateTime dataConvertida2 = DateTime.ParseExact(data_mat_errado, "dd/MM/yyyy", null);
            string data_mat = dataConvertida2.ToString("yyyy-MM-dd");

            caminhoNoServidor = caminhoNoServidor.Replace(@"\", "+");

            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=ensina_mais; UID= root ; PASSWORD = ; ");//indica o caminho e dados do banco
            conexao.Open();//abrindo o banco

            // Insere no Aluno

            string inserir = "INSERT INTO aluno(pfp, nome, data_nasc, rg, data_mat) values('" + caminhoNoServidor + "','" + nome + "','" + data_nasc + "','" + rg + "','" + data_mat + "');";
            MySqlCommand comandos = new MySqlCommand(inserir, conexao);

            // Insere no Responsavel

            string inserir2 = "INSERT INTO responsavel(nome1, email1, cpf1, tel1, tel2) values('" + nome_responsavel + "','" + email_responsavel + "','" + cpf_responsavel + "','" + contato_resp_1 + "','" + contato_resp_2 + "');";
            MySqlCommand comandos2 = new MySqlCommand(inserir2, conexao);

            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=;";

            string id_responsavel = "";
            string id_aluno = "";
            string id_curso = "";

            comandos.ExecuteNonQuery();

            comandos2.ExecuteNonQuery();

            try
            {
                using (var conexao1 = new MySqlConnection(cmdconexao))
                {
                    conexao1.Open();

                    // Obter id_responsavel
                    string pegaid = "SELECT respId FROM responsavel WHERE responsavel.nome1 = @nome_responsavel";
                    using (var cmd = new MySqlCommand(pegaid, conexao1))
                    {
                        cmd.Parameters.AddWithValue("@nome_responsavel", nome_responsavel);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                id_responsavel = reader["respId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum responsável encontrado para o nome: " + nome_responsavel);
                            }
                        }
                    }

                    // Obter id_aluno
                    string pegaid2 = "SELECT alunoId FROM aluno WHERE aluno.nome = @nome";
                    using (var cmd = new MySqlCommand(pegaid2, conexao1))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                id_aluno = reader["alunoId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum aluno encontrado para o nome: " + nome);
                            }
                        }
                    }

                    string pegaid3 = "SELECT cursoId FROM curso WHERE curso.nome LIKE '%"+ curso +"%'";
                    using (var cmd = new MySqlCommand(pegaid3, conexao1))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                id_curso = reader["cursoId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum curso encontrada para o curso: " + curso);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }

            // Cadastrando relação de responsável / aluno

            string inserir4 = "INSERT INTO respaluno(fk_Aluno_alunoId, fk_Responsavel_respId) values('" + id_aluno + "','" + id_responsavel + "');";
            MySqlCommand comandos4 = new MySqlCommand(inserir4, conexao);

            comandos4.ExecuteNonQuery();

            // Insere na Matricula

            string inserir3 = "INSERT INTO matricula(data_mat, hora, valor, FK_aluno_alunoId, FK_usuario_userId, FK_curso_cursoId) values('" + data_mat + "','" + hora + "','" + valor + "'," + id_aluno + "," + id_usuario + "," + id_curso + ");";
            MySqlCommand comandos3 = new MySqlCommand(inserir3, conexao);

            comandos3.ExecuteNonQuery();

            conexao.Close(); //fechando a conexão com o banco de dados

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBox1.Text = "";
            dateTimePicker3.Text = DateTime.Now.ToString("HH:mm:ss");
            pictureBox1.Image = null;

            MessageBox.Show("Aluno cadastrado com Sucesso!!!");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDaImagem = openFileDialog.FileName;

                string pastaDestino = @"C:\Users\Familia Costa\source\repos\Zstraffey\sistema-ensina-mais\Projeto Ensina Mais\Imagens\alunos\";

                nomeArquivo = Path.GetFileName(caminhoDaImagem);
                caminhoNoServidor = Path.Combine(pastaDestino, nomeArquivo);

                try
                {
                    File.Copy(caminhoDaImagem, caminhoNoServidor);
                }
                catch
                {
                    MessageBox.Show("Essa imagem já existe");
                }

                pictureBox1.Image = Image.FromFile(caminhoDaImagem);

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }
    }
}
