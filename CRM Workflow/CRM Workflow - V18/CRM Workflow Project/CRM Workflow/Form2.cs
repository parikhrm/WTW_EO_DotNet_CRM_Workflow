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
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.IO;

namespace CRM_Workflow
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            reset_overall();
            roletype_list();
            partylocation_list();
            queryresolvedby_list();
            segmentname_list();
            bu_list();
            datagridview_display_overall();
        }

        private void associatename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                associatename.SelectedIndex = -1;
            }
        }

        private void receiveddate_ValueChanged(object sender, EventArgs e)
        {
            receiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void receiveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                receiveddate.CustomFormat = " ";
            }
        }

        private void receivedtime_ValueChanged(object sender, EventArgs e)
        {
            //receivedtime.Text = DateTime.Now.ToLongTimeString();
            //receivedtime.CustomFormat = "HH:mm:ss";
        }

        private void receivedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                receivedtime.CustomFormat = " ";
            }
        }

        private void requestorbusinessunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                requestorbusinessunit.SelectedIndex = -1;
            }
        }

        private void roletype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                roletype.SelectedIndex = -1;
            }
        }

        private void partylocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                partylocation.SelectedIndex = -1;
            }
        }

        private void queryraiseddate_ValueChanged(object sender, EventArgs e)
        {
            queryraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void queryraiseddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryraiseddate.CustomFormat = " ";
            }
        }

        private void queryraisedtime_ValueChanged(object sender, EventArgs e)
        {
            //queryraisedtime.Text = DateTime.Now.ToLongTimeString();
            //queryraisedtime.CustomFormat = "HH:mm:ss";
        }

        private void queryraisedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryraisedtime.CustomFormat = " ";
            }
        }

        private void queryresolveddate_ValueChanged(object sender, EventArgs e)
        {
            queryresolveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void queryresolveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryresolveddate.CustomFormat = " ";
            }
        }

        private void queryresolvedtime_ValueChanged(object sender, EventArgs e)
        {
            //queryresolvedtime.Text = DateTime.Now.ToLongTimeString();
            //queryresolvedtime.CustomFormat = "HH:mm:ss";
        }

        private void queryresolvedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryresolvedtime.CustomFormat = " ";
            }
        }

        private void queryresolvedby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryresolvedby.SelectedIndex = -1;
            }
        }

        private void completiondate_ValueChanged(object sender, EventArgs e)
        {
            completiondate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completiondate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completiondate.CustomFormat = " ";
            }
        }

        private void completiontime_ValueChanged(object sender, EventArgs e)
        {
            //completiontime.Text = DateTime.Now.ToLongTimeString();
            //completiontime.CustomFormat = "HH:mm:ss";
        }

        private void completiontime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completiontime.CustomFormat = " ";
            }
        }

        private void segmentname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                segmentname.SelectedIndex = -1;
            }
        }

        public void reset_overall()
        {
            todaydate.Visible = false;
            todaydate.Text = DateTime.Now.ToLongDateString();
            associatename_list();
            //roletype_list();
            //partylocation_list();
            //queryresolvedby_list();
            //segmentname_list();
            //bu_list();
            roletype.SelectedIndex = -1;
            partylocation.SelectedIndex = -1;
            queryresolvedby.SelectedIndex = -1;
            segmentname.SelectedIndex = -1;
            requestorbusinessunit.SelectedIndex = -1;
            requestid.Enabled = false;
            requestid.Text = string.Empty;
            associatename.SelectedIndex = -1;
            requestoremailaddress.Text = string.Empty;
            subject.Text = string.Empty;
            partyname.Text = string.Empty;
            receiveddate.CustomFormat = " ";
            receivedtime.CustomFormat = " ";
            queryraiseddate.CustomFormat = " ";
            queryraisedtime.CustomFormat = " ";
            queryresolveddate.CustomFormat = " ";
            queryresolvedtime.CustomFormat = " ";
            queryresolvedby.SelectedIndex = -1;
            completiondate.CustomFormat = " ";
            completiontime.CustomFormat = " ";
            comments.Text = string.Empty;
            isdeleted.Visible = false;
            isdeleted.Value = 0;
            insert.Enabled = true;
            update.Enabled = false;
            //datagridview_display_overall();
        }

        public void associatename_list()
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //conn.ConnectionString = connectionstringtxt;
            //cmd.Connection = conn;
            //conn.Open();
            //cmd.CommandText = "select * from tbl_crm_associatename_dotnet with(nolock) order by associatename asc ";
            //sda.SelectCommand = cmd;
            //sda.Fill(dt);
            //associatename.DataSource = dt;
            //associatename.DisplayMember = "AssociateName";
            //conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                AssociateName obj_associatename = new AssociateName();
                DataTable dtaa = new DataTable();
                obj_associatename.associatename_list(dtaa);
                associatename.DataSource = dtaa;
                associatename.DisplayMember = "AssociateName";
                conn.Close();
                associatename.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }



        public void datagridview_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "select * from dbo.tbl_dms_daily_dotnet with(nolock) where isdeleted = 0 order by RequestID asc ";
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void roletype_list()
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //conn.ConnectionString = connectionstringtxt;
            //cmd.Connection = conn;
            //conn.Open();
            //cmd.CommandText = "select * from tbl_cvt_Role_dotnet with(nolock) order by role asc ";
            //sda.SelectCommand = cmd;
            //sda.Fill(dt);
            //roletype.DataSource = dt;
            //roletype.DisplayMember = "Role";
            //conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                RoleType obj_roletype = new RoleType();
                DataTable dtaa = new DataTable();
                obj_roletype.roletype_list(dtaa);
                roletype.DataSource = dtaa;
                roletype.DisplayMember = "Role";
                conn.Close();
                roletype.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void partylocation_list()
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //conn.ConnectionString = connectionstringtxt;
            //cmd.Connection = conn;
            //conn.Open();
            //cmd.CommandText = "select * from tbl_partylocation_dotnet with(nolock) order by [Party Location] asc ";
            //sda.SelectCommand = cmd;
            //sda.Fill(dt);
            //partylocation.DataSource = dt;
            //partylocation.DisplayMember = "Party Location";
            //conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                PartyLocation obj_partylocation = new PartyLocation();
                DataTable dtaa = new DataTable();
                obj_partylocation.partylocation_list(dtaa);
                partylocation.DataSource = dtaa;
                partylocation.DisplayMember = "Party Location";
                conn.Close();
                partylocation.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void queryresolvedby_list()
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //conn.ConnectionString = connectionstringtxt;
            //cmd.Connection = conn;
            //conn.Open();
            //cmd.CommandText = "select * from tbl_crm_queryresolvedby_dotnet with(nolock) order by QueryResolvedBy asc ";
            //sda.SelectCommand = cmd;
            //sda.Fill(dt);
            //queryresolvedby.DataSource = dt;
            //queryresolvedby.DisplayMember = "QueryResolvedBy";
            //conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                QueryResolvedBy obj_queryresolvedby = new QueryResolvedBy();
                DataTable dtaa = new DataTable();
                obj_queryresolvedby.queryresolvedby_list(dtaa);
                queryresolvedby.DataSource = dtaa;
                queryresolvedby.DisplayMember = "QueryResolvedBy";
                conn.Close();
                queryresolvedby.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void segmentname_list()
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //conn.ConnectionString = connectionstringtxt;
            //cmd.Connection = conn;
            //conn.Open();
            //cmd.CommandText = "select * from tbl_segmentname_dotnet with(nolock) order by SegmentName asc ";
            //sda.SelectCommand = cmd;
            //sda.Fill(dt);
            //segmentname.DataSource = dt;
            //segmentname.DisplayMember = "SegmentName";
            //conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SegmentName obj_segmentname = new SegmentName();
                DataTable dtaa = new DataTable();
                obj_segmentname.segmentname_list(dtaa);
                segmentname.DataSource = dtaa;
                segmentname.DisplayMember = "SegmentName";
                conn.Close();
                segmentname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void bu_list()
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //SqlDataAdapter sda = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //conn.ConnectionString = connectionstringtxt;
            //cmd.Connection = conn;
            //conn.Open();
            //cmd.CommandText = "select * from tbl_dms_bu_dotnet with(nolock) order by BU asc ";
            //sda.SelectCommand = cmd;
            //sda.Fill(dt);
            //requestorbusinessunit.DataSource = dt;
            //requestorbusinessunit.DisplayMember = "BU";
            //conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DMS_BUs obj_bu = new DMS_BUs();
                DataTable dtaa = new DataTable();
                obj_bu.bu_list(dtaa);
                requestorbusinessunit.DataSource = dtaa;
                requestorbusinessunit.DisplayMember = "BU";
                conn.Close();
                requestorbusinessunit.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj1 = new Form1();
            obj1.Show();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandText = "insert into dbo.tbl_dms_daily_dotnet(AssociateName,RequestorEmailAddress,Subject,PartyName,ReceivedDate,ReceivedTime,RequestorBusinessUnit,RoleType,PartyLocation,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryResolvedBy,CompletionDate,CompletionTime,SegmentName,Comments,LastUpdatedBy,LastUpdatedDateTime,MachineName,IsDeleted) values (@AssociateNameparam,@RequestorEmailAddressparam,@Subjectparam,@PartyNameparam,@ReceivedDateparam,@ReceivedTimeparam,@RequestorBusinessUnitparam,@RoleTypeparam,@PartyLocationparam,@QueryRaisedDateparam,@QueryRaisedTimeparam,@QueryResolvedDateparam,@QueryResolvedTimeparam,@QueryResolvedByparam,@CompletionDateparam,@CompletionTimeparam,@SegmentNameparam,@Commentsparam,@LastUpdatedByparam,@LastUpdatedDateTimeparam,@MachineNameparam,@IsDeletedparam) ";
                cmd.Parameters.AddWithValue("@AssociateNameparam",associatename.Text);
                cmd.Parameters.AddWithValue("@RequestorEmailAddressparam",requestoremailaddress.Text);
                cmd.Parameters.AddWithValue("@Subjectparam",subject.Text);
                cmd.Parameters.AddWithValue("@PartyNameparam",partyname.Text);
                cmd.Parameters.AddWithValue("@ReceivedDateparam",receiveddate.Value.Date);
                cmd.Parameters.AddWithValue("@ReceivedTimeparam",receivedtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@RequestorBusinessUnitparam",requestorbusinessunit.Text);
                cmd.Parameters.AddWithValue("@RoleTypeparam",roletype.Text);
                cmd.Parameters.AddWithValue("@PartyLocationparam",partylocation.Text);
                if (queryraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDateparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDateparam", queryraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", queryraisedtime.Value.ToLongTimeString());
                }
                if (queryresolveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDateparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryResolvedByparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDateparam", queryresolveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", queryresolvedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@QueryResolvedByparam", queryresolvedby.Text);
                }
                if (completiondate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CompletionDateparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompletionTimeparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CompletionDateparam", completiondate.Value.Date);
                    cmd.Parameters.AddWithValue("@CompletionTimeparam", completiontime.Value.ToLongTimeString());
                }
                cmd.Parameters.AddWithValue("@SegmentNameparam",segmentname.Text);
                if (string.IsNullOrEmpty(comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Commentsparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Commentsparam", comments.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedByparam",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@LastUpdatedDateTimeparam",DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@MachineNameparam",Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@IsDeletedparam",isdeleted.Value);

                //If Conditions
                if (receiveddate.Value.Date > todaydate.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be greater than today's date");
                }
                else if (receiveddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Date");
                }
                else if (receivedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Time");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Time");
                }
                else if(queryraiseddate.Text.Trim() == string.Empty && queryraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryresolvedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Time");
                }
                else if (queryresolveddate.Text.Trim() == string.Empty && queryresolvedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else if (completiondate.Text.Trim() != string.Empty && completiontime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Time");
                }
                else if (completiondate.Text.Trim() == string.Empty && completiontime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if (string.IsNullOrEmpty(associatename.Text))
                {
                    MessageBox.Show("Please update Associate Name");
                }
                else if (string.IsNullOrEmpty(subject.Text))
                {
                    MessageBox.Show("Please update Subject");
                }
                else if (string.IsNullOrEmpty(partyname.Text))
                {
                    MessageBox.Show("Please update Party Name");
                }
                else if (string.IsNullOrEmpty(requestorbusinessunit.Text))
                {
                    MessageBox.Show("Please update Requestor Business Unit");
                }
                else if (string.IsNullOrEmpty(roletype.Text))
                {
                    MessageBox.Show("Please update Role Type");
                }
                else if (string.IsNullOrEmpty(partylocation.Text))
                {
                    MessageBox.Show("Please update Party Location");
                }
                else if (string.IsNullOrEmpty(segmentname.Text))
                {
                    MessageBox.Show("Please update Segment Name");
                }
                else if (queryraiseddate.Value.Date > todaydate.Value.Date && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Query Raised Date cannot be greater than Today's date");
                }
                else if (queryraiseddate.Value.Date < receiveddate.Value.Date && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Received Date and Query Raised Date");
                }
                else if (queryresolveddate.Value.Date > todaydate.Value.Date && queryresolveddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Query Resolved Date cannot be greater than Today's date");
                }
                else if (queryresolveddate.Value.Date < queryraiseddate.Value.Date && queryresolveddate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Query Raised Date and Query Resolved Date");
                }
                else if (queryresolveddate.Value.Date < receiveddate.Value.Date && queryresolveddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Received Date and Query Resolved Date");
                }
                else if (completiondate.Value.Date > todaydate.Value.Date && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion Date cannot be greater then Today's date");
                }
                else if (completiondate.Value.Date < receiveddate.Value.Date && completiondate.Text.Trim() != string.Empty )
                {
                    MessageBox.Show("Please check Received Date anc Completion Date");
                }
                else if (completiondate.Value.Date < queryraiseddate.Value.Date && completiondate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Query Raised Date and Completion Date");
                }
                else if (completiondate.Value.Date < queryresolveddate.Value.Date && completiondate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Query Resolved Date and Completion Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(queryresolvedby.Text))
                {
                    MessageBox.Show("Please update Query Resolved By");
                }
                else if (completiondate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Records Inserted Successfully");
                    cmd.Parameters.Clear();
                    reset_overall();
                }
            }
            catch(Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string messsage = "Do you want to update the record?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                        requestid.Text = row.Cells["txtrequestid"].Value.ToString();
                        associatename.Text = row.Cells["txtassociatename"].Value.ToString();
                        requestoremailaddress.Text = row.Cells["txtrequestoremailaddress"].Value.ToString();
                        subject.Text = row.Cells["txtsubject"].Value.ToString();
                        partyname.Text = row.Cells["txtpartyname"].Value.ToString();
                        receiveddate.CustomFormat = "dd-MMMM-yyyy";
                        receiveddate.Text = row.Cells["dtreceiveddate"].Value.ToString();
                        receivedtime.CustomFormat = "HH:mm:ss";
                        receivedtime.Text = row.Cells["dtreceivedtime"].Value.ToString();
                        requestorbusinessunit.Text = row.Cells["txtrequestorbusinessunit"].Value.ToString();
                        roletype.Text = row.Cells["txtroletype"].Value.ToString();
                        partylocation.Text = row.Cells["txtpartylocation"].Value.ToString();
                        if (string.IsNullOrEmpty(row.Cells["dtqueryraiseddate"].Value.ToString()))
                        {
                            queryraiseddate.CustomFormat = " ";
                            queryraisedtime.CustomFormat = " ";
                        }
                        else
                        {
                            queryraiseddate.CustomFormat = "dd-MMMM-yyyy";
                            queryraiseddate.Text = row.Cells["dtqueryraiseddate"].Value.ToString();
                            queryraisedtime.CustomFormat = "HH:mm:ss";
                            queryraisedtime.Text = row.Cells["dtqueryraisedtime"].Value.ToString();
                        }
                        if (string.IsNullOrEmpty(row.Cells["dtqueryresolveddate"].Value.ToString()))
                        {
                            queryresolvedby.SelectedIndex = -1;
                            queryresolveddate.CustomFormat = " ";
                            queryresolvedtime.CustomFormat = " ";
                        }
                        else
                        {
                            queryresolveddate.CustomFormat = "dd-MMMM-yyyy";
                            queryresolveddate.Text = row.Cells["dtqueryresolveddate"].Value.ToString();
                            queryresolvedtime.CustomFormat = "HH:mm:ss";
                            queryresolvedtime.Text = row.Cells["dtqueryresolvedtime"].Value.ToString();
                            queryresolvedby.Text = row.Cells["txtqueryresolvedby"].Value.ToString();
                        }
                        if (string.IsNullOrEmpty(row.Cells["dtcompletiondate"].Value.ToString()))
                        {
                            completiondate.CustomFormat = " ";
                            completiontime.CustomFormat = " ";
                        }
                        else
                        {
                            completiondate.CustomFormat = "dd-MMMM-yyyy";
                            completiondate.Text = row.Cells["dtcompletiondate"].Value.ToString();
                            completiontime.CustomFormat = "HH:mm:ss";
                            completiontime.Text = row.Cells["dtcompletiontime"].Value.ToString();
                        }
                        segmentname.Text = row.Cells["txtsegmentname"].Value.ToString();
                        comments.Text = row.Cells["txtcomments"].Value.ToString();
                        insert.Enabled = false;
                        update.Enabled = true;
                    }
                    else
                    {
                        requestid.Focus();
                    }
                }
            }
            catch(Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(myrow.Cells["dtcompletiondate"].Value.ToString()))
                {
                    myrow.DefaultCellStyle.BackColor = Color.ForestGreen;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchbypartyname.Text))
            {
                datagridview_display_overall();
            }
            else
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from dbo.tbl_dms_daily_dotnet with(nolock) where isdeleted = 0 and partyname like @partynameparam order by RequestID asc ";
                cmd.Parameters.AddWithValue("@partynameparam", "%" + searchbypartyname.Text + "%");
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandText = "update dbo.tbl_dms_daily_dotnet set AssociateName=@AssociateNameparam,RequestorEmailAddress=@RequestorEmailAddressparam,Subject=@Subjectparam,PartyName=@PartyNameparam,ReceivedDate=@ReceivedDateparam,ReceivedTime=@ReceivedTimeparam,RequestorBusinessUnit=@RequestorBusinessUnitparam,RoleType=@RoleTypeparam,PartyLocation=@PartyLocationparam,QueryRaisedDate=@QueryRaisedDateparam,QueryRaisedTime=@QueryRaisedTimeparam,QueryResolvedDate=@QueryResolvedDateparam,QueryResolvedTime=@QueryResolvedTimeparam,QueryResolvedBy=@QueryResolvedByparam,CompletionDate=@CompletionDateparam,CompletionTime=@CompletionTimeparam,SegmentName=@SegmentNameparam,Comments=@Commentsparam,LastUpdatedBy=@LastUpdatedByparam,LastUpdatedDateTime=@LastUpdatedDateTimeparam,MachineName=@MachineNameparam,IsDeleted=@IsDeletedparam where RequestID=@RequestIDparam";
                cmd.Parameters.AddWithValue("@RequestIDparam", requestid.Text);
                cmd.Parameters.AddWithValue("@AssociateNameparam", associatename.Text);
                cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", requestoremailaddress.Text);
                cmd.Parameters.AddWithValue("@Subjectparam", subject.Text);
                cmd.Parameters.AddWithValue("@PartyNameparam", partyname.Text);
                cmd.Parameters.AddWithValue("@ReceivedDateparam", receiveddate.Value.Date);
                cmd.Parameters.AddWithValue("@ReceivedTimeparam", receivedtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@RequestorBusinessUnitparam", requestorbusinessunit.Text);
                cmd.Parameters.AddWithValue("@RoleTypeparam", roletype.Text);
                cmd.Parameters.AddWithValue("@PartyLocationparam", partylocation.Text);
                if (queryraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDateparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDateparam", queryraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", queryraisedtime.Value.ToLongTimeString());
                }
                if (queryresolveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDateparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryResolvedByparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDateparam", queryresolveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", queryresolvedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@QueryResolvedByparam", queryresolvedby.Text);
                }
                if (completiondate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CompletionDateparam", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompletionTimeparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CompletionDateparam", completiondate.Value.Date);
                    cmd.Parameters.AddWithValue("@CompletionTimeparam", completiontime.Value.ToLongTimeString());
                }
                cmd.Parameters.AddWithValue("@SegmentNameparam", segmentname.Text);
                if (string.IsNullOrEmpty(comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Commentsparam", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Commentsparam", comments.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedByparam", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@LastUpdatedDateTimeparam", DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@MachineNameparam", Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@IsDeletedparam", isdeleted.Value);

                //If Conditions
                if (receiveddate.Value.Date > todaydate.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be greater than today's date");
                }
                else if (receiveddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Date");
                }
                else if (receivedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Time");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Time");
                }
                else if (queryraiseddate.Text.Trim() == string.Empty && queryraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryresolvedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Time");
                }
                else if (queryresolveddate.Text.Trim() == string.Empty && queryresolvedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else if (completiondate.Text.Trim() != string.Empty && completiontime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Time");
                }
                else if (completiondate.Text.Trim() == string.Empty && completiontime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if (string.IsNullOrEmpty(associatename.Text))
                {
                    MessageBox.Show("Please update Associate Name");
                }
                else if (string.IsNullOrEmpty(subject.Text))
                {
                    MessageBox.Show("Please update Subject");
                }
                else if (string.IsNullOrEmpty(partyname.Text))
                {
                    MessageBox.Show("Please update Party Name");
                }
                else if (string.IsNullOrEmpty(requestorbusinessunit.Text))
                {
                    MessageBox.Show("Please update Requestor Business Unit");
                }
                else if (string.IsNullOrEmpty(roletype.Text))
                {
                    MessageBox.Show("Please update Role Type");
                }
                else if (string.IsNullOrEmpty(partylocation.Text))
                {
                    MessageBox.Show("Please update Party Location");
                }
                else if (string.IsNullOrEmpty(segmentname.Text))
                {
                    MessageBox.Show("Please update Segment Name");
                }
                else if (queryraiseddate.Value.Date > todaydate.Value.Date && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Query Raised Date cannot be greater than Today's date");
                }
                else if (queryraiseddate.Value.Date < receiveddate.Value.Date && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Received Date and Query Raised Date");
                }
                else if (queryresolveddate.Value.Date > todaydate.Value.Date && queryresolveddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Query Resolved Date cannot be greater than Today's date");
                }
                else if (queryresolveddate.Value.Date < queryraiseddate.Value.Date && queryresolveddate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Query Raised Date and Query Resolved Date");
                }
                else if (queryresolveddate.Value.Date < receiveddate.Value.Date && queryresolveddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Received Date and Query Resolved Date");
                }
                else if (completiondate.Value.Date > todaydate.Value.Date && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion Date cannot be greater then Today's date");
                }
                else if (completiondate.Value.Date < receiveddate.Value.Date && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Received Date anc Completion Date");
                }
                else if (completiondate.Value.Date < queryraiseddate.Value.Date && completiondate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Query Raised Date and Completion Date");
                }
                else if (completiondate.Value.Date < queryresolveddate.Value.Date && completiondate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please check Query Resolved Date and Completion Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(queryresolvedby.Text))
                {
                    MessageBox.Show("Please update Query Resolved By");
                }
                else if (completiondate.Text.Trim() != string.Empty && queryraiseddate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Records Updated Successfully");
                    cmd.Parameters.Clear();
                    reset_overall();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_DMS_Daily_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void receivedtime_MouseDown(object sender, MouseEventArgs e)
        {
            receivedtime.Text = DateTime.Now.ToLongTimeString();
            receivedtime.CustomFormat = "HH:mm:ss";
        }

        private void queryraisedtime_MouseDown(object sender, MouseEventArgs e)
        {
            queryraisedtime.Text = DateTime.Now.ToLongTimeString();
            queryraisedtime.CustomFormat = "HH:mm:ss";
        }

        private void queryresolvedtime_MouseDown(object sender, MouseEventArgs e)
        {
            queryresolvedtime.Text = DateTime.Now.ToLongTimeString();
            queryresolvedtime.CustomFormat = "HH:mm:ss";
        }

        private void completiontime_MouseDown(object sender, MouseEventArgs e)
        {
            completiontime.Text = DateTime.Now.ToLongTimeString();
            completiontime.CustomFormat = "HH:mm:ss";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }
    }
}
