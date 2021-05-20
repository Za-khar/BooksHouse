using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksHouse
{
    public partial class MainForm : Form
    {
        private MySqlConnection conn = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void TextBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void TextBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void TextBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Введіть всі дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox1.Text) <= 0 || Convert.ToInt32(textBox2.Text) <= 0 ||
                Convert.ToInt32(textBox3.Text) <= 0)
                MessageBox.Show("Дані не можуть бути від'ємними!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox2.Text) >= Convert.ToInt32(textBox3.Text))
                MessageBox.Show("Мінімальний вік не може бути більше або рівним максимального!", "Помилка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // @TODO:  Create Word file
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("Введіть всі дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox4.Text.Length < 3)
                MessageBox.Show("Логін повинен бути більш ніж 3 символа!", "Помилка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox5.Text.Length < 8)
                MessageBox.Show("Пароль повинен бути більш ніж 8 символів!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Console.WriteLine("Getting Connection ...");
                conn = DBUtils.GetDBConnection();

                Console.WriteLine("Openning Connection ...");
                conn.Open();

                Console.WriteLine("Connection successful!");

                string query = $"SELECT password FROM Users WHERE username = {textBox4.Text}";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataReader reader = command.ExecuteReader();

                string password = "";
                while (reader.Read())
                    if (reader[0].ToString())
                        password = reader[0].ToString();
   
                reader.Close();
                conn.Close();

                if (password == textBox5.Text)
                    Application.Run(new EditForm());
                else
                    MessageBox.Show("Користувача не існує або введені невірні дані", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
