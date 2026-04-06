using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RC
{
    public class DBconnection
    {

        public OleDbConnection _dbConnection;

        public void DbConnection()//Oledb function
        {
            _dbConnection = new OleDbConnection { ConnectionString = GetConnectionString() };
        }
        private string GetConnectionString()//Connection string return
        {
            //Database string 
            return (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\RC_Database\Database_RC.accdb;Persist Security Info=False;");
        }
    }
}
