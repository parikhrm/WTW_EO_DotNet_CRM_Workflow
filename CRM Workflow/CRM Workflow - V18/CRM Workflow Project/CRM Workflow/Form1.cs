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
using System.Security.Permissions;

namespace CRM_Workflow
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dRDDataSet19.tbl_segmentname_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_segmentname_dotnetTableAdapter.Fill(this.dRDDataSet19.tbl_segmentname_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet18.tbl_crm_typeofupdaterequired_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_typeofupdaterequired_dotnetTableAdapter.Fill(this.dRDDataSet18.tbl_crm_typeofupdaterequired_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet17.tbl_crm_investigationplaced_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_investigationplaced_dotnetTableAdapter.Fill(this.dRDDataSet17.tbl_crm_investigationplaced_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet16.tbl_crm_validationsource_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_validationsource_dotnetTableAdapter.Fill(this.dRDDataSet16.tbl_crm_validationsource_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet15.tbl_crm_queryresolvedby_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_queryresolvedby_dotnetTableAdapter.Fill(this.dRDDataSet15.tbl_crm_queryresolvedby_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet14.tbl_crm_typeofquery_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_typeofquery_dotnetTableAdapter.Fill(this.dRDDataSet14.tbl_crm_typeofquery_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet13.tbl_crm_associatename_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_associatename_dotnetTableAdapter.Fill(this.dRDDataSet13.tbl_crm_associatename_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet12.tbl_crm_typeofparty_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_typeofparty_dotnetTableAdapter.Fill(this.dRDDataSet12.tbl_crm_typeofparty_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet11.tbl_crm_requesttype_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_requesttype_dotnetTableAdapter.Fill(this.dRDDataSet11.tbl_crm_requesttype_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet7.tbl_partylocation_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_partylocation_dotnetTableAdapter.Fill(this.dRDDataSet7.tbl_partylocation_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet4.tbl_crmlist_dotnet_V1' table. You can move, or remove it, as needed.
            //this.tbl_crmlist_dotnet_V1TableAdapter.Fill(this.dRDDataSet4.tbl_crmlist_dotnet_V1);
            // TODO: This line of code loads data into the 'dRDDataSet3.tbl_crm_daily_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crm_daily_dotnetTableAdapter.Fill(this.dRDDataSet3.tbl_crm_daily_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet2.tbl_crmlist_dotnet' table. You can move, or remove it, as needed.
            //this.tbl_crmlist_dotnetTableAdapter.Fill(this.dRDDataSet2.tbl_crmlist_dotnet);
            // TODO: This line of code loads data into the 'dRDDataSet1.tbl_BUMappings_May2018onwards' table. You can move, or remove it, as needed.
            //this.tbl_BUMappings_May2018onwardsTableAdapter.Fill(this.dRDDataSet1.tbl_BUMappings_May2018onwards);
            // TODO: This line of code loads data into the 'dRDDataSet.tbl_emp_details' table. You can move, or remove it, as needed.
            //this.tbl_emp_detailsTableAdapter.Fill(this.dRDDataSet.tbl_emp_details);
            reset();
            button2.Enabled = false;
            requesttype_list();
            partylocation_list();
            //typeofparty_list();
            queryresolvedby_list();
            //validationsource_list();
            //investigationplaced_list();
            //typeofupdaterequired_list();
            //commented on 4th aug 2023
            //requestorbusinessunit_list();
            //segmentname_list();
            //queriesraised();
            associatename_list();
            typeofquery_list();
            //clear_completed();
            //clear_pending();
            //clear_queriesraised();
            //pending();
            //completed();
            //queriesraised();
            boolean_list();
            empdetails_checkaccess();
            //qc_typeoferror_list();
            associatename_check.Visible = false;
            status_list();
            
        }

        public void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        //public void queriesraised()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    conn.ConnectionString = connectionstringtxt;
        //    cmd.Connection = conn;
        //    conn.Open();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select RequestID,RequestType,ReceivedDate,ReceivedTime,Volumes,PartyName,PartyLocation,ValidationSource,AssociateName,QueryRaisedDate,QueryRaisedTime,TypeOfQuery,QueryResolvedDate,QueryResolvedTime,QueryResolvedBy,CompletionDate,CompletionTime,RequestorBusinessUnit,RequestorEmailAddress,RequestorSegmentName,Comments,RequestorOffice,FoundInFactiva,QueryChaser1Sent_Status_Date,QueryChaser2Sent_Status_Date,QueryChaser1_SentBy,QueryChaser2_SentBy,WFT_RequestID,Termination_Status from dbo.tbl_crm_daily_dotnet with(nolock) where queryraiseddate is not null and completiondate is null and convert(date,receiveddate) between convert(date,dateadd(yy,-1,getdate())) and convert(date,getdate()) and isdeleted = 0 order by requestid asc";
        //    sda.SelectCommand = cmd;
        //    sda.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    conn.Close();
        //}

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

                if (string.IsNullOrEmpty(searchby_requestid.Text) && string.IsNullOrEmpty(searchby_associatename.Text) && string.IsNullOrEmpty(searchby_requeststatus.Text) && string.IsNullOrEmpty(searchby_partyname.Text) && string.IsNullOrEmpty(searchby_wftrequestid.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 RequestID,RequestType,ReceivedDate,ReceivedTime,Volumes,PartyName,PartyLocation,AssociateName,QueryRaisedDate,QueryRaisedTime,TypeOfQuery,QueryResolvedDate,QueryResolvedTime,QueryResolvedBy,CompletionDate,CompletionTime,RequestorBusinessUnit,RequestorEmailAddress,RequestorSegmentName,Comments,RequestorOffice,FoundInFactiva,QueryChaser1Sent_Status_Date,QueryChaser2Sent_Status_Date,QueryChaser1_SentBy,QueryChaser2_SentBy,WFT_RequestID,Termination_Status,Synthetic_Approval_RaisedDate,Synthetic_Approval_Raisedtime,Synthetic_Approval_ReceivedDate,Synthetic_Approval_ReceivedTime from dbo.tbl_crm_daily_dotnet with(nolock) where  convert(date,receiveddate) between convert(date,dateadd(yy,-1,getdate())) and convert(date,getdate()) and isdeleted = 0 order by requestid desc";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_crmworkflow_datagridview_search_dotnet";
                    if(string.IsNullOrEmpty(searchby_requestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@requestid",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@requestid",searchby_requestid.Text);
                    }
                    if(string.IsNullOrEmpty(searchby_requeststatus.Text))
                    {
                        cmd.Parameters.AddWithValue("@requeststatus",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@requeststatus",searchby_requeststatus.Text);
                    }
                    if(string.IsNullOrEmpty(searchby_partyname.Text))
                    {
                        cmd.Parameters.AddWithValue("@partyname",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@partyname",searchby_partyname.Text);
                    }
                    if(string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename",searchby_associatename.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_wftrequestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@wftrequestid",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@wftrequestid", searchby_wftrequestid.Text);
                    }
                }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView3.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        //public void pending()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    conn.ConnectionString = connectionstringtxt;
        //    cmd.Connection = conn;
        //    conn.Open();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select RequestID,RequestType,ReceivedDate,ReceivedTime,Volumes,PartyName,PartyLocation,ValidationSource,AssociateName,QueryRaisedDate,QueryRaisedTime,TypeOfQuery,QueryResolvedDate,QueryResolvedTime,QueryResolvedBy,CompletionDate,CompletionTime,RequestorBusinessUnit,RequestorEmailAddress,RequestorSegmentName,Comments,RequestorOffice,FoundInFactiva,QueryChaser1Sent_Status_Date,QueryChaser2Sent_Status_Date,QueryChaser1_SentBy,QueryChaser2_SentBy,WFT_RequestID,Termination_Status from dbo.tbl_crm_daily_dotnet with(nolock) where 1=1 and completiondate is null and convert(date,receiveddate) between convert(date,dateadd(yy,-1,getdate())) and convert(date,getdate()) and isdeleted = 0 order by requestid asc";
        //    sda.SelectCommand = cmd;
        //    sda.Fill(dt);
        //    dataGridView3.DataSource = dt;
        //    conn.Close();
        //}

        //public void completed()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    conn.ConnectionString = connectionstringtxt;
        //    cmd.Connection = conn;
        //    conn.Open();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select RequestID,RequestType,ReceivedDate,ReceivedTime,Volumes,PartyName,PartyLocation,ValidationSource,AssociateName,QueryRaisedDate,QueryRaisedTime,TypeOfQuery,QueryResolvedDate,QueryResolvedTime,QueryResolvedBy,CompletionDate,CompletionTime,RequestorBusinessUnit,RequestorEmailAddress,RequestorSegmentName,Comments,RequestorOffice,FoundInFactiva,QueryChaser1Sent_Status_Date,QueryChaser2Sent_Status_Date,QueryChaser1_SentBy,QueryChaser2_SentBy,WFT_RequestID,Termination_Status from dbo.tbl_crm_daily_dotnet with(nolock) where 1=1 and completiondate is not null and convert(date,receiveddate) between convert(date,dateadd(yy,-1,getdate())) and convert(date,getdate()) and isdeleted = 0 order by requestid asc";
        //    sda.SelectCommand = cmd;
        //    sda.Fill(dt);
        //    dataGridView4.DataSource = dt;
        //    conn.Close();
        //}

        //public void clear_queriesraised()
        //{
        //    searchassociatenameunactioned.Text = string.Empty;
        //    searchrequesttypeunactioned.Text = string.Empty;
        //    searchreceiveddateunactioned.Text = DateTime.Now.ToLongDateString();
        //    searchpartynameunactioned.Text = string.Empty;
        //    queriesraised();
        //}

        //public void clear_pending()
        //{
        //    pending();
        //    searchrequesttypepending.Text = string.Empty;
        //    searchassociatenamepending.Text = string.Empty;
        //    searchreceiveddatepending.Text = DateTime.Now.ToLongDateString();
        //    searchby_partyname.Text = string.Empty;
        //}

        //public void clear_completed()
        //{
        //    completed();
        //    searchrequesttypecompleted.Text = string.Empty;
        //    searchassociatenamecompleted.Text = string.Empty;
        //    searchreceiveddatecompleted.Text = DateTime.Now.ToLongDateString();
        //    searchpartynamecompleted.Text = string.Empty;
        //}


        public void reset()
        {
            requestid.Enabled = false;
            requestid.Text = string.Empty;
            requesttype.SelectedIndex = -1;
            receiveddate.CustomFormat = " ";
            receivedtime.CustomFormat = " ";
            today.Visible = false;
            today.Text = DateTime.Now.ToLongDateString();
            volumes.Value = 1;
            partyname.Text = string.Empty;
            partylocation.SelectedIndex = -1;
            //updatedlegalentityname.Text = string.Empty;
            //requestoroffice.Text = string.Empty;
            //typeofparty.SelectedIndex = -1;
            //validationsource.SelectedIndex = -1;
            associatename.SelectedIndex = -1;
            queryraiseddate.CustomFormat = " ";
            queryraiseddate.Enabled = false;
            queryraisedtime.CustomFormat = " ";
            queryraisedtime.Enabled = false;
            typeofquery.SelectedIndex = -1;
            typeofquery.Enabled = false;
            //typeofparty.SelectedIndex = -1;
            queryresolveddate.CustomFormat = " ";
            queryresolveddate.Enabled = false;
            queryresolvedtime.CustomFormat = " ";
            queryresolvedtime.Enabled = false;
            queryresolvedby.SelectedIndex = -1;
            queryresolvedby.Enabled = false;
            //validationsource.SelectedIndex = -1;
            //validationsource.Enabled = false;
            completiondate.CustomFormat = " ";
            completiondate.Enabled = false;
            completiontime.CustomFormat = " ";
            completiontime.Enabled = false;
            //investigationplaced.SelectedIndex = -1;
            //investigationplaced.Enabled = false;
            //investigationraiseddate.CustomFormat = " ";
            //investigationraiseddate.Enabled = false;
            //investigationraisedtime.CustomFormat = " ";
            //investigationraisedtime.Enabled = false;
            //reportreceiveddate.CustomFormat = " ";
            //reportreceiveddate.Enabled = false;
            //reportreceivedtime.CustomFormat = " ";
            //reportreceivedtime.Enabled = false;
            //typeofupdaterequired.SelectedIndex = -1;
            requestorbusinessunit.SelectedIndex = -1;
            requestoremailaddress.Text = string.Empty;
            requestorsegmentname.SelectedIndex = -1;
            Comments.Text = string.Empty;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            //checkBox4.Checked = false;
            //checkBox5.Checked = false;
            button1.Enabled = true;
            //queriesraised();
            //pending();
            //completed();
            foundinfactiva.SelectedIndex = -1;
            //clear_completed();
            //clear_pending();
            //clear_queriesraised();
            //button1.Enabled = false;
            //button2.Enabled = false;
            //button4.Enabled = false;
            chaser1sent.Checked = false;
            chaser2sent.Checked = false;
            //chaser3sent.Checked = false;
            chaser1_sentdate.CustomFormat = " ";
            chaser2_sentdate.CustomFormat = " ";
            //chaser3_sentdate.CustomFormat = " ";
            chaser1_sentby.SelectedIndex = -1;
            chaser2_sentby.SelectedIndex = -1;
            //chaser3_sentby.SelectedIndex = -1;
            //qcdate.CustomFormat = " ";
            //qcdoneby.SelectedIndex = -1;
            //qc_associatenamefirstcheck.SelectedIndex = -1;
            //qc_overallstatus.SelectedIndex = -1;
            //qc_typeoferror.SelectedIndex = -1;
            //qc_qualityparameters.SelectedIndex = -1;
            //for (int i = 0; i < qc_qualityparameters.Items.Count; i++)
            //{
            //    qc_qualityparameters.SetItemChecked(i, false);
            //}
            wftrequestid.Text = string.Empty;
            checkbox_termination.Checked = false;
            datagridview_display_overall();
            datagridview.Enabled = false;
            requestorbusinessunit.SelectedIndex = -1;
            requestorsegmentname.SelectedIndex = -1;
            synthetic_approval_raiseddate.CustomFormat = " ";
            synthetic_approval_raisedtime.CustomFormat = " ";
            synthetic_approval_receiveddate.CustomFormat = " ";
            synthetic_approval_receivedtime.CustomFormat = " ";
        }

        public void empdetails_checkaccess()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.empdetails_accesscheck_list(dtaa,Environment.UserName.ToString());
                associatename_check.DataSource = dtaa;
                associatename_check.DisplayMember = "CRMTool_Access";
                conn.Close();
                //associatename_check.SelectedIndex = -1;
                if (associatename_check.Text == "Admin")
                {
                    qcworkflow.Enabled = true;

                }
                else
                {
                    qcworkflow.Enabled = false;
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        //public void qualityparameters_list()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        QualityParameters obj_quality = new QualityParameters();
        //        DataTable dtaa = new DataTable();
        //        DataSet ds = new DataSet();
        //        obj_quality.qualityparameters_list(dtaa, qc_typeoferror.Text);
        //        foreach (DataRow datarow in dtaa.Rows)
        //        {
        //            qc_qualityparameters.Items.Add(datarow["QualityParameters"]);
        //        }
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}

        public void requesttype_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                RequestType obj_requesttype = new RequestType();
                DataTable dtaa = new DataTable();
                obj_requesttype.requesttype_list(dtaa);
                requesttype.DataSource = dtaa;
                requesttype.DisplayMember = "RequestType";
                conn.Close();
                requesttype.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        //public void qc_typeoferror_list()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        TypeOfError obj_typeoferror = new TypeOfError();
        //        DataTable dtaa = new DataTable();
        //        obj_typeoferror.typeoferror_list (dtaa);
        //        qc_typeoferror.DataSource = dtaa;
        //        qc_typeoferror.DisplayMember = "TypeOfError";
        //        conn.Close();
        //        qc_typeoferror.SelectedIndex = -1;
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}


        public void boolean_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Boolean obj_boolean = new Boolean();
                DataTable dtaa = new DataTable();
                DataTable dtaa1 = new DataTable();

                obj_boolean.boolean_list(dtaa);
                foundinfactiva.DataSource = dtaa;
                foundinfactiva.DisplayMember = "Boolean";

                obj_boolean.boolean_list(dtaa1);
                //qc_overallstatus.DataSource = dtaa1;
                //qc_overallstatus.DisplayMember = "Boolean";

                conn.Close();
                //qc_overallstatus.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void partylocation_list()
        {
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

        //public void typeofparty_list()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        TypeOfParty obj_typeofparty = new TypeOfParty();
        //        DataTable dtaa = new DataTable();
        //        obj_typeofparty.typeofparty_list(dtaa);
        //        typeofparty.DataSource = dtaa;
        //        typeofparty.DisplayMember = "TypeOfParty";
        //        conn.Close();
        //        typeofparty.SelectedIndex = -1;
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}

        public void associatename_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                AssociateName obj_associatename = new AssociateName();
                DataTable dtaa = new DataTable();
                DataTable dtaa1 = new DataTable();
                DataTable dtaa2 = new DataTable();
                DataTable dtaa3 = new DataTable();
                DataTable dtaa4 = new DataTable();
                DataTable dtaa5 = new DataTable();
                DataTable dtaa6 = new DataTable();

                obj_associatename.associatename_list(dtaa);
                associatename.DataSource = dtaa;
                associatename.DisplayMember = "AssociateName";

                obj_associatename.chaser1_sentby_list (dtaa1);
                chaser1_sentby.DataSource = dtaa1;
                chaser1_sentby.DisplayMember = "AssociateName";

                obj_associatename.chaser2_sentby_list(dtaa2);
                chaser2_sentby.DataSource = dtaa2;
                chaser2_sentby.DisplayMember = "AssociateName";

                obj_associatename.chaser3_sentby_list(dtaa3);
                //chaser3_sentby.DataSource = dtaa3;
                //chaser3_sentby.DisplayMember = "AssociateName";

                obj_associatename.associatename_list(dtaa4);
                //qcdoneby.DataSource = dtaa4;
                //qcdoneby.DisplayMember = "AssociateName";

                obj_associatename.associatename_list(dtaa5);
                //qc_associatenamefirstcheck.DataSource = dtaa5;
                //qc_associatenamefirstcheck.DisplayMember = "AssociateName";

                obj_associatename.associatename_datagridview_list(dtaa6);
                searchby_associatename.DataSource = dtaa6;
                searchby_associatename.DisplayMember = "AssociateName";


                conn.Close();
                associatename.SelectedIndex = -1;
                chaser1_sentby.SelectedIndex = -1;
                chaser2_sentby.SelectedIndex = -1;
                searchby_associatename.SelectedIndex = -1;
                //chaser3_sentby.SelectedIndex = -1;
                //qcdoneby.SelectedIndex = -1;
                //qc_associatenamefirstcheck.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void typeofquery_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                TypeOfQuery obj_typeofquery = new TypeOfQuery();
                DataTable dtaa = new DataTable();
                obj_typeofquery.typeofquery_list(dtaa);
                typeofquery.DataSource = dtaa;
                typeofquery.DisplayMember = "TypeOfQuery";
                conn.Close();
                typeofquery.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void queryresolvedby_list()
        {
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

        //public void validationsource_list()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        ValidationSource obj_validationsource = new ValidationSource();
        //        DataTable dtaa = new DataTable();
        //        obj_validationsource.validationsource_list(dtaa);
        //        validationsource.DataSource = dtaa;
        //        validationsource.DisplayMember = "ValidationSource";
        //        conn.Close();
        //        validationsource.SelectedIndex = -1;
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}

        //public void investigationplaced_list()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        InvestigationPlaced obj_investigationplaced = new InvestigationPlaced();
        //        DataTable dtaa = new DataTable();
        //        obj_investigationplaced.investigationplaced_list(dtaa);
        //        investigationplaced.DataSource = dtaa;
        //        investigationplaced.DisplayMember = "InvestigationPlaced";
        //        conn.Close();
        //        investigationplaced.SelectedIndex = -1;
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}

        //public void typeofupdaterequired_list()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }

        //    try
        //    {
        //        TypeOfUpdateRequired obj_typeofupdaterequired = new TypeOfUpdateRequired();
        //        DataTable dtaa = new DataTable();
        //        obj_typeofupdaterequired.typeofupdaterequired_list(dtaa);
        //        typeofupdaterequired.DataSource = dtaa;
        //        typeofupdaterequired.DisplayMember = "TypeOfUpdateRequired";
        //        conn.Close();
        //        typeofupdaterequired.SelectedIndex = -1;
        //    }
        //    catch (Exception ab)
        //    {
        //        MessageBox.Show("Error Generated Details: " + ab.ToString());
        //    }
        //}

        public void requestorbusinessunit_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                RequestorBusinessUnit obj_requestorbusinessunit = new RequestorBusinessUnit();
                DataTable dtaa = new DataTable();
                obj_requestorbusinessunit.requestorbusinessunit_list(dtaa);
                requestorbusinessunit.DataSource = dtaa;
                requestorbusinessunit.DisplayMember = "NewBU";
                conn.Close();
                //requestorbusinessunit.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void segmentname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SegmentName obj_segmentname = new SegmentName();
                DataTable dtaa = new DataTable();
                obj_segmentname.segmentname_list(dtaa);
                requestorsegmentname.DataSource = dtaa;
                requestorsegmentname.DisplayMember = "SegmentName";
                conn.Close();
                //requestorsegmentname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void status_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                Status obj_status = new Status();
                DataTable dtaa = new DataTable();
                obj_status.datagridview_requeststatus_list (dtaa);
                searchby_requeststatus.DataSource = dtaa;
                searchby_requeststatus.DisplayMember = "Status";
                conn.Close();
                searchby_requeststatus.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "dbo.usp_crm_insert_dotnet";
                    //cmd.CommandText = "insert into tbl_crm_daily_dotnet (RequestType,ReceivedDate,ReceivedTime,Volumes,PartyName,PartyLocation,UpdatedLegalEntityName,TypeOfParty,ValidationSource,AssociateName,QueryRaisedDate,QueryRaisedTime,TypeOfQuery,QueryResolvedDate,QueryResolvedTime,QueryResolvedBy,CompletionDate,CompletionTime,InvestigationPlaced,InvestigationRaisedDate,InvestigationRaisedTime,ReportReceivedDate,ReportReceivedTime,TypeOfUpdateRequired,RequestorBusinessUnit,RequestorEmailAddress,RequestorSegmentName,Comments,LastUpdateDateTime,RequestorOffice,LastUpdatedBy,MachineName,IsDeleted) values(@RequestTypeparam,@ReceivedDateparam,@ReceivedTimeparam,@Volumesparam,@PartyNameparam,@PartyLocationparam,@UpdatedLegalEntityNameparam,@TypeOfPartyparam,@ValidationSourceparam,@AssociateNameparam,@QueryRaisedDateparam,@QueryRaisedTimeparam,@TypeOfQueryparam,@QueryResolvedDateparam,@QueryResolvedTimeparam,@QueryResolvedByparam,@CompletionDateparam,@CompletionTimeparam,@InvestigationPlacedparam,@InvestigationRaisedDateparam,@InvestigationRaisedTimeparam,@ReportReceivedDateparam,@ReportReceivedTimeparam,@TypeOfUpdateRequiredparam,@RequestorBusinessUnitparam,@RequestorEmailAddressparam,@RequestorSegmentNameparam,@Commentsparam,@LastUpdateDateTimeparam,@RequestorOfficeparam,@LastUpdatedByparam,@MachineNameparam,0)";
                    cmd.Parameters.AddWithValue("@RequestTypeparam", requesttype.Text);
                    
                    if(synthetic_approval_raiseddate.Text.Trim() != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_RaisedDate",synthetic_approval_raiseddate.Value.Date);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_Raisedtime",synthetic_approval_raisedtime.Value.ToLongTimeString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_RaisedDate", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_Raisedtime", DBNull.Value);
                    }

                    if (synthetic_approval_receiveddate.Text.Trim() != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedDate", synthetic_approval_receiveddate.Value.Date);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedTime", synthetic_approval_receivedtime.Value.ToLongTimeString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedDate", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedTime", DBNull.Value);
                    }


                    if (chaser1sent.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Statusparam", 1);
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Status_Dateparam", chaser1_sentdate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryChaser1_SentBy", chaser1_sentby.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Statusparam", 0);
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Status_Dateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryChaser1_SentBy", DBNull.Value);
                    }
                    if (chaser2sent.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Statusparam", 1);
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Status_Dateparam", chaser2_sentdate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryChaser2_SentBy", chaser2_sentby.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Statusparam", 0);
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Status_Dateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryChaser2_SentBy", DBNull.Value);
                    }
                    //if (chaser3sent.Checked == true)
                    //{
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Statusparam", 1);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Status_Dateparam", chaser3_sentdate.Value.Date);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3_SentBy", chaser3_sentby.Text);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Statusparam", 0);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Status_Dateparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3_SentBy", DBNull.Value);
                    //}
                    cmd.Parameters.AddWithValue("@ReceivedDateparam", receiveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@ReceivedTimeparam", receivedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@Volumesparam", volumes.Value);
                    cmd.Parameters.AddWithValue("@PartyNameparam", partyname.Text);
                    if (string.IsNullOrEmpty(partylocation.Text))
                    {
                        cmd.Parameters.AddWithValue("@PartyLocationparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PartyLocationparam", partylocation.Text);
                    }
                    //if (string.IsNullOrEmpty(updatedlegalentityname.Text))
                    //{
                    //    cmd.Parameters.AddWithValue("@UpdatedLegalEntityNameparam", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@UpdatedLegalEntityNameparam", updatedlegalentityname.Text);
                    //}
                    //if (string.IsNullOrEmpty(typeofparty.Text))
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfPartyparam", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfPartyparam", typeofparty.Text);
                    //}
                    cmd.Parameters.AddWithValue("@AssociateNameparam", associatename.Text);
                    if (checkBox1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@QueryRaisedDateparam", queryraiseddate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", queryraisedtime.Value.ToLongTimeString());
                        cmd.Parameters.AddWithValue("@TypeOfQueryparam", typeofquery.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryRaisedDateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@TypeOfQueryparam", DBNull.Value);
                    }
                    if (checkBox2.Checked)
                    {
                        cmd.Parameters.AddWithValue("@QueryResolvedDateparam", queryresolveddate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", queryresolvedtime.Value.ToShortTimeString());
                        cmd.Parameters.AddWithValue("@QueryResolvedByparam", queryresolvedby.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryResolvedDateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryResolvedByparam", DBNull.Value);
                    }
                    if (checkBox3.Checked)
                    {
                        cmd.Parameters.AddWithValue("@CompletionDateparam", completiondate.Value.Date);
                        cmd.Parameters.AddWithValue("@CompletionTimeparam", completiontime.Value.ToShortTimeString());
                        //cmd.Parameters.AddWithValue("@ValidationSourceparam", validationsource.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompletionDateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@CompletionTimeparam", DBNull.Value);
                        //cmd.Parameters.AddWithValue("@ValidationSourceparam", DBNull.Value);
                    }
                    //if (checkBox4.Checked)
                    //{
                    //    cmd.Parameters.AddWithValue("@InvestigationPlacedparam", investigationplaced.Text);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedDateparam", investigationraiseddate.Value.Date);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedTimeparam", investigationraisedtime.Value.ToLongTimeString());
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@InvestigationPlacedparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedDateparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedTimeparam", DBNull.Value);
                    //}

                    //if (checkBox5.Checked)
                    //{
                    //    cmd.Parameters.AddWithValue("@ReportReceivedDateparam", reportreceiveddate.Value.Date);
                    //    cmd.Parameters.AddWithValue("@ReportReceivedTimeparam", reportreceivedtime.Value.ToLongTimeString());
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@ReportReceivedDateparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@ReportReceivedTimeparam", DBNull.Value);
                    //}
                    //if (string.IsNullOrEmpty(typeofupdaterequired.Text))
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfUpdateRequiredparam", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfUpdateRequiredparam", typeofupdaterequired.Text);
                    //}
                    if (string.IsNullOrEmpty(requestorbusinessunit.Text))
                    {
                        cmd.Parameters.AddWithValue("@RequestorBusinessUnitparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RequestorBusinessUnitparam", requestorbusinessunit.Text);
                    }
                    if (string.IsNullOrEmpty(requestoremailaddress.Text))
                    {
                        cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", requestoremailaddress.Text);
                    }
                    if (string.IsNullOrEmpty(requestorsegmentname.Text))
                    {
                        cmd.Parameters.AddWithValue("@RequestorSegmentNameparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RequestorSegmentNameparam", requestorsegmentname.Text);
                    }
                    if (string.IsNullOrEmpty(Comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@Commentsparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Commentsparam", Comments.Text);
                    }
                    cmd.Parameters.AddWithValue("@LastUpdateDateTimeparam", DateTime.Now.ToLocalTime());
                    //cmd.Parameters.AddWithValue("@RequestorOfficeparam", requestoroffice.Text);
                    cmd.Parameters.AddWithValue("@LastUpdatedByparam", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineNameparam", Environment.MachineName.ToString());
                    if (string.IsNullOrEmpty(foundinfactiva.Text))
                    {
                        cmd.Parameters.AddWithValue("@FoundInFactiva", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FoundInFactiva",foundinfactiva.Text);
                    }
                    if (string.IsNullOrEmpty(wftrequestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@wftrequestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@wftrequestid", wftrequestid.Text);
                    }
                    if (checkbox_termination.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@terminationstatus", "Yes");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@terminationstatus", "No");
                    }



                    //if conditions
                    if (receiveddate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Received Date cannnot be greater than today's date");
                    }
                    else if (queryraiseddate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Query Raised Date cannnot be greater than today's date");
                    }
                    else if (queryresolveddate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Query Resolved Date cannot be greater than today's date");
                    }
                    //else if (investigationraiseddate.Value.Date > today.Value.Date)
                    //{
                    //    MessageBox.Show("Investigation Raised Date cannot be greater than today's date");
                    //}
                    //else if (reportreceiveddate.Value.Date > today.Value.Date)
                    //{
                    //    MessageBox.Show("Report Received Date cannot be greater than today's date");
                    //}
                    else if (completiondate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Completion date cannot be greater than today's date");
                    }
                    else if (checkBox1.Checked && checkBox2.Checked && queryraiseddate.Value.Date > queryresolveddate.Value.Date)
                    {
                        MessageBox.Show("Query Raised Date cannot be greater than Query resolved Date");
                    }
                    else if (checkBox3.Checked && receiveddate.Value.Date > completiondate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than Completion Date");
                    }
                    else if (checkBox1.Checked && receiveddate.Value.Date > queryraiseddate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than Query Raised Date");
                    }
                    else if (checkBox1.Checked && checkBox2.Checked && receiveddate.Value.Date > queryresolveddate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than Query Resolved Date");
                    }
                    else if (checkBox1.Checked && checkBox3.Checked && queryraiseddate.Value.Date > completiondate.Value.Date)
                    {
                        MessageBox.Show("Query Raised Date cannot be greater than Completion Date");
                    }
                    else if (checkBox2.Checked && checkBox3.Checked && queryresolveddate.Value.Date > completiondate.Value.Date)
                    {
                        MessageBox.Show("Query Resolved Date cannot be greater than Completion Date");
                    }
                    else if (checkBox1.Checked && string.IsNullOrEmpty(typeofquery.Text))
                    {
                        MessageBox.Show("Please update Type Of Query");
                    }
                    else if (checkBox2.Checked && string.IsNullOrEmpty(queryresolvedby.Text))
                    {
                        MessageBox.Show("Please update query resolved by");
                    }
                    //else if (checkBox3.Checked && string.IsNullOrEmpty(validationsource.Text))
                    //{
                    //    MessageBox.Show("Please update Validation Soure");
                    //}
                    //else if (checkBox4.Checked && string.IsNullOrEmpty(investigationplaced.Text))
                    //{
                    //    MessageBox.Show("Please update investigation placed?");
                    //}
                    else if (checkBox1.Checked && checkBox3.Checked && !checkBox2.Checked)
                    {
                        MessageBox.Show("Please update Query Resolved Date");
                    }
                    else if (checkBox2.Checked && !checkBox1.Checked)
                    {
                        MessageBox.Show("Please update Query Raised Date");
                    }
                    else if (string.IsNullOrEmpty(requesttype.Text))
                    {
                        MessageBox.Show("Please update Request Type");
                    }
                    else if (string.IsNullOrEmpty(partyname.Text))
                    {
                        MessageBox.Show("Please update Party Name");
                    }
                    else if (string.IsNullOrEmpty(associatename.Text))
                    {
                        MessageBox.Show("Please update Associate Name");
                    }
                    else if (requesttype.Text != "Adhoc" && string.IsNullOrEmpty(requestorbusinessunit.Text))
                    {
                        MessageBox.Show("Please update Requestor Business Unit");
                    }
                    else if (requesttype.Text != "Adhoc" && string.IsNullOrEmpty(requestoremailaddress.Text))
                    {
                        MessageBox.Show("Please update Requestor Email Address");
                    }
                    else if (requesttype.Text == "BAU" && string.IsNullOrEmpty(partylocation.Text))
                    {
                        MessageBox.Show("Please update Party Location");
                    }
                    else if (requesttype.Text == "MailBox" && string.IsNullOrEmpty(partylocation.Text))
                    {
                        MessageBox.Show("Please update Party Location");
                    }
                    else if (requesttype.Text == "Self Service" && string.IsNullOrEmpty(partylocation.Text))
                    {
                        MessageBox.Show("Please update Party Location");
                    }
                    //else if (partylocation.Text == "India")
                    //{
                    //    MessageBox.Show("Record cannot be processed due to regulatory restrictions where Party Location is India");
                    //}
                    //else if (string.IsNullOrEmpty(partylocation.Text) && requesttype.Text != "Adhoc")
                    //{
                    //    MessageBox.Show("Please update Party Location");
                    //}
                    else if (requestorbusinessunit.Text == "Accident & Health India" || requestorbusinessunit.Text == "Aerospace India" || requestorbusinessunit.Text == "Claims India" || requestorbusinessunit.Text == "CPC India" || requestorbusinessunit.Text == "Energy India" || requestorbusinessunit.Text == "FINEX India" || requestorbusinessunit.Text == "Human Resources India" || requestorbusinessunit.Text == "International India" || requestorbusinessunit.Text == "Marine India" || requestorbusinessunit.Text == "Market Security India " || requestorbusinessunit.Text == "Reinsurance India")
                    {
                        MessageBox.Show("Record cannot be processed due to regulatory restrictions where Requestor Business Unit is India");
                    }
                    else if (chaser1sent.Checked == true && chaser1_sentdate.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Chaser1 Sent Date");
                    }
                    else if (chaser2sent.Checked == true && chaser2_sentdate.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Chaser2 Sent Date");
                    }
                    //else if (chaser3sent.Checked == true && chaser3_sentdate.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Chaser3 Sent Date");
                    //}
                    else if (chaser1sent.Checked == false && chaser1_sentdate.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please checkbox Chaser1 Sent");
                    }
                    else if (chaser2sent.Checked == false && chaser2_sentdate.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please checkbox Chaser2 Sent");
                    }
                    //else if (chaser3sent.Checked == false && chaser3_sentdate.Text.Trim() != string.Empty)
                    //{
                    //    MessageBox.Show("Please checkbox Chaser1 Sent");
                    //}
                    else if (chaser1_sentdate.Text.Trim() != string.Empty && chaser2_sentdate.Text.Trim() != string.Empty && chaser1_sentdate.Value.Date > chaser2_sentdate.Value.Date)
                    {
                        MessageBox.Show("Chaser1 Sent Date cannnot be more than Chaser2 Sent Date");
                    }
                    //else if (chaser2_sentdate.Text.Trim() != string.Empty && chaser3_sentdate.Text.Trim() != string.Empty && chaser2_sentdate.Value.Date > chaser3_sentdate.Value.Date)
                    //{
                    //    MessageBox.Show("Chaser2 Sent Date cannnot be more than Chaser3 Sent Date");
                    //}
                    //else if (chaser1_sentdate.Text.Trim() != string.Empty && chaser3_sentdate.Text.Trim() != string.Empty && chaser1_sentdate.Value.Date > chaser3_sentdate.Value.Date)
                    //{
                    //    MessageBox.Show("Chaser1 Sent Date cannnot be more than Chaser3 Sent Date");
                    //}
                    else if (chaser1_sentdate.Text.Trim() != string.Empty && string.IsNullOrEmpty(chaser1_sentby.Text))
                    {
                        MessageBox.Show("Please update Chaser1 Sent By Name");
                    }
                    else if (chaser2_sentdate.Text.Trim() != string.Empty && string.IsNullOrEmpty(chaser2_sentby.Text))
                    {
                        MessageBox.Show("Please update Chaser2 Sent By Name");
                    }
                    //else if (chaser3_sentdate.Text.Trim() != string.Empty && string.IsNullOrEmpty(chaser3_sentby.Text))
                    //{
                    //    MessageBox.Show("Please update Chaser3 Sent By Name");
                    //}
                    //else if (!string.IsNullOrEmpty(qc_overallstatus.Text) && qc_overallstatus.Text == "No" && string.IsNullOrEmpty(qc_typeoferror.Text))
                    //{
                    //    MessageBox.Show("Please update Type Of error");
                    //}
                    //else if (!string.IsNullOrEmpty(qc_typeoferror.Text) && qc_qualityparameters.CheckedItems.Count == 0)
                    //{
                    //    MessageBox.Show("Please select Quality Parameters");
                    //}
                    else if(synthetic_approval_raiseddate.Text.Trim() != string.Empty && synthetic_approval_raisedtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_Raisedtime");
                    }
                    else if (synthetic_approval_raiseddate.Text.Trim() == string.Empty && synthetic_approval_raisedtime.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_RaisedDate");
                    }
                    else if(synthetic_approval_receiveddate.Text.Trim() != string.Empty && synthetic_approval_receivedtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_ReceivedTime");
                    }
                    else if (synthetic_approval_receiveddate.Text.Trim() == string.Empty && synthetic_approval_receivedtime.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_ReceivedDate");
                    }
                    else
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Records Inserted Successfully");
                        cmd.Parameters.Clear();
                        reset();
                        //queriesraised();
                        //pending();
                        //completed();
                        conn.Close();
                    }

                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error generated details" + ab.ToString());
                }
            }
            else
            {
                requestid.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to update the record?";
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
                    cmd.CommandText = "dbo.usp_crm_update_dotnet";
                    //cmd.CommandText = "update tbl_crm_daily_dotnet set RequestType=@RequestTypeparam1,ReceivedDate=@ReceivedDateparam1,ReceivedTime=@ReceivedTimeparam1,Volumes=@Volumesparam1,PartyName=@PartyNameparam1,PartyLocation=@PartyLocationparam1,UpdatedLegalEntityName=@UpdatedLegalEntityNameparam1,TypeOfParty=@TypeOfPartyparam1,ValidationSource=@ValidationSourceparam1,AssociateName=@AssociateNameparam1,QueryRaisedDate=@QueryRaisedDateparam1,QueryRaisedTime=@QueryRaisedTimeparam1,TypeOfQuery=@TypeOfQueryparam1,QueryResolvedDate=@QueryResolvedDateparam1,QueryResolvedTime=@QueryResolvedTimeparam1,QueryResolvedBy=@QueryResolvedByparam1,CompletionDate=@CompletionDateparam1,CompletionTime=@CompletionTimeparam1,InvestigationPlaced=@InvestigationPlacedparam1,InvestigationRaisedDate=@InvestigationRaisedDateparam1,InvestigationRaisedTime=@InvestigationRaisedTimeparam1,ReportReceivedDate=@ReportReceivedDateparam1,ReportReceivedTime=@ReportReceivedTimeparam1,TypeOfUpdateRequired=@TypeOfUpdateRequiredparam1,RequestorBusinessUnit=@RequestorBusinessUnitparam1,RequestorEmailAddress=@RequestorEmailAddressparam1,RequestorSegmentName=@RequestorSegmentNameparam1,Comments=@Commentsparam1,LastUpdateDateTime=@LastUpdateDateTimeparam,RequestorOffice=@RequestorOfficeparam,LastUpdatedBy=@LastUpdatedByparam,MachineName=@MachineNameparam where requestid=@requestidparam1";
                    cmd.Parameters.AddWithValue("@requestid", requestid.Text);
                    if (synthetic_approval_raiseddate.Text.Trim() != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_RaisedDate", synthetic_approval_raiseddate.Value.Date);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_Raisedtime", synthetic_approval_raisedtime.Value.ToLongTimeString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_RaisedDate", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_Raisedtime", DBNull.Value);
                    }

                    if (synthetic_approval_receiveddate.Text.Trim() != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedDate", synthetic_approval_receiveddate.Value.Date);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedTime", synthetic_approval_receivedtime.Value.ToLongTimeString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedDate", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Synthetic_Approval_ReceivedTime", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@RequestTypeparam", requesttype.Text);
                    if (chaser1sent.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Statusparam", 1);
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Status_Dateparam", chaser1_sentdate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryChaser1_SentBy", chaser1_sentby.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Statusparam", 0);
                        cmd.Parameters.AddWithValue("@QueryChaser1Sent_Status_Dateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryChaser1_SentBy", DBNull.Value);
                    }
                    if (chaser2sent.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Statusparam", 1);
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Status_Dateparam", chaser2_sentdate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryChaser2_SentBy", chaser2_sentby.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Statusparam", 0);
                        cmd.Parameters.AddWithValue("@QueryChaser2Sent_Status_Dateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryChaser2_SentBy", DBNull.Value);
                    }
                    //if (chaser3sent.Checked == true)
                    //{
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Statusparam", 1);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Status_Dateparam", chaser3_sentdate.Value.Date);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3_SentBy", chaser3_sentby.Text);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Statusparam", 0);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3Sent_Status_Dateparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@QueryChaser3_SentBy", DBNull.Value);
                    //}
                    cmd.Parameters.AddWithValue("@ReceivedDateparam", receiveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@ReceivedTimeparam", receivedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@Volumesparam", volumes.Value);
                    cmd.Parameters.AddWithValue("@PartyNameparam", partyname.Text);
                    if (string.IsNullOrEmpty(partylocation.Text))
                    {
                        cmd.Parameters.AddWithValue("@PartyLocationparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PartyLocationparam", partylocation.Text);
                    }
                    //if (string.IsNullOrEmpty(updatedlegalentityname.Text))
                    //{
                    //    cmd.Parameters.AddWithValue("@UpdatedLegalEntityNameparam", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@UpdatedLegalEntityNameparam", updatedlegalentityname.Text);
                    //}
                    //if (string.IsNullOrEmpty(typeofparty.Text))
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfPartyparam", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfPartyparam", typeofparty.Text);
                    //}
                    cmd.Parameters.AddWithValue("@AssociateNameparam", associatename.Text);
                    if (checkBox1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@QueryRaisedDateparam", queryraiseddate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", queryraisedtime.Value.ToLongTimeString());
                        cmd.Parameters.AddWithValue("@TypeOfQueryparam", typeofquery.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryRaisedDateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryRaisedTimeparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@TypeOfQueryparam", DBNull.Value);
                    }
                    if (checkBox2.Checked)
                    {
                        cmd.Parameters.AddWithValue("@QueryResolvedDateparam", queryresolveddate.Value.Date);
                        cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", queryresolvedtime.Value.ToShortTimeString());
                        cmd.Parameters.AddWithValue("@QueryResolvedByparam", queryresolvedby.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@QueryResolvedDateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryResolvedTimeparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@QueryResolvedByparam", DBNull.Value);
                    }
                    if (checkBox3.Checked)
                    {
                        cmd.Parameters.AddWithValue("@CompletionDateparam", completiondate.Value.Date);
                        cmd.Parameters.AddWithValue("@CompletionTimeparam", completiontime.Value.ToShortTimeString());
                        //cmd.Parameters.AddWithValue("@ValidationSourceparam", validationsource.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompletionDateparam", DBNull.Value);
                        cmd.Parameters.AddWithValue("@CompletionTimeparam", DBNull.Value);
                        //cmd.Parameters.AddWithValue("@ValidationSourceparam", DBNull.Value);
                    }
                    //if (checkBox4.Checked)
                    //{
                    //    cmd.Parameters.AddWithValue("@InvestigationPlacedparam", investigationplaced.Text);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedDateparam", investigationraiseddate.Value.Date);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedTimeparam", investigationraisedtime.Value.ToLongTimeString());
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@InvestigationPlacedparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedDateparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@InvestigationRaisedTimeparam", DBNull.Value);
                    //}

                    //if (checkBox5.Checked)
                    //{
                    //    cmd.Parameters.AddWithValue("@ReportReceivedDateparam", reportreceiveddate.Value.Date);
                    //    cmd.Parameters.AddWithValue("@ReportReceivedTimeparam", reportreceivedtime.Value.ToLongTimeString());
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@ReportReceivedDateparam", DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@ReportReceivedTimeparam", DBNull.Value);
                    //}
                    //if (string.IsNullOrEmpty(typeofupdaterequired.Text))
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfUpdateRequiredparam", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@TypeOfUpdateRequiredparam", typeofupdaterequired.Text);
                    //}
                    if (string.IsNullOrEmpty(requestorbusinessunit.Text))
                    {
                        cmd.Parameters.AddWithValue("@RequestorBusinessUnitparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RequestorBusinessUnitparam", requestorbusinessunit.Text);
                    }
                    if (string.IsNullOrEmpty(requestoremailaddress.Text))
                    {
                        cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", requestoremailaddress.Text);
                    }
                    if (string.IsNullOrEmpty(requestorsegmentname.Text))
                    {
                        cmd.Parameters.AddWithValue("@RequestorSegmentNameparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RequestorSegmentNameparam", requestorsegmentname.Text);
                    }
                    if (string.IsNullOrEmpty(Comments.Text))
                    {
                        cmd.Parameters.AddWithValue("@Commentsparam", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Commentsparam", Comments.Text);
                    }
                    cmd.Parameters.AddWithValue("@LastUpdateDateTimeparam", DateTime.Now.ToLocalTime());
                    //cmd.Parameters.AddWithValue("@RequestorOfficeparam", requestoroffice.Text);
                    cmd.Parameters.AddWithValue("@LastUpdatedByparam", Environment.UserName.ToString());
                    cmd.Parameters.AddWithValue("@MachineNameparam", Environment.MachineName.ToString());
                    if (string.IsNullOrEmpty(foundinfactiva.Text))
                    {
                        cmd.Parameters.AddWithValue("@FoundInFactiva", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FoundInFactiva", foundinfactiva.Text);
                    }
                    if (string.IsNullOrEmpty(wftrequestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@wftrequestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@wftrequestid", wftrequestid.Text);
                    }
                    if (checkbox_termination.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@terminationstatus", "Yes");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@terminationstatus", "No");
                    }



                    //if conditions
                    if (receiveddate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Received Date cannnot be greater than today's date");
                    }
                    else if (queryraiseddate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Query Raised Date cannnot be greater than today's date");
                    }
                    else if (queryresolveddate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Query Resolved Date cannot be greater than today's date");
                    }
                    //else if (investigationraiseddate.Value.Date > today.Value.Date)
                    //{
                    //    MessageBox.Show("Investigation Raised Date cannot be greater than today's date");
                    //}
                    //else if (reportreceiveddate.Value.Date > today.Value.Date)
                    //{
                    //    MessageBox.Show("Report Received Date cannot be greater than today's date");
                    //}
                    else if (completiondate.Value.Date > today.Value.Date)
                    {
                        MessageBox.Show("Completion date cannot be greater than today's date");
                    }
                    else if (checkBox1.Checked && checkBox2.Checked && queryraiseddate.Value.Date > queryresolveddate.Value.Date)
                    {
                        MessageBox.Show("Query Raised Date cannot be greater than Query resolved Date");
                    }
                    else if (checkBox3.Checked && receiveddate.Value.Date > completiondate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than Completion Date");
                    }
                    else if (checkBox1.Checked && receiveddate.Value.Date > queryraiseddate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than Query Raised Date");
                    }
                    else if (checkBox1.Checked && checkBox2.Checked && receiveddate.Value.Date > queryresolveddate.Value.Date)
                    {
                        MessageBox.Show("Received Date cannot be greater than Query Resolved Date");
                    }
                    else if (checkBox1.Checked && checkBox3.Checked && queryraiseddate.Value.Date > completiondate.Value.Date)
                    {
                        MessageBox.Show("Query Raised Date cannot be greater than Completion Date");
                    }
                    else if (checkBox2.Checked && checkBox3.Checked && queryresolveddate.Value.Date > completiondate.Value.Date)
                    {
                        MessageBox.Show("Query Resolved Date cannot be greater than Completion Date");
                    }
                    else if (checkBox1.Checked && string.IsNullOrEmpty(typeofquery.Text))
                    {
                        MessageBox.Show("Please update Type Of Query");
                    }
                    else if (checkBox2.Checked && string.IsNullOrEmpty(queryresolvedby.Text))
                    {
                        MessageBox.Show("Please update query resolved by");
                    }
                    //else if (checkBox3.Checked && string.IsNullOrEmpty(validationsource.Text))
                    //{
                    //    MessageBox.Show("Please update Validation Soure");
                    //}
                    //else if (checkBox4.Checked && string.IsNullOrEmpty(investigationplaced.Text))
                    //{
                    //    MessageBox.Show("Please update investigation placed?");
                    //}
                    else if (checkBox1.Checked && checkBox3.Checked && !checkBox2.Checked)
                    {
                        MessageBox.Show("Please update Query Resolved Date");
                    }
                    else if (checkBox2.Checked && !checkBox1.Checked)
                    {
                        MessageBox.Show("Please update Query Raised Date");
                    }
                    else if (string.IsNullOrEmpty(requesttype.Text))
                    {
                        MessageBox.Show("Please update Request Type");
                    }
                    else if (string.IsNullOrEmpty(partyname.Text))
                    {
                        MessageBox.Show("Please update Party Name");
                    }
                    else if (string.IsNullOrEmpty(associatename.Text))
                    {
                        MessageBox.Show("Please update Associate Name");
                    }
                    else if (requesttype.Text != "Adhoc" && string.IsNullOrEmpty(requestorbusinessunit.Text))
                    {
                        MessageBox.Show("Please update Requestor Business Unit");
                    }
                    else if (requesttype.Text != "Adhoc" && string.IsNullOrEmpty(requestoremailaddress.Text))
                    {
                        MessageBox.Show("Please update Requestor Email Address");
                    }
                    else if (requesttype.Text == "BAU" && string.IsNullOrEmpty(partylocation.Text))
                    {
                        MessageBox.Show("Please update Party Location");
                    }
                    else if (requesttype.Text == "MailBox" && string.IsNullOrEmpty(partylocation.Text))
                    {
                        MessageBox.Show("Please update Party Location");
                    }
                    else if (requesttype.Text == "Self Service" && string.IsNullOrEmpty(partylocation.Text))
                    {
                        MessageBox.Show("Please update Party Location");
                    }
                    //else if (partylocation.Text == "India")
                    //{
                    //    MessageBox.Show("Record cannot be processed due to regulatory restrictions where Party Location is India");
                    //}
                    //else if (string.IsNullOrEmpty(partylocation.Text) && requesttype.Text != "Adhoc")
                    //{
                    //    MessageBox.Show("Please update Party Location");
                    //}
                    else if (requestorbusinessunit.Text == "Accident & Health India" || requestorbusinessunit.Text == "Aerospace India" || requestorbusinessunit.Text == "Claims India" || requestorbusinessunit.Text == "CPC India" || requestorbusinessunit.Text == "Energy India" || requestorbusinessunit.Text == "FINEX India" || requestorbusinessunit.Text == "Human Resources India" || requestorbusinessunit.Text == "International India" || requestorbusinessunit.Text == "Marine India" || requestorbusinessunit.Text == "Market Security India " || requestorbusinessunit.Text == "Reinsurance India")
                    {
                        MessageBox.Show("Record cannot be processed due to regulatory restrictions where Requestor Business Unit is India");
                    }
                    else if (chaser1sent.Checked == true && chaser1_sentdate.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Chaser1 Sent Date");
                    }
                    else if (chaser2sent.Checked == true && chaser2_sentdate.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Chaser2 Sent Date");
                    }
                    //else if (chaser3sent.Checked == true && chaser3_sentdate.Text.Trim() == string.Empty)
                    //{
                    //    MessageBox.Show("Please update Chaser3 Sent Date");
                    //}
                    else if (chaser1sent.Checked == false && chaser1_sentdate.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please checkbox Chaser1 Sent");
                    }
                    else if (chaser2sent.Checked == false && chaser2_sentdate.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please checkbox Chaser2 Sent");
                    }
                    //else if (chaser3sent.Checked == false && chaser3_sentdate.Text.Trim() != string.Empty)
                    //{
                    //    MessageBox.Show("Please checkbox Chaser1 Sent");
                    //}
                    else if (chaser1_sentdate.Text.Trim() != string.Empty && chaser2_sentdate.Text.Trim() != string.Empty && chaser1_sentdate.Value.Date > chaser2_sentdate.Value.Date)
                    {
                        MessageBox.Show("Chaser1 Sent Date cannnot be more than Chaser2 Sent Date");
                    }
                    //else if (chaser2_sentdate.Text.Trim() != string.Empty && chaser3_sentdate.Text.Trim() != string.Empty && chaser2_sentdate.Value.Date > chaser3_sentdate.Value.Date)
                    //{
                    //    MessageBox.Show("Chaser2 Sent Date cannnot be more than Chaser3 Sent Date");
                    //}
                    //else if (chaser1_sentdate.Text.Trim() != string.Empty && chaser3_sentdate.Text.Trim() != string.Empty && chaser1_sentdate.Value.Date > chaser3_sentdate.Value.Date)
                    //{
                    //    MessageBox.Show("Chaser1 Sent Date cannnot be more than Chaser3 Sent Date");
                    //}
                    else if (chaser1_sentdate.Text.Trim() != string.Empty && string.IsNullOrEmpty(chaser1_sentby.Text))
                    {
                        MessageBox.Show("Please update Chaser1 Sent By Name");
                    }
                    else if (chaser2_sentdate.Text.Trim() != string.Empty && string.IsNullOrEmpty(chaser2_sentby.Text))
                    {
                        MessageBox.Show("Please update Chaser2 Sent By Name");
                    }
                    //else if (chaser3_sentdate.Text.Trim() != string.Empty && string.IsNullOrEmpty(chaser3_sentby.Text))
                    //{
                    //    MessageBox.Show("Please update Chaser3 Sent By Name");
                    //}
                    //else if (!string.IsNullOrEmpty(qc_overallstatus.Text) && qc_overallstatus.Text == "No" && string.IsNullOrEmpty(qc_typeoferror.Text))
                    //{
                    //    MessageBox.Show("Please update Type Of error");
                    //}
                    //else if (!string.IsNullOrEmpty(qc_typeoferror.Text) && qc_qualityparameters.CheckedItems.Count == 0)
                    //{
                    //    MessageBox.Show("Please select Quality Parameters");
                    //}
                    else if (synthetic_approval_raiseddate.Text.Trim() != string.Empty && synthetic_approval_raisedtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_Raisedtime");
                    }
                    else if (synthetic_approval_raiseddate.Text.Trim() == string.Empty && synthetic_approval_raisedtime.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_RaisedDate");
                    }
                    else if (synthetic_approval_receiveddate.Text.Trim() != string.Empty && synthetic_approval_receivedtime.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_ReceivedTime");
                    }
                    else if (synthetic_approval_receiveddate.Text.Trim() == string.Empty && synthetic_approval_receivedtime.Text.Trim() != string.Empty)
                    {
                        MessageBox.Show("Please update Synthetic_Approval_ReceivedDate");
                    }
                    else
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Records Updated Successfully");
                        cmd.Parameters.Clear();
                        reset();
                        //queriesraised();
                        //pending();
                        //completed();
                        conn.Close();
                    }
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Error generated details" + ab.ToString());
                }
            }
            else
            {
                requestid.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                queryraiseddate.Enabled = true;
                queryraisedtime.Enabled = true;
                typeofquery.Enabled = true;
            }
            else
            {
                queryraiseddate.Enabled = false;
                //queryraiseddate.Text = DateTime.Now.ToLongDateString();
                queryraisedtime.Enabled = false;
                typeofquery.SelectedIndex = -1;
                typeofquery.Enabled = false;
                queryraiseddate.CustomFormat = " ";
                queryraisedtime.CustomFormat = " ";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                queryresolveddate.Enabled = true;
                queryresolvedtime.Enabled = true;
                queryresolvedby.Enabled = true;
                
            }
            else
            {
                queryresolveddate.Enabled = false;
                queryresolvedtime.Enabled = false;
                queryresolvedby.SelectedIndex = -1;
                queryresolvedby.Enabled = false;
                queryresolveddate.CustomFormat = " ";
                queryresolvedtime.CustomFormat = " ";
              

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                completiondate.Enabled = true;
                completiontime.Enabled = true;
                //validationsource.Enabled = true;
            }
            else
            {
                completiondate.Enabled = false;
                completiontime.Enabled = false;
                //validationsource.SelectedIndex = -1;
                //validationsource.Enabled = false;
            }
        }


        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset();
        }

  

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                datagridview.Enabled = true;
                segmentname_list();
                requestorbusinessunit_list();
                if (e.RowIndex >= 0)
                {
                    
                    DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                    requestid.Text = row.Cells["txtRequestID3"].Value.ToString();
                    requesttype.Text = row.Cells["txtRequestType3"].Value.ToString();
                    receiveddate.CustomFormat = "dd-MMMM-yyyy";
                    receiveddate.Text = row.Cells["txtReceivedDate3"].Value.ToString();
                    receivedtime.CustomFormat = "HH:mm:ss";
                    receivedtime.Text = row.Cells["txtReceivedTime3"].Value.ToString();
                    volumes.Value = Convert.ToInt32(row.Cells["txtVolumes3"].Value);
                    if (string.IsNullOrEmpty(row.Cells["txtPartyName3"].Value.ToString()))
                    {
                        partyname.Text = string.Empty;
                    }
                    else
                    {
                        partyname.Text = row.Cells["txtPartyName3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtFoundInFactiva3"].Value.ToString()))
                    {
                        foundinfactiva.SelectedIndex = -1;
                    }
                    else
                    {
                        foundinfactiva.Text = row.Cells["txtFoundInFactiva3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtPartyLocation3"].Value.ToString()))
                    {
                        partylocation.SelectedIndex = -1;
                    }
                    else
                    {
                        partylocation.Text = row.Cells["txtPartyLocation3"].Value.ToString();
                    }
                    //if (string.IsNullOrEmpty(row.Cells["txtUpdatedLegalEntityName3"].Value.ToString()))
                    //{
                    //    updatedlegalentityname.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    updatedlegalentityname.Text = row.Cells["txtUpdatedLegalEntityName3"].Value.ToString();
                    //}
                    //if (string.IsNullOrEmpty(row.Cells["txtTypeOfParty3"].Value.ToString()))
                    //{
                    //    typeofparty.SelectedIndex = -1;
                    //}
                    //else
                    //{
                    //    typeofparty.Text = row.Cells["txtTypeOfParty3"].Value.ToString();
                    //}

                    if (string.IsNullOrEmpty(row.Cells["txtAssociateName3"].Value.ToString()))
                    {
                        associatename.SelectedIndex = -1;
                    }
                    else
                    {
                        associatename.Text = row.Cells["txtAssociateName3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtQueryRaisedDate3"].Value.ToString()))
                    {
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = true;
                        queryraiseddate.CustomFormat = "dd-MMMM-yyyy";
                        queryraiseddate.Text = row.Cells["txtQueryRaisedDate3"].Value.ToString();
                        queryraisedtime.CustomFormat = "HH:mm:ss";
                        queryraisedtime.Text = row.Cells["txtQueryRaisedTime3"].Value.ToString();
                        typeofquery.Text = row.Cells["txtTypeOfQuery3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtQueryResolvedDate3"].Value.ToString()))
                    {
                        checkBox2.Checked = false;
                    }
                    else
                    {
                        checkBox2.Checked = true;
                        queryresolveddate.CustomFormat = "dd-MMMM-yyyy";
                        queryresolveddate.Text = row.Cells["txtQueryResolvedDate3"].Value.ToString();
                        queryresolvedtime.CustomFormat = "HH:mm:ss";
                        queryresolvedtime.Text = row.Cells["txtQueryResolvedTime3"].Value.ToString();
                        queryresolvedby.Text = row.Cells["txtQueryResolvedBy3"].Value.ToString();
                    }
                    if (!string.IsNullOrEmpty(row.Cells["txtSynthetic_Approval_RaisedDate_3"].Value.ToString()))
                    {
                        synthetic_approval_raiseddate.CustomFormat = "dd-MMMM-yyyy";
                        synthetic_approval_raiseddate.Text = row.Cells["txtSynthetic_Approval_RaisedDate_3"].Value.ToString();
                        synthetic_approval_raisedtime.CustomFormat = "HH:mm:ss";
                        synthetic_approval_raisedtime.Text = row.Cells["txtSynthetic_Approval_Raisedtime_3"].Value.ToString();
                    }
                    else
                    {
                        synthetic_approval_raiseddate.CustomFormat = " ";
                        synthetic_approval_raisedtime.CustomFormat = " ";
                    }
                    

                    if (!string.IsNullOrEmpty(row.Cells["txtSynthetic_Approval_ReceivedDate_3"].Value.ToString()))
                    {
                        synthetic_approval_receiveddate.CustomFormat = "dd-MMMM-yyyy";
                        synthetic_approval_receiveddate.Text = row.Cells["txtSynthetic_Approval_ReceivedDate_3"].Value.ToString();
                        synthetic_approval_receivedtime.CustomFormat = "HH:mm:ss";
                        synthetic_approval_receivedtime.Text = row.Cells["txtSynthetic_Approval_ReceivedTime_3"].Value.ToString();
                    }
                    else
                    {
                        synthetic_approval_receiveddate.CustomFormat = " ";
                        synthetic_approval_receivedtime.CustomFormat = " ";
                    }
                    
                    if (string.IsNullOrEmpty(row.Cells["txtCompletionDate3"].Value.ToString()))
                    {
                        checkBox3.Checked = false;
                    }
                    else
                    {
                        checkBox3.Checked = true;
                        completiondate.CustomFormat = "dd-MMMM-yyyy";
                        completiondate.Text = row.Cells["txtCompletionDate3"].Value.ToString();
                        completiontime.CustomFormat = "HH:mm:ss";
                        completiontime.Text = row.Cells["txtCompletionTime3"].Value.ToString();
                        //validationsource.Text = row.Cells["txtValidationSource3"].Value.ToString();
                    }
                    //if (string.IsNullOrEmpty(row.Cells["txtInvestigationRaisedDate3"].Value.ToString()))
                    //{
                    //    checkBox4.Checked = false;
                    //}
                    //else
                    //{
                    //    checkBox4.Checked = true;
                    //    investigationraiseddate.CustomFormat = "dd-MMMM-yyyy";
                    //    investigationraiseddate.Text = row.Cells["txtInvestigationRaisedDate3"].Value.ToString();
                    //    investigationraisedtime.CustomFormat = "HH:mm:ss";
                    //    investigationraisedtime.Text = row.Cells["txtInvestigationRaisedTime3"].Value.ToString();
                    //    investigationplaced.Text = row.Cells["txtInvestigationPlaced3"].Value.ToString();
                    //}
                    //if (string.IsNullOrEmpty(row.Cells["txtReportReceivedDate3"].Value.ToString()))
                    //{
                    //    checkBox5.Checked = false;
                    //}
                    //else
                    //{
                    //    checkBox5.Checked = true;
                    //    reportreceiveddate.CustomFormat = "dd-MMMM-yyyy";
                    //    reportreceiveddate.Text = row.Cells["txtReportReceivedDate3"].Value.ToString();
                    //    reportreceivedtime.CustomFormat = "HH:mm:ss";
                    //    reportreceivedtime.Text = row.Cells["txtReportReceivedTime3"].Value.ToString();
                    //}
                    //if (string.IsNullOrEmpty(row.Cells["txtTypeOfUpdateRequired3"].Value.ToString()))
                    //{
                    //    typeofupdaterequired.SelectedIndex = -1;
                    //}
                    //else
                    //{
                    //    typeofupdaterequired.Text = row.Cells["txtTypeOfUpdateRequired3"].Value.ToString();
                    //}
                    if (string.IsNullOrEmpty(row.Cells["txtRequestorBusinessUnit3"].Value.ToString()))
                    {
                        requestorbusinessunit.SelectedIndex = -1;
                    }
                    else
                    {
                        requestorbusinessunit.Text = row.Cells["txtRequestorBusinessUnit3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtRequestorEmailAddress3"].Value.ToString()))
                    {
                        requestoremailaddress.Text = string.Empty;
                    }
                    else
                    {
                        requestoremailaddress.Text = row.Cells["txtRequestorEmailAddress3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtRequestorSegmentName3"].Value.ToString()))
                    {
                        requestorsegmentname.SelectedIndex = -1;
                    }
                    else
                    {
                        requestorsegmentname.Text = row.Cells["txtRequestorSegmentName3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtComments3"].Value.ToString()))
                    {
                        Comments.Text = string.Empty;
                    }
                    else
                    {
                        Comments.Text = row.Cells["txtComments3"].Value.ToString();
                    }
                    //if (string.IsNullOrEmpty(row.Cells["txtRequestorOffice3"].Value.ToString()))
                    //{
                    //    requestoroffice.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    requestoroffice.Text = row.Cells["txtRequestorOffice3"].Value.ToString();
                    //}
                    if (string.IsNullOrEmpty(row.Cells["txtQueryChaser1Sent_Status_Date_3"].Value.ToString()))
                    {
                        chaser1sent.Checked = false;
                        chaser1_sentdate.CustomFormat = " ";
                        chaser1_sentby.SelectedIndex = -1;
                    }
                    else
                    {
                        chaser1sent.Checked = true;
                        chaser1_sentdate.Text = row.Cells["txtQueryChaser1Sent_Status_Date_3"].Value.ToString();
                        chaser1_sentdate.CustomFormat = "dd-MMMM-yyyy";
                        chaser1_sentby.Text = row.Cells["txtQueryChaser1_SentBy_3"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtQueryChaser2Sent_Status_Date_3"].Value.ToString()))
                    {
                        chaser2sent.Checked = false;
                        chaser2_sentdate.CustomFormat = " ";
                        chaser2_sentby.SelectedIndex = -1;
                    }
                    else
                    {
                        chaser2sent.Checked = true;
                        chaser2_sentdate.Text = row.Cells["txtQueryChaser2Sent_Status_Date_3"].Value.ToString();
                        chaser2_sentdate.CustomFormat = "dd-MMMM-yyyy";
                        chaser2_sentby.Text = row.Cells["txtQueryChaser2_SentBy_3"].Value.ToString();
                    }
                    //if (string.IsNullOrEmpty(row.Cells["txtQueryChaser3Sent_Status_Date_3"].Value.ToString()))
                    //{
                    //    chaser3sent.Checked = false;
                    //    chaser3_sentdate.CustomFormat = " ";
                    //    chaser3_sentby.SelectedIndex = -1;
                    //}
                    //else
                    //{
                    //    chaser3sent.Checked = true;
                    //    chaser3_sentdate.Text = row.Cells["txtQueryChaser3Sent_Status_Date_3"].Value.ToString();
                    //    chaser3_sentdate.CustomFormat = "dd-MMMM-yyyy";
                    //    chaser3_sentby.Text = row.Cells["txtQueryChaser3_SentBy_3"].Value.ToString();
                    //}
                    if (string.IsNullOrEmpty(row.Cells["txtWFT_RequestID_3"].Value.ToString()))
                    {
                        wftrequestid.Text = string.Empty;
                    }
                    else
                    {
                        wftrequestid.Text = row.Cells["txtWFT_RequestID_3"].Value.ToString();
                    }
                    if (row.Cells["txtTermination_Status_3"].Value.ToString() == "Yes")
                    {
                        checkbox_termination.Checked = true;
                    }
                    else
                    {
                        checkbox_termination.Checked = false;
                    }

                    
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
            else
            {
                requestid.Focus();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BulkUpload obj1 = new BulkUpload();
            obj1.Show();
        }

    
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_CRM_Daily_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
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


        private void requesttype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                requesttype.SelectedIndex = -1;
            }
        }

        private void partylocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                partylocation.SelectedIndex = -1;
            }
        }


        private void associatename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                associatename.SelectedIndex = -1;
            }
        }

        private void typeofquery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                typeofquery.SelectedIndex = -1;
            }
        }

        private void queryresolvedby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryresolvedby.SelectedIndex = -1;
            }
        }

       
        private void requestorbusinessunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                requestorbusinessunit.SelectedIndex = -1;
            }
        }

        private void requestorsegmentname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                requestorsegmentname.SelectedIndex = -1;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj2 = new Form2();
            obj2.Show();
        }


        private void searchpartynamepending_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
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

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.TabPages.ToString() == "tabpage1")
            //{
            //    queriesraised();
            //}
            //else if (tabControl1.TabPages.ToString() == "tabpage2")
            //{
            //    pending();
            //}
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            //queriesraised();
        }

        private void dataGridView3_MouseEnter(object sender, EventArgs e)
        {
            //pending();
        }

        private void dataGridView4_MouseEnter(object sender, EventArgs e)
        {
            //completed();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel1.LinkVisited = true;
                //System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_CRM_QueryChasers_DotNet");
                System.Diagnostics.Process.Start("\\\\inmum-i-fs5\\group$\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\Automated Workflows\\CRM\\Query Chasers Report");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //if (tabControl1.TabPages.ToString() == "tabpage1")
            //{
            //    queriesraised();
            //}
            //else if (tabControl1.TabPages.ToString() == "tabpage2")
            //{
            //    pending();
            //}
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_CRM_QueryChasers_DotNet");
                //System.Diagnostics.Process.Start("\\\\inmum-i-fs5\\group$\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\Automated Workflows\\CRM\\Query Chasers Report");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void chaser1_sentdate_ValueChanged(object sender, EventArgs e)
        {
            chaser1_sentdate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser1_sentdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser1_sentdate.CustomFormat = " ";
            }
        }

        private void chaser2_sentdate_ValueChanged(object sender, EventArgs e)
        {
            chaser2_sentdate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser2_sentdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser2_sentdate.CustomFormat = " ";
            }
        }

        private void chaser1sent_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        

        private void qcworkflow_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            QC_Form obj_qcform = new QC_Form();
            obj_qcform.Show();
        }

        private void searchby_associatename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_associatename.SelectedIndex = -1;
            }
        }

        private void searchby_requeststatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_requeststatus.SelectedIndex = -1;
            }
        }

        private void searchby_requestid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_associatename_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_requeststatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void requestoremailaddress_TextChanged(object sender, EventArgs e)
        {
            if (datagridview.Enabled == false)
            {
                autopopulate_businessunit();
                autopopulate_segment();
            }
            //else
            //{
            //    segmentname_list();
            //    requestorbusinessunit_list();
            //}
        }

        public void autopopulate_segment()
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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "exec dbo.usp_crmworkflow_segment_autopopulate_dotnet @RequestorEmailAddressparam";
                cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", requestoremailaddress.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                requestorsegmentname.DataSource = dt;
                requestorsegmentname.DisplayMember = "Segment";
                //requestorsegmentname.ValueMember = "ID";
                conn.Close();
                requestorsegmentname.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void autopopulate_businessunit()
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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "exec dbo.usp_crmworkflow_businessunit_autopopulate_dotnet @RequestorEmailAddressparam";
                cmd.Parameters.AddWithValue("@RequestorEmailAddressparam", requestoremailaddress.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                requestorbusinessunit.DataSource = dt;
                requestorbusinessunit.DisplayMember = "BusinessUnit";
                //bu.ValueMember = "ID";
                conn.Close();
                requestorbusinessunit.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void requestorbusinessunit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchby_requestid.Text = string.Empty;
            searchby_associatename.SelectedIndex = -1;
            searchby_requeststatus.SelectedIndex = -1;
            searchby_partyname.Text = string.Empty;
        }

        private void searchby_wftrequestid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void synthetic_approval_raiseddate_ValueChanged(object sender, EventArgs e)
        {
            synthetic_approval_raiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void synthetic_approval_raiseddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                synthetic_approval_raiseddate.CustomFormat = " ";
            }
        }

        private void synthetic_approval_receiveddate_ValueChanged(object sender, EventArgs e)
        {
            synthetic_approval_receiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void synthetic_approval_receiveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                synthetic_approval_receiveddate.CustomFormat = " ";
            }
        }

        private void synthetic_approval_raisedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                synthetic_approval_raisedtime.CustomFormat = " ";
            }
        }

        private void synthetic_approval_raisedtime_MouseDown(object sender, MouseEventArgs e)
        {
            synthetic_approval_raisedtime.Text = DateTime.Now.ToLongTimeString();
            synthetic_approval_raisedtime.CustomFormat = "HH:mm:ss";
        }

        private void synthetic_approval_receivedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                synthetic_approval_receivedtime.CustomFormat = " ";
            }
        }

        private void synthetic_approval_receivedtime_MouseDown(object sender, MouseEventArgs e)
        {
            synthetic_approval_receivedtime.Text = DateTime.Now.ToLongTimeString();
            synthetic_approval_receivedtime.CustomFormat = "HH:mm:ss";
        }

        
    }
}
