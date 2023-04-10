using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace MySQLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=127.0.0.1;port=3306;Database=db_xyt;Uid=root;Pwd=xyt123456;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // 打开数据库连接
                connection.Open();

                // 查询数据
                string query = "SELECT * FROM coal";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                // 输出查询结果
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["编号"]);
                    double c = Convert.ToDouble(reader["C"]);
                    double h = Convert.ToDouble(reader["H"]);
                    Console.WriteLine($"ID: {id}, C: {c}, H: {h}");
                }

                // 关闭数据读取器
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // 关闭数据库连接
                connection.Close();
            }

            Console.ReadLine();
        }
    }
}
