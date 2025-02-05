﻿namespace WinAdmin
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.menuFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuNewDB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuData = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuDataGetTankDataFromAPI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.readMasteryBadgesFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readTankTypeFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readNationImagesFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAdminSQLiteDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogDQLiteADminDB = new System.Windows.Forms.OpenFileDialog();
            this.menuDataCreateTableStruct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuData});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.ShowItemToolTips = false;
            this.toolStripMain.Size = new System.Drawing.Size(441, 25);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDB,
            this.menuDataCreateTableStruct,
            this.toolStripSeparator3,
            this.menuSelectDB,
            this.toolStripSeparator1,
            this.MenuExit});
            this.menuFile.Image = ((System.Drawing.Image)(resources.GetObject("menuFile.Image")));
            this.menuFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(38, 22);
            this.menuFile.Text = "&File";
            // 
            // menuNewDB
            // 
            this.menuNewDB.Name = "menuNewDB";
            this.menuNewDB.Size = new System.Drawing.Size(201, 22);
            this.menuNewDB.Text = "Create New Admin DB...";
            this.menuNewDB.Click += new System.EventHandler(this.menuNewDB_Click);
            // 
            // menuSelectDB
            // 
            this.menuSelectDB.Name = "menuSelectDB";
            this.menuSelectDB.Size = new System.Drawing.Size(201, 22);
            this.menuSelectDB.Text = "Select Admin DB...";
            this.menuSelectDB.Click += new System.EventHandler(this.menuSelectDB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(201, 22);
            this.MenuExit.Text = "&Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // menuData
            // 
            this.menuData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDataGetTankDataFromAPI,
            this.toolStripSeparator2,
            this.readMapsToolStripMenuItem,
            this.toolStripSeparator4,
            this.readMasteryBadgesFromFileToolStripMenuItem,
            this.readTankTypeFromFileToolStripMenuItem,
            this.readNationImagesFromFileToolStripMenuItem});
            this.menuData.Image = ((System.Drawing.Image)(resources.GetObject("menuData.Image")));
            this.menuData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(44, 22);
            this.menuData.Text = "Data";
            // 
            // menuDataGetTankDataFromAPI
            // 
            this.menuDataGetTankDataFromAPI.Name = "menuDataGetTankDataFromAPI";
            this.menuDataGetTankDataFromAPI.Size = new System.Drawing.Size(275, 22);
            this.menuDataGetTankDataFromAPI.Text = "Get tank data from API...";
            this.menuDataGetTankDataFromAPI.Click += new System.EventHandler(this.menuDataGetTankDataFromAPI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(272, 6);
            // 
            // readMasteryBadgesFromFileToolStripMenuItem
            // 
            this.readMasteryBadgesFromFileToolStripMenuItem.Name = "readMasteryBadgesFromFileToolStripMenuItem";
            this.readMasteryBadgesFromFileToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.readMasteryBadgesFromFileToolStripMenuItem.Text = "Read mastery badges images from file";
            this.readMasteryBadgesFromFileToolStripMenuItem.Click += new System.EventHandler(this.readMasteryBadgesFromFileToolStripMenuItem_Click);
            // 
            // readTankTypeFromFileToolStripMenuItem
            // 
            this.readTankTypeFromFileToolStripMenuItem.Name = "readTankTypeFromFileToolStripMenuItem";
            this.readTankTypeFromFileToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.readTankTypeFromFileToolStripMenuItem.Text = "Read tank type images from file";
            this.readTankTypeFromFileToolStripMenuItem.Click += new System.EventHandler(this.readTankTypeFromFileToolStripMenuItem_Click);
            // 
            // readNationImagesFromFileToolStripMenuItem
            // 
            this.readNationImagesFromFileToolStripMenuItem.Name = "readNationImagesFromFileToolStripMenuItem";
            this.readNationImagesFromFileToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.readNationImagesFromFileToolStripMenuItem.Text = "Read nation images from file";
            this.readNationImagesFromFileToolStripMenuItem.Click += new System.EventHandler(this.readNationImagesFromFileToolStripMenuItem_Click);
            // 
            // readMapsToolStripMenuItem
            // 
            this.readMapsToolStripMenuItem.Name = "readMapsToolStripMenuItem";
            this.readMapsToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.readMapsToolStripMenuItem.Text = "Read map images from file";
            this.readMapsToolStripMenuItem.Click += new System.EventHandler(this.readMapsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAdminSQLiteDB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection to Admin SQLite database";
            // 
            // txtAdminSQLiteDB
            // 
            this.txtAdminSQLiteDB.Enabled = false;
            this.txtAdminSQLiteDB.Location = new System.Drawing.Point(19, 45);
            this.txtAdminSQLiteDB.Multiline = true;
            this.txtAdminSQLiteDB.Name = "txtAdminSQLiteDB";
            this.txtAdminSQLiteDB.Size = new System.Drawing.Size(357, 56);
            this.txtAdminSQLiteDB.TabIndex = 1;
            this.txtAdminSQLiteDB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename:";
            // 
            // openFileDialogDQLiteADminDB
            // 
            this.openFileDialogDQLiteADminDB.FileName = "openFileDialog1";
            // 
            // menuDataCreateTableStruct
            // 
            this.menuDataCreateTableStruct.Name = "menuDataCreateTableStruct";
            this.menuDataCreateTableStruct.Size = new System.Drawing.Size(201, 22);
            this.menuDataCreateTableStruct.Text = "Create Table Structure";
            this.menuDataCreateTableStruct.Click += new System.EventHandler(this.menuDataCreateTableStruct_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(272, 6);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 188);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Wot Number Admin";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripDropDownButton menuFile;
		private System.Windows.Forms.ToolStripMenuItem MenuExit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtAdminSQLiteDB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialogDQLiteADminDB;
		private System.Windows.Forms.ToolStripMenuItem menuNewDB;
		private System.Windows.Forms.ToolStripMenuItem menuSelectDB;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton menuData;
		private System.Windows.Forms.ToolStripMenuItem menuDataGetTankDataFromAPI;
		private System.Windows.Forms.ToolStripMenuItem readMasteryBadgesFromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem readTankTypeFromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem readNationImagesFromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem readMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDataCreateTableStruct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}

