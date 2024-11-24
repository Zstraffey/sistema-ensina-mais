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
using static System.Net.Mime.MediaTypeNames;

namespace Projeto_Ensina_Mais
{
    public partial class AlunoEditar : Form
    {

        public string permissao, id_usuario;
        public AlunoEditar(string permissao, string id_usuario)
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
            consulta.CommandText = "SELECT aluno.alunoId, aluno.nome, aluno.data_nasc, aluno.rg, aluno.data_mat, aluno.pfp," +
                "responsavel.respId, responsavel.nome1, responsavel.email1, responsavel.cpf1, responsavel.tel1, responsavel.tel2 " +
                "FROM aluno, responsavel, respaluno " +
                "WHERE respaluno.fk_Aluno_alunoId = aluno.alunoId AND " +
                "respaluno.fk_Responsavel_respId = responsavel.respId;";

            // Operando com o dataGridView

            dataGridView1.Rows.Clear();

            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)

            {
                while (resultado.Read())
                {

                    dataGridView1.Rows.Add(resultado["alunoId"].ToString(),
                    resultado["nome"].ToString(),
                    resultado["data_nasc"].ToString(),
                    resultado["rg"].ToString(),
                    resultado["data_mat"].ToString(),
                    resultado["pfp"].ToString(),
                    resultado["respId"].ToString(),
                    resultado["nome1"].ToString(),
                    resultado["email1"].ToString(),
                    resultado["cpf1"].ToString(),
                    resultado["tel1"].ToString(),
                    resultado["tel2"].ToString()
                    );

                }

            }

            else
            {

                MessageBox.Show("Nenhum registro foi encontrado");

            }

            conexao.Close();
        }

        Microsoft.Office.Interop.Excel.Application XcellApp = new Microsoft.Office.Interop.Excel.Application();

        private void AlunoEditar_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlunoCadastrar cadAluno = new AlunoCadastrar(permissao, id_usuario);
            cadAluno.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                XcellApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcellApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcellApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                XcellApp.Columns.AutoFit();
                XcellApp.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id_aluno = textBox2.Text;

            AlunoAlterar altAluno = new AlunoAlterar(permissao, id_usuario, id_aluno);
            altAluno.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id_aluno = textBox2.Text;

            AlunoExcluir delAluno = new AlunoExcluir(permissao, id_usuario, id_aluno);
            delAluno.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string campo = Convert.ToString(comboBox1.Text);

            string nomecampo = Convert.ToString(textBox1.Text);

            if (nomecampo == "" || campo == "")
            {

                MessageBox.Show("Preencha o campo e sua informação para realizar a filtragem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                // Conectando no Banco de Dados

                MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =;Allow Zero Datetime=True;Convert Zero Datetime=True;");
                conexao.Open();

                // Filtragem

                MySqlCommand consulta = new MySqlCommand();
                consulta.Connection = conexao;
                consulta.CommandText = "";

                if (campo == "alunoId" || campo == "nome" || campo == "data_nasc" || campo == "rg" || campo == "data_mat" || campo == "pfp")
                {

                    consulta.CommandText = "SELECT aluno.alunoId, aluno.nome, aluno.data_nasc, aluno.rg, aluno.data_mat, aluno.pfp," +
                        "responsavel.respId, responsavel.nome1, responsavel.email1, responsavel.cpf1, responsavel.tel1, responsavel.tel2 " +
                        "FROM aluno, responsavel, respaluno " +
                        "WHERE respaluno.fk_Aluno_alunoId = aluno.alunoId AND " +
                        "respaluno.fk_Responsavel_respId = responsavel.respId AND aluno." + campo + " like '%" + nomecampo + "%'";

                }

                else if (campo == "respId" || campo == "nome1" || campo == "email1" || campo == "cpf1" || campo == "tel1" || campo == "tel2")
                {

                    consulta.CommandText = "SELECT aluno.alunoId, aluno.nome, aluno.data_nasc, aluno.rg, aluno.data_mat, aluno.pfp," +
                       "responsavel.respId, responsavel.nome1, responsavel.email1, responsavel.cpf1, responsavel.tel1, responsavel.tel2 " +
                       "FROM aluno, responsavel, respaluno " +
                       "WHERE respaluno.fk_Aluno_alunoId = aluno.alunoId AND " +
                       "respaluno.fk_Responsavel_respId = responsavel.respId AND responsavel." + campo + " like '%" + nomecampo + "%'";

                }

                dataGridView1.Rows.Clear();

                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {

                        dataGridView1.Rows.Add(resultado["alunoId"].ToString(),
                        resultado["nome"].ToString(),
                        resultado["data_nasc"].ToString(),
                        resultado["rg"].ToString(),
                        resultado["data_mat"].ToString(),
                        resultado["pfp"].ToString(),
                        resultado["respId"].ToString(),
                        resultado["nome1"].ToString(),
                        resultado["email1"].ToString(),
                        resultado["cpf1"].ToString(),
                        resultado["tel1"].ToString(),
                        resultado["tel2"].ToString()
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
}
