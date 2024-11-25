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
using OOP_Teste;

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
        
            string cmdconexao = "SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=;";

            string id_usuario = "";

            try
            {
                using (var conexao1 = new MySqlConnection(cmdconexao))
                {
                    conexao1.Open();

                    
                    string pegaid = "SELECT usuario.userId FROM usuario WHERE usuario.codFunc = @codFunc;";
                    using (var cmd = new MySqlCommand(pegaid, conexao1))
                    {
                        cmd.Parameters.AddWithValue("@codFunc", codFunc);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                id_usuario = reader["userId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum usuário encontrado para o código: " + codFunc);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }


            using (conn)
                {
                    try
                    {
                      

                        
                        string query = "SELECT permissao FROM usuario WHERE codFunc = @codFunc AND senha = @senha";

                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            
                            command.Parameters.AddWithValue("@codFunc", codFunc);
                            command.Parameters.AddWithValue("@senha", senha);

                            
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                string permissao = result.ToString().Trim();

                                
                                if (permissao.Length == 3 && (permissao == "pro" || permissao == "sec" || permissao == "adm"))
                                {
                                    
                                    tela_inicial telaInicial = new tela_inicial(permissao, id_usuario);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
        }
 
