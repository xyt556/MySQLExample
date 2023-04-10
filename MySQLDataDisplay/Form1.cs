using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using OfficeOpenXml;
namespace MySQLDataDisplay
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        string connectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 设置连接字符串
            connectionString = "Server=127.0.0.1;port=3306;user=root;Pwd=xyt123456;";
            connection = new MySqlConnection(connectionString);

            try
            {
                // 打开连接
                connection.Open();

                // 获取所有数据库名称
                DataTable databases = connection.GetSchema("Databases");

                // 将数据库名称添加到第一个ListBox中
                foreach (DataRow row in databases.Rows)
                {
                    listBox1.Items.Add(row["database_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //listBoxTables.Items.Clear();
            //// 获取数据库中的表名
            //DataTable tableSchema = connection.GetSchema("Tables");
            //foreach (DataRow row in tableSchema.Rows)
            //{
            //    string tableName = row["TABLE_NAME"].ToString();
            //    listBoxTables.Items.Add(tableName);
            //}
            //// 查询数据并绑定到 DataGridView 控件
            //string query = "SELECT * FROM city";
            //command = new MySqlCommand(query, connection);
            //adapter = new MySqlDataAdapter(command);
            //dataTable = new DataTable();
            //adapter.Fill(dataTable);
            //dataGridView1.DataSource = dataTable;

            // 关闭数据库连接
            connection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭数据库连接
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 创建 Excel 文件
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // 写入表头
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                }

                // 写入表数据
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                    }
                }

                // 保存 Excel 文件
                package.SaveAs(new System.IO.FileInfo("output.xlsx"));
            }

            MessageBox.Show("文件保存成功！");
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();
            //dataGridView1.Refresh();
            dataGridView1.DataSource = null;

            string selectedTable = listBoxTables.SelectedItem.ToString();
            LoadTableData(selectedTable);

        }
        private void LoadTableData(string tableName)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SELECT * FROM {tableName}", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            { 
                connection.Close(); 
            }     

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清空第二个ListBox
            listBoxTables.Items.Clear();

            // 获取选中的数据库名称
            string dbName = listBox1.SelectedItem.ToString();

            // 创建连接
            connection = new MySqlConnection(connectionString + $";database={dbName}");

            try
            {
                // 打开连接
                connection.Open();

                // 获取所有表名称
                DataTable tables = connection.GetSchema("Tables");

                // 将表名称添加到第二个ListBox中
                foreach (DataRow row in tables.Rows)
                {
                    listBoxTables.Items.Add(row["TABLE_NAME"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 关闭数据库连接
            connection.Close();
            //finally
            //{
            //    // 关闭连接
            //    conn.Close();
            //}
        }
    }
}

