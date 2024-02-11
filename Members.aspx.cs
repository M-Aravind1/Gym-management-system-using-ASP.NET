using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Members : System.Web.UI.Page
{
    
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("Members.aspx");
    }

    SqlConnection c = new SqlConnection(@"data source=LAPTOP-1FKDLJQT;initial catalog=gym;integrated security = true");

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand a = new SqlCommand("meminsert", c);
        a.CommandType = CommandType.StoredProcedure;
        a.Parameters.AddWithValue("@Name", TextBox1.Text);
        a.Parameters.AddWithValue("@Duration", TextBox2.Text);
        a.Parameters.AddWithValue("@Goal", TextBox3.Text);
        a.Parameters.AddWithValue("@Membership_type", TextBox4.Text);
        a.Parameters.AddWithValue("@Fees", TextBox5.Text);
        a.Parameters.AddWithValue("@CoachId", TextBox7.Text);
        

        SqlDataAdapter b = new SqlDataAdapter(a);
        DataTable dt = new DataTable();
        b.Fill(dt);
        GridView1.DataBind();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("first page.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        c.Open();
        SqlCommand a = new SqlCommand("select * from member where ID=@id", c);
        a.Parameters.AddWithValue("@id", TextBox6.Text);
        SqlDataReader r = a.ExecuteReader();
        if (r.Read())
        {
            TextBox1.Text = r["Name"].ToString();
            TextBox2.Text = r["Duration"].ToString();
            TextBox3.Text = r["Goal"].ToString();
            TextBox4.Text = r["Membership_type"].ToString();
            TextBox5.Text = r["Fees"].ToString();
            TextBox7.Text = r["CoachId"].ToString();
            

            r.Close();

        }
        c.Close();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        c.Open();
        SqlCommand a = new SqlCommand("delete from member where ID = id", c);
        a.Parameters.AddWithValue("id", TextBox6.Text);
        a.ExecuteNonQuery();

        c.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlCommand b = new SqlCommand("update member set Name = @name,CoachId = @CoachId, Duration = @duration ,Goal =@goal,Membership_type = @membership,Fees = @fees where ID =@id", c);
        b.Parameters.AddWithValue("name", TextBox1.Text);
        b.Parameters.AddWithValue("duration", TextBox2.Text);
        b.Parameters.AddWithValue("goal", TextBox3.Text);
        b.Parameters.AddWithValue("membership", TextBox4.Text);
        b.Parameters.AddWithValue("fees", TextBox5.Text);
        b.Parameters.AddWithValue("id", TextBox6.Text);
        b.Parameters.AddWithValue("CoachId", TextBox7.Text);
        c.Open();
        b.ExecuteNonQuery();

        c.Close();
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        SqlCommand a = new SqlCommand("select Coach.name as Coach,member.Name as Member_name,member.Goal from Coach inner join member on Coach.CoachId=member.CoachId", c);
        SqlDataAdapter b = new SqlDataAdapter(a);
        DataTable dt = new DataTable();
        b.Fill(dt);
        GridView2.DataSource = dt;  
        GridView2.DataBind();
    }
}