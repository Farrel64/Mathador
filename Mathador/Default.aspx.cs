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
            if (!IsPostBack)
            {

            }
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