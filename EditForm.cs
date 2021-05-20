using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BooksHouse
{
    public partial class EditForm : Form
    {
        private MySqlConnection conn = null;

        private List<string[]> data = null;

        public EditForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dataGridView.Rows.Clear();

            try
            {
                Console.WriteLine("Getting Connection ...");
                conn = DBUtils.GetDBConnection();


                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");

                string query = "SELECT * FROM Books ORDER BY name";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataReader reader = command.ExecuteReader();

                data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[7]);

                    for (int i = 0; i < 6; ++i)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }

                    data[data.Count - 1][6] = "Delete";
                }

                reader.Close();

                conn.Close();

                foreach (string[] s in data)
                {
                    dataGridView.Rows.Add(s);
                }
            }
            catch (Exception exep)
            {
                Console.WriteLine("Error: " + exep.Message);
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RefreshData()
        {
            dataGridView.Rows.Clear();

            foreach (string[] s in data)
            {
                dataGridView.Rows.Add(s);
            }
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Введіть всі дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToDouble(textBox2.Text) <= 0) 
                MessageBox.Show("Ціна не може бути від'ємной!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToInt32(textBox3.Text) <= 0) 
                MessageBox.Show("Кількість не може бути від'ємной!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]+-[0-9]+$")) 
                MessageBox.Show("Вікові межі введені некоректно! Введіть у форматі 'min-max'", "Помилка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                conn.Open();

                string[] age = textBox4.Text.Split('-');

                string query = $"INSERT INTO Books (name, price, amount, minAge, maxAge)" +
                    $"VALUES ('{textBox1.Text}', {textBox2.Text.Replace(",", ".")}, {textBox3.Text}, {age[0]}, {age[1]})";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();

                conn.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                LoadData();
            }

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 6)
                {
                    string task = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();

                    int rowIndex = e.RowIndex;

                    switch (task)
                    {
                        case "Delete":
                            if(MessageBox.Show("Видалити цей рядок?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string delId = dataGridView.Rows[rowIndex].Cells["id"].Value.ToString();

                                dataGridView.Rows.RemoveAt(rowIndex);
                                data.RemoveAt(rowIndex);

                                conn.Open();

                                string deleteQuery = $"DELETE FROM Books WHERE id = {delId}";
                                MySqlCommand delCommand = new MySqlCommand(deleteQuery, conn);
                                delCommand.ExecuteNonQuery();

                                conn.Close();
                            }
                            break;
                        case "Update":
                            string upId = dataGridView.Rows[rowIndex].Cells["id"].Value.ToString();
                            string name = dataGridView.Rows[rowIndex].Cells["name"].Value.ToString();
                            string price = dataGridView.Rows[rowIndex].Cells["price"].Value.ToString();
                            string amount = dataGridView.Rows[rowIndex].Cells["amount"].Value.ToString();
                            string minAge = dataGridView.Rows[rowIndex].Cells["minAge"].Value.ToString();
                            string maxAge = dataGridView.Rows[rowIndex].Cells["maxAge"].Value.ToString();

                            if (name == "" || price == "" || amount == "" || minAge == "" || maxAge == ""
                                || !System.Text.RegularExpressions.Regex.IsMatch(price, "^[0-9]+(,[0-9]+)?$")
                                || !System.Text.RegularExpressions.Regex.IsMatch(amount, "^[0-9]+$") 
                                || !System.Text.RegularExpressions.Regex.IsMatch(minAge, "^[0-9]+$")
                                || !System.Text.RegularExpressions.Regex.IsMatch(maxAge, "^[0-9]+$"))
                            {
                                MessageBox.Show("Введені не валідні дані!", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                                data[rowIndex][6] = "Delete";
                                RefreshData();

                            }
                            else
                            {
                                data[rowIndex][1] = name;
                                data[rowIndex][2] = price;
                                data[rowIndex][3] = amount;
                                data[rowIndex][4] = minAge;
                                data[rowIndex][5] = maxAge;

                                conn.Open();

                                string query = $"UPDATE Books SET name = '{name}', price = {price}, amount = {amount}, " +
                                    $"minAge = {minAge}, maxAge = {maxAge} WHERE id = {upId}";

                                MySqlCommand command = new MySqlCommand(query, conn);

                                command.ExecuteNonQuery();

                                conn.Close();

                                data[rowIndex][6] = "Delete";
                                RefreshData();
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (data != null)
                {
                    data[e.RowIndex][6] = "Update";
                    dataGridView.Rows[e.RowIndex].Cells["task"].Value = data[e.RowIndex][6];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && !System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[0-9]+\\,?[0-9]*$"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                if (textBox2.Text.Length != 0)
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && !System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Будь ласка вводьте тільки цифри.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && !System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]+\\-?[0-9]*$"))
            {
                MessageBox.Show("Вікові межі введені некоректно! Введіть у форматі 'min-max'.");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }
    }
}
