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
    public partial class AulaAlterar : Form
    {
        public string permissao, id_usuario, id_aula;
        public AulaAlterar(string permissao, string id_usuario, string id_aula)
        {
            InitializeComponent();

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            this.permissao = permissao;
            this.id_usuario = id_usuario;
            this.id_aula = id_aula;

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
            conexao.Open();

            // Consulta para preencher a comboBox1 com os nomes dos cursos
            MySqlCommand cmdCursos = new MySqlCommand("SELECT nome FROM curso", conexao);
            MySqlDataReader resultadoCursos = cmdCursos.ExecuteReader();
            while (resultadoCursos.Read())
            {
                comboBox1.Items.Add(resultadoCursos["nome"].ToString());
            }
            resultadoCursos.Close();

            // Consulta para preencher a comboBox2 e comboBox3 com os nomes dos usuários com permissão 'pro'
            MySqlCommand cmdUsuarios = new MySqlCommand("SELECT nome FROM usuario WHERE permissao = 'pro'", conexao);
            MySqlDataReader resultadoUsuarios = cmdUsuarios.ExecuteReader();
            while (resultadoUsuarios.Read())
            {
                comboBox2.Items.Add(resultadoUsuarios["nome"].ToString());
                comboBox3.Items.Add(resultadoUsuarios["nome"].ToString());
            }
            resultadoUsuarios.Close();

            // Primeiro, consulta para pegar o nome do curso usando o cursoId da tabela aula
            MySqlCommand cmdCurso = new MySqlCommand("SELECT nome FROM curso WHERE cursoId = (SELECT FK_curso_cursoId FROM aula WHERE aulaId = @aulaId)", conexao);
            cmdCurso.Parameters.AddWithValue("@aulaId", id_aula);

            // Usando ExecuteScalar para pegar o nome do curso
            object cursoResult = cmdCurso.ExecuteScalar();

            // Verificando se o valor retornado é nulo
            string nomeCurso = string.Empty;
            if (cursoResult != null)
            {
                nomeCurso = cursoResult.ToString();
            }
            else
            {
                MessageBox.Show("Curso não encontrado para o ID da aula fornecido.");
                conexao.Close();
                return; // Finaliza o processo, já que o curso não foi encontrado
            }

            // Agora consulta para pegar os dados da aula
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT * FROM aula WHERE aulaId = @aulaId";
            consulta.Parameters.AddWithValue("@aulaId", id_aula);

            MySqlDataReader resultado = consulta.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    // Preenche o ComboBox1 com o nome do curso
                    comboBox1.Text = nomeCurso;

                    // Preenche os outros campos com os dados da tabela 'aula'
                    textBox1.Text = resultado["aulaId"].ToString();
                    dateTimePicker1.Text = resultado["data_aula"].ToString();
                    dateTimePicker3.Text = resultado["horario"].ToString();
                    textBox3.Text = resultado["tema"].ToString();

                    // Tenta preencher o NumericUpDown com o valor de 'numero_aula'
                    if (decimal.TryParse(resultado["numero_aula"].ToString(), out decimal numeroAula))
                    {
                        numericUpDown1.Value = numeroAula;
                    }
                    else
                    {
                        MessageBox.Show("O valor de 'numero_aula' não é válido para o NumericUpDown.");
                    }

                    comboBox2.Text = resultado["prof1"].ToString();
                    comboBox3.Text = resultado["prof2"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado");
            }
            resultado.Close();
            conexao.Close();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja alterar as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                // Dados do formulário
                string data_aula_errado = dateTimePicker1.Text;
                string hora_aula = dateTimePicker3.Text;
                string cursoNome = comboBox1.Text; // Nome do curso
                string tema = textBox3.Text;
                string numero_aula = Convert.ToString(numericUpDown1.Value);
                string prof1 = comboBox2.Text;
                string prof2 = comboBox3.Text;

              
                DateTime dataConvertida = DateTime.ParseExact(data_aula_errado, "dd/MM/yyyy", null);
                string data_aula = dataConvertida.ToString("yyyy-MM-dd");

               
                MySqlConnection conexao2 = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD = ; Allow Zero Datetime=True; Convert Zero Datetime=True;");
                conexao2.Open();

                MySqlCommand cmdCurso = new MySqlCommand("SELECT cursoId FROM curso WHERE nome = @nomeCurso", conexao2);
                cmdCurso.Parameters.AddWithValue("@nomeCurso", cursoNome);
                object cursoIdResult = cmdCurso.ExecuteScalar();

                if (cursoIdResult == null)
                {
                    MessageBox.Show("Curso não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao2.Close();
                    return; 
                }

                int cursoId = Convert.ToInt32(cursoIdResult);

                string alterar = "UPDATE aula SET aula.data_aula = @dataAula, aula.horario = @horaAula, " +
                                 "aula.FK_curso_cursoId = @cursoId, aula.tema = @tema, aula.prof1 = @prof1, aula.prof2 = @prof2 " +
                                 "WHERE aula.aulaId = @aulaId";

                MySqlCommand comandos = new MySqlCommand(alterar, conexao2);
                comandos.Parameters.AddWithValue("@dataAula", data_aula);
                comandos.Parameters.AddWithValue("@horaAula", hora_aula);
                comandos.Parameters.AddWithValue("@cursoId", cursoId);
                comandos.Parameters.AddWithValue("@tema", tema);
                comandos.Parameters.AddWithValue("@prof1", prof1);
                comandos.Parameters.AddWithValue("@prof2", prof2);
                comandos.Parameters.AddWithValue("@aulaId", id_aula); 

                comandos.ExecuteNonQuery();

                conexao2.Close();

                AulaEditar aulaEdit = new AulaEditar(permissao, id_usuario);
                aulaEdit.Show();
                this.Close();
            }
        }

    }
}
