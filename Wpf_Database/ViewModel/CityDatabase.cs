using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database
{
    public class CityDatabase
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\User\\Documents\\עבודות הנדסת תוכנה\\Wpf_Database\\ViewModel\\Database_Practice.accdb\";Persist Security Info=True";
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader reader;

        public CityDatabase()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public CityList SelectAll() 
        {
            try
            {
                CityList cityList = new CityList();

                command.CommandText = "SELECT * FROM CityTable;";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    City city = new City();
                    city.ID = int.Parse(reader["ID"].ToString());
                    city.CITY_NAME = reader["CityName"].ToString();
                    cityList.Add(city);
                }

                return cityList;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            finally
            { 
                if(reader != null)
                {
                    reader.Close();
                }
                if(connection != null)
                {
                    connection.Close();
                }
            }

            return null;
        }
        public City SeleceByID(int Id)
        {
            try
            {
                string query = "SELECT * FROM CityTable WHERE ID=";
                query += Id.ToString();
                query += ";";
                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    City city = new City();
                    city.ID = int.Parse(reader["ID"].ToString());
                    city.CITY_NAME = reader["CityName"].ToString();
                    return city;
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
