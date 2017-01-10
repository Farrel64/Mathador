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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["values"] == null)
            {
                List<int> initialValues = moteur.getRandomNumbers();
                Cache.Insert("values", initialValues, null,
                DateTime.Now.AddSeconds(300), TimeSpan.Zero);
            }

            List<int> values = (List<int>)Cache["values"];
            Button2.Text = Convert.ToString(values[0]);
            Button3.Text = Convert.ToString(values[1]);
            Button4.Text = Convert.ToString(values[2]);
            Button5.Text = Convert.ToString(values[3]);
            Button6.Text = Convert.ToString(values[4]);

            if (Cache["solution"] == null)
            {
                int solution = moteur.getTargetNumber();
                Cache.Insert("solution", solution, null,
                DateTime.Now.AddSeconds(300), TimeSpan.Zero);
                Button6.Text = Convert.ToString(solution);
            }

            if(Cache["pile"] == null)
            {
                Cache.Insert("pile", pile, null,
                    DateTime.Now.AddSeconds(300), TimeSpan.Zero);
            }

        }

        protected void ajouterPile(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            try
            {
                pile = (Stack<String>)Cache["pile"];
                pile.Push(senderButton.Text);
                Cache.Insert("pile", pile, null,
                    DateTime.Now.AddSeconds(300), TimeSpan.Zero);
                if (pile.Count == 3)
                {
                    int result = controller.calculerPile(pile);

                    List<int> myValues = (List<int>)Cache["values"];
                    myValues.Remove(Convert.ToInt32(pile.Pop()));
                    pile.Pop();
                    myValues.Remove(Convert.ToInt32(pile.Pop()));
                    myValues.Add(result);

                    Cache.Insert("values", myValues, null,
                    DateTime.Now.AddSeconds(300), TimeSpan.Zero);
                }
            }
            catch (NullReferenceException ex)
            {
                Response.Write(ex);
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string nickname = TextBox1.Text;
            int score = Convert.ToInt32(TextBox2.Text);
            controller.insertResult(nickname, score);
        }
    }
}