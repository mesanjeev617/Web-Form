using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Card_View
{
    public partial class StaffCardView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Ds.MyStaffTableAdapters.Staff_InfoTableAdapter ta   = new Ds.MyStaffTableAdapters.Staff_InfoTableAdapter();
            Ds.MyStaff ds = new Ds.MyStaff();
            //-----------FILL DATA----------------------------------------------------
            string tmpl,path,filePath,AllTempl;
            ta.Fill(ds.Staff_Info);
            path = "~/Css/CardViewTmpl.htm";
            filePath = Server.MapPath(path);
            //--------------Return Content Of File------------------------------------
            tmpl = System.IO.File.ReadAllText(filePath, System.Text.Encoding.UTF8);
            AllTempl = "";
            //--------------Counting no of items in data table------------------------
            Int32 RowCount;
            RowCount = ds.Staff_Info.Rows.Count;
            String tmp = "";

            for(int i = 0; i < RowCount; i++)
            {
                //----------Get All the data------------------------------------------

                //----------First SB for row.. Second SB for Column-------------------
                object my_id = ds.Staff_Info.Rows[i]["id"];
                object fname = ds.Staff_Info.Rows[i]["FirstName"];
                object lname = ds.Staff_Info.Rows[i]["LastName"];
                object start_date = ds.Staff_Info.Rows[i]["StartDate"];
                object cell_number = ds.Staff_Info.Rows[i]["Cell_Number"];
                object email = ds.Staff_Info.Rows[i]["Email"];
                object photo_path = ds.Staff_Info.Rows[i]["Photo_Path"];

                //--------------DB NULL CHECKER--------------------------------------------
                if (my_id == System.DBNull.Value)
                {
                    my_id = 0;
                }
                //-------------------------------------------------------------------------
                if (fname == System.DBNull.Value)
                {
                    fname = "---";
                }
                //-------------------------------------------------------------------------
                if (lname == System.DBNull.Value)
                {
                    lname = "---";
                }
                //-------------------------------------------------------------------------
                if (start_date == System.DBNull.Value)
                {
                    start_date = "---";
                }
                else
                {
                    DateTime MyDate;
                    MyDate = Convert.ToDateTime(start_date);
                    //--------------
                    String y, m, d;
                    y= MyDate.Year.ToString();
                    m= MyDate.Month.ToString();
                    d= MyDate.Day.ToString();
                    //---------------------
                    start_date = d + "-" + m + "-" + y;
                }
                //-------------------------------------------------------------------------
                if (cell_number == System.DBNull.Value)
                {
                    cell_number = "---";
                }
                //-------------------------------------------------------------------------
                if (email == System.DBNull.Value)
                {
                    email = "---";
                }
                //-------------------------------------------------------------------------
                if (photo_path == System.DBNull.Value)
                {
                    //-----Default photo---------------
                    photo_path = "pics/Empty.png";
                }
                //--------------------Fname & Lname----------------------------------------
                string fullname = fname.ToString() + " " + lname.ToString();
                tmp = tmpl.Replace("Full_Name_PlaceHolder", fullname);

                //--------------------Start Date-------------------------------------------
                tmp = tmp.Replace("Start_Date_PlaceHolder", "Start Date: "+start_date.ToString());

                //--------------------Cell Number -----------------------------------------
                tmp = tmp.Replace("Cell_Number_PlaceHolder", cell_number.ToString());

                //--------------------Email----- ------------------------------------------
                tmp = tmp.Replace("Email_PlaceHolder", email.ToString());

                //--------------------Photo Path------------------------------------------------
                tmp = tmp.Replace("pics_placeholder", photo_path.ToString());

                AllTempl = AllTempl + tmp;
            }
            
            //-----------------------------------------------------------------------------
            this.FlexMainContainer.InnerHtml = AllTempl;
        }
    }
}