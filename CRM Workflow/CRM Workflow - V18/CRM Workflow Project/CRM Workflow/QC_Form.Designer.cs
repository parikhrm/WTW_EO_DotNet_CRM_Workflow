namespace CRM_Workflow
{
    partial class QC_Form
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
            this.qc_qualityparameters = new System.Windows.Forms.CheckedListBox();
            this.label_qualityparameters = new System.Windows.Forms.Label();
            this.qc_typeoferror = new System.Windows.Forms.ComboBox();
            this.label_typeoferror = new System.Windows.Forms.Label();
            this.qc_associatename = new System.Windows.Forms.ComboBox();
            this.label_associatenamefirstcheck = new System.Windows.Forms.Label();
            this.qc_overallstatus = new System.Windows.Forms.ComboBox();
            this.qc_doneby = new System.Windows.Forms.ComboBox();
            this.qc_startdate = new System.Windows.Forms.DateTimePicker();
            this.label_overallstatus = new System.Windows.Forms.Label();
            this.label_qcdoneby = new System.Windows.Forms.Label();
            this.label_qcdate = new System.Windows.Forms.Label();
            this.qc_comlpetiondate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crmrequestid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCRM_RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQC_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQC_Done_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAssociate_Name_FirstCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOverall_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTypeOfError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQualityParameters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQC_Completion_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.searchby_qcstartdate = new System.Windows.Forms.DateTimePicker();
            this.searchby_qcdoneby = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qc_comments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.homepage = new System.Windows.Forms.Button();
            this.qc_rawdata = new System.Windows.Forms.Button();
            this.searchby_crm_requestid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qc_qualityparameters
            // 
            this.qc_qualityparameters.CheckOnClick = true;
            this.qc_qualityparameters.FormattingEnabled = true;
            this.qc_qualityparameters.HorizontalScrollbar = true;
            this.qc_qualityparameters.Location = new System.Drawing.Point(841, 88);
            this.qc_qualityparameters.Name = "qc_qualityparameters";
            this.qc_qualityparameters.Size = new System.Drawing.Size(478, 151);
            this.qc_qualityparameters.Sorted = true;
            this.qc_qualityparameters.TabIndex = 15;
            this.qc_qualityparameters.ThreeDCheckBoxes = true;
            // 
            // label_qualityparameters
            // 
            this.label_qualityparameters.AutoSize = true;
            this.label_qualityparameters.Location = new System.Drawing.Point(679, 88);
            this.label_qualityparameters.Name = "label_qualityparameters";
            this.label_qualityparameters.Size = new System.Drawing.Size(143, 20);
            this.label_qualityparameters.TabIndex = 14;
            this.label_qualityparameters.Text = "Quality Parameters";
            // 
            // qc_typeoferror
            // 
            this.qc_typeoferror.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qc_typeoferror.FormattingEnabled = true;
            this.qc_typeoferror.Location = new System.Drawing.Point(446, 88);
            this.qc_typeoferror.Name = "qc_typeoferror";
            this.qc_typeoferror.Size = new System.Drawing.Size(215, 28);
            this.qc_typeoferror.TabIndex = 13;
            this.qc_typeoferror.SelectedIndexChanged += new System.EventHandler(this.qc_typeoferror_SelectedIndexChanged);
            this.qc_typeoferror.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qc_typeoferror_KeyDown);
            // 
            // label_typeoferror
            // 
            this.label_typeoferror.AutoSize = true;
            this.label_typeoferror.Location = new System.Drawing.Point(325, 88);
            this.label_typeoferror.Name = "label_typeoferror";
            this.label_typeoferror.Size = new System.Drawing.Size(103, 20);
            this.label_typeoferror.TabIndex = 12;
            this.label_typeoferror.Text = "Type Of Error";
            // 
            // qc_associatename
            // 
            this.qc_associatename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qc_associatename.FormattingEnabled = true;
            this.qc_associatename.Location = new System.Drawing.Point(1371, 28);
            this.qc_associatename.Name = "qc_associatename";
            this.qc_associatename.Size = new System.Drawing.Size(297, 28);
            this.qc_associatename.TabIndex = 9;
            this.qc_associatename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qc_associatenamefirstcheck_KeyDown);
            // 
            // label_associatenamefirstcheck
            // 
            this.label_associatenamefirstcheck.AutoSize = true;
            this.label_associatenamefirstcheck.Location = new System.Drawing.Point(1220, 26);
            this.label_associatenamefirstcheck.Name = "label_associatenamefirstcheck";
            this.label_associatenamefirstcheck.Size = new System.Drawing.Size(125, 20);
            this.label_associatenamefirstcheck.TabIndex = 8;
            this.label_associatenamefirstcheck.Text = "Associate Name";
            // 
            // qc_overallstatus
            // 
            this.qc_overallstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qc_overallstatus.FormattingEnabled = true;
            this.qc_overallstatus.Location = new System.Drawing.Point(135, 88);
            this.qc_overallstatus.Name = "qc_overallstatus";
            this.qc_overallstatus.Size = new System.Drawing.Size(182, 28);
            this.qc_overallstatus.TabIndex = 11;
            this.qc_overallstatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qc_overallstatus_KeyDown);
            // 
            // qc_doneby
            // 
            this.qc_doneby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qc_doneby.FormattingEnabled = true;
            this.qc_doneby.Location = new System.Drawing.Point(926, 26);
            this.qc_doneby.Name = "qc_doneby";
            this.qc_doneby.Size = new System.Drawing.Size(272, 28);
            this.qc_doneby.TabIndex = 7;
            this.qc_doneby.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qc_doneby_KeyDown);
            // 
            // qc_startdate
            // 
            this.qc_startdate.CustomFormat = "";
            this.qc_startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qc_startdate.Location = new System.Drawing.Point(317, 26);
            this.qc_startdate.Name = "qc_startdate";
            this.qc_startdate.Size = new System.Drawing.Size(240, 26);
            this.qc_startdate.TabIndex = 3;
            this.qc_startdate.ValueChanged += new System.EventHandler(this.qc_startdate_ValueChanged);
            // 
            // label_overallstatus
            // 
            this.label_overallstatus.AutoSize = true;
            this.label_overallstatus.Location = new System.Drawing.Point(17, 88);
            this.label_overallstatus.Name = "label_overallstatus";
            this.label_overallstatus.Size = new System.Drawing.Size(108, 20);
            this.label_overallstatus.TabIndex = 10;
            this.label_overallstatus.Text = "Overall Status";
            // 
            // label_qcdoneby
            // 
            this.label_qcdoneby.AutoSize = true;
            this.label_qcdoneby.Location = new System.Drawing.Point(821, 26);
            this.label_qcdoneby.Name = "label_qcdoneby";
            this.label_qcdoneby.Size = new System.Drawing.Size(97, 20);
            this.label_qcdoneby.TabIndex = 6;
            this.label_qcdoneby.Text = "QC Done By";
            // 
            // label_qcdate
            // 
            this.label_qcdate.AutoSize = true;
            this.label_qcdate.Location = new System.Drawing.Point(180, 26);
            this.label_qcdate.Name = "label_qcdate";
            this.label_qcdate.Size = new System.Drawing.Size(110, 20);
            this.label_qcdate.TabIndex = 2;
            this.label_qcdate.Text = "QC Start Date";
            // 
            // qc_comlpetiondate
            // 
            this.qc_comlpetiondate.CustomFormat = " ";
            this.qc_comlpetiondate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qc_comlpetiondate.Location = new System.Drawing.Point(1516, 91);
            this.qc_comlpetiondate.Name = "qc_comlpetiondate";
            this.qc_comlpetiondate.Size = new System.Drawing.Size(240, 26);
            this.qc_comlpetiondate.TabIndex = 17;
            this.qc_comlpetiondate.ValueChanged += new System.EventHandler(this.qc_comlpetiondate_ValueChanged);
            this.qc_comlpetiondate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qc_comlpetiondate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1341, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "QC Completion Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "CRM Request ID";
            // 
            // crmrequestid
            // 
            this.crmrequestid.Location = new System.Drawing.Point(700, 26);
            this.crmrequestid.Name = "crmrequestid";
            this.crmrequestid.Size = new System.Drawing.Size(115, 26);
            this.crmrequestid.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(49, 26);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(109, 26);
            this.id.TabIndex = 1;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(492, 165);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(99, 51);
            this.insert.TabIndex = 18;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(608, 165);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(99, 51);
            this.update.TabIndex = 19;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(726, 165);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(99, 51);
            this.reset.TabIndex = 20;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtID,
            this.txtCRM_RequestID,
            this.txtQC_Start_Date,
            this.txtQC_Done_By,
            this.txtAssociate_Name_FirstCheck,
            this.txtOverall_Status,
            this.txtTypeOfError,
            this.txtQualityParameters,
            this.txtQC_Completion_Date,
            this.txtLastUpdatedBy,
            this.txtComments});
            this.dataGridView1.Location = new System.Drawing.Point(16, 410);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1780, 484);
            this.dataGridView1.TabIndex = 104;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtID
            // 
            this.txtID.DataPropertyName = "ID";
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            // 
            // txtCRM_RequestID
            // 
            this.txtCRM_RequestID.DataPropertyName = "CRM_RequestID";
            this.txtCRM_RequestID.HeaderText = "CRM_RequestID";
            this.txtCRM_RequestID.Name = "txtCRM_RequestID";
            this.txtCRM_RequestID.ReadOnly = true;
            // 
            // txtQC_Start_Date
            // 
            this.txtQC_Start_Date.DataPropertyName = "QC_Start_Date";
            this.txtQC_Start_Date.HeaderText = "QC_Start_Date";
            this.txtQC_Start_Date.Name = "txtQC_Start_Date";
            this.txtQC_Start_Date.ReadOnly = true;
            // 
            // txtQC_Done_By
            // 
            this.txtQC_Done_By.DataPropertyName = "QC_Done_By";
            this.txtQC_Done_By.HeaderText = "QC_Done_By";
            this.txtQC_Done_By.Name = "txtQC_Done_By";
            this.txtQC_Done_By.ReadOnly = true;
            // 
            // txtAssociate_Name_FirstCheck
            // 
            this.txtAssociate_Name_FirstCheck.DataPropertyName = "Associate_Name_FirstCheck";
            this.txtAssociate_Name_FirstCheck.HeaderText = "Associate_Name_FirstCheck";
            this.txtAssociate_Name_FirstCheck.Name = "txtAssociate_Name_FirstCheck";
            this.txtAssociate_Name_FirstCheck.ReadOnly = true;
            // 
            // txtOverall_Status
            // 
            this.txtOverall_Status.DataPropertyName = "Overall_Status";
            this.txtOverall_Status.HeaderText = "Overall_Status";
            this.txtOverall_Status.Name = "txtOverall_Status";
            this.txtOverall_Status.ReadOnly = true;
            // 
            // txtTypeOfError
            // 
            this.txtTypeOfError.DataPropertyName = "TypeOfError";
            this.txtTypeOfError.HeaderText = "TypeOfError";
            this.txtTypeOfError.Name = "txtTypeOfError";
            this.txtTypeOfError.ReadOnly = true;
            // 
            // txtQualityParameters
            // 
            this.txtQualityParameters.DataPropertyName = "QualityParameters";
            this.txtQualityParameters.HeaderText = "QualityParameters";
            this.txtQualityParameters.Name = "txtQualityParameters";
            this.txtQualityParameters.ReadOnly = true;
            // 
            // txtQC_Completion_Date
            // 
            this.txtQC_Completion_Date.DataPropertyName = "QC_Completion_Date";
            this.txtQC_Completion_Date.HeaderText = "QC_Completion_Date";
            this.txtQC_Completion_Date.Name = "txtQC_Completion_Date";
            this.txtQC_Completion_Date.ReadOnly = true;
            // 
            // txtLastUpdatedBy
            // 
            this.txtLastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.txtLastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.txtLastUpdatedBy.Name = "txtLastUpdatedBy";
            this.txtLastUpdatedBy.ReadOnly = true;
            // 
            // txtComments
            // 
            this.txtComments.DataPropertyName = "Comments";
            this.txtComments.HeaderText = "Comments";
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 20);
            this.label4.TabIndex = 105;
            this.label4.Text = "Search by QC Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 20);
            this.label5.TabIndex = 106;
            this.label5.Text = "Search by QC Done By";
            // 
            // searchby_qcstartdate
            // 
            this.searchby_qcstartdate.CustomFormat = " ";
            this.searchby_qcstartdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.searchby_qcstartdate.Location = new System.Drawing.Point(16, 343);
            this.searchby_qcstartdate.Name = "searchby_qcstartdate";
            this.searchby_qcstartdate.Size = new System.Drawing.Size(245, 26);
            this.searchby_qcstartdate.TabIndex = 0;
            this.searchby_qcstartdate.ValueChanged += new System.EventHandler(this.searchby_qcstartdate_ValueChanged);
            this.searchby_qcstartdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchby_qcstartdate_KeyDown);
            // 
            // searchby_qcdoneby
            // 
            this.searchby_qcdoneby.Location = new System.Drawing.Point(277, 343);
            this.searchby_qcdoneby.Name = "searchby_qcdoneby";
            this.searchby_qcdoneby.Size = new System.Drawing.Size(237, 26);
            this.searchby_qcdoneby.TabIndex = 1;
            this.searchby_qcdoneby.TextChanged += new System.EventHandler(this.searchby_qcdoneby_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qc_comments);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label_qcdate);
            this.groupBox1.Controls.Add(this.label_qcdoneby);
            this.groupBox1.Controls.Add(this.qc_startdate);
            this.groupBox1.Controls.Add(this.qc_doneby);
            this.groupBox1.Controls.Add(this.label_associatenamefirstcheck);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.qc_associatename);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.insert);
            this.groupBox1.Controls.Add(this.crmrequestid);
            this.groupBox1.Controls.Add(this.qc_comlpetiondate);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_overallstatus);
            this.groupBox1.Controls.Add(this.qc_qualityparameters);
            this.groupBox1.Controls.Add(this.qc_overallstatus);
            this.groupBox1.Controls.Add(this.label_qualityparameters);
            this.groupBox1.Controls.Add(this.label_typeoferror);
            this.groupBox1.Controls.Add(this.qc_typeoferror);
            this.groupBox1.Location = new System.Drawing.Point(16, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1780, 275);
            this.groupBox1.TabIndex = 109;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // qc_comments
            // 
            this.qc_comments.Location = new System.Drawing.Point(109, 165);
            this.qc_comments.Multiline = true;
            this.qc_comments.Name = "qc_comments";
            this.qc_comments.Size = new System.Drawing.Size(364, 74);
            this.qc_comments.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Comments";
            // 
            // homepage
            // 
            this.homepage.Location = new System.Drawing.Point(16, 12);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(125, 39);
            this.homepage.TabIndex = 110;
            this.homepage.Text = "Home Page";
            this.homepage.UseVisualStyleBackColor = true;
            this.homepage.Click += new System.EventHandler(this.homepage_Click);
            // 
            // qc_rawdata
            // 
            this.qc_rawdata.Location = new System.Drawing.Point(780, 343);
            this.qc_rawdata.Name = "qc_rawdata";
            this.qc_rawdata.Size = new System.Drawing.Size(109, 35);
            this.qc_rawdata.TabIndex = 111;
            this.qc_rawdata.Text = "Raw Data";
            this.qc_rawdata.UseVisualStyleBackColor = true;
            this.qc_rawdata.Click += new System.EventHandler(this.qc_rawdata_Click);
            // 
            // searchby_crm_requestid
            // 
            this.searchby_crm_requestid.Location = new System.Drawing.Point(521, 343);
            this.searchby_crm_requestid.Name = "searchby_crm_requestid";
            this.searchby_crm_requestid.Size = new System.Drawing.Size(202, 26);
            this.searchby_crm_requestid.TabIndex = 112;
            this.searchby_crm_requestid.TextChanged += new System.EventHandler(this.searchby_crm_requestid_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(524, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 20);
            this.label7.TabIndex = 113;
            this.label7.Text = "Search by CRM Request ID";
            // 
            // QC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1848, 934);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.searchby_crm_requestid);
            this.Controls.Add(this.qc_rawdata);
            this.Controls.Add(this.homepage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchby_qcdoneby);
            this.Controls.Add(this.searchby_qcstartdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QC_Form";
            this.Text = "QC_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QC_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox qc_qualityparameters;
        private System.Windows.Forms.Label label_qualityparameters;
        private System.Windows.Forms.ComboBox qc_typeoferror;
        private System.Windows.Forms.Label label_typeoferror;
        private System.Windows.Forms.ComboBox qc_associatename;
        private System.Windows.Forms.Label label_associatenamefirstcheck;
        private System.Windows.Forms.ComboBox qc_overallstatus;
        private System.Windows.Forms.ComboBox qc_doneby;
        private System.Windows.Forms.DateTimePicker qc_startdate;
        private System.Windows.Forms.Label label_overallstatus;
        private System.Windows.Forms.Label label_qcdoneby;
        private System.Windows.Forms.Label label_qcdate;
        private System.Windows.Forms.DateTimePicker qc_comlpetiondate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox crmrequestid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker searchby_qcstartdate;
        private System.Windows.Forms.TextBox searchby_qcdoneby;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button homepage;
        private System.Windows.Forms.Button qc_rawdata;
        private System.Windows.Forms.TextBox qc_comments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCRM_RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQC_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQC_Done_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAssociate_Name_FirstCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOverall_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTypeOfError;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQualityParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQC_Completion_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComments;
        private System.Windows.Forms.TextBox searchby_crm_requestid;
        private System.Windows.Forms.Label label7;
    }
}