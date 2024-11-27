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
    public partial class AlunoAlterar : Form
    {
        public string permissao, id_usuario, id_aluno, id_responsavel, id_matricula;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }

        string caminhoNoServidor, nomeArquivo;

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja alterar as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
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
                string curso = textBox5.Text;
                string valor = textBox6.Text.Replace("R$", "").Replace(",", ".").Trim();
                string hora = dateTimePicker3.Text;

                caminhoNoServidor = caminhoNoServidor.Replace(@"\", "+");

                DateTime dataConvertida = DateTime.ParseExact(data_nasc_errado, "dd/MM/yyyy", null);
                string data_nasc = dataConvertida.ToString("yyyy-MM-dd");

                DateTime dataConvertida2 = DateTime.ParseExact(data_mat_errado, "dd/MM/yyyy", null);
                string data_mat = dataConvertida2.ToString("yyyy-MM-dd");


                // Conectando no Banco de Dados

                MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =");
                MySqlConnection conexao2 = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =");
                MySqlConnection conexao3 = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =");
                conexao.Open();
                conexao2.Open();
                conexao3.Open();

                MySqlCommand alterar = new MySqlCommand();
                MySqlCommand alterar2 = new MySqlCommand();
                MySqlCommand alterar3 = new MySqlCommand();

                // alterar em aluno

                alterar.Connection = conexao;
                alterar.CommandText = "UPDATE aluno SET aluno.nome = '" + nome + "', aluno.data_nasc = '" + data_nasc + "'," +
                    " aluno.rg = '" + rg + "', aluno.data_mat = '" + data_mat + "', aluno.pfp = '" + caminhoNoServidor + "' WHERE aluno.alunoId = " + id_aluno;
                MySqlDataReader resultado = alterar.ExecuteReader();

                // alterar em responsável

                alterar2.Connection = conexao2;
                alterar2.CommandText = "UPDATE responsavel SET responsavel.nome1 = '" + nome_responsavel + "', responsavel.email1 = '" + email_responsavel + "', responsavel.cpf1 = '" + cpf_responsavel + "', responsavel.tel1 = '" + contato_resp_1 + "', responsavel.tel2 = '" + contato_resp_2 + "' WHERE responsavel.respId = " + id_responsavel;
                MySqlDataReader resultado2 = alterar2.ExecuteReader();

                // alterar em matrícula

                alterar3.Connection = conexao3;
                alterar3.CommandText = "UPDATE matricula SET matricula.data_mat = '" + data_mat + "', matricula.hora = '" + hora + "', matricula.curso = '" + curso + "', matricula.valor = '" + valor + "' WHERE matricula.matId = " + id_matricula;
                MySqlDataReader resultado3 = alterar3.ExecuteReader();

                conexao.Close();
                conexao2.Close();
                conexao3.Close();

                AlunoEditar alunoEdit = new AlunoEditar(permissao, id_usuario);
                alunoEdit.Show();
                this.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDaImagem = openFileDialog.FileName;

                string pastaDestino = @"C:\Users\Familia Costa\source\repos\Zstraffey\sistema-ensina-mais\Projeto Ensina Mais\Imagens\alunos\";

                MessageBox.Show(nomeArquivo);
                MessageBox.Show(caminhoNoServidor);

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

        public AlunoAlterar(string permissao, string id_usuario, string id_aluno)
        {
            InitializeComponent();

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            this.permissao = permissao;
            this.id_usuario = id_usuario;
            this.id_aluno = id_aluno;

            string nome_responsavel = "";
            string hora = "";

            MySqlConnection conexao2 = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=");
            conexao2.Open();

            MySqlCommand consulta2 = new MySqlCommand();
            consulta2.Connection = conexao2;
            consulta2.CommandText = "SELECT * FROM aluno WHERE aluno.alunoId =" + id_aluno;

            MySqlDataReader resultado2 = consulta2.ExecuteReader();

            if (resultado2.HasRows)
            {

                while (resultado2.Read())
                {
                    caminhoNoServidor = resultado2["pfp"].ToString().Replace("+", @"\");
                    pictureBox1.Image = Image.FromFile(resultado2["pfp"].ToString().Replace("+", @"\"));
                    break;
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado");
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            conexao2.Close();

            // Conectando no Banco de Dados

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
            conexao.Open();

            // Comando para Consultar

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT aluno.alunoId, aluno.nome, aluno.data_nasc, aluno.rg, aluno.data_mat, aluno.pfp, " +
                "responsavel.respId, responsavel.nome1, responsavel.email1, responsavel.cpf1, responsavel.tel1, responsavel.tel2, " +
                "matricula.hora, matricula.curso, matricula.valor" +
                "\r\nFROM aluno" +
                "\r\nINNER JOIN respaluno ON respaluno.fk_Aluno_alunoId = aluno.alunoId" +
                "\r\nINNER JOIN responsavel ON respaluno.fk_Responsavel_respId = responsavel.respId" +
                "\r\nINNER JOIN mat_aluno ON mat_aluno.fk_Aluno_alunoId = aluno.alunoId" +
                "\r\nINNER JOIN matricula ON matricula.matId = mat_aluno.fk_Matricula_matId" +
                "\r\nWHERE aluno.alunoId = " + id_aluno;

            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    textBox1.Text = resultado["nome"].ToString();
                    dateTimePicker1.Text = resultado["data_nasc"].ToString();
                    maskedTextBox1.Text = resultado["rg"].ToString();
                    dateTimePicker2.Text = resultado["data_mat"].ToString();
                    caminhoNoServidor = resultado["pfp"].ToString();
                    textBox2.Text = resultado["nome1"].ToString();
                    textBox3.Text = resultado["email1"].ToString();
                    maskedTextBox2.Text = resultado["cpf1"].ToString();
                    maskedTextBox3.Text = resultado["tel1"].ToString();
                    maskedTextBox4.Text = resultado["tel2"].ToString();
                    dateTimePicker3.Text = resultado["hora"].ToString();
                    textBox5.Text = resultado["curso"].ToString();
                    textBox6.Text = resultado["valor"].ToString();
                    nome_responsavel = resultado["nome1"].ToString();
                    hora = resultado["hora"].ToString();
                }

            }

            else
            {

                MessageBox.Show("Nenhum registro foi encontrado");

            }

            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=;";

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

                    // Obter id_matricula
                    string pegaid3 = "SELECT matId FROM matricula WHERE matricula.hora = @hora";
                    using (var cmd = new MySqlCommand(pegaid3, conexao1))
                    {
                        cmd.Parameters.AddWithValue("@hora", hora);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                id_matricula = reader["matId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma matrícula encontrada para a hora: " + hora);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }

            conexao.Close();

        }
    }
}
