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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Response.Write("Here");
                showTable();
            }
                    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //retrieve first name from textbox control
            string FName = txtFName.Text;

            //retrieve last name from textbox control
            string LName = txtLName.Text;

            //retrieve course name from textbox
            string courseName = txtcourseName.Text;

            //insert...
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            string query = "insert into login_Wade (FirstName, LastName, CourseName) " +
                "VALUES ('" + FName + "', '" + LName + "','" + courseName + "');";

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

            showTable();


            // Response.Write(query);

        }

        private void showTable()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //variable for db connection
            SqlConnection myConnection;

            myConnection = new SqlConnection(connection);
            myConnection.Open(); //opens a tunel or pipe to allow for data to flow between this project and the DB

            string query = "select * from login_Wade"; // one should feel itchy here


            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);

            //what is this
            myConnection.Close();

            gvUsers.DataSource = myDataSet.Tables[0];
            gvUsers.DataBind();
        }
    }
}