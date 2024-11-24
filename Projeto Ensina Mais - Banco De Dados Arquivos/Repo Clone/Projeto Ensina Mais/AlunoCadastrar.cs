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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Ensina_Mais
{
    public partial class AlunoCadastrar : Form
    {
        string caminhoNoServidor;
        string nomeArquivo;

        public AlunoCadastrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nome = textBox1.Text;
            string data_nasc = dateTimePicker1.Text;
            string rg = maskedTextBox1.Text;
            string data_mat = dateTimePicker2.Text;
            string nome_responsavel = textBox2.Text;
            string email_responsavel = textBox3.Text;
            string cpf_responsavel = maskedTextBox2.Text;
            string contato_resp_1 = maskedTextBox3.Text;
            string contato_resp_2 = maskedTextBox4.Text;

            caminhoNoServidor = caminhoNoServidor.Replace(@"\", "+");

            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=ensina_mais; UID= root ; PASSWORD = ; ");//indica o caminho e dados do banco
            conexao.Open();//abrindo o banco

            // Shiiiuuu grita baixo nengue, eu sei que tá feio mas funciona, melhor assim do que fazer cod no banco

            string inserir = "INSERT INTO aluno(pfp, nome, data_nasc, rg, data_mat) values('" + caminhoNoServidor + "','" + nome + "','" + data_nasc + "','" + rg + "','" + data_mat + "');";
            MySqlCommand comandos = new MySqlCommand(inserir, conexao);

            string inserir2 = "INSERT INTO responsavel(nome1, email1, cpf1, tel1, tel2) values('" + nome_responsavel + "','" + email_responsavel + "','" + cpf_responsavel + "','" + contato_resp_1 + "','" + contato_resp_2 + "');";
            MySqlCommand comandos2 = new MySqlCommand(inserir2, conexao);

            comandos.ExecuteNonQuery();

            comandos2.ExecuteNonQuery();

            conexao.Close(); //fechando a conexão com o banco de dados

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
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

                string pastaDestino = @"C:\Users\Familia Costa\Desktop\Projeto Ensina Mais\Imagens";
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
    }
}
