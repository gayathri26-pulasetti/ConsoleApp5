using System;
using System.Data.SqlClient;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student No:");
            int StuNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Student Name:");
            string StuName = Console.ReadLine();

            Console.WriteLine("Enter Student Address:");
            string StuAddress = Console.ReadLine();

            Console.WriteLine("Enter Student Marks:");
            int StuMarks = Convert.ToInt32(Console.ReadLine());

            string connectionString =
                "data source=LAPTOP-DCHN8VAV;database=demo;integrated security=yes";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Student VALUES (@StuNo, @StuName, @StuAddress, @StuMarks)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@StuNo", StuNo);
                cmd.Parameters.AddWithValue("@StuName", StuName);
                cmd.Parameters.AddWithValue("@StuAddress", StuAddress);
                cmd.Parameters.AddWithValue("@StuMarks", StuMarks);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Student record inserted successfully!");
            }
        }
    }
}
