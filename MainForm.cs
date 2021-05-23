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
                MessageBox.Show("Введіть всі дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox1.Text) <= 0 || Convert.ToInt32(textBox2.Text) < 0 ||
                Convert.ToInt32(textBox3.Text) <= 0)
                MessageBox.Show("Дані не можуть бути від'ємними!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox2.Text) >= Convert.ToInt32(textBox3.Text))
                MessageBox.Show("Мінімальний вік не може бути більше або рівним максимального!", "Помилка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
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


                    Word.Application wordApp = new Word.Application();
                    Word.Document wordDoc = wordApp.Documents.Add();
     

                    Word.Paragraph par1 = wordDoc.Paragraphs.Add();
                    par1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    par1.Range.Font.Size = 16;
                    par1.Range.Font.Name = "Times New Roman";
                    par1.Range.Font.Bold = 900;

/*                    Word.Paragraph par2 = wordDoc.Paragraphs.Add();
                    par2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    par2.Range.Font.Size = 14;
                    par2.Range.Font.Name = "Times New Roman";*/


                    par1.Range.Text = "Книги з мінімальною ціною:";
                    par1.Range.InsertParagraphAfter();
                    
                    for (int i = 0; i < minPriceBooks.Count; i++)
                    {
                        /*par2.Range.Text = $"Назва: {minPriceBooks[i][1]}, ціна: {minPriceBooks[i][0]}";*/
                        wordDoc.Content.Text = $"Назва: { minPriceBooks[i][1]}, ціна: { minPriceBooks[i][0]}" + Environment.NewLine;
                        /*par2.Range.InsertParagraphAfter();*/
                    }


/*                    par1.Range.Text = $"\n\nКниги, які вам підходять:";
                    par1.Range.InsertParagraphAfter();

                    for (int i = 0; i < books.Count; i++)
                    {
                        par2.Range.Text = $"Назва: {books[i][0]}";
                        par2.Range.InsertParagraphAfter();
                    }*/


                    wordApp.Visible = true;

                    object filename = @"D:\zvitBooks.docx";
                    wordDoc.SaveAs2(ref filename);


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    MessageBox.Show("Успішно створено звіт MS Word по посиланню D:/zvitBooks.docx", "Успіх",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exep)
                {
                    MessageBox.Show($"Помилка з'єднання з базою! Текст помилки: {exep}", "Помилка",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }
    }
}
