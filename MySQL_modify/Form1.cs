
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQL_modify
{
    
    public partial class Form1 : Form
    {
        // MySQL 数据库连接字符串
        string connectionString = "Server=127.0.0.1;port=3306;Database=db_xyt;Uid=root;Pwd=xyt123456;";
        public Form1()
        {
            InitializeComponent();
        }
        // 加载数据到 DataGridView
        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM test";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据加载失败：" + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int age = Convert.ToInt32(txtAge.Text.Trim());
                string city = txtCity.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(city))
                {
                    MessageBox.Show("请输入姓名和城市！");
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO test (Name, Age, City) VALUES ('{name}', {age}, '{city}')";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("数据添加成功！");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据添加失败：" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
        }
    }
}
