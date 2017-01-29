using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using ControllerLib;
using MoteurLib;

namespace Mathador
{

    public partial class _Default : Page
    {
        private Stack<String> pile = new Stack<String>();
        private Controller controller = new Controller();
        private Moteur moteur = new Moteur();
        public List<int> values = new List<int>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["time"] = DateTime.Now.AddSeconds(300);
            }

            if (Cache["values"] == null)
            {
                List<int> initialValues = moteur.getRandomNumbers();
                Cache.Insert("values", initialValues, null,
                DateTime.Now.AddSeconds(300), TimeSpan.Zero);
                Cache.Insert("initialValues", new List<int>(initialValues), null,
                DateTime.Now.AddSeconds(300), TimeSpan.Zero);
            }

            values = (List<int>)Cache["values"];

           

            if (Cache["solution"] == null)
            {
                int solution = moteur.getTargetNumber();
                Cache.Insert("solution", solution, null,
                DateTime.Now.AddSeconds(300), TimeSpan.Zero);
                Solution.Text = Convert.ToString(solution);
            } else
            {
                Solution.Text = Convert.ToString(Cache["solution"]);
            }


            if (Cache["pile"] == null)
            {
                Cache.Insert("pile", pile, null,
                    DateTime.Now.AddSeconds(300), TimeSpan.Zero);
            }

            setButtons();
        }

        protected void ajouterPile(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            
            try
            {
                pile = (Stack<String>)Cache["pile"];
                if (senderButton.Text.Equals("+") || senderButton.Text.Equals("-") || senderButton.Text.Equals("*") || senderButton.Text.Equals("/"))
                {
                    if (pile.Count == 1)
                    {
                        pile.Push(senderButton.Text);
                    }
                    else
                    {
                        pile.Clear();
                        Response.Write("Opération non valable : l'opérateur doit être en deuxième position");
                    }
                }
                else
                { 
                    if (Cache["lastButtonID"] == null || !((String)Cache["lastButtonID"]).Equals(senderButton.ID))
                    {
                        pile.Push(senderButton.Text);
                        Cache.Insert("lastButtonID", senderButton.ID, null,
                        DateTime.Now.AddSeconds(300), TimeSpan.Zero);
                    }
                    else
                    {
                        pile.Clear();
                        Response.Write("Opération non valable : vous avez cliqué sur la même valeur");
                    }
                }

                Cache.Insert("pile", pile, null,
                    DateTime.Now.AddSeconds(300), TimeSpan.Zero);

                if (pile.Count == 3)
                {
                    Cache.Remove("lastButtonID");
                    int result = controller.calculerPile(pile);
                    if(result == -1)
                    {
                        pile.Clear();
                        Response.Write("Opération non valable");
                    } else if (result == (int)Cache["solution"])
                    {
                        //TODO this.calculerScore
                        Response.Write("Bravo tu as gagné !");
                        Cache.Remove("lastButtonID");
                        Cache.Remove("solution");
                        Cache.Remove("values");
                        Cache.Remove("pile");
                        Page.Response.Redirect(Page.Request.RawUrl);
                    } else
                    {
                        List<int> myValues = (List<int>)Cache["values"];
                        myValues.Remove(Convert.ToInt32(pile.Pop()));
                        pile.Pop();
                        myValues.Remove(Convert.ToInt32(pile.Pop()));
                        myValues.Add(result);


                        Cache.Remove("lastButtonID");
                        Cache.Insert("values", myValues, null,
                        DateTime.Now.AddSeconds(300), TimeSpan.Zero);

                        setButtons();
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Response.Write(ex);
            }

        }

        public void setButtons()
        {
            if (values.Count >= 1)
            {
                Button2.Text = Convert.ToString(values[0]);
            }
            if (values.Count >= 2)
            {
                Button3.Text = Convert.ToString(values[1]);
            }
            if (values.Count >= 3)
            {
                Button4.Text = Convert.ToString(values[2]);
            }
            if (values.Count >= 4)
            {
                Button5.Text = Convert.ToString(values[3]);
            }
            if (values.Count >= 5)
            {
                Button6.Text = Convert.ToString(values[4]);
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string nickname = TextBox1.Text;
            int score = Convert.ToInt32(TextBox2.Text);
            controller.insertResult(nickname, score);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Cache.Insert("values", Cache["initialValues"], null,
                DateTime.Now.AddSeconds(300), TimeSpan.Zero);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1 = new TimeSpan();
            time1 = (DateTime)Session["time"] - DateTime.Now;
            if (time1.Seconds <= 0)
            {
                Label1.Text = "TimeOut!";
            }
            else
            {
                Label1.Text = time1.Seconds.ToString();
            }

        }
    }
}