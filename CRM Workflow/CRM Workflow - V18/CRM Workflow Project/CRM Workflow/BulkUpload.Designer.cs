namespace CRM_Workflow
{
    partial class BulkUpload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.filepath = new System.Windows.Forms.TextBox();
            this.worksheetname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtRequestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeOfParty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestorEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWFT_RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblcrmbulkuploaddotnetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblcrmbulkuploadprojectsdotnetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtRequestType1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceivedDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociateName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartyLocation1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeOfParty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestorBusinessUnit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestorSegmentName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestorEmailAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestorOffice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWFT_RequestID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblcrmbulkuploadprojectsdotnetv1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcrmbulkuploaddotnetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcrmbulkuploadprojectsdotnetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcrmbulkuploadprojectsdotnetv1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(502, 89);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Select File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(65, 210);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 60);
            this.button3.TabIndex = 2;
            this.button3.Text = "Upload File - Non Projects";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(704, 89);
            this.filepath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(523, 26);
            this.filepath.TabIndex = 3;
            // 
            // worksheetname
            // 
            this.worksheetname.Location = new System.Drawing.Point(1263, 89);
            this.worksheetname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.worksheetname.Name = "worksheetname";
            this.worksheetname.Size = new System.Drawing.Size(202, 26);
            this.worksheetname.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(858, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Excel File Complete Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1270, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Excel Worksheet Name";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(386, 210);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(260, 60);
            this.button4.TabIndex = 7;
            this.button4.Text = "Upload Final Data into SQL Database - Non Projects";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtRequestType,
            this.txtReceivedDate,
            this.txtPartyName,
            this.txtTypeOfParty,
            this.txtAssociateName,
            this.txtRequestorEmailAddress,
            this.txtWFT_RequestID});
            this.dataGridView1.DataSource = this.tblcrmbulkuploaddotnetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(38, 312);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(719, 686);
            this.dataGridView1.TabIndex = 8;
            // 
            // txtRequestType
            // 
            this.txtRequestType.DataPropertyName = "RequestType";
            this.txtRequestType.HeaderText = "RequestType";
            this.txtRequestType.Name = "txtRequestType";
            this.txtRequestType.ReadOnly = true;
            // 
            // txtReceivedDate
            // 
            this.txtReceivedDate.DataPropertyName = "ReceivedDate";
            this.txtReceivedDate.HeaderText = "ReceivedDate";
            this.txtReceivedDate.Name = "txtReceivedDate";
            this.txtReceivedDate.ReadOnly = true;
            // 
            // txtPartyName
            // 
            this.txtPartyName.DataPropertyName = "PartyName";
            this.txtPartyName.HeaderText = "PartyName";
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
            // 
            // txtTypeOfParty
            // 
            this.txtTypeOfParty.DataPropertyName = "TypeOfParty";
            this.txtTypeOfParty.HeaderText = "TypeOfParty";
            this.txtTypeOfParty.Name = "txtTypeOfParty";
            this.txtTypeOfParty.ReadOnly = true;
            // 
            // txtAssociateName
            // 
            this.txtAssociateName.DataPropertyName = "AssociateName";
            this.txtAssociateName.HeaderText = "AssociateName";
            this.txtAssociateName.Name = "txtAssociateName";
            this.txtAssociateName.ReadOnly = true;
            // 
            // txtRequestorEmailAddress
            // 
            this.txtRequestorEmailAddress.DataPropertyName = "RequestorEmailAddress";
            this.txtRequestorEmailAddress.HeaderText = "RequestorEmailAddress";
            this.txtRequestorEmailAddress.Name = "txtRequestorEmailAddress";
            this.txtRequestorEmailAddress.ReadOnly = true;
            // 
            // txtWFT_RequestID
            // 
            this.txtWFT_RequestID.DataPropertyName = "WFT_RequestID";
            this.txtWFT_RequestID.HeaderText = "WFT_RequestID";
            this.txtWFT_RequestID.Name = "txtWFT_RequestID";
            this.txtWFT_RequestID.ReadOnly = true;
            // 
            // tblcrmbulkuploaddotnetBindingSource
            // 
            this.tblcrmbulkuploaddotnetBindingSource.DataMember = "tbl_crm_bulkupload_dotnet";
            // 
            // tblcrmbulkuploadprojectsdotnetBindingSource
            // 
            this.tblcrmbulkuploadprojectsdotnetBindingSource.DataMember = "tbl_crm_bulkupload_projects_dotnet";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1110, 210);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(222, 60);
            this.button5.TabIndex = 10;
            this.button5.Text = "Upload File - Projects";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1408, 210);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(260, 60);
            this.button6.TabIndex = 11;
            this.button6.Text = "Upload Final Data into SQL Database - Projects";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtRequestType1,
            this.txtReceivedDate1,
            this.txtPartyName1,
            this.txtAssociateName1,
            this.txtPartyLocation1,
            this.txtTypeOfParty1,
            this.txtRequestorBusinessUnit1,
            this.txtRequestorSegmentName1,
            this.txtRequestorEmailAddress1,
            this.txtRequestorOffice1,
            this.txtWFT_RequestID1});
            this.dataGridView2.Location = new System.Drawing.Point(833, 312);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1019, 686);
            this.dataGridView2.TabIndex = 12;
            // 
            // txtRequestType1
            // 
            this.txtRequestType1.DataPropertyName = "RequestType";
            this.txtRequestType1.HeaderText = "RequestType";
            this.txtRequestType1.Name = "txtRequestType1";
            this.txtRequestType1.ReadOnly = true;
            // 
            // txtReceivedDate1
            // 
            this.txtReceivedDate1.DataPropertyName = "ReceivedDate";
            this.txtReceivedDate1.HeaderText = "ReceivedDate";
            this.txtReceivedDate1.Name = "txtReceivedDate1";
            this.txtReceivedDate1.ReadOnly = true;
            // 
            // txtPartyName1
            // 
            this.txtPartyName1.DataPropertyName = "PartyName";
            this.txtPartyName1.HeaderText = "PartyName";
            this.txtPartyName1.Name = "txtPartyName1";
            this.txtPartyName1.ReadOnly = true;
            // 
            // txtAssociateName1
            // 
            this.txtAssociateName1.DataPropertyName = "AssociateName";
            this.txtAssociateName1.HeaderText = "AssociateName";
            this.txtAssociateName1.Name = "txtAssociateName1";
            this.txtAssociateName1.ReadOnly = true;
            // 
            // txtPartyLocation1
            // 
            this.txtPartyLocation1.DataPropertyName = "PartyLocation";
            this.txtPartyLocation1.HeaderText = "PartyLocation";
            this.txtPartyLocation1.Name = "txtPartyLocation1";
            this.txtPartyLocation1.ReadOnly = true;
            // 
            // txtTypeOfParty1
            // 
            this.txtTypeOfParty1.DataPropertyName = "TypeOfParty";
            this.txtTypeOfParty1.HeaderText = "TypeOfParty";
            this.txtTypeOfParty1.Name = "txtTypeOfParty1";
            this.txtTypeOfParty1.ReadOnly = true;
            // 
            // txtRequestorBusinessUnit1
            // 
            this.txtRequestorBusinessUnit1.DataPropertyName = "RequestorBusinessUnit";
            this.txtRequestorBusinessUnit1.HeaderText = "RequestorBusinessUnit";
            this.txtRequestorBusinessUnit1.Name = "txtRequestorBusinessUnit1";
            this.txtRequestorBusinessUnit1.ReadOnly = true;
            // 
            // txtRequestorSegmentName1
            // 
            this.txtRequestorSegmentName1.DataPropertyName = "RequestorSegmentName";
            this.txtRequestorSegmentName1.HeaderText = "RequestorSegmentName";
            this.txtRequestorSegmentName1.Name = "txtRequestorSegmentName1";
            this.txtRequestorSegmentName1.ReadOnly = true;
            // 
            // txtRequestorEmailAddress1
            // 
            this.txtRequestorEmailAddress1.DataPropertyName = "RequestorEmailAddress";
            this.txtRequestorEmailAddress1.HeaderText = "RequestorEmailAddress";
            this.txtRequestorEmailAddress1.Name = "txtRequestorEmailAddress1";
            this.txtRequestorEmailAddress1.ReadOnly = true;
            // 
            // txtRequestorOffice1
            // 
            this.txtRequestorOffice1.DataPropertyName = "RequestorOffice";
            this.txtRequestorOffice1.HeaderText = "RequestorOffice";
            this.txtRequestorOffice1.Name = "txtRequestorOffice1";
            this.txtRequestorOffice1.ReadOnly = true;
            // 
            // txtWFT_RequestID1
            // 
            this.txtWFT_RequestID1.DataPropertyName = "WFT_RequestID";
            this.txtWFT_RequestID1.HeaderText = "WFT_RequestID";
            this.txtWFT_RequestID1.Name = "txtWFT_RequestID1";
            this.txtWFT_RequestID1.ReadOnly = true;
            // 
            // tblcrmbulkuploadprojectsdotnetv1BindingSource
            // 
            this.tblcrmbulkuploadprojectsdotnetv1BindingSource.DataMember = "tbl_crm_bulkupload_projects_dotnet_v1";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(159, 13);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(211, 54);
            this.button7.TabIndex = 13;
            this.button7.Text = "Download Upload Templates";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // BulkUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.worksheetname);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BulkUpload";
            this.Text = "BulkUpload";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BulkUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcrmbulkuploaddotnetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcrmbulkuploadprojectsdotnetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcrmbulkuploadprojectsdotnetv1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.TextBox worksheetname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        //private DRDDataSet5 dRDDataSet5;
        private System.Windows.Forms.BindingSource tblcrmbulkuploaddotnetBindingSource;
        //private DRDDataSet5TableAdapters.tbl_crm_bulkupload_dotnetTableAdapter tbl_crm_bulkupload_dotnetTableAdapter;
        //private DRDDataSet6 dRDDataSet6;
        private System.Windows.Forms.BindingSource tblcrmbulkuploadprojectsdotnetBindingSource;
        //private DRDDataSet6TableAdapters.tbl_crm_bulkupload_projects_dotnetTableAdapter tbl_crm_bulkupload_projects_dotnetTableAdapter;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView2;
        //private DRDDataSet10 dRDDataSet10;
        private System.Windows.Forms.BindingSource tblcrmbulkuploadprojectsdotnetv1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeOfParty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestorEmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWFT_RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestType1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReceivedDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociateName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPartyLocation1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeOfParty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestorBusinessUnit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestorSegmentName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestorEmailAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequestorOffice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWFT_RequestID1;
        private System.Windows.Forms.Button button7;
        //private DRDDataSet10TableAdapters.tbl_crm_bulkupload_projects_dotnet_v1TableAdapter tbl_crm_bulkupload_projects_dotnet_v1TableAdapter;
        //private System.Windows.Forms.DataGridViewTextBoxColumn requestTypeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn receivedDateDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn partyNameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn typeOfPartyDataGridViewTextBoxColumn;
    }
}