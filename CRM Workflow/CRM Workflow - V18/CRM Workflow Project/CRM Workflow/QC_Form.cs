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
    public partial class QC_Form : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";

        public QC_Form()
        {
            InitializeComponent();
        }

        private void QC_Form_Load(object sender, EventArgs e)
        {
            overallstatus_list();
            associatename_list();
            qc_typeoferror_list();
            qualityparameters_list();
            reset_overall();
        }

        public void reset_overall()
        {
            id.Text = string.Empty;
            id.Enabled = false;
            crmrequestid.Text = string.Empty;
            qc_doneby.SelectedIndex = -1;
            qc_associatename.SelectedIndex = -1;
            qc_overallstatus.SelectedIndex = -1;
            qc_typeoferror.SelectedIndex = -1;
            for (int i = 0; i < qc_qualityparameters.Items.Count; i++)
            {
                qc_qualityparameters.SetItemChecked(i, false);
            }
            qc_comlpetiondate.CustomFormat = " ";
            qc_startdate.CustomFormat = "dd-MMMM-yyyy";
            insert.Enabled = true;
            update.Enabled = false;
            datagridview_display_overall();
        }

        public void overallstatus_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Status obj_status = new Status();
                DataTable dtaa = new DataTable();

                obj_status.status_list(dtaa);
                qc_overallstatus.DataSource = dtaa;
                qc_overallstatus.DisplayMember = "Status";
                conn.Close();
                qc_overallstatus.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void associatename_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            AssociateName obj_associatename = new AssociateName();

            DataTable dtaa = new DataTable();
            DataTable dtaa1 = new DataTable();

            obj_associatename.associatename_list(dtaa);
            qc_doneby.DataSource = dtaa;
            qc_doneby.DisplayMember = "AssociateName";

            obj_associatename.associatename_list(dtaa1);
            qc_associatename.DataSource = dtaa1;
            qc_associatename.DisplayMember = "AssociateName";

            qc_doneby.SelectedIndex = -1;
            qc_associatename.SelectedIndex = -1;
        }

        private void qc_comlpetiondate_ValueChanged(object sender, EventArgs e)
        {
            qc_comlpetiondate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void qc_comlpetiondate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                qc_comlpetiondate.CustomFormat = " ";
            }
        }

        private void qc_startdate_ValueChanged(object sender, EventArgs e)
        {
            qc_startdate.CustomFormat = "dd-MMMM-yyyy";
        }

        public void qc_typeoferror_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                TypeOfError obj_typeoferror = new TypeOfError();
                DataTable dtaa = new DataTable();
                obj_typeoferror.typeoferror_list(dtaa);
                qc_typeoferror.DataSource = dtaa;
                qc_typeoferror.DisplayMember = "TypeOfError";
                conn.Close();
                qc_typeoferror.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void qualityparameters_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                QualityParameters obj_quality = new QualityParameters();
                DataTable dtaa = new DataTable();
                DataSet ds = new DataSet();
                obj_quality.qualityparameters_list(dtaa, qc_typeoferror.Text);
                foreach (DataRow datarow in dtaa.Rows)
                {
                    qc_qualityparameters.Items.Add(datarow["QualityParameters"]);
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void qc_typeoferror_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(qc_typeoferror.Text))
            {
                qc_qualityparameters.Enabled = false;
                qc_qualityparameters.Items.Clear();
                for (int i = 0; i < qc_qualityparameters.Items.Count; i++)
                {
                    qc_qualityparameters.SetItemChecked(i, false);
                }

            }
            else
            {
                qc_qualityparameters.Enabled = true;
                qc_qualityparameters.Items.Clear();
                for (int i = 0; i < qc_qualityparameters.Items.Count; i++)
                {
                    qc_qualityparameters.SetItemChecked(i, false);
                }
                qualityparameters_list();
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to insert this record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
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
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_crm_qc_insert_daily_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@qcstartdate", qc_startdate.Value.Date);
                    if (string.IsNullOrEmpty(qc_comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@comments", qc_comments.Text);
                    }
                    if (string.IsNullOrEmpty(crmrequestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@crmrequestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@crmrequestid", crmrequestid.Text);
                    }
                    if (string.IsNullOrEmpty(qc_doneby.Text))
                    {
                        cmd.Parameters.AddWithValue("@qcdoneby", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qcdoneby", qc_doneby.Text);
                    }
                    if (string.IsNullOrEmpty(qc_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatenamefirstcheck", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatenamefirstcheck", qc_associatename.Text);
                    }
                    if (string.IsNullOrEmpty(qc_overallstatus.Text))
                    {
                        cmd.Parameters.AddWithValue("@overallstatus", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@overallstatus", qc_overallstatus.Text);
                    }
                    if (string.IsNullOrEmpty(qc_typeoferror.Text))
                    {
                        cmd.Parameters.AddWithValue("@typeoferror", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@typeoferror", qc_typeoferror.Text);
                    }
                    if (qc_qualityparameters.CheckedItems.Count != 0)
                    {
                        string qualityitems = string.Empty;
                        foreach (var checkeditem in this.qc_qualityparameters.CheckedItems)
                        {
                            qualityitems += "," + checkeditem.ToString();
                        }
                        qualityitems = qualityitems.Substring(1);
                        cmd.Parameters.AddWithValue("@qualityparameters", qualityitems);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qualityparameters", DBNull.Value);
                    }
                    if (qc_comlpetiondate.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@qcompletiondate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qcompletiondate", qc_comlpetiondate.Value.Date);
                    }
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@machinename", Environment.MachineName.ToString());

                    // if conditions
                    if (string.IsNullOrEmpty(crmrequestid.Text))
                    {
                        MessageBox.Show("Please update CRM Request ID");
                    }
                    else if (string.IsNullOrEmpty(qc_doneby.Text))
                    {
                        MessageBox.Show("Please update QC Done By");
                    }
                    else if (string.IsNullOrEmpty(qc_associatename.Text))
                    {
                        MessageBox.Show("Please update Associate Name");
                    }
                    else if (string.IsNullOrEmpty(qc_overallstatus.Text))
                    {
                        MessageBox.Show("Please update Overall Status");
                    }
                    else if (!string.IsNullOrEmpty(qc_overallstatus.Text) && qc_overallstatus.Text == "Fail" && string.IsNullOrEmpty(qc_typeoferror.Text))
                    {
                        MessageBox.Show("Please update Type Of Error");
                    }
                    else if (!string.IsNullOrEmpty(qc_overallstatus.Text) && qc_overallstatus.Text == "Pending" && string.IsNullOrEmpty(qc_typeoferror.Text))
                    {
                        MessageBox.Show("Please update Type Of Error");
                    }
                    else if (!string.IsNullOrEmpty(qc_typeoferror.Text) && qc_qualityparameters.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select quality parameters");
                    }
                    else if (qc_startdate.Value.Date > qc_comlpetiondate.Value.Date)
                    {
                        MessageBox.Show("QC Start Date cannot be more then QC Completion Date");
                    }
                    else
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        cmd.Parameters.Clear();
                        reset_overall();
                        conn.Close();
                    }
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error generated details" + ab.ToString());
                }
            }
            
        }

        private void update_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to insert this record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
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
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_crm_qc_update_daily_dotnet";
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@id", id.Text);
                    cmd.Parameters.AddWithValue("@qcstartdate", qc_startdate.Value.Date);
                    if (string.IsNullOrEmpty(qc_comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@comments", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@comments", qc_comments.Text);
                    }
                    if (string.IsNullOrEmpty(crmrequestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@crmrequestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@crmrequestid", crmrequestid.Text);
                    }
                    if (string.IsNullOrEmpty(qc_doneby.Text))
                    {
                        cmd.Parameters.AddWithValue("@qcdoneby", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qcdoneby", qc_doneby.Text);
                    }
                    if (string.IsNullOrEmpty(qc_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatenamefirstcheck", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatenamefirstcheck", qc_associatename.Text);
                    }
                    if (string.IsNullOrEmpty(qc_overallstatus.Text))
                    {
                        cmd.Parameters.AddWithValue("@overallstatus", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@overallstatus", qc_overallstatus.Text);
                    }
                    if (string.IsNullOrEmpty(qc_typeoferror.Text))
                    {
                        cmd.Parameters.AddWithValue("@typeoferror", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@typeoferror", qc_typeoferror.Text);
                    }
                    if (qc_qualityparameters.CheckedItems.Count != 0)
                    {
                        string qualityitems = string.Empty;
                        foreach (var checkeditem in this.qc_qualityparameters.CheckedItems)
                        {
                            qualityitems += "," + checkeditem.ToString();
                        }
                        qualityitems = qualityitems.Substring(1);
                        cmd.Parameters.AddWithValue("@qualityparameters", qualityitems);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qualityparameters", DBNull.Value);
                    }
                    if (qc_comlpetiondate.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@qcompletiondate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qcompletiondate", qc_comlpetiondate.Value.Date);
                    }
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@machinename", Environment.MachineName.ToString());

                    // if conditions
                    if (string.IsNullOrEmpty(crmrequestid.Text))
                    {
                        MessageBox.Show("Please update CRM Request ID");
                    }
                    else if (string.IsNullOrEmpty(qc_doneby.Text))
                    {
                        MessageBox.Show("Please update QC Done By");
                    }
                    else if (string.IsNullOrEmpty(qc_associatename.Text))
                    {
                        MessageBox.Show("Please update Associate Name");
                    }
                    else if (string.IsNullOrEmpty(qc_overallstatus.Text))
                    {
                        MessageBox.Show("Please update Overall Status");
                    }
                    else if (!string.IsNullOrEmpty(qc_overallstatus.Text) && qc_overallstatus.Text == "Fail" && string.IsNullOrEmpty(qc_typeoferror.Text))
                    {
                        MessageBox.Show("Please update Type Of Error");
                    }
                    else if (!string.IsNullOrEmpty(qc_overallstatus.Text) && qc_overallstatus.Text == "Pending" && string.IsNullOrEmpty(qc_typeoferror.Text))
                    {
                        MessageBox.Show("Please update Type Of Error");
                    }
                    else if (!string.IsNullOrEmpty(qc_typeoferror.Text) && qc_qualityparameters.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select quality parameters");
                    }
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        cmd.Parameters.Clear();
                        reset_overall();
                        conn.Close();
                    }
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error generated details" + ab.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    id.Text = row.Cells["txtID"].Value.ToString();
                    qc_startdate.Text = row.Cells["txtQC_Start_Date"].Value.ToString();
                    qc_startdate.CustomFormat = "dd-MMMM-yyyy";
                    if (string.IsNullOrEmpty(row.Cells["txtCRM_RequestID"].Value.ToString()))
                    {
                        crmrequestid.Text = string.Empty;
                    }
                    else
                    {
                        crmrequestid.Text = row.Cells["txtCRM_RequestID"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtQC_Done_By"].Value.ToString()))
                    {
                        qc_doneby.SelectedIndex = -1;
                    }
                    else
                    {
                        qc_doneby.Text = row.Cells["txtQC_Done_By"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtAssociate_Name_FirstCheck"].Value.ToString()))
                    {
                        qc_associatename.SelectedIndex = -1;
                    }
                    else
                    {
                        qc_associatename.Text = row.Cells["txtAssociate_Name_FirstCheck"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtOverall_Status"].Value.ToString()))
                    {
                        qc_overallstatus.SelectedIndex = -1;
                    }
                    else
                    {
                        qc_overallstatus.Text = row.Cells["txtOverall_Status"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtTypeOfError"].Value.ToString()))
                    {
                        qc_typeoferror.SelectedIndex = -1;
                    }
                    else
                    {
                        qc_typeoferror.Text = row.Cells["txtTypeOfError"].Value.ToString();
                    }
                    if (!string.IsNullOrEmpty(row.Cells["txtQualityParameters"].Value.ToString()))
                    {
                        for (int i = 0; i < qc_qualityparameters.Items.Count; i++)
                        {
                            qc_qualityparameters.SetItemChecked(i, false);
                        }
                        foreach (string value in row.Cells["txtQualityParameters"].Value.ToString().Split(','))
                        {
                            qc_qualityparameters.SetItemChecked(qc_qualityparameters.Items.IndexOf(value), true);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < qc_qualityparameters.Items.Count; i++)
                        {
                            qc_qualityparameters.SetItemChecked(i, false);
                        }
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtQC_Completion_Date"].Value.ToString()))
                    {
                        qc_comlpetiondate.CustomFormat = " ";
                    }
                    else
                    {
                        qc_comlpetiondate.Text = row.Cells["txtQC_Completion_Date"].Value.ToString();
                        qc_comlpetiondate.CustomFormat = "dd-MMMM-yyyy";
                    }
                    update.Enabled = true;
                    insert.Enabled = false;
                }
            }
            else
            {
                update.Enabled = false;
                insert.Enabled = true;
            }
        }

        private void searchby_qcstartdate_ValueChanged(object sender, EventArgs e)
        {
            searchby_qcstartdate.CustomFormat = "dd-MMMM-yyyy";
            datagridview_display_overall();
        }

        private void searchby_qcstartdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_qcstartdate.CustomFormat = " ";
            }
        }

        public void datagridview_display_overall()
        {
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

                if (searchby_qcstartdate.Text.Trim() == string.Empty && string.IsNullOrEmpty(searchby_qcdoneby.Text) && string.IsNullOrEmpty(searchby_crm_requestid.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select ID,CRM_RequestID,QC_Start_Date,QC_Done_By,Associate_Name_FirstCheck,Overall_Status,TypeOfError,QualityParameters,QC_Completion_Date,LastUpdatedBy,Comments from dbo.tbl_crm_qc_daily_dotnet with(nolock) where isdeleted = 0 order by id";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_crmworkflow_qc_datagridview_search_dotnet";
                    if (searchby_qcstartdate.Text.Trim() == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@gcid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qcstartdate", searchby_qcstartdate.Value.Date);
                    }
                    if (string.IsNullOrEmpty(searchby_qcdoneby.Text))
                    {
                        cmd.Parameters.AddWithValue("@qcdoneby", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qcdoneby", searchby_qcdoneby.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_crm_requestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@crm_requestid",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@crm_requestid",searchby_crm_requestid.Text);
                    }

                }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 obj_form1 = new Form1();
            obj_form1.Show();
        }

        private void qc_typeoferror_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                qc_typeoferror.SelectedIndex = -1;
            }
        }

        private void qc_associatenamefirstcheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                qc_associatename.SelectedIndex = -1;
            }
        }

        private void qc_doneby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                qc_doneby.SelectedIndex = -1;
            }
        }

        private void qc_overallstatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                qc_overallstatus.SelectedIndex = -1;
            }
        }

        private void qc_rawdata_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_CRM_QC_RawData_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void searchby_qcdoneby_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void searchby_crm_requestid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }
        
    }
}
