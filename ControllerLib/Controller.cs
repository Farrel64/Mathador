using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web;


namespace ControllerLib
{
    public class Controller
    {
        public void insertResult(string pseudo, int score)
        {
            string _connStr = @"Data Source=localhost; Database=Mathador; User ID=root; Password=''";
            string _query = "INSERT INTO user_data (pseudo,score,date) values(@pseudo,@score,now())";
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand comm = new MySqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = _query;
                    comm.Parameters.AddWithValue("@pseudo", pseudo);
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

        public int calculerPile(Stack<String> pile)
        {
            Stack<String> maPile = new Stack<string>(pile);
            int firstNumber = Convert.ToInt32(maPile.Pop());
            String _operator = maPile.Pop();
            int secondNumber = Convert.ToInt32(maPile.Pop());

            switch (_operator)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return secondNumber < firstNumber ? firstNumber - secondNumber : -1;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber % secondNumber == 0 ? firstNumber / secondNumber : -1;
            }

            return -1;
        }

        public int calculerScore(List<String> operators)
        {
            int score = 0;

            foreach(String operateur in operators)
            {
                switch (operateur)
                {
                    case "+":
                        score += 1;
                        break;
                    case "-":
                        score += 2;
                        break;
                    case "*":
                        score += 1;
                        break;
                    case "/":
                        score += 3;
                        break;
                }
            }
            return score;
        }

        public List<KeyValuePair<String, int>> getHighScores()
        {
            List<KeyValuePair<String, int>> highScores = new List<KeyValuePair<string, int>>();
            string _connStr = @"Data Source=localhost; Database=Mathador; User ID=root; Password=''";
            string _query = "SELECT * FROM user_data ORDER BY score desc LIMIT 10";
            MySqlConnection conn = new MySqlConnection(_connStr);
            MySqlCommand comm = new MySqlCommand(_query, conn);

            try
            {
                conn.Open();
                MySqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    highScores.Add(new KeyValuePair<string, int>(rdr.GetString(0), rdr.GetInt32(1)));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return highScores;
        }

        

    }
}

