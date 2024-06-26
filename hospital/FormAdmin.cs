﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace hospital
{
    public partial class FormAdmin : Form
    {
        private string admin_username;
        private string admin_role;
        String MySQLConn = "";
        MySqlConnection conn;
        MySqlCommand command;
        Boolean buttonSave, buttonEdit, buttonRemove, buttonSearch, buttonReset;
        //MySqlConnection conn;
        public FormAdmin(string admin_username, string admin_role)
        {
            InitializeComponent();
            this.Text = "Admin";
            this.admin_username = admin_username;
            this.admin_role = admin_role;
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

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            FormManagement formManagement = new FormManagement(admin_username, admin_role);
            formManagement.Show();
            this.Hide();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var key = "sw9zbIu5mZ1AouhBGKikQWyhUhFdGftx";

            conn = new MySqlConnection(MySQLConn);
            buttonSave = true;
            if (btnSave.Text == "Save")
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please enter name.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }
                else if (txtName.ForeColor == System.Drawing.Color.Red)
                {
                    MessageBox.Show("No Special Character enter.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }
                else if (txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Please enter confirm password.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return;
                }
                else if (cbPosition.SelectedIndex != 1 && cbPosition.SelectedIndex != 2 && cbPosition.SelectedIndex != 3)
                {
                    MessageBox.Show("Please set user permission.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbPosition.Focus();
                    return;
                }
                try
                {
                    btnEdit.Enabled = false;
                    // check duplicated data
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(txtName.Text))
                        {
                            MessageBox.Show("Duplicate Name. Please try again!!!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                            return;
                        }
                    }
                    conn.Open();
                    string name = txtName.Text;
                    string password = txtPassword.Text;
                    string confirmPassword = txtConfirmPassword.Text;
                    string position = "";

                    if (cbPosition.SelectedIndex == 1)
                    {
                        position = "View Only";
                    }
                    else if (cbPosition.SelectedIndex == 2)
                    {
                        position = "Create Only";
                    }
                    else if (cbPosition.SelectedIndex == 3)
                    {
                        position = "Super Admin";
                    }

                    if (!password.Equals(confirmPassword))
                    {
                        MessageBox.Show("Incorrect Confirmation Password.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                        return;
                    }
                    var encryptedPassword = EncryptionDecryption.EncryptString(key, password);
                    string query = "INSERT INTO tbadmin(id, name, position, password) VALUES (@id, @name, @position, @password)";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("id", "");
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("position", position);
                    command.Parameters.AddWithValue("password", encryptedPassword);
                    command.ExecuteNonQuery();
                    TrackUserAction("Save");

                    int id = int.Parse(txtID.Text);
                    int nextID = id + 1;
                    txtID.Text = nextID.ToString();

                    txtName.Clear();
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                    cbPosition.SelectedIndex = 0;

                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                btnSave.Text = "Save";
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                txtID.Enabled = false;
                int maxId = 0;
                conn.Open();
                MySqlCommand command_id = new MySqlCommand("SELECT id FROM tbadmin ORDER BY id DESC LIMIT 1", conn);

                object result = command_id.ExecuteScalar();
                maxId = Convert.ToInt32(result);
                int nextId = maxId + 1;
                txtID.Text = nextId.ToString();

                txtName.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                cbPosition.SelectedIndex = 0;
                txtConfirmPassword.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void Refresh()
        {
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
            txtID.Enabled = false;
            buttonSave = false;
            buttonEdit = false;
            buttonRemove = false;
            buttonSearch = false;
            buttonReset = false;
            MySqlConnection conn = new MySqlConnection(MySQLConn);
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tbadmin WHERE active = 1 ORDER BY id DESC", conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MySqlCommand command_id = new MySqlCommand("SELECT id FROM tbadmin ORDER BY id DESC LIMIT 1", conn);
                object result = command_id.ExecuteScalar();
                int maxId = 0;
                maxId = Convert.ToInt32(result);
                int nextId = maxId + 1;
                txtID.Text = nextId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM tbadmin WHERE name LIKE @name && active = 1 ORDER BY id DESC";
            buttonSearch = true;
            if (txtName.ForeColor == System.Drawing.Color.Red)
            {
                MessageBox.Show("No Special Character enter.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(MySQLConn))
            {
                using (MySqlCommand command = new MySqlCommand(searchQuery, conn))
                {
                    command.Parameters.AddWithValue("@name", "%" + txtName.Text + "%");
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = table;
                        dataGridView1.RowTemplate.Height = 30;
                        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.Columns[4].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            btnSave.Text = "New";
            TrackUserAction("Search");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySQLConn);
            try
            {
                if (txtName.ForeColor == System.Drawing.Color.Red)
                {
                    MessageBox.Show("No Special Character enter.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                buttonEdit = true;
                btnSave.Text = "New";
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;

                conn.Open();
                string position = "";
                if (cbPosition.SelectedIndex == 1)
                {
                    position = "View Only";
                }
                else if (cbPosition.SelectedIndex == 2)
                {
                    position = "Create Only";
                }
                else if (cbPosition.SelectedIndex == 3)
                {
                    position = "Super Admin";
                }
                String updateQuery = "UPDATE tbadmin SET name = @newName, position = @newPosition WHERE id = @id";
                MySqlCommand update_command = new MySqlCommand(updateQuery, conn);

                update_command.Parameters.AddWithValue("newName", txtName.Text);
                update_command.Parameters.AddWithValue("newPosition", position);
                update_command.Parameters.AddWithValue("id", txtID.Text);

                update_command.ExecuteNonQuery();
                TrackUserAction("Edit");
                txtName.Clear();
                cbPosition.SelectedIndex = 0;

                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name to delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            buttonRemove = true;
            MySqlConnection conn = new MySqlConnection(MySQLConn);
            try
            {
                conn.Open();
                String updateQuery = "UPDATE tbadmin SET active = @newValue WHERE id = @id || name = @name";
                MySqlCommand command = new MySqlCommand(updateQuery, conn);

                command.Parameters.AddWithValue("@newValue", 0);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@name", txtName.Text);

                command.ExecuteNonQuery();
                TrackUserAction("Remove");
                txtID.Clear();
                txtName.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                cbPosition.SelectedIndex = 0;
                btnSave.Text = "Save";
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var key = "sw9zbIu5mZ1AouhBGKikQWyhUhFdGftx";
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name to reset new password", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }else if (ContainsSpecialCharacters(txtName.Text))
            {
                MessageBox.Show("No Special Character enter.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            buttonReset = true;
            MySqlConnection conn = new MySqlConnection(MySQLConn);
            try
            {
                string newpassword = txtName.Text+"_1234";
                var encryptedNewPassword = EncryptionDecryption.EncryptString(key, newpassword);
                conn.Open();
                String updateQuery = "UPDATE tbadmin SET password = @newValue WHERE id = @id || name = @name";
                MySqlCommand command = new MySqlCommand(updateQuery, conn);

                command.Parameters.AddWithValue("@newValue",encryptedNewPassword);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@name", txtName.Text);

                command.ExecuteNonQuery();
                TrackUserAction("Reset");
                MessageBox.Show("Your new password is: " + newpassword, "New Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtID.Clear();
                txtName.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                btnSave.Text = "Save";
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                cbPosition.SelectedIndex = 0;

                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string position = "";
            txtConfirmPassword.Enabled = false;
            txtPassword.Enabled = false;
            btnRemove.Enabled = true;
            try
            {
                //MessageBox.Show("Hello");
                btnSave.Text = "New";
                btnEdit.Enabled = true;
                int index = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                txtID.Text = selectedRow.Cells[0].Value.ToString();
                txtName.Text = selectedRow.Cells[1].Value.ToString();
                position = selectedRow.Cells[2].Value.ToString();
                if (position.Equals("View Only"))
                {
                    cbPosition.SelectedIndex = 1;
                }
                else if (position.Equals("Create Only"))
                {
                    cbPosition.SelectedIndex = 2;
                }
                else if (position.Equals("Super Admin"))
                {
                    cbPosition.SelectedIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            FormPosition formPosition = new FormPosition(admin_username, admin_role);
            formPosition.Show();
            this.Hide();
        }

        private void btnaddbed_Click(object sender, EventArgs e)
        {
            FormAmountBed formAmountBed = new FormAmountBed(admin_username, admin_role);
            formAmountBed.Show();
            this.Hide();
        }

        private void btnAmountAmbulance_Click(object sender, EventArgs e)
        {
            FormAmountAmbulance formAmountAmbulance = new FormAmountAmbulance(admin_username, admin_role);
            formAmountAmbulance.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormRecordLog formRecordLog = new FormRecordLog(admin_username, admin_role);
            formRecordLog.Show();
            this.Hide();
        }
        
        private bool ContainsSpecialCharacters(string text)
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";

            return text.Any(c => !allowedCharacters.Contains(c));
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (ContainsSpecialCharacters(txtName.Text))
            {
                txtName.BorderStyle = BorderStyle.FixedSingle;
                txtName.BackColor = System.Drawing.Color.White;
                txtName.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtName.BorderStyle = BorderStyle.FixedSingle;
                txtName.BackColor = System.Drawing.SystemColors.Window;
                txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void TrackUserAction(string userAction)
        {
            try
            {
                using (conn = new MySqlConnection(MySQLConn))
                {
                    conn.Open();
                    string query = "INSERT INTO tbrecord(userID, userName, userRole, userAction, userForm, personID, personName, actionDateTime) VALUES (@uID, @uName, @uRole, @uAction, @uForm, @pID, @pName, @aDateTime)";

                    command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("uAction", userAction);
                    command.Parameters.AddWithValue("uForm", "Admin");
                    command.Parameters.AddWithValue("uID", "");
                    command.Parameters.AddWithValue("uName", admin_username);
                    command.Parameters.AddWithValue("uRole", admin_role);
                    command.Parameters.AddWithValue("pID", txtID.Text);
                    command.Parameters.AddWithValue("pName", txtName.Text);
                    command.Parameters.AddWithValue("aDateTime", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}