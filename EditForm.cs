﻿using System;
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

        private void EditForm_Load(object sender, EventArgs e)
        {
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
            dataGridView.Rows.Clear();

            foreach (string[] s in data)
            {
                dataGridView.Rows.Add(s);
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

            }
        }
    }
}