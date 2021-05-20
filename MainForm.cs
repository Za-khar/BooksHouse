using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MySql.Data.MySqlClient;

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
            label4.Visible = false;
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void TextBox3_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void TextBox4_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void TextBox5_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
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
            EditForm editForm = new EditForm();

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
                try
                {
                    conn = DBUtils.GetDBConnection();

                    conn.Open();

                    string query = $"SELECT password FROM Users WHERE username = '{textBox4.Text}'";

                    MySqlCommand command = new MySqlCommand(query, conn);

                    MySqlDataReader reader = command.ExecuteReader();

                    string password = "";

                    while (reader.Read())
                    {
                        if (reader[0].ToString() != "")
                            password = reader[0].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    if (password == textBox5.Text)
                    {
                        editForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Користувача не існує або введені невірні дані", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exep)
                {
                    MessageBox.Show($"Помилка з'єднання з базою! Текст помилки: {exep}", "Помилка",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }

            if (textBox1.Text.Length == 0)
                label4.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
            if (textBox2.Text.Length == 0)
                label5.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
            if (textBox3.Text.Length == 0)
                label6.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
                label7.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
                label8.Visible = true;
        }
    }
}
