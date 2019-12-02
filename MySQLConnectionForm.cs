using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBSpy
{
    public partial class MySQLConnectionForm : Form
    {
        private string server, database, uid, pwd;
        private MySqlConnection connection;
        public MySQLConnectionForm(string server, string database, string userid, string password){
            this.server = server;
            this.database = database;
            this.uid = userid;
            this.pwd = password;
            InitializeComponent();

        }

        protected override void OnFormClosing(FormClosingEventArgs e){
            base.OnFormClosing(e);
            MessageBox.Show("closing.");
            //free/close connections here
        }

    }

}
