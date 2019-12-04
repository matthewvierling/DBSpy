using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBSpy{
    partial class MySQLConnectionForm
    {
        /// <summary>
        
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {



            this.tableDisplay.Size = new Size(200, 450);
            this.dataTable.Controls.Add(tableDisplay, 1, 1);

            this.mainTable.Controls.Add(this.terminal, 1, 3);

        }

    }
}

