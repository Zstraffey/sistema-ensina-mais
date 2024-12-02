using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OOP_Teste
{
    public partial class formCadastro : Form
    {
        string tipo = "";
        string[] campos = { };
        string[] tipos = { };
        caixaTexto[] caixas = { };

        string[] nomesAluno = { "Nome" };
        string[] nomesUsuario = { "Senha", "Permissão", "Nome", "Data de Nascimento", "Pagamento", "CPF", "RG", "Telefone", "Email", "Foto de Perfil" };
        string[] nomesProduto = { "Nome", "Descrição", "Preço", "Quantidade", "Data de Aquisição", "Foto do Produto" };

        public formCadastro(string _tipo)
        {
            InitializeComponent();

            tipo = _tipo;
            label1.Text = "Cadastrar " + tipo;

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=");
            conexao.Open();

            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT column_name FROM information_schema.columns WHERE table_name = '"+tipo+"' AND table_schema = 'ensina_mais';";

            MySqlDataReader resultado = consulta.ExecuteReader();
            int y = -1;

            while (resultado.Read())
            {
                y += 1;
            }

            campos = new string[y];
            tipos = new string[y];
            conexao.Close();
            conexao.Open();

            consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT column_name FROM information_schema.columns WHERE table_name = '" + tipo + "' AND table_schema = 'ensina_mais';";

            resultado = consulta.ExecuteReader();
            y = 0;

            while (resultado.Read())
            {
                if (y > 0)
                {
                    campos[y-1] = resultado[0].ToString();
                }
                
                y += 1;
            }

            conexao.Close();
            conexao.Open();

            consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT data_type FROM information_schema.columns WHERE table_name = '" + tipo + "' AND table_schema = 'ensina_mais';";

            resultado = consulta.ExecuteReader();
            y = 0;

            while (resultado.Read())
            {
                if (y > 0)
                {
                    tipos[y-1] = resultado[0].ToString();
                    //MessageBox.Show(resultado[0].ToString());
                }
                y += 1;
            }

            caixas = new caixaTexto[campos.Length];

            this.Size = new Size(this.Size.Width, 125 + (60 * campos.Length) + (button1.Size.Height) + (50));
            button1.Location = new Point(45, this.Size.Height - button1.Size.Height - 60);

            for (int x = 0; x < campos.Length; x++)
            {
                caixaTexto objeto = new caixaTexto();

                if (tipos[x] == "varchar" || tipos[x] == "int" || tipos[x] == "float")
                {
                    this.Controls.Add(objeto.caixa);
                }
                else if (tipos[x] == "date") 
                {
                    this.Controls.Add(objeto.date);
                }
                else if (tipos[x] == "blob")
                {
                    this.Controls.Add(objeto.button);
                    this.Controls.Add(objeto.pfp);

                    void buttonClick(object sender, EventArgs e) 
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string caminhoDaImagem = openFileDialog.FileName;

                            byte[] imagemBytes = ConverterImagemParaBytes(caminhoDaImagem);
                            objeto.pfp.Image = Image.FromFile(caminhoDaImagem);

                            objeto.conversaoBytes = imagemBytes;
                        }
                    }

                    objeto.button.Click += buttonClick;
                }

                this.Controls.Add(objeto.texto);

                string nome;

                if (tipo == "curso")
                {
                    nome = nomesAluno[x];
                }
                else if (tipo == "usuario") 
                {
                    nome = nomesUsuario[x];
                }
                else
                {
                    nome = nomesProduto[x];
                }

                objeto.inicializar(nome, x, tipos[x]);
                caixas[x] = objeto;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comando = "INSERT INTO " + tipo.ToLower() + "(";

            byte[] conversaoBytes = null;

            for (int x = 0; x < campos.Length; x++)
            {
                comando += x + 1 == campos.Length ? campos[x].ToLower() + ")" : campos[x].ToLower() + ", ";
            }
            comando += " VALUES('";

            for (int x = 0; x < campos.Length; x++)
            {
                string tipoCampo = "";

                if (tipos[x] == "varchar" || tipos[x] == "int" || tipos[x] == "float")
                {
                    tipoCampo = caixas[x].caixa.Text;
                }
                else if (tipos[x] == "date")
                {
                    tipoCampo = caixas[x].date.Value.Date.ToString("yyyy-MM-dd");
                    string[] conversao = tipoCampo.Split(' ');

                    tipoCampo = conversao[0];
                }
                else if (tipos[x] == "blob")
                {
                    conversaoBytes = caixas[x].conversaoBytes;
                }

                comando += x + 1 == campos.Length ? (tipos[x] == "blob" ? "@dadosImagem" + ");" : tipoCampo + "');") : tipos[x] == "blob" ? "@dadosImagem" + ", '" : tipoCampo + (tipos[x+1] == "blob" ? "', " : "', '");
            }

            //MessageBox.Show(comando);

            //MySqlConnection conexao = new MySqlConnection("SERVER=mysql3.serv00.com; DATABASE=m1012_sistema; UID=m1012_smaadmin; PASSWORD=!Sam12062024!;");
            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=");
            conexao.Open();

            MySqlCommand comandos = new MySqlCommand(comando, conexao);

            if (conversaoBytes != null) 
            {
                comandos.Parameters.Add("@dadosImagem", MySqlDbType.Blob).Value = conversaoBytes;
                //comandos.Parameters.AddWithValue("@dadosImagem", conversaoBytes);
            }

            comandos.ExecuteNonQuery();

            conexao.Close();

            MessageBox.Show(tipo+" cadastrado com sucesso!");

            for (int x = 0; x < campos.Length; x++)
            {
                caixas[x].caixa.Clear();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public static byte[] ConverterImagemParaBytes(string caminhoImagem)
        {
            return File.ReadAllBytes(caminhoImagem);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
