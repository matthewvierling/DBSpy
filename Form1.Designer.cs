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
        private int txtBoxHeight;
        private string textFont = "Arial";
        private int fontSize = 14;

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

        //button
        private Button ExeButton;

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
            this.txtBoxHeight = this.IPTextBox.Height;
            //IPText
            this.IPLabel = new Label();
            this.IPLabel.Font = new Font(this.textFont, this.fontSize, FontStyle.Regular);
            this.IPLabel.Text = "Server IP: ";
            this.IPLabel.Size = new Size(99, this.txtBoxHeight);
            this.IPLabel.Location = new Point(0, 0);

            //IPTextBox
            this.IPTextBox = new TextBox();
            this.IPTextBox.AcceptsReturn = false;
            this.IPTextBox.AcceptsTab = true;
            this.IPTextBox.Size = new Size(100, this.txtBoxHeight);
            this.IPTextBox.Location = new Point(100,0);
            this.IPTextBox.Text = "127.0.0.1";

            //PrtText
            this.PortLabel = new Label();
            this.PortLabel.Font = new Font(this.textFont, this.fontSize, FontStyle.Regular);
            this.PortLabel.Text = "Port: ";
            this.PortLabel.Size = new Size(59, this.txtBoxHeight);
            this.PortLabel.Location = new Point(210, 0);

            //PortTextBox
            this.PortTextBox = new TextBox();
            this.PortTextBox.AcceptsReturn = false;
            this.PortTextBox.AcceptsTab = true;
            this.PortTextBox.Size = new Size(50, this.txtBoxHeight);
            this.PortTextBox.Location = new Point(270, 0);
            this.PortTextBox.Text = "3306";

            //Usertext
            this.UserLabel = new Label();
            this.UserLabel.Font = new Font(this.textFont, this.fontSize, FontStyle.Regular);
            this.UserLabel.Text = "User: ";
            this.UserLabel.Size = new Size(59, this.txtBoxHeight);
            this.UserLabel.Location = new Point(330, 0);

            //UserTextBox
            this.UserTextBox = new TextBox();
            this.UserTextBox.AcceptsReturn = false;
            this.UserTextBox.AcceptsTab = true;
            this.UserTextBox.Size = new Size(70, this.txtBoxHeight);
            this.UserTextBox.Location = new Point(390, 0);
            this.UserTextBox.Text = "root";

            //PasswordText
            this.PasswordLabel = new Label();
            this.PasswordLabel.Font = new Font(this.textFont, this.fontSize, FontStyle.Regular);
            this.PasswordLabel.Text = "Password: ";
            this.PasswordLabel.Size = new Size(99, this.txtBoxHeight);
            this.PasswordLabel.Location = new Point(470, 0);

            //PasswordTextBox
            this.PasswordTextBox = new TextBox();
            this.PasswordTextBox.AcceptsReturn = false;
            this.PasswordTextBox.AcceptsTab = true;
            this.PasswordTextBox.Size = new Size(100, this.txtBoxHeight);
            this.PasswordTextBox.Location = new Point(570, 0);

            //ExeButton
            this.ExeButton = new Button();
            this.ExeButton.Name = "ExeButton";
            this.ExeButton.Text = "Execute";
            this.ExeButton.Font = new Font(this.textFont, this.fontSize - 3, FontStyle.Bold);
            this.ExeButton.Size = new Size(100, this.txtBoxHeight);
            this.ExeButton.Location = new Point(690, 0);
            this.ExeButton.Click += new System.EventHandler(this.ExecuteDBSpy);

            //Terminal
            this.Terminal = new TextBox();
            this.Terminal.AcceptsReturn = false;
            this.Terminal.AcceptsTab = false;
            this.Terminal.Multiline = true;
            this.Terminal.ReadOnly = true;
            this.Terminal.Size = new Size(this.formWidth - 20, this.formHeight - this.txtBoxHeight - 10);
            this.Terminal.Location = new Point(10, this.txtBoxHeight + 1);

            //form
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(this.formWidth, this.formHeight);
            this.Text = "DBSpy";

            //adding items to form
            this.Controls.Add(IPLabel);
            this.Controls.Add(IPTextBox);
            this.Controls.Add(PortLabel);
            this.Controls.Add(PortTextBox);
            this.Controls.Add(UserLabel);
            this.Controls.Add(UserTextBox);
            this.Controls.Add(PasswordLabel);
            this.Controls.Add(PasswordTextBox);
            this.Controls.Add(ExeButton);
            this.Controls.Add(Terminal);
        }      

        #endregion
    }
}

