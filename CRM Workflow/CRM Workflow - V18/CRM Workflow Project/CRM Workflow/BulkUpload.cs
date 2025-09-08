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

namespace CRM_Workflow
{
    public partial class BulkUpload : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        
        public BulkUpload()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }

        //public string convertQuotes(string str)
        //{
        //    return str.Replace("'", "''");
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.filepath.Text = openFileDialog1.FileName;
            }
        }
        public void display_bulkupload()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select RequestType,ReceivedDate,PartyName,TypeOfParty,AssociateName,RequestorEmailAddress,WFT_RequestID from dbo.tbl_crm_bulkupload_dotnet with(nolock)";
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            button4.Enabled = false;
        }

        public void display_bulkupload_projects()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select RequestType,ReceivedDate,PartyName,AssociateName,PartyLocation,TypeOfParty,RequestorBusinessUnit,RequestorSegmentName,RequestorEmailAddress,RequestorOffice,UpdatedLegalEntityName,CompletionDate,ValidationSource from dbo.tbl_crm_bulkupload_projects_dotnet_v1 with(nolock)";
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(worksheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                try
                {
                    button4.Enabled = true;
                    string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                    OleDbConnection conn = new OleDbConnection(pathconn);
                    OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + worksheetname.Text + "$]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
        }

        private void BulkUpload_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dRDDataSet10.tbl_crm_bulkupload_projects_dotnet_v1' table. You can move, or remove it, as needed.
            //this.tbl_crm_bulkupload_projects_dotnet_v1TableAdapter.Fill(this.dRDDataSet10.tbl_crm_bulkupload_projects_dotnet_v1);
            // TODO: This line of code loads data into the 'dRDDataSet6.tbl_crm_bulkupload_projects_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_bulkupload_projects_dotnetTableAdapter.Fill(this.dRDDataSet6.tbl_crm_bulkupload_projects_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet5.tbl_crm_bulkupload_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_bulkupload_dotnetTableAdapter.Fill(this.dRDDataSet5.tbl_crm_bulkupload_dotnet);
            button4.Enabled = false;
            button6.Enabled = false;
            display_bulkupload();
            display_bulkupload_projects();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "truncate table tbl_crm_bulkupload_dotnet";
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cmd.CommandText = "insert into dbo.tbl_crm_bulkupload_dotnet (RequestType,ReceivedDate,PartyName,TypeOfParty,AssociateName,RequestorEmailAddress,WFT_RequestID) values('" + row.Cells["txtRequestType"].Value + "','" + Convert.ToDateTime(row.Cells["txtReceivedDate"].Value) + "','" + row.Cells["txtPartyName"].Value + "','" + row.Cells["txtTypeOfParty"].Value + "','" + row.Cells["txtAssociateName"].Value + "','" + row.Cells["txtRequestorEmailAddress"].Value + "','" + row.Cells["txtWFT_RequestID"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                //cmd.Parameters.Clear();
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    cmd.CommandText = "insert into tbl_crm_bulkupload_dotnet (RequestType,ReceivedDate,PartyName,TypeOfParty) values(@requesttypeparam,@receiveddateparam,@partynameparam,@typeofpartyparam)";
                //    cmd.Parameters.AddWithValue("@requesttypeparam", row.Cells["requestTypeDataGridViewTextBoxColumn"].Value);
                //    cmd.Parameters.AddWithValue("@receiveddateparam", Convert.ToDateTime(row.Cells["receivedDateDataGridViewTextBoxColumn"].Value));
                //    cmd.Parameters.AddWithValue("@partynameparam", row.Cells["partyNameDataGridViewTextBoxColumn"].Value);
                //    cmd.Parameters.AddWithValue("@typeofpartyparam", row.Cells["typeOfPartyDataGridViewTextBoxColumn"].Value);
                //    cmd.ExecuteNonQuery();
                //}


                int numrows = dataGridView1.Rows.Count - 1;

                cmd.CommandText = "execute usp_insert_crm_bulkupload_dotnet @LastUpdatedDateTime,@LastUpdatedBy,@MachineName";
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime",DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rows Uploaded and Inserted Successfully in the final table" + "(" + numrows.ToString() + ")");



                cmd.CommandText = "truncate table dbo.tbl_crm_bulkupload_dotnet";
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.CommandText = "select RequestType,ReceivedDate,PartyName,TypeOfParty,AssociateName,RequestorEmailAddress,WFT_RequestID from dbo.tbl_crm_bulkupload_dotnet with(nolock)";
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Rows uploaded unsuccessfully");
                MessageBox.Show("Error Generated Details" + ab.ToString());
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "truncate table dbo.tbl_crm_bulkupload_dotnet";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            display_bulkupload();
        }

        //private string convertQuotes(object p)
        //{
        //    throw new NotImplementedException();
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(worksheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                try
                {
                    //dataGridView2.Visible = true;
                    button6.Enabled = true;
                    string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                    OleDbConnection conn = new OleDbConnection(pathconn);
                    OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + worksheetname.Text + "$]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "truncate table dbo.tbl_crm_bulkupload_projects_dotnet_v1";
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    cmd.CommandText = "insert into dbo.tbl_crm_bulkupload_projects_dotnet_v1 (RequestType,ReceivedDate,PartyName,AssociateName,PartyLocation,TypeOfParty,RequestorBusinessUnit,RequestorSegmentName,RequestorEmailAddress,RequestorOffice,UpdatedLegalEntityName,CompletionDate,ValidationSource,WFT_RequestID) values('" + row.Cells[0].Value + "','" + Convert.ToDateTime(row.Cells[1].Value) + "','" + row.Cells[2].Value + "','" + row.Cells[3].Value + "','" + row.Cells[4].Value + "','" + row.Cells[5].Value + "','" + row.Cells[6].Value + "','" + row.Cells[7].Value + "','" + row.Cells[8].Value + "','" + row.Cells[9].Value + "','" + row.Cells[10].Value + "','" + Convert.ToDateTime(row.Cells[11].Value) + "','" + row.Cells[12].Value + "','" + row.Cells[13].Value + "')";
                    //cmd.Parameters.Clear();
                    //cmd.CommandText = "insert into tbl_crm_bulkupload_projects_dotnet_v1 (RequestType,ReceivedDate,PartyName,AssociateName,PartyLocation,TypeOfParty,RequestorBusinessUnit,RequestorSegmentName,RequestorEmailAddress,RequestorOffice,UpdatedLegalEntityName,CompletionDate,ValidationSource) values(@param0,@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12)";
                    //if (row.Cells[0].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param0", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param0", row.Cells[0].Value);
                    //}
                    //cmd.Parameters.AddWithValue("@param1", Convert.ToDateTime(row.Cells[1].Value));
                    //if (row.Cells[2].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param2", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param2", row.Cells[2].Value);
                    //}
                    //if (row.Cells[3].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param3", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param3", row.Cells[3].Value);
                    //}
                    //if (row.Cells[4].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param4", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param4", row.Cells[4].Value);
                    //}
                    //if (row.Cells[5].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param5", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param5", row.Cells[5].Value);
                    //}
                    //if (row.Cells[6].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param6", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param6", row.Cells[6].Value);
                    //}
                    //if (row.Cells[7].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param7", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param7", row.Cells[7].Value);
                    //}
                    //if (row.Cells[8].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param8", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param8", row.Cells[8].Value);
                    //}
                    //if (row.Cells[9].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param9", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param9", row.Cells[9].Value);
                    //}
                    //if (row.Cells[10].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param10", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param10", row.Cells[10].Value);
                    //}
                    //cmd.Parameters.AddWithValue("@param11", Convert.ToDateTime(row.Cells[11].Value));
                    //if (row.Cells[12].Value == string.Empty)
                    //{
                    //    cmd.Parameters.AddWithValue("@param12", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@param12", row.Cells[12].Value);
                    //}

                    cmd.ExecuteNonQuery();
                }
                int numrows = dataGridView2.Rows.Count - 1;
                cmd.CommandText = "execute dbo.usp_insert_crm_bulkupload_projects_dotnet_v1 @LastUpdatedDateTime,@LastUpdatedBy,@MachineName";
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime",DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rows Uploaded and Inserted Successfully in the final table" + "(" + numrows.ToString() + ")");



                cmd.CommandText = "truncate table dbo.tbl_crm_bulkupload_projects_dotnet_v1";
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.CommandText = "select RequestType,ReceivedDate,PartyName,AssociateName,PartyLocation,TypeOfParty,RequestorBusinessUnit,RequestorSegmentName,RequestorEmailAddress,RequestorOffice,UpdatedLegalEntityName,CompletionDate,ValidationSource,WFT_RequestID from dbo.tbl_crm_bulkupload_projects_dotnet_v1 with(nolock)";
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();



            }
            catch (Exception ab)
            {
                MessageBox.Show("Rows uploaded unsuccessfully");
                MessageBox.Show("Error Generated Details" + ab.ToString());
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "truncate table dbo.tbl_crm_bulkupload_projects_dotnet_v1";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            display_bulkupload_projects();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://wtwonlineap.sharepoint.com/sites/tctnonclient_edskycoms/Documents/Forms/All%20Documents.aspx?id=%2Fsites%2Ftctnonclient%5Fedskycoms%2FDocuments%2FWorkflow%2FEDS%20%2D%20Dot%20Net%20Workflows%2FCRM%2FUpload%20Templates&viewid=9f41f8f4%2Dcfdf%2D4ddb%2Db6fa%2Dc825bd64240c");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        //private void tblcrmbulkuploadprojectsdotnetv1BindingSource_CurrentChanged(object sender, EventArgs e)
        //{

        //}
    }
}
