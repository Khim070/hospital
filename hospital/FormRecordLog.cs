﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace hospital
{
    public partial class FormRecordLog : Form
    {
        private string recordlog_username;
        private string recordlog_role;
        String MySQLConn = "";
        MySqlConnection conn;
        MySqlCommand command;
        DataTable table;
        private string sqlquery = "SELECT * FROM tbrecord ORDER BY userID DESC";
        public FormRecordLog(string recordlog_username, string recordlog_role)
        {
            InitializeComponent();
            this.Text = "Record Log";
            this.recordlog_username = recordlog_username;
            this.recordlog_role = recordlog_role;
            MySQLConn = "server=127.0.0.1; user=root; database=hospital; password=";
            MySqlConnection conn = new MySqlConnection(MySQLConn);
            try
            {
                conn.Open();
                //MessageBox.Show("Connection success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void FormRecordLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin(recordlog_username, recordlog_role);
            formAdmin.Show();
            this.Hide();
        }

        private void FormRecordLog_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(MySQLConn);
            try
            {
                conn.Open();
                command = new MySqlCommand(sqlquery, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    if (row["PersonID"].ToString() == "0")
                    {
                        row["PersonID"] = DBNull.Value;
                    }
                }

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = table;

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[2].HeaderText = "Position";
                dataGridView1.Columns[3].HeaderText = "Action";
                dataGridView1.Columns[4].HeaderText = "Form";
                dataGridView1.Columns[7].HeaderText = "Date&Time";

                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime StartDate = startDate.Value.Date;
            DateTime EndDate = endDate.Value.Date.AddDays(1).AddTicks(-1);

            string searchQuery = "SELECT * FROM tbrecord WHERE actionDateTime BETWEEN @StartDate AND @EndDate ORDER BY userID DESC";

            using (MySqlConnection conn = new MySqlConnection(MySQLConn))
            {
                using (MySqlCommand command = new MySqlCommand(searchQuery, conn))
                {
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        foreach (DataRow row in table.Rows)
                        {
                            if (row["PersonID"].ToString() == "0")
                            {
                                row["PersonID"] = DBNull.Value;
                            }
                        }

                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = table;

                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "Name";
                        dataGridView1.Columns[2].HeaderText = "Position";
                        dataGridView1.Columns[3].HeaderText = "Action";
                        dataGridView1.Columns[4].HeaderText = "Form";
                        dataGridView1.Columns[7].HeaderText = "Date&Time";

                        dataGridView1.RowTemplate.Height = 30;
                        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.ReadOnly = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport report = new FormReport(recordlog_username, recordlog_role, FormReport._ReportType.Record, sqlquery);
            report.Show();
            this.Hide();
        }
    }
}
