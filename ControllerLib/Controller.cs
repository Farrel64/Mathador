using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControllerLib
{
    public class Controller
    {
        private Stack<string> pile = new Stack<string>();

        public int getPileSize()
        {
            return this.pile.Count;
        }

        public void insertResult(string nickname, int score)
        {
            string _connStr = @"Data Source=localhost; Database=Mathador; User ID=root; Password=''";
            string _query = "INSERT INTO user_data (pseudo,score,date) values(@pseudo,@score,now())";
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand comm = new MySqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = _query;
                    comm.Parameters.AddWithValue("@pseudo", nickname);
                    comm.Parameters.AddWithValue("@score", score);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        public void ajouterPile(String value)
        {
            if (value != null && pile.Count <= 3)
            {
                pile.Push(value);
            }
        }
    }
}
