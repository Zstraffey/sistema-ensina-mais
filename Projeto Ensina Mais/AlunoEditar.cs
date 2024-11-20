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
    public partial class AlunoEditar : Form
    {
        public AlunoEditar()
        {
            InitializeComponent();


            // Conectando no Banco de Dados
            string cmdconexao = "SERVER=localhost;DATABASE=escola;UID=root;PASSWORD =; Allow Zero Datetime=True;Convert Zero Datetime=True;";

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
            consulta.CommandText = "SELECT * FROM aluno";

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

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Editar";
            btn.Text = "Editar";
            btn.Name = "btnAlterar";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.HeaderText = "Excluir";
            btn2.Text = "Excluir";
            btn2.Name = "btnExcluir";
            btn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn2);

            conexao.Close();
        }

        private void AlunoEditar_Load(object sender, EventArgs e)
        {

        }
    }
}
