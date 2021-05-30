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
using System.Windows.Input;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace BooksHouse
{
    public partial class MainForm : Form
    {
        private MySqlConnection conn = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                ShowError("Введіть всі дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox1.Text) <= 0 || Convert.ToInt32(textBox2.Text) < 0 ||
                Convert.ToInt32(textBox3.Text) <= 0)
                ShowError("Дані не можуть бути від'ємними!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox2.Text) >= Convert.ToInt32(textBox3.Text))
                ShowError("Мінімальний вік не може бути більше або рівним максимального!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                    folderDialog.Description = "Select the document folder";
                    DialogResult result = folderDialog.ShowDialog();

                    string lText = label5.Text;

                    label4.Visible = false;
                    label5.Text = "Йде побудова звіту...";
                    label5.Refresh();
                    label6.Visible = false;

                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    button1.Visible = false;

                    conn = DBUtils.GetDBConnection();
                    conn.Open();

                    string query1 = $"SELECT price, name FROM Books WHERE price = (SELECT min(price) FROM Books)";
                    MySqlCommand command1 = new MySqlCommand(query1, conn);

                    MySqlDataReader reader1 = command1.ExecuteReader();
                    List<string[]> minPriceBooks = new List<string[]>();

                    while (reader1.Read())
                    {
                        minPriceBooks.Add(new string[2]);

                        for (int i = 0; i < 2; ++i)
                        {
                            minPriceBooks[minPriceBooks.Count - 1][i] = reader1[i].ToString();
                        }
                    }
                    reader1.Close();

                    string query2 = $"SELECT name FROM Books WHERE price <= {textBox1.Text} AND minAge >= {textBox2.Text}" +
                        $" AND maxAge <= {textBox3.Text}";
                    MySqlCommand command2 = new MySqlCommand(query2, conn);

                    MySqlDataReader reader2 = command2.ExecuteReader();
                    List<string[]> books = new List<string[]>();

                    while (reader2.Read())
                    {
                        books.Add(new string[1]);
                        books[books.Count - 1][0] = reader2[0].ToString();

                    }
                    reader2.Close();
                    conn.Close();

                    WordApi wp = new WordApi();

                    wp.addParagraph("Звіт від магазину ''Будинок мрій': ", 24, 900);

                    wp.addParagraph("Найдешевші книги: ", 16, 900);

                    for (int i = 0; i < minPriceBooks.Count; i++)
                    {
                        wp.addParagraph($"Назва: { minPriceBooks[i][1]}, ціна: { minPriceBooks[i][0]}", 14);
                    }

                    wp.addParagraph("Книги, які вам підходять: ", 16, 900);

                    for (int i = 0; i < books.Count; i++)
                    {
                        wp.addParagraph($"Назва: {books[i][0]}", 14);
                    }

                    if (result == DialogResult.OK)
                    {
                        wp.saveDoc($"{Directory.GetCurrentDirectory()}\\zvitBooks.docx");
                    }
                    else
                    {
                        wp.saveDoc($"{Directory.GetCurrentDirectory()}\\zvitBooks.docx");
                    }

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
        
                    label4.Visible = true;
                    label5.Text = lText;
                    label5.Refresh();
                    label6.Visible = true;

                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    button1.Visible = true;                              
                }
                catch
                {
                    ShowError("Помилка з'єднання з базою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();

            if (textBox4.Text == "" || textBox5.Text == "")
                ShowError("Введіть всі дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox4.Text.Length < 3)
                ShowError("Логін повинен бути більш ніж 3 символа!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox5.Text.Length < 8)
                ShowError("Пароль повинен бути більш ніж 8 символів!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        ShowError("Користувача не існує або введені невірні дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    ShowError("Помилка з'єднання з базою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                ShowError("Будь ласка вводьте тільки цифри", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                ShowError("Будь ласка вводьте тільки цифри", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                ShowError("Будь ласка вводьте тільки цифри", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private static void ShowError(string MsgStr, string MsgName, MessageBoxButtons MsgBtn, MessageBoxIcon MsgIcon)
        {
            MessageBox.Show(MsgStr, MsgName, MsgBtn, MsgIcon);
        }
    }
}
