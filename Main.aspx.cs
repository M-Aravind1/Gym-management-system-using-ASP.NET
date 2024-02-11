using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Main : System.Web.UI.Page
{
    
    

    SqlConnection c = new SqlConnection(@"data source=LAPTOP-1FKDLJQT;initial catalog=gym;integrated security = true");

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlCommand a = new SqlCommand("cinsert", c);
        a.CommandType = CommandType.StoredProcedure;
        a.Parameters.AddWithValue("@Name", TextBox1.Text);
        a.Parameters.AddWithValue("@Gender", TextBox2.Text);
        a.Parameters.AddWithValue("@Phone", TextBox3.Text);
        a.Parameters.AddWithValue("@Experience", TextBox4.Text);
        a.Parameters.AddWithValue("@Local_Address", TextBox5.Text);
        a.Parameters.AddWithValue("@Pass_Word", TextBox6.Text);
        a.Parameters.AddWithValue("@Email", TextBox7.Text);

        SqlDataAdapter b = new SqlDataAdapter(a);
        DataTable dt = new DataTable();
        b.Fill(dt);
        
        GridView1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        c.Open();
        SqlCommand a = new SqlCommand("delete from coach where CoachId =  @ID ", c);
        a.Parameters.AddWithValue("@ID",TextBox8.Text);
        a.ExecuteNonQuery();
       
        c.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        c.Open();
        SqlCommand a = new SqlCommand("select * from coach where CoachId= @ID", c);
        a.Parameters.AddWithValue("@ID", TextBox8.Text);
        SqlDataReader r = a.ExecuteReader();
        if (r.Read())
        {
            TextBox1.Text = r["Name"].ToString();
            TextBox2.Text = r["Gender"].ToString();
            TextBox3.Text = r["Phone"].ToString();
            TextBox4.Text = r["Experience"].ToString();
            TextBox5.Text = r["Local_Address"].ToString();
            TextBox6.Text = r["Pass_Word"].ToString();
            TextBox7.Text = r["Email"].ToString();

            r.Close();

        }
        c.Close();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        SqlCommand b = new SqlCommand("update coach set Name = @Name, Gender = @gender ,Phone = @phone,Experience =@experience,Local_Address = @address,Pass_Word =@password,Email = @email where CoachId=@ID", c);
        b.Parameters.AddWithValue("@Name", TextBox1.Text);
        b.Parameters.AddWithValue("@gender", TextBox2.Text);
        b.Parameters.AddWithValue("@phone", TextBox3.Text);
        b.Parameters.AddWithValue("@experience", TextBox4.Text);
        b.Parameters.AddWithValue("@address", TextBox5.Text);
        b.Parameters.AddWithValue("@password", TextBox6.Text);
        b.Parameters.AddWithValue("@email", TextBox7.Text);
        b.Parameters.AddWithValue("@ID", TextBox8.Text);
        c.Open();
        b.ExecuteNonQuery();
        
        c.Close();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        TextBox1.Text ="";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Members.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("first page.aspx");

    }
}