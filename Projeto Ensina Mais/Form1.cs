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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD =;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string codFunc = textBox1.Text;
            string senha = textBox2.Text;

            
                using (conn)
                {
                    try
                    {
                      

                        // Query SQL para verificar os campos e obter a permissão
                        string query = "SELECT permissao FROM usuario WHERE codFunc = @codFunc AND senha = @senha";

                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            // Adiciona parâmetros para evitar SQL Injection
                            command.Parameters.AddWithValue("@codFunc", codFunc);
                            command.Parameters.AddWithValue("@senha", senha);

                            // Executa a consulta e obtém a permissão
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                string permissao = result.ToString().Trim();

                                // Valida se a permissão é de 3 caracteres
                                if (permissao.Length == 3 && (permissao == "pro" || permissao == "sec" || permissao == "adm"))
                                {
                                    // Abre a tela inicial e passa a permissão
                                    tela_inicial telaInicial = new tela_inicial(permissao);
                                    telaInicial.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Permissão inválida no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        }
 
