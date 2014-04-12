﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotDBUpdater.Code;

namespace WotDBUpdater.Code
{
	class db
	{
		public static DataTable FetchData(string sql, string OverrideDbCon = "")
		{
			DataTable dt = new DataTable();
			string connectionstring = Config.DatabaseConnection();
			if (OverrideDbCon != "") connectionstring = OverrideDbCon;
			try
			{
				if (Config.Settings.databaseType == ConfigData.dbType.MSSQLserver)
				{
					SqlConnection con = new SqlConnection(connectionstring);
					con.Open();
					SqlCommand command = new SqlCommand(sql, con);
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					adapter.Fill(dt);
					con.Close();
				}
				else if (Config.Settings.databaseType == ConfigData.dbType.SQLite)
				{
					SQLiteConnection con = new SQLiteConnection(connectionstring);
					con.Open();
					SQLiteCommand command = new SQLiteCommand(sql, con);
					SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
					adapter.Fill(dt);
					con.Close();
				}
			}
			catch (Exception ex)
			{
				Code.MsgBox.Show("Error fetching data from database. Please check your database settings.\n\n" + 
					Environment.NewLine + Environment.NewLine + ex.ToString(), "Database error");
			}
			return dt;
		}

		public static bool ExecuteNonQuery(string sql)
		{
			bool ok = false;
			string[] sqlList = sql.Split(new string[] { "GO",";" }, StringSplitOptions.RemoveEmptyEntries);
			try
			{
				if (Config.Settings.databaseType == ConfigData.dbType.MSSQLserver)
				{
					SqlConnection con = new SqlConnection(Config.DatabaseConnection());
					con.Open();
					foreach (string s in sqlList)
					{
						SqlCommand command = new SqlCommand(s, con);
						command.ExecuteNonQuery();
					}
					con.Close();
					ok = true;
				}
				else if (Config.Settings.databaseType == ConfigData.dbType.SQLite)
				{
					SQLiteConnection con = new SQLiteConnection(Config.DatabaseConnection());
					con.Open();
					foreach (string s in sqlList)
					{
						SQLiteCommand command = new SQLiteCommand(s, con);
						command.ExecuteNonQuery();
					}
					con.Close();
					ok = true;
				}
			}
			catch (Exception ex)
			{
				Code.MsgBox.Show("Error execute query to database. Please check you input parameters." + 
					Environment.NewLine + Environment.NewLine + ex.ToString(), "Database error");
				ok = false;
			}
			return ok;
		}

		public static DataTable ListTables()
		{
			DataTable dt = new DataTable();
			if (Config.Settings.databaseType == ConfigData.dbType.MSSQLserver)
			{
				string sql = "SELECT '( Select from list )' AS TABLE_NAME UNION SELECT table_name AS TABLE_NAME FROM information_schema.tables ORDER BY TableName";
				dt = FetchData(sql);
			}
			else if (Config.Settings.databaseType == ConfigData.dbType.SQLite)
			{
				SQLiteConnection con = new SQLiteConnection(Config.DatabaseConnection());
				con.Open();
				DataTable Tables = new DataTable();
				Tables = FetchData("SELECT '( Select from list )' AS TABLE_NAME");
				DataTable TableList = new DataTable();
				TableList = con.GetSchema("tables"); // Returns list of tables in column "TABLE_NAME"
				foreach (DataRow r in TableList.Rows)
				{
					Tables.Rows.Add(r["TABLE_NAME"]);
				}
				con.Clone();
				dt = Tables;
			}
			return dt;
		}

		public static bool CreateDatabase(string databaseName, string fileLocation)
		{
			bool dbOk = false;
			// Check database file location
			bool fileLocationExsits = true;
			fileLocation = fileLocation.Trim();
			if (fileLocation.Substring(fileLocation.Length - 1, 1) != "\\" && fileLocation.Substring(fileLocation.Length - 1, 1) != "/")
				fileLocation += "\\";
			if (!Directory.Exists(fileLocation))
			{
				DirectoryInfo prevPath = Directory.GetParent(fileLocation);
				if (!prevPath.Exists)
				{
					if (!Directory.GetParent(prevPath.FullName).Exists)
					{
						fileLocationExsits = false;
						Code.MsgBox.Show("Error createing database, file parh does not exist", "Error creating database");
					}
					else
					{
						Directory.CreateDirectory(fileLocation);
					}
				}
			}
			// Start Creating if file location exists
			if (fileLocationExsits)
			{
				if (Config.Settings.databaseType == ConfigData.dbType.MSSQLserver)
				{
					// Check if database exists
					bool dbExists = false;
					using (SqlConnection con = new SqlConnection(Config.DatabaseConnection()))
					{
						con.Open();
						string sql = "SELECT [name] FROM master.dbo.sysdatabases WHERE [name] = '" + databaseName + "'";
						SqlCommand cmd = new SqlCommand(sql, con);
						SqlDataReader reader = cmd.ExecuteReader();
						if (reader.HasRows) dbExists = true;
						con.Close();
					}
					if (dbExists)
					{
						Code.MsgBox.Show("Database with this name alreade exsits, choose another database name.", "Cannot create database");
					}
					else
					{
						SqlConnection myConn = new SqlConnection(Config.DatabaseConnection("", "master"));
						string sql = "CREATE DATABASE " + databaseName + " ON PRIMARY " +
									"(NAME = " + databaseName + ", " +
									"FILENAME = '" + fileLocation + databaseName + ".mdf', " +
									"SIZE = 5MB, FILEGROWTH = 10%) " +
									"LOG ON (NAME = " + databaseName + "_Log, " +
									"FILENAME = '" + fileLocation + databaseName + "_log.ldf', " +
									"SIZE = 1MB, " +
									"FILEGROWTH = 10%)";

						SqlCommand myCommand = new SqlCommand(sql, myConn);
						try
						{
							// Create db now
							myConn.Open();
							myCommand.ExecuteNonQuery();
							myConn.Close();
							// Save new db into settings
							Config.Settings.databaseName = databaseName;
							string msg = "";
							Config.SaveConfig(out msg);
							dbOk = true;
						}
						catch (System.Exception ex)
						{
							dbOk = false;
							Code.MsgBox.Show("Error creating database, check that valid databasename is selected." + 
								Environment.NewLine + Environment.NewLine + ex.ToString(), "Error creating database");
						}
					}
				}
				else if (Config.Settings.databaseType == ConfigData.dbType.SQLite)
				{
					// Check if database exists
					if (File.Exists(fileLocation + databaseName + ".db"))
					{
						Code.MsgBox.Show("Error creating database, databasefile already exists, select another database name", "Error creating database");
					}
					else
					{
						// Create new db file now
						string db = fileLocation + databaseName + ".db";
						SQLiteConnection.CreateFile(db);
						// Save new db file into settings
						Config.Settings.databaseFileName = fileLocation + databaseName + ".db";
						string msg = "";
						Config.SaveConfig(out msg);
						dbOk = true;
					}
				}
			}
			return dbOk;
		}


	}
}