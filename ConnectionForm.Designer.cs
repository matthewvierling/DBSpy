using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DBSpy
{
    partial class ConnectionForm
    {
        /// <summary>
        protected int formWidth = 1000;
        protected int formHeight = 700;
        protected int headerHeight;

        //text boxed
        protected TextBox terminal;

        //flow and table layout panels
        protected FlowLayoutPanel headerFlow;
        protected TableLayoutPanel mainTable;
        protected TableLayoutPanel dataTable;

        //Table Display
        protected TableDisplay tableDisplay;

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

            //form
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(this.formWidth, this.formHeight);
            this.Text = "DBSpyConnection";

            //main table panel
            this.mainTable = new TableLayoutPanel();
            this.mainTable.AutoSize = true;
            this.mainTable.Dock = DockStyle.Fill;

            //data table panel
            this.dataTable = new TableLayoutPanel();
            this.dataTable.AutoSize = true;
            this.dataTable.Dock = DockStyle.Fill;

            //header flow panel
            this.headerHeight = 30;
            this.headerFlow = new FlowLayoutPanel();
            this.headerFlow.Size = new Size(10, this.headerHeight);
            this.headerFlow.Dock = DockStyle.Left;

            //terminal
            this.terminal = new TextBox();
            this.terminal.AcceptsReturn = false;
            this.terminal.AcceptsTab = false;
            this.terminal.Multiline = true;
            this.terminal.ReadOnly = true;
            this.terminal.Size = new Size(100, 150);
            //this.terminal.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.terminal.Dock = DockStyle.Fill;

            //adding items to form
            this.mainTable.Controls.Add(this.headerFlow, 1, 1);
            this.mainTable.Controls.Add(this.dataTable, 1, 2);
            this.Controls.Add(this.mainTable);

        }

    }
}

