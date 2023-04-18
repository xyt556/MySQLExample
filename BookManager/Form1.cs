using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace BookManager
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        private int selectedRowIndex; // 选中行的索引
        string connectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 连接到MySQL数据库
            connectionString = "server=localhost;user=root;database=bookmanager;port=3306;password=xyt123456;";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // 获取数据并显示在DataGridView控件中
            adapter = new MySqlDataAdapter("SELECT * FROM book", connection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 添加新书籍
            DataRow row = dataTable.NewRow();
            row["id"] = textBoxId.Text;
            row["书名"] = textBoxTitle.Text;
            row["作者"] = textBoxAuthor.Text;
            row["价格"] = textBoxPrice.Text;
            dataTable.Rows.Add(row);

            // 更新数据库
            adapter.Update(dataTable);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 在单元格值更改后更新数据表的对应行和列的值
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataTable.Rows[cell.RowIndex][cell.ColumnIndex] = cell.Value;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // 删除选中的书籍
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int bookId = Convert.ToInt32(row.Cells["id"].Value); // 获取选中行的书籍ID
                DeleteBook(bookId); // 调用删除书籍的方法
                dataGridView1.Rows.Remove(row);
            }

        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // 更新数据库
                adapter.Update(dataTable);

                // 提示更新成功
                MessageBox.Show("数据更新成功！");
            }
            catch (Exception ex)
            {
                // 更新失败，显示错误信息
                MessageBox.Show("数据更新失败：" + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭数据库连接
            connection.Close();
        }
        private void DeleteBook(int bookId)
        {
            // 执行删除操作
            string query = "DELETE FROM book WHERE id = @bookId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@bookId", bookId);
            command.ExecuteNonQuery();
        }

 

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxId.Text = row.Cells["id"].Value.ToString();
                textBoxTitle.Text = row.Cells["书名"].Value.ToString();
                textBoxAuthor.Text = row.Cells["作者"].Value.ToString();
                textBoxPrice.Text = row.Cells["价格"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 创建数据库连接
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 开始事务
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 创建DataAdapter和对应的UpdateCommand
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM books", connection))
                        {
                            adapter.UpdateCommand = new MySqlCommand("UPDATE books SET title = @title, author = @author, price = @price WHERE id = @id", connection);
                            adapter.UpdateCommand.Parameters.Add("@title", MySqlDbType.VarChar, 50, "title");
                            adapter.UpdateCommand.Parameters.Add("@author", MySqlDbType.VarChar, 50, "author");
                            adapter.UpdateCommand.Parameters.Add("@price", MySqlDbType.Decimal, 10, "price");
                            adapter.UpdateCommand.Parameters.Add("@id", MySqlDbType.Int32, 11, "id").SourceVersion = DataRowVersion.Original;

                            // 更新数据
                            adapter.Update(dataTable);

                            // 提交事务
                            transaction.Commit();
                        }
                    }
                    catch (DBConcurrencyException ex)
                    {
                        // 处理并发冲突异常
                        MessageBox.Show("更新失败，请重试或者检查记录是否已被其他用户修改！");
                        transaction.Rollback();
                    }
                    catch (Exception ex)
                    {
                        // 处理其他异常
                        MessageBox.Show("更新失败：" + ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
