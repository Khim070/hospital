﻿using Microsoft.Reporting;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital
{
    public partial class FormReport : Form
    {
        public enum _ReportType { Doctor, Bed, Patient, Staff, Ambulance, Medicine };

        private string doctor_username;
        private string doctor_role;
        private string sqlquery;
        private Form form;
        private string MySQLConn = "server=127.0.0.1; user=root; database=hospital; password=";
        private _ReportType type;

        public FormReport(string doctor_username, string doctor_role,_ReportType type , string mysqlquery)
        {
            InitializeComponent();
            this.doctor_username = doctor_username;
            this.doctor_role = doctor_role;
            this.sqlquery = mysqlquery;
            this.type = type;
            try
            {
                switch (type)
                {
                    case _ReportType.Doctor:
                        LoadData(sqlquery, "tbdoctor", "hospital\\Report.rdlc");
                        break;
                    case _ReportType.Bed:
                        LoadData(sqlquery, "tbbed", "hospital\\BedReport.rdlc");
                        break;
                    case _ReportType.Patient:
                        LoadData(sqlquery, "tbpatient", "hospital\\PatientReport.rdlc");
                        break;
                    case _ReportType.Medicine:
                        LoadData(sqlquery, "tbmedicine", "hospital\\MedicineReport.rdlc");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadData(string query, string tablename, string reportPath)
        {
            try
            {
                DataSet ds = new DataSet();

                using (MySqlConnection con = new MySqlConnection(MySQLConn))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);

                    da.Fill(ds, tablename);
                    con.Close();
                }

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);
                DirectoryInfo targetDirectoryInfo = directoryInfo.Parent.Parent.Parent;
                string exeFolder = targetDirectoryInfo.FullName;
                string reportPathFile = Path.Combine(exeFolder, reportPath);
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet", ds.Tables[tablename]);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                reportViewer1.LocalReport.ReportPath = reportPathFile;
                reportViewer1.RefreshReport();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            switch(type)
            {
                case _ReportType.Doctor:
                    FormChange(new FormDoctor(doctor_username, doctor_role));
                    break;
                case _ReportType.Bed:
                    FormChange(new FormBed(doctor_username, doctor_role));
                    break;
                case _ReportType.Patient:
                    FormChange(new FormPatient(doctor_username, doctor_role));
                    break;
                case _ReportType.Medicine:
                    FormChange(new FormMedicine(doctor_username, doctor_role));
                    break;
            }
        }

        private void FormChange(Form form)
        {
            Form doctor = form;
            doctor.Show();
            this.Hide();
        }
    }
}
