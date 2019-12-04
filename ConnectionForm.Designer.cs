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

        //text boxed
        protected TextBox terminal;

        //flow and table layout panels
        protected FlowLayoutPanel headerFlow;
        protected TableLayoutPanel mainTable;

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

            //header flow panel
            this.headerFlow = new FlowLayoutPanel();
            this.headerFlow.Dock = DockStyle.Left;

            //terminal
            this.terminal = new TextBox();
            this.terminal.AcceptsReturn = false;
            this.terminal.AcceptsTab = false;
            this.terminal.Multiline = true;
            this.terminal.ReadOnly = true;
            //this.Terminal.Size = new Size(this.formWidth - 20, this.formHeight - (this.txtBoxHeight+3)*3 - 30);
            this.terminal.Dock = DockStyle.Fill;

            //adding items to form
            this.mainTable.Controls.Add(this.headerFlow, 1, 1);
            this.Controls.Add(this.mainTable);

        }

    }
}

