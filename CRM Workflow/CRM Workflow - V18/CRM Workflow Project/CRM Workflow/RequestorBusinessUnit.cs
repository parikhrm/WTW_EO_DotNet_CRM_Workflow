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
    class RequestorBusinessUnit
    {
        public void requestorbusinessunit_list(DataTable dta)
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
                //cmd.CommandText = "select NewBU from dbo.tbl_BUMappings_May2018onwards with(nolock) where 1=1 order by NewBU asc";
                //cmd.CommandText = "select distinct RequestorBusinessUnit as NewBU from dbo.vw_crm_daily_dotnet where 1=1 and RequestorBusinessUnit is not null order by RequestorBusinessUnit asc";
                cmd.CommandText = "select distinct Business_Unit as NewBU from dbo.vw_Globaldirectory_Upload_New where 1=1 and Business_Unit is not null order by Business_Unit asc";
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
