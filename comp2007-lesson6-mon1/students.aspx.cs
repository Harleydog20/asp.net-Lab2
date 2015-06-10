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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {

            //connect using our connection string from web.config and EF context class
            using (DefaultConnection conn = new DefaultConnection())
            {
                //use link to query the Departments model
                var stus = from s in conn.Students select s;

                //bind the query result to the gridview
                grdStudents.DataSource = stus.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get the selected DepartmentID
                Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

                var s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();

                //process the delete
                conn.Students.Remove(s);
                conn.SaveChanges();

                //update the grid
                GetStudents();
            }
        }
    }
}