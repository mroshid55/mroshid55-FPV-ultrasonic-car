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
using AForge.Video;
using System.Data.OleDb;
namespace RC
{
    public partial class CForm : DevExpress.XtraEditors.XtraForm
    {
         MJPEGStream stream;
         Graphics g;
        //**-DB Connection-**//
        DBconnection conn = new DBconnection();
        OleDbCommand cmd = new OleDbCommand();
        public CForm()
        {
            
            InitializeComponent();
            IP_Data_Show();//Combo Box Member Name Data Show Queary
            
        }
        

        private void stream_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            g = Graphics.FromImage(bmp);
            g.DrawString("Md.Mamunur Roshid, Ashif, Supen, Shamim,#Dhaka International University,#Group-H", new Font("Arial", 22), new SolidBrush(Color.White), new PointF(2, 2));
            g.Dispose();
            pictureBox1.Image = bmp;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != String.Empty)
            {
                //stream = new MJPEGStream("http://" + comboBox1.Text + ":" + "4747/mjpegfeed?680x680");
                stream = new MJPEGStream("http://" + comboBox1.Text + ":" + "4747/video");
                stream.NewFrame += stream_newFrame;
                stream.Start();
                MessageBox.Show("Connection Start Sucessfully");
            }
            else
            {
                MessageBox.Show("Please select your IP Address ,Then click start button", "Information", MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stream.Stop();
            MessageBox.Show("Connection Stop Sucessfully");
        }

        public void IP_Data_Show()//Combo Box Member Name Data Show Queary
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
                select_member = "Select IP_Address from IP_Address_Table";
                cmd = new OleDbCommand(select_member, conn._dbConnection);
                cmd.ExecuteNonQuery();
                DataTable dt = new System.Data.DataTable();
                OleDbDataAdapter odp = new OleDbDataAdapter(cmd);
                odp.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    comboBox1.Items.Add(item[0].ToString());
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
    }
}