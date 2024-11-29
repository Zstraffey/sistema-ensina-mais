using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace OOP_Teste
{
    public partial class formAlterar : Form
    {
        string tipo = "";
        string id = "";
        string[] campos = { };
        string[] tipos = { };
        caixaTexto[] caixas = { };

        string[] nomesAluno = { "Nome" };
        string[] nomesUsuario = { "Senha", "Permissão", "Nome", "Data de Nascimento", "Pagamento", "CPF", "RG", "Telefone", "Email", "Foto de Perfil" };
        string[] nomesProduto = { "Nome", "Descrição", "Preço", "Quantidade", "Data de Aquisição", "Foto do Produto" };

        public formAlterar(string _tipo, string _id)
        {
            InitializeComponent();

            tipo = _tipo;
            id = _id;

            string acharId = tipo == "curso" ? "cursoId" : tipo == "usuário" ? "userId" : "prodId";

            label1.Text = "Alterar " + tipo + " (ID: "+_id+")";

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;DATABASE=ensina_mais;UID=root;PASSWORD=; Convert Zero Datetime=True");
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
            y  = 0;

            while (resultado.Read())
            {
                if (y > 0)
                {
                    tipos[y - 1] = resultado[0].ToString();
                    //MessageBox.Show(resultado[0].ToString());
                }
                y += 1;
            }

            caixas = new caixaTexto[campos.Length];

            this.Size = new Size(this.Size.Width, 125 + (60 * campos.Length) + (button1.Size.Height) + (50));
            button1.Location = new Point(45, this.Size.Height - button1.Size.Height - 60);

            conexao.Close();
            conexao.Open();

            consulta = new MySqlCommand();
            consulta.Connection = conexao;
            consulta.CommandText = "SELECT * FROM "+tipo+ " WHERE "+tipo+"."+acharId+" = "+id+";";

            resultado = consulta.ExecuteReader();

            while (resultado.Read()) 
            {
                for (int x = 1; x < campos.Length + 1; x++)
                {

                    caixaTexto objeto = new caixaTexto();

                    if (tipos[x-1] == "varchar" || tipos[x - 1] == "int" || tipos[x - 1] == "float")
                    {
                        this.Controls.Add(objeto.caixa);

                        objeto.caixa.Text = resultado[x].ToString();
                    }
                    else if (tipos[x - 1] == "date")
                    {
                        this.Controls.Add(objeto.date);
                        objeto.date.Value = Convert.ToDateTime(resultado[x]);
                    }
                    else if (tipos[x - 1] == "blob")
                    {
                        this.Controls.Add(objeto.button);
                        this.Controls.Add(objeto.pfp);

                        byte[] imageBytes = (byte[])resultado[x];

                        objeto.pfp.Image = ConverterBytesParaImagem(imageBytes);
                        objeto.conversaoBytes = imageBytes;

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
                        nome = nomesAluno[x - 1];
                    }
                    else if (tipo == "usuário")
                    {
                        nome = nomesUsuario[x - 1];
                    }
                    else
                    {
                        nome = nomesProduto[x - 1];
                    }

                    objeto.inicializar(nome, x - 1, tipos[x - 1]);
                    caixas[x - 1] = objeto;
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

        private void button1_Click(object sender, EventArgs e)
        {

            string acharFoto = tipo == "aluno" ? "pfp" : tipo == "usuário" ? "pfp" : "foto";
            string acharId = tipo == "curso" ? "cursoId" : tipo == "usuário" ? "userId" : "prodId";
            string comando = "UPDATE " + tipo.ToLower() + " SET ";

            byte[] conversaoBytes = null;

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

                comando += tipos[x] == "blob" ? campos[x] + " = @dadosImagem " : campos[x] + " = '" + tipoCampo + "', ";
                
            }

            
            comando += " WHERE " + tipo + "." + acharId + " = " + id;

            if (tipo == "curso") 
            {
                int indexOf = -1;
                indexOf = comando.IndexOf(',', 0, comando.Length);
                MessageBox.Show(indexOf.ToString());

                comando.Remove(indexOf-1, 1);
            }

            MessageBox.Show(comando);

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

            MessageBox.Show(tipo+" alterado com sucesso!");

            this.Close();

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
