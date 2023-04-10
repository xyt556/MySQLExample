using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AccessDatabaseReader
{
    public partial class Form1 : Form
    {
        string connectionString = string.Empty; // 数据库连接字符串
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化 DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // 打开文件对话框选择 Access 数据库文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Access Database Files (*.mdb;*.accdb)|*.mdb;*.accdb";
            openFileDialog.Title = "选择 Access 数据库文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取选中的数据库文件路径
                string dbFilePath = openFileDialog.FileName;

                // 构建数据库连接字符串
                connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFilePath};Persist Security Info=False;";

                try
                {
                    // 连接数据库
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    connection.Open();

                    // 获取数据库中的数据表名
                    DataTable schemaTable = connection.GetSchema("Tables");
                    comboBoxTables.Items.Clear();
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        comboBoxTables.Items.Add(tableName);
                    }
                    MessageBox.Show("数据库打开成功！" );
                    // 关闭数据库连接
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据库连接失败：" + ex.Message);
                }
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取选中的数据表名
            string selectedTableName = comboBoxTables.SelectedItem.ToString();

            try
            {
                // 连接数据库
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();

                // 查询选中数据表的内容
                OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT * FROM [{selectedTableName}]", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, selectedTableName);
                dataGridView1.DataSource = dataSet.Tables[selectedTableName];

                // 关闭数据库连接
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询数据表内容失败：" + ex.Message);
            }
        }
    }
}

