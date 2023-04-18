using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Create_Mysql
{
    public partial class Form1 : Form
    {
        // MySQL 数据库连接字符串
       string connectionString = "Server=127.0.0.1;port=3306;Database=db_xyt;Uid=root;Pwd=xyt123456;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            
            try
            {
                // 创建数据库
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("数据库连接成功！");
                    string query = $"CREATE DATABASE IF NOT EXISTS {txtDatabase.Text.Trim()}" ;
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("数据库创建成功！","提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库创建失败：" + ex.Message);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                // 新建数据表
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"USE {txtDatabase.Text.Trim()}; CREATE TABLE IF NOT EXISTS {txtTable.Text.Trim()} (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(50), age INT)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("数据表创建成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据表创建失败：" + ex.Message);
            }
        }
    }
}
