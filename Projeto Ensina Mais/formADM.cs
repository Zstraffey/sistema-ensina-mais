using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OOP_Teste
{
    public partial class formADM: Form
    {
        //Dictionary<string, string[]> tabelas = new Dictionary<string, string[]>();

        public formADM()
        {
            InitializeComponent();

            /*MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=");
            conexao.Open();

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'ensina_mais'";

            MySqlDataReader resultado = consulta.ExecuteReader();

            while (resultado.Read())
            {
                comboBox1.Items.Add(resultado[0].ToString());
            }

            conexao.Close();*/

            //string[] row1 = new string[]{"Meatloaf", "Main Dish", "oxi", "eba"};
            //string[] row2 = new string[]{"Key Lime Pie",
            //"Dessert", "lime juice, evaporated milk", "****"};
            //string[] row3 = new string[]{"Orange-Salsa Pork Chops",
            //"Main Dish", "pork chops, salsa, orange juice", "****"};
            //string[] row4 = new string[]{"Black Bean and Rice Salad",
            //"Salad", "black beans, brown rice", "****"};
            //string[] row5 = new string[]{"Chocolate Cheesecake",
            //"Dessert", "cream cheese", "***"};
         
            //string[] row6 = new string[]{"Black Bean Dip", "Appetizer",
            //"black beans, sour cream", "***"};
            //object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

            //foreach (string[] rowArray in rows)
            //{
            //    dataGridView1.Rows.Add(rowArray);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecione uma tabela");
            }
            else 
            { 
                formCadastro formulario = new formCadastro(comboBox1.Text.ToLower());
                formulario.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecione uma tabela");
            }
            else
            {
                formVisualizar formulario = new formVisualizar(comboBox1.Text.ToLower());
                formulario.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
