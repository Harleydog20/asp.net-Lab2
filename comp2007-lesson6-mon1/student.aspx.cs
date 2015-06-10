using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_lesson6_mon1.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson6_mon1
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    GetStudent();
                }
            }
        }

        protected void GetStudent()
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get id from url parameter and store in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                var s = (from stu in conn.Students where stu.StudentID == StudentID select stu).FirstOrDefault();

                //populate the form from our department object
                txtFName.Text = s.FirstMidName;
                txtLName.Text = s.LastName;
            }
        }

        protected void btnSaveStu_Click(object sender, EventArgs e)
        {
            using (DefaultConnection conn = new DefaultConnection())
            {
                //instantiate a new deparment object in memory
                Student s = new Student();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                s.FirstMidName = txtFName.Text;
                s.LastName = txtLName.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Students.Add(s);
                }
                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("students.aspx");
            }
        }
    }
}