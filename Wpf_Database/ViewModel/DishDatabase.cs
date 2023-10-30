using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database
{
   public class DishDatabase
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\User\\Documents\\עבודות הנדסת תוכנה\\Wpf_Database\\ViewModel\\Database_Practice.accdb\";Persist Security Info=True";
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader reader;

        public DishDatabase()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public DishList SelectAll()
        {
            try
            {
                DishList dishList = new DishList();
                command.CommandText = "SELECT * FROM DishTable;";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Dish dish = new Dish();
                    dish.ID = int.Parse(reader["ID"].ToString());
                    dish.DISH_NAME = reader["DishName"].ToString();
                    dishList.Add(dish);
                }

                return dishList;
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

        public Dish SeleceByID(int Id) 
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
                    Dish dish = new Dish();
                    dish.ID = int.Parse(reader["ID"].ToString());
                    dish.DISH_NAME = reader["DishName"].ToString();
                    return dish;
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
