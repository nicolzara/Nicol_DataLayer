using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database.ViewModel
{
    public class StudentDatabase
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\User\\Documents\\עבודות הנדסת תוכנה\\Wpf_Database\\ViewModel\\Database_Practice.accdb\";Persist Security Info=True";
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader reader;

        public StudentDatabase()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public StudentList SelectAll()
        {
            try
            {
                StudentList studentList = new StudentList();
                command.CommandText = "SELECT * FROM StudentTable;";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID = int.Parse(reader["ID"].ToString());
                    student.FIRST_NAME = reader["FirstName"].ToString();
                    student.LAST_NAME = reader["LastName"].ToString();
                    student.BIRTHDATE = DateTime.Parse(reader["Bithdate"].ToString());
                    student.GENDER = Convert.ToBoolean(int.Parse(reader["Gender"].ToString()));
                    student.PHONE_NUMBER = reader["PhoneNumber"].ToString();
                    studentList.Add(student);
                }

                return studentList;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            finally 
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return null;
        }

        public Student SeleceByID(int Id)
        {
            try
            {
                string query = "SELECT * FROM DishTable WHERE ID=";
                query += Id.ToString();
                query += ";";
                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Student student = new Student();
                    student.ID = int.Parse(reader["ID"].ToString());
                    student.FIRST_NAME = reader["FirstName"].ToString();
                    student.LAST_NAME = reader["LastName"].ToString();
                    student.BIRTHDATE = DateTime.Parse(reader["Bithdate"].ToString());
                    student.GENDER = Convert.ToBoolean(int.Parse(reader["Gender"].ToString()));
                    student.PHONE_NUMBER = reader["PhoneNumber"].ToString();
                    return student;
                }
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return null;
        }
    }
}
