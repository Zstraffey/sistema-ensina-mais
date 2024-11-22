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

            using (conn)
            {
                try
                {
                    

                    // Query SQL para verificar os campos
                    string query = "SELECT COUNT(*) FROM usuario WHERE codFunc = @codFunc AND senha = @senha";

                    string query2 = "SELECT permissao FROM usuario WHERE codFunc = @codFunc AND senha = @senha";

                    MySqlCommand comando = new MySqlCommand(query2, conn);

                    string permissao2 = Convert.ToString(comando.ExecuteNonQuery());

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        // Adiciona parâmetros para evitar SQL Injection
                        command.Parameters.AddWithValue("@codFunc", textBox1.Text);
                        command.Parameters.AddWithValue("@senha", textBox2.Text);

                        // Executa a consulta
                        int result = Convert.ToInt32(command.ExecuteScalar());

                        if (result != null)
                        {
                            string permissao = result.ToString();

                            // Verifica o tipo de permissão e abre a janela apropriada
                            tela_inicial telaInicial = new tela_inicial(permissao, permissao2);
                            telaInicial.Show();
                            this.Hide();
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
