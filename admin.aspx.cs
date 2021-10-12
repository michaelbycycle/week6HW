using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sept9
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                fillusers();
            }
            else
            {
                int userID = Convert.ToInt32(ddlUsers.SelectedValue);
                Session["userID"] = userID;

                if(Convert.ToBoolean(Session["dontdothis"]) == false)
                fillSpecificUser(userID);
            }
            
        }
        private void fillusers()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //variable for db connection
            SqlConnection myConnection;

            myConnection = new SqlConnection(connection);
            myConnection.Open(); //opens a tunel or pipe to allow for data to flow between this project and the DB

            string query = "SELECT FirstName + ' ' + LastName as FullName, CourseName, userID FROM login_Wade";
           


            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);

            //what is this
            myConnection.Close();

            //fill our dropdown
            ddlUsers.DataSource = myDataSet.Tables[0];
            ddlUsers.DataTextField = "FullName";
            ddlUsers.DataValueField = "userID";
            ddlUsers.DataBind();
        }
        private void fillSpecificUser(int userID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //variable for db connection
            SqlConnection myConnection;

            myConnection = new SqlConnection(connection);
            myConnection.Open(); //opens a tunel or pipe to allow for data to flow between this project and the DB

            string query = "SELECT FirstName, LastName, CourseName, userID FROM login_Wade WHERE userID = " + userID;



            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);

            //what is this
            myConnection.Close();

            //f
            txtFName.Text = myDataSet.Tables[0].Rows[0]["FirstName"].ToString();
            txtLName.Text = myDataSet.Tables[0].Rows[0]["LastName"].ToString();
            txtcourseName.Text = myDataSet.Tables[0].Rows[0]["CourseName"].ToString();

            Session["dontdothis"] = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string FName = txtFName.Text;

            //retrieve last name from textbox control
            string LName = txtLName.Text;

            //retrieve course name from textbox
            string courseName = txtcourseName.Text;

            int userID = Convert.ToInt32(Session["userID"]);

            //insert...
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            string query = "UPDATE login_Wade SET FirstName='" + FName + "', LastName='" + LName + "',CourseName='" + courseName +
                "'" + " WHERE userID = "  + userID;
            
            //Response.Write(query);
            
            //variable for db connection
            SqlConnection myConnection;

            myConnection = new SqlConnection(connection);
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            myCommand.ExecuteNonQuery();

            //what is this
            myConnection.Close();
            Session["dontdothis"] = false;
            fillusers();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string FName = txtFName.Text;

            //retrieve last name from textbox control
            //string LName = txtLName.Text;

            //retrieve course name from textbox
            //string courseName = txtcourseName.Text;

            int userID = Convert.ToInt32(Session["userID"]);

            //insert...
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            string query = "DELETE FROM login_Wade WHERE userID = " + userID;

            //Response.Write(query);

            //variable for db connection
            SqlConnection myConnection;

            myConnection = new SqlConnection(connection);
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            myCommand.ExecuteNonQuery();

            //what is this
            myConnection.Close();
            Session["dontdothis"] = false;
            fillusers();
        }
     }
}