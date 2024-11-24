using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Teste
{
    internal class caixaTexto
    {
        public TextBox caixa = new TextBox();
        public DateTimePicker date = new DateTimePicker();
        public Button button = new Button();
        public PictureBox pfp = new PictureBox();

        public byte[] conversaoBytes;

        public Label texto = new Label();

        public void inicializar(string nome, int incremento, string tipo)
        {
            caixa.Visible = true;
            button.Visible = true;
            pfp.Visible = true;
            texto.Visible = true;

            /*caixa.Name = nome.ToLower();
            date.Name = nome.ToLower();
            button.Name = nome.ToLower();*/

            texto.Text = nome;
            texto.AutoSize = true;

            caixa.Size = new Size(156, 25);

            date.Size = new Size(156, 25);
            date.Format = DateTimePickerFormat.Short;

            button.Size = new Size(156, 25);
            button.Text = "Carregar";

            pfp.Size = new Size(80, 80);
            pfp.BackColor = Color.Black;
            pfp.SizeMode = PictureBoxSizeMode.StretchImage;

            caixa.Location = new Point(44, 95 + (50 * incremento));
            date.Location = new Point(44, 95 + (50 * incremento));

            button.Location = new Point(44, 95 + (50 * incremento));
            pfp.Location = new Point(button.Location.X + 40, button.Location.Y + (35));

            texto.Location = new Point(37, 80 + (50 * incremento));
        }
    }
}
