using Microsoft.Office.Core;
using MySql.Data.MySqlClient;
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
    public partial class AlunoExcluir : Form
    {
        public string permissao, id_usuario, id_aluno, id_matricula, id_responsavel;

        private void button1_Click(object sender, EventArgs e)
        {
            string nome_responsavel = textBox2.Text;
            string hora = textBox12.Text;

            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {

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

                // Conectando no Banco de Dados

                MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =");
                conexao.Open();

                MySqlCommand deletar = new MySqlCommand();
                deletar.Connection = conexao;
                deletar.CommandText = "DELETE FROM mat_aluno WHERE mat_aluno.FK_aluno_alunoId = " + id_aluno + ";" +
                    "\r\nDELETE FROM respaluno WHERE respaluno.FK_aluno_alunoId = " + id_aluno + ";" +
                    "\r\nDELETE FROM mat_usuario WHERE mat_usuario.FK_matricula_matId = " + id_matricula + ";" +
                    "\r\nDELETE FROM aluno WHERE aluno.alunoId = " + id_aluno + ";" +
                    "\r\nDELETE FROM responsavel WHERE responsavel.respId = " + id_responsavel + ";" +
                    "\r\nDELETE FROM matricula WHERE matricula.matId = " + id_matricula + "";
                MySqlDataReader resultado = deletar.ExecuteReader();
                conexao.Close();

                //Confirmando exclusão para o usuário

                MessageBox.Show("Informações apagadas com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AlunoEditar alunoEdit = new AlunoEditar(permissao, id_usuario);
                alunoEdit.Show();
                this.Close();

            }

        }

            private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }

        public AlunoExcluir(string permissao, string id_usuario, string id_aluno)
        {
            InitializeComponent();

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            this.permissao = permissao;
            this.id_usuario = id_usuario;
            this.id_aluno = id_aluno;

            string caminhoNoServidor;

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
                    textBox4.Text = resultado["data_nasc"].ToString();
                    textBox7.Text = resultado["rg"].ToString();
                    textBox8.Text = resultado["data_mat"].ToString();
                    caminhoNoServidor = resultado["pfp"].ToString();
                    textBox2.Text = resultado["nome1"].ToString();
                    textBox3.Text = resultado["email1"].ToString();
                    textBox9.Text = resultado["cpf1"].ToString();
                    textBox10.Text = resultado["tel1"].ToString();
                    textBox11.Text = resultado["tel2"].ToString();
                    textBox12.Text = resultado["hora"].ToString();
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
