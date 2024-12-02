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
            string id_aula = textBox2.Text;

            AulaAlterar altAula = new AulaAlterar(permissao, id_usuario, id_aula);
            altAula.Show();
            this.Close();
        }

        public AulaEditar(string permissao, string id_usuario)
        {
            // Inicializando os componentes
            InitializeComponent();
            this.id_usuario = id_usuario;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.permissao = permissao;

            // String de conexão com o banco de dados
            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            MySqlConnection conexao = new MySqlConnection(cmdconexao);

            try
            {
                conexao.Open();

                // Consulta para buscar as colunas da tabela aula
                string comando = @"SELECT COLUMN_NAME 
                       FROM INFORMATION_SCHEMA.COLUMNS 
                       WHERE TABLE_SCHEMA = 'ensina_mais' AND TABLE_NAME = 'aula'";
                dataGridView1.Columns.Clear();

                using (var conexao2 = new MySqlConnection(cmdconexao))
                {
                    conexao2.Open();
                    MySqlCommand cmd = new MySqlCommand(comando, conexao2);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nomeDaColuna = reader["COLUMN_NAME"].ToString();

                        // Ignorar as colunas de chaves estrangeiras
                        if (nomeDaColuna == "FK_curso_cursoId" || nomeDaColuna == "FK_usuario_userId")
                            continue;

                        comboBox1.Items.Add(nomeDaColuna);
                        dataGridView1.Columns.Add(nomeDaColuna, nomeDaColuna);
                    }

                    // Adicionando manualmente a coluna para exibir o nome do curso
                    dataGridView1.Columns.Add("nome_curso", "Nome do Curso");

                    reader.Close();
                }

                // Consulta SQL para buscar os dados das tabelas
                string consultaSQL = @"SELECT a.aulaId, a.data_aula, a.horario, a.tema, 
                                  a.numero_aula, a.prof1, a.prof2, 
                                  c.nome AS nome_curso
                           FROM aula a
                           LEFT JOIN curso c ON a.FK_curso_cursoId = c.cursoId";

                MySqlCommand consulta = new MySqlCommand(consultaSQL, conexao);
                dataGridView1.Rows.Clear();

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        dataGridView1.Rows.Add(
                            resultado["aulaId"].ToString(),
                            resultado["data_aula"].ToString(),
                            resultado["horario"].ToString(),
                            resultado["tema"].ToString(),
                            resultado["numero_aula"].ToString(),
                            resultado["prof1"].ToString(),
                            resultado["prof2"].ToString(),
                            resultado["nome_curso"].ToString() // Nome do curso no lugar da chave estrangeira
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi encontrado");
                }

                resultado.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            AulaCadastrar cadAula = new AulaCadastrar(permissao, id_usuario);
            cadAula.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string campo = Convert.ToString(comboBox1.Text);
            string nomecampo = Convert.ToString(textBox1.Text);

            if (string.IsNullOrWhiteSpace(nomecampo) || string.IsNullOrWhiteSpace(campo))
            {
                MessageBox.Show("Preencha o campo e sua informação para realizar a filtragem.",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
               
                string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=;Allow Zero Datetime=True;Convert Zero Datetime=True;";
                MySqlConnection conexao = new MySqlConnection(cmdconexao);

                try
                {
                    conexao.Open();

                  
                    string consultaSQL;

                    if (campo == "nome_curso") 
                    {
                        consultaSQL = @"SELECT a.aulaId, a.data_aula, a.horario, a.tema, 
                                   a.numero_aula, a.prof1, a.prof2, 
                                   c.nome AS nome_curso
                            FROM aula a
                            LEFT JOIN curso c ON a.FK_curso_cursoId = c.cursoId
                            WHERE c.nome LIKE @nomecampo";
                    }
                    else 
                    {
                        consultaSQL = @"SELECT a.aulaId, a.data_aula, a.horario, a.tema, 
                                   a.numero_aula, a.prof1, a.prof2, 
                                   c.nome AS nome_curso
                            FROM aula a
                            LEFT JOIN curso c ON a.FK_curso_cursoId = c.cursoId
                            WHERE a." + campo + " LIKE @nomecampo";
                    }


                    MySqlCommand consulta = new MySqlCommand(consultaSQL, conexao);
                    consulta.Parameters.AddWithValue("@nomecampo", "%" + nomecampo + "%");

                    dataGridView1.Rows.Clear();

                    MySqlDataReader resultado = consulta.ExecuteReader();

                    if (resultado.HasRows)
                    {
                        while (resultado.Read())
                        {
                            dataGridView1.Rows.Add(
                                resultado["aulaId"].ToString(),
                                resultado["data_aula"].ToString(),
                                resultado["horario"].ToString(),
                                resultado["tema"].ToString(),
                                resultado["numero_aula"].ToString(),
                                resultado["prof1"].ToString(),
                                resultado["prof2"].ToString(),
                                resultado["nome_curso"].ToString() 
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro foi encontrado.",
                                        "Informação",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }

                    resultado.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro durante a filtragem: " + ex.Message,
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id_aula = textBox2.Text;

            AulaExcluir delAula = new AulaExcluir(permissao, id_usuario, id_aula);
            delAula.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            comboBox1.Text = "";
            textBox1.Text = "";


            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=;Allow Zero Datetime=True;Convert Zero Datetime=True;";
            MySqlConnection conexao = new MySqlConnection(cmdconexao);

            try
            {
                conexao.Open();


                string consultaSQL = @"SELECT a.aulaId, a.data_aula, a.horario, a.tema, 
                                      a.numero_aula, a.prof1, a.prof2, 
                                      c.nome AS nome_curso
                               FROM aula a
                               LEFT JOIN curso c ON a.FK_curso_cursoId = c.cursoId";

                MySqlCommand consulta = new MySqlCommand(consultaSQL, conexao);


                dataGridView1.Rows.Clear();


                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        
                        dataGridView1.Rows.Add(
                            resultado["aulaId"].ToString(),
                            resultado["data_aula"].ToString(),
                            resultado["horario"].ToString(),
                            resultado["tema"].ToString(),
                            resultado["numero_aula"].ToString(),
                            resultado["prof1"].ToString(),
                            resultado["prof2"].ToString(),
                            resultado["nome_curso"].ToString() 
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi encontrado.",
                                    "Informação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                resultado.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao recarregar os dados: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        Microsoft.Office.Interop.Excel.Application XcellApp = new Microsoft.Office.Interop.Excel.Application();

    }
}
