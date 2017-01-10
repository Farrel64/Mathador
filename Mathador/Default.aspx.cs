using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using ControllerLib;

namespace Mathador
{

    public partial class _Default : Page
    {

        private Controller controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                Button6.Text += "Page Posted Back.<br/>";
            }
            else
            {
                Button6.Text += "page Created.<br/>";
            }

            if (Cache["testitem"] == null)
            {
                Button6.Text += "Creating test item.<br/>";
                DateTime testItem = DateTime.Now;
                Button6.Text += "Storing test item in cache ";
                Button6.Text += "for 30 seconds.<br/>";
                Cache.Insert("testitem", testItem, null,
                DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            }
            else
            {
                Button6.Text += "Retrieving test item.<br/>";
                Cache["testitem"] = "mdr";
                String testItem = (String)Cache["testitem"];
                Button6.Text += "Test item is: " + testItem.ToString();
                Button6.Text += "<br/>";
            }

            Button6.Text += "<br/>";

        }

        protected void ajouterPile(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            try
            {
                controller.ajouterPile(senderButton.Text);
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