﻿namespace hospital
{
    partial class FormAmbulance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAmbulance));
            this.btnReturn = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtAm = new System.Windows.Forms.TextBox();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.dateTimedeparture = new System.Windows.Forms.DateTimePicker();
            this.dateTimearrived = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnID = new System.Windows.Forms.Label();
            this.btnAm = new System.Windows.Forms.Label();
            this.btnstaff = new System.Windows.Forms.Label();
            this.departure = new System.Windows.Forms.Label();
            this.arrived = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(722, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 29);
            this.btnReturn.TabIndex = 113;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.Window;
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtid.Location = new System.Drawing.Point(243, 53);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(47, 40);
            this.txtid.TabIndex = 114;
            // 
            // txtAm
            // 
            this.txtAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAm.Location = new System.Drawing.Point(243, 110);
            this.txtAm.Multiline = true;
            this.txtAm.Name = "txtAm";
            this.txtAm.Size = new System.Drawing.Size(318, 36);
            this.txtAm.TabIndex = 115;
            this.txtAm.TextChanged += new System.EventHandler(this.txtAm_TextChanged);
            // 
            // cbStaff
            // 
            this.cbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStaff.FormattingEnabled = true;
            this.cbStaff.Items.AddRange(new object[] {
            "",
            "Sok",
            "Sao",
            "Tola",
            "Vanna"});
            this.cbStaff.Location = new System.Drawing.Point(243, 162);
            this.cbStaff.Name = "cbStaff";
            this.cbStaff.Size = new System.Drawing.Size(318, 39);
            this.cbStaff.TabIndex = 116;
            // 
            // dateTimedeparture
            // 
            this.dateTimedeparture.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimedeparture.Checked = false;
            this.dateTimedeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimedeparture.Location = new System.Drawing.Point(243, 212);
            this.dateTimedeparture.Name = "dateTimedeparture";
            this.dateTimedeparture.Size = new System.Drawing.Size(318, 35);
            this.dateTimedeparture.TabIndex = 117;
            // 
            // dateTimearrived
            // 
            this.dateTimearrived.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimearrived.Location = new System.Drawing.Point(243, 262);
            this.dateTimearrived.Name = "dateTimearrived";
            this.dateTimearrived.Size = new System.Drawing.Size(318, 35);
            this.dateTimearrived.TabIndex = 118;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 371);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(719, 241);
            this.dataGridView1.TabIndex = 119;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(35, 317);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(107, 43);
            this.btnsave.TabIndex = 120;
            this.btnsave.Text = "Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsearch.Location = new System.Drawing.Point(185, 317);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(117, 43);
            this.btnsearch.TabIndex = 121;
            this.btnsearch.Text = "Search";
            this.btnsearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(328, 317);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(96, 43);
            this.btnedit.TabIndex = 122;
            this.btnedit.Text = "Edit";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(467, 317);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(120, 43);
            this.btndelete.TabIndex = 123;
            this.btndelete.Text = "Delete";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnreport
            // 
            this.btnreport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnreport.Image = ((System.Drawing.Image)(resources.GetObject("btnreport.Image")));
            this.btnreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreport.Location = new System.Drawing.Point(625, 317);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(129, 43);
            this.btnreport.TabIndex = 124;
            this.btnreport.Text = "Report";
            this.btnreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnreport.UseVisualStyleBackColor = false;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 35);
            this.label1.TabIndex = 125;
            this.label1.Text = "ប្រព័ន្ធគ្រប់គ្រងឡានពេទ្យ";
            // 
            // btnID
            // 
            this.btnID.AutoSize = true;
            this.btnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnID.Location = new System.Drawing.Point(29, 53);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(42, 31);
            this.btnID.TabIndex = 126;
            this.btnID.Text = "ID";
            // 
            // btnAm
            // 
            this.btnAm.AutoSize = true;
            this.btnAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAm.Location = new System.Drawing.Point(29, 110);
            this.btnAm.Name = "btnAm";
            this.btnAm.Size = new System.Drawing.Size(191, 31);
            this.btnAm.TabIndex = 127;
            this.btnAm.Text = "Ambulance No";
            // 
            // btnstaff
            // 
            this.btnstaff.AutoSize = true;
            this.btnstaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstaff.Location = new System.Drawing.Point(29, 165);
            this.btnstaff.Name = "btnstaff";
            this.btnstaff.Size = new System.Drawing.Size(164, 31);
            this.btnstaff.TabIndex = 128;
            this.btnstaff.Text = "Staff\'s name";
            // 
            // departure
            // 
            this.departure.AutoSize = true;
            this.departure.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departure.Location = new System.Drawing.Point(29, 212);
            this.departure.Name = "departure";
            this.departure.Size = new System.Drawing.Size(193, 31);
            this.departure.TabIndex = 129;
            this.departure.Text = "Departure time";
            // 
            // arrived
            // 
            this.arrived.AutoSize = true;
            this.arrived.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrived.Location = new System.Drawing.Point(29, 259);
            this.arrived.Name = "arrived";
            this.arrived.Size = new System.Drawing.Size(158, 31);
            this.arrived.TabIndex = 130;
            this.arrived.Text = "Arrived time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(656, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 131;
            this.label2.Text = "Time";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(585, 110);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(180, 187);
            this.time.TabIndex = 132;
            this.time.TabStop = false;
            // 
            // FormAmbulance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.arrived);
            this.Controls.Add(this.departure);
            this.Controls.Add(this.btnstaff);
            this.Controls.Add(this.btnAm);
            this.Controls.Add(this.btnID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimearrived);
            this.Controls.Add(this.dateTimedeparture);
            this.Controls.Add(this.cbStaff);
            this.Controls.Add(this.txtAm);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnReturn);
            this.Name = "FormAmbulance";
            this.Text = "FormAmbulance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAmbulance_FormClosed);
            this.Load += new System.EventHandler(this.FormAmbulance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtAm;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.DateTimePicker dateTimedeparture;
        private System.Windows.Forms.DateTimePicker dateTimearrived;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnID;
        private System.Windows.Forms.Label btnAm;
        private System.Windows.Forms.Label btnstaff;
        private System.Windows.Forms.Label departure;
        private System.Windows.Forms.Label arrived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox time;
    }
}