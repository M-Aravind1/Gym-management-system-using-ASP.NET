using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Email = TextBox1.Text;
        int Password = int.Parse(TextBox2.Text);
        if((Email=="admin@gmail.com") && (Password==1234))
        {
            Response.Redirect("Main.aspx");
        }
    }
}