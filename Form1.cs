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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //returns the names of all the Databases on a MySQL Database
        private void ExecuteDBSpy(object source, EventArgs e){

            string conString = "", result = "";

            //try to connect to server and read the tables
            try{

                conString = "server=" + this.IPTextBox.Text + ";uid=" + this.UserTextBox.Text + ";pwd=" + this.PasswordTextBox.Text + ";";

                using (MySqlConnection connection = new MySqlConnection(conString)){

                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SHOW DATABASES;", connection)){

                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            //result = dr.Read().ToString();
                            while (dr.Read())
                            {
                                result = result + dr[0].ToString() + ", ";
                            }
                        }
                    }
                }
            }
            catch(Exception ex){
                result = ex.ToString();
            }
            finally{
                this.Terminal.Text = result;
            }
            
        }

    }

    
}
