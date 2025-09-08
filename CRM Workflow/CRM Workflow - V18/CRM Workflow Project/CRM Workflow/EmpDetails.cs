using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace CRM_Workflow
{
    class EmpDetails
    {
        public void empdetails_accesscheck_list(DataTable dta, string intid)
        {
            //string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select * from vw_emp_details_dotnet where [Admin Level] = 'Associate' and process not like '%Batch%' order by EmpName asc";
                cmd.CommandText = "select * from dbo.vw_emp_details_dotnet where intid_new = @intid";
                cmd.Parameters.AddWithValue("@intid",intid);
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }
    }
}
