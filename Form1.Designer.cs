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
    partial class Form1
    {
        /// <summary>

        //size parameters
        private string textFont = "Arial";
        private int fontSize = 14;
        private Font txtFont;
        private int txtBoxHeight;
        private int formHeight = 300;
        private int formWidth = 800;
        
        //text boxes
        private TextBox IPTextBox;
        private TextBox PortTextBox;
        private TextBox UserTextBox;
        private TextBox PasswordTextBox;
        private TextBox Terminal;

        //labels
        private Label IPLabel;
        private Label PortLabel;
        private Label UserLabel;
        private Label PasswordLabel;
        private Label DatabasesLabel;

        //buttons
        private Button ExeButton;
        private Button connectButton;

        //combo boxes
        private ComboBox databaseTypeCombo;
        private ComboBox databasesOnServerCombo;

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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //initializing private variables
            this.txtFont = new Font(this.textFont, this.fontSize, FontStyle.Regular);
            this.txtBoxHeight = (int)txtFont.SizeInPoints*2;

            //DB Type Combo
            this.databaseTypeCombo = new ComboBox();
            this.databaseTypeCombo.Name = "DatabaseTypeCombo";
            this.databaseTypeCombo.Size = new Size(100, this.txtBoxHeight);
            this.databaseTypeCombo.TabIndex = 0;
            this.databaseTypeCombo.Items.AddRange(this.databaseOptions);
            this.databaseTypeCombo.SelectedItem = this.currentDBServerType;
            this.databaseTypeCombo.DropDownClosed += new System.EventHandler(this.ChangeDBServerType);
            this.databaseTypeCombo.Refresh();

            //IPText
            this.IPLabel = new Label();
            this.IPLabel.Font = this.txtFont;
            this.IPLabel.Text = "Server IP:";
            this.IPLabel.AutoSize = true;

            //IPTextBox
            this.IPTextBox = new TextBox();
            this.IPTextBox.AcceptsReturn = false;
            this.IPTextBox.AcceptsTab = true;
            this.IPTextBox.Size = new Size(100, this.txtBoxHeight);
            this.IPTextBox.Text = "127.0.0.1";

            //PrtText
            this.PortLabel = new Label();
            this.PortLabel.Font = this.txtFont;
            this.PortLabel.Text = "Port:";
            this.PortLabel.AutoSize = true;

            //PortTextBox
            this.PortTextBox = new TextBox();
            this.PortTextBox.AcceptsReturn = false;
            this.PortTextBox.AcceptsTab = true;
            this.PortTextBox.Size = new Size(50, this.txtBoxHeight);
            this.PortTextBox.Text = "3306";

            //Usertext
            this.UserLabel = new Label();
            this.UserLabel.Font = this.txtFont;
            this.UserLabel.Text = "User:";
            this.UserLabel.AutoSize = true;

            //UserTextBox
            this.UserTextBox = new TextBox();
            this.UserTextBox.AcceptsReturn = false;
            this.UserTextBox.AcceptsTab = true;
            this.UserTextBox.Size = new Size(70, this.txtBoxHeight);
            this.UserTextBox.Text = "root";

            //PasswordText
            this.PasswordLabel = new Label();
            this.PasswordLabel.Font = this.txtFont;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.AutoSize = true;

            //PasswordTextBox
            this.PasswordTextBox = new TextBox();
            this.PasswordTextBox.AcceptsReturn = false;
            this.PasswordTextBox.AcceptsTab = true;
            this.PasswordTextBox.Size = new Size(100, this.txtBoxHeight);

            //ExeButton
            this.ExeButton = new Button();
            this.ExeButton.Name = "ExeButton";
            this.ExeButton.Text = "Update";
            this.ExeButton.Font = new Font(this.textFont, this.fontSize - 3, FontStyle.Bold);
            this.ExeButton.Size = new Size(100, this.txtBoxHeight);
            this.ExeButton.Click += new System.EventHandler(this.UpdateDBSpy);

            //databases label
            this.DatabasesLabel = new Label();
            this.DatabasesLabel.Font = this.txtFont;
            this.DatabasesLabel.Text = "Databases:";
            this.DatabasesLabel.AutoSize = true;

            //DBs on Server
            this.databasesOnServerCombo = new ComboBox();
            this.databasesOnServerCombo.Name = "DatabasesOnServerCombo";
            this.databasesOnServerCombo.Size = new Size(200, this.txtBoxHeight);
            this.databasesOnServerCombo.TabIndex = 0;
            this.databasesOnServerCombo.DropDownClosed += new System.EventHandler(this.DBToConnect);
            this.databasesOnServerCombo.Refresh();

            //connect button
            this.connectButton = new Button();
            this.connectButton.Name = "ConnectButton";
            this.connectButton.Text = "Connect";
            this.connectButton.Font = new Font(this.textFont, this.fontSize - 3, FontStyle.Bold);
            this.connectButton.Size = new Size(100, this.txtBoxHeight);
            this.connectButton.Click += new System.EventHandler(this.ConnectToDB);

            //Terminal
            this.Terminal = new TextBox();
            this.Terminal.AcceptsReturn = false;
            this.Terminal.AcceptsTab = false;
            this.Terminal.Multiline = true;
            this.Terminal.ReadOnly = true;
            this.Terminal.Size = new Size(this.formWidth - 6, this.formHeight - (this.txtBoxHeight+3)*3 - 30);
            this.Terminal.Anchor = (AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left);

            //form
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(this.formWidth, this.formHeight);
            this.Text = "DBSpy";

            //flow panel1
            FlowLayoutPanel flowPanel1 = new FlowLayoutPanel();
            flowPanel1.Size = new Size(this.formWidth, this.txtBoxHeight+3);

            //flow Panel 2
            FlowLayoutPanel flowPanel2 = new FlowLayoutPanel();
            flowPanel2.Size = new Size(this.formWidth, this.txtBoxHeight+3);

            //flow panel3
            FlowLayoutPanel flowPanel3 = new FlowLayoutPanel();
            flowPanel3.Size = new Size(this.formWidth, this.txtBoxHeight+3);

            //table panel
            TableLayoutPanel tablePanel = new TableLayoutPanel();
            tablePanel.AutoSize = true;
            tablePanel.Anchor = (AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left);

            //adding controls to Flow Layout 1
            flowPanel1.Controls.Add(databaseTypeCombo);            

            //adding controls to Flow Layout 2
            flowPanel2.Controls.Add(IPLabel);
            flowPanel2.Controls.Add(IPTextBox);
            flowPanel2.Controls.Add(PortLabel);
            flowPanel2.Controls.Add(PortTextBox);
            flowPanel2.Controls.Add(UserLabel);
            flowPanel2.Controls.Add(UserTextBox);
            flowPanel2.Controls.Add(PasswordLabel);
            flowPanel2.Controls.Add(PasswordTextBox);

            //adding controls to Flow Layout 3
            flowPanel3.Controls.Add(ExeButton);
            flowPanel3.Controls.Add(DatabasesLabel);
            flowPanel3.Controls.Add(databasesOnServerCombo);
            flowPanel3.Controls.Add(connectButton);

            //adding controls to Table Layout
            tablePanel.Controls.Add(flowPanel1, 1, 1);
            tablePanel.Controls.Add(flowPanel2, 1, 2);
            tablePanel.Controls.Add(flowPanel3, 1, 3);
            tablePanel.Controls.Add(this.Terminal, 1, 4);

            this.Controls.Add(tablePanel);
        }      

        #endregion
    }
}

