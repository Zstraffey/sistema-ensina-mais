using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace OOP_Teste
{
    public partial class formVisualizar : Form
    {
        string tipo = "";
        string[] campos = { };
        public formVisualizar(string _tipo)
        {
            InitializeComponent();
            tipo = _tipo;

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=");
            conexao.Open();

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT column_name FROM information_schema.columns WHERE table_name = '" + tipo + "' AND table_schema = 'ensina_mais';";

            MySqlDataReader resultado = consulta.ExecuteReader();

            int y = 0;

            while (resultado.Read())
            {
                y += 1;
            }

            campos = new string[y];
            conexao.Close();

            conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=");
            conexao.Open();

            consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT column_name FROM information_schema.columns WHERE table_name = '" + tipo + "' AND table_schema = 'ensina_mais';";

            resultado = consulta.ExecuteReader();

            y = 0;
            while (resultado.Read())
            {
                campos[y] = resultado[0].ToString();
                y += 1;
            }

            dataGridView1.ColumnCount = 0;

            foreach (var item in campos)
            {
                dataGridView1.ColumnCount += 1;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name = campos[dataGridView1.ColumnCount - 1];
            }
            conexao.Close();
            conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=; Convert Zero Datetime=True");
            conexao.Open();

            consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT * FROM " + tipo;

            dataGridView1.Rows.Clear();
            resultado = consulta.ExecuteReader();

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Alterar Dados";
            buttonColumn.Text = "Alterar";
            buttonColumn.DefaultCellStyle.NullValue = "Alterar";
            buttonColumn.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns.Insert(dataGridView1.ColumnCount, buttonColumn);

            buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Excluir Dados";
            buttonColumn.Text = "Excluir";
            buttonColumn.DefaultCellStyle.NullValue = "Excluir";
            buttonColumn.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns.Insert(dataGridView1.ColumnCount, buttonColumn);

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {

                    // Create a new row first as it will include the columns you've created at design-time.

                    int rowId = dataGridView1.Rows.Add();

                    // Grab the new row!
                    DataGridViewRow row = dataGridView1.Rows[rowId];

                    // Add the data

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

                    y = 0;
                    foreach (var item in campos)
                    {
                        row.Cells[item].Value = resultado[y].ToString();
                        y += 1;
                    }

                }
            }
            else
            {
                MessageBox.Show("Nenhum registro foi encontrado");
            }

            conexao.Close();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            string acharId = tipo == "aluno" ? "alunoId" : tipo == "usuário" ? "userId" : "prodId";

            string acharFoto = tipo == "aluno" ? "pfp" : tipo == "usuário" ? "pfp" : "foto";

            if (tipo != "curso") 
            { 
                using (MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD="))
                {
                    conexao.Open();

                    string comandoSQL = "SELECT " + acharFoto + " FROM " + tipo + " WHERE " + Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()) + " = " + acharId;

                    using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
                    {
                        byte[] imagemBytes = (byte[])comando.ExecuteScalar();

                        if (imagemBytes != null)
                        {
                            Image imagem = ConverterBytesParaImagem(imagemBytes);
                            pictureBox1.Image = imagem;
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma imagem encontrada com o ID especificado.");
                        }
                    }
                }
            }

        }

        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            formVisualizar novo = new formVisualizar(tipo);
            novo.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string acharId = tipo == "aluno" ? "alunoId" : tipo == "usuário" ? "userId" : "prodId";

            if (e.ColumnIndex == dataGridView1.Columns["Alterar Dados"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                formAlterar formulario = new formAlterar(tipo, row.Cells[0].Value.ToString());
                formulario.Show();

                formulario.FormClosed += form_Closed;
            }
            else
            {
                if (e.ColumnIndex == dataGridView1.Columns["Excluir Dados"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    DialogResult dialogResult = MessageBox.Show("Você quer mesmo apagar estes dados?", "Exclusão", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        MySqlConnection conexao = new MySqlConnection();
                        conexao.ConnectionString = ("SERVER=127.0.0.1; DATABASE=ensina_mais;UID = root; PASSWORD = ; ");
                        conexao.Open();

                        MySqlCommand consulta = new MySqlCommand();
                        consulta.Connection = conexao;
                        consulta.CommandText = "DELETE FROM " + tipo + " WHERE " + tipo + "." + acharId + " = " + row.Cells[0].Value.ToString();
                        MySqlDataReader resultado = consulta.ExecuteReader();

                        conexao.Close();

                        formVisualizar novo = new formVisualizar(tipo);
                        novo.Show();
                        this.Close();
                    }

                    // DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    //excluirflores formulario = new excluirflores(row.Cells[0].Value.ToString());
                    //formulario.Show();

                    //formulario.FormClosed += form_Closed;
                }
            }
        }

        public static Image ConverterBytesParaImagem(byte[] dadosImagem)
        {
            using (var ms = new MemoryStream(dadosImagem))
            {
                ms.Position = 0;
                return Image.FromStream(ms);
            }
        }

        private void formVisualizar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
