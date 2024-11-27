using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Ensina_Mais
{
    
    public partial class AulaCadastrar : Form
    {
        public string permissao, id_usuario;
        public AulaCadastrar(string permissao, string id_usuario)
        {
            InitializeComponent();
            this.permissao = permissao;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            dateTimePicker3.CustomFormat = "'hh:mm'";
            this.id_usuario = id_usuario;
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tela_inicial tela_inicial = new tela_inicial(permissao, id_usuario);
            tela_inicial.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string data_aula_errado = dateTimePicker1.Text;
            string hora_aula = dateTimePicker3.Text;
            string curso = comboBox1.Text;
            string tema = textBox3.Text;
            string numero_aula = Convert.ToString(numericUpDown1.Value);
            string prof1 = comboBox2.Text;
            string prof2 = comboBox3.Text;

            DateTime dataConvertida = DateTime.ParseExact(data_aula_errado, "dd/MM/yyyy", null);
            string data_aula = dataConvertida.ToString("yyyy-MM-dd");

            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=ensina_mais; UID= root ; PASSWORD = ; ");
            conexao.Open();

            string inserir = "INSERT INTO aulas(data_aula, horario, curso, tema, numero_aula, prof1, prof2) values('" + data_aula + "','" + hora_aula + "','" + curso + "','" + tema + "','" + numero_aula + "','" + prof1 + "','" + prof2 + "');";
            MySqlCommand comandos = new MySqlCommand(inserir, conexao);

            comandos.ExecuteNonQuery();

            dateTimePicker1.Text = "";
            dateTimePicker3.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = 0;
            comboBox2.Text = "";
            comboBox3.Text = "";

            MessageBox.Show("Aula cadastrada com Sucesso!!!");
        }
    }
}
