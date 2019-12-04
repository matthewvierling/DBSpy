using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSpy
{
    //class for all connection forms to inherit from to give consistancy and promode code reuse
    public abstract partial class ConnectionForm : Form
    {
        protected string server, port, database, uid, pwd;
        protected bool connectionCreated, connectionOpen;

        public ConnectionForm(string server, string port, string database, string userid, string password){
            this.server = server;
            this.port = port;
            this.database = database;
            this.uid = userid;
            this.pwd = password;
            this.connectionCreated = false;
            this.connectionOpen = false;

            this.InitializeComponent();
        }

        //method to override in derived classes to create the connection to the database
        //returns true if connection was successful--false if connection failed.
        protected abstract bool CreateConnection();
        // {
        //     //create connection in following format
        //     try{
        //         //create connection
        //         return true;
        //     }catch(Exception e){
        //         //connection failed
        //         MessageBox.Show(e.ToString());
        //         return false;
        //     }
        // }

        // method to override in derived classes to open the connection to the database
        protected abstract bool OpenConnection();
        // {
        //     //open connection in following format
        //     try{
        //         //open connection
        //         return true;
        //     }catch(Exception e){
        //         //opening connection failed
        //         MessageBox.Show(e.ToString());
        //         return false;
        //     }
        // }

        //method to override in derived classes to close the db connections being used
        protected abstract void CloseConnection();

        protected override void OnFormClosing(FormClosingEventArgs e){
            base.OnFormClosing(e);
            this.CloseConnection();
        }

    }

}