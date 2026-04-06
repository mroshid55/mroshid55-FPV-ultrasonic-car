using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
namespace RC
{
    public partial class Setting_Form : DevExpress.XtraEditors.XtraForm
    {
        //**-DB Connection-**//
        DBconnection conn = new DBconnection();
        OleDbCommand cmd = new OleDbCommand();
        public Setting_Form()
        {
            InitializeComponent();
            IP_Data_Show();//GridView Show Queary
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.DbConnection();
            if (txt_IP_ID.Text == string.Empty || txt_IP_Address.Text == string.Empty)
            {
                MessageBox.Show("places fillup all fields and try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (conn._dbConnection.State == ConnectionState.Open)
                    {
                        conn._dbConnection.Close();
                    }
                    conn._dbConnection.Open();
                    string insert_ip = "";
                    insert_ip = "INSERT INTO IP_Address_Table(IP_ID,IP_Address)values('" + txt_IP_ID.Text.Trim() + "','"
                        + txt_IP_Address.Text.Trim() + "')";
                    cmd = new OleDbCommand(insert_ip, conn._dbConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IP_Data_Show();//GridView Show Queary
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn._dbConnection.Close();
                }
            }

        }
        public void IP_Data_Show()//GridView Show Queary
        {
            conn.DbConnection();
            try
            {
                if (conn._dbConnection.State == ConnectionState.Open)
                {
                    conn._dbConnection.Close();
                }
                conn._dbConnection.Open();
                string select_member = "";
                select_member = "Select * from IP_Address_Table";
                cmd = new OleDbCommand(select_member, conn._dbConnection);
                cmd.ExecuteNonQuery();
                DataTable dt = new System.Data.DataTable();
                OleDbDataAdapter odp = new OleDbDataAdapter(cmd);
                odp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn._dbConnection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Update", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                IP_update();//member data update query
            }
            
        }
        public void IP_update()//member data update query
        {
            conn.DbConnection();
            try
            {
                if (conn._dbConnection.State == ConnectionState.Open)
                {
                    conn._dbConnection.Close();
                }
                conn._dbConnection.Open();
                string IP_update = "";
                IP_update = "Update IP_Address_Table set IP_ID='"
                    + txt_IP_ID.Text + "',IP_Address='"
                    + txt_IP_Address.Text + "' where IP_ID='"
                    + txt_IP_ID.Text + "' ";
                cmd = new OleDbCommand(IP_update, conn._dbConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully Completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IP_Data_Show();//GridView Show Queary
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn._dbConnection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.DbConnection();
            try
            {
                if (conn._dbConnection.State == ConnectionState.Open)
                {
                    conn._dbConnection.Close();
                }
                conn._dbConnection.Open();
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    txt_IP_ID.Text = row.Cells["IP_ID"].Value.ToString();
                    txt_IP_Address.Text = row.Cells["IP_Address"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn._dbConnection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                IP_Delete();//Delete data update query
            }
            
        }

        public void IP_Delete()//Delete data update query
        {
            conn.DbConnection();
            try
            {
                if (conn._dbConnection.State == ConnectionState.Open)
                {
                    conn._dbConnection.Close();
                }
                conn._dbConnection.Open();
                string IP_delete = "";
                IP_delete = "DELETE FROM IP_Address_Table  where IP_ID='"+ txt_IP_ID.Text + "' ";
                cmd = new OleDbCommand(IP_delete, conn._dbConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully Completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IP_Data_Show();//GridView Show Queary
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn._dbConnection.Close();
            }
        }
    }
}