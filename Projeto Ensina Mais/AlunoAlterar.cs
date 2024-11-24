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
        public string permissao, id_usuario;
        string caminhoNoServidor, nomeArquivo;

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
            this.permissao = permissao;
            this.id_usuario = id_usuario;

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
                    textBox2.Text = resultado["nome"].ToString();
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
