﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Code.FormView
{
	class ColListSystemDefault
	{
        //
        // *** SQL TO GENERATE INSERT FOR columnListSelection BASED ON EXISTING COLLIST **
        // *** columListId 5230 = Default2
        //
        //SELECT '"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values ('+cast(columnSelectionId as varchar)+',"+id+",'+cast(sortorder as varchar)+','+cast(columnListSelection.colWidth as varchar)+');" + // ' + columnSelection.name
        //FROM columnListSelection inner join columnSelection on columnSelection.Id = columnListSelection.columnSelectionId
        //WHERE columnListSelection.columnListId=5230
        //ORDER BY sortorder

        // *** TANK SYSTEM COL LIST *** //

        public async static Task NewSystemTankColList()
		{
			// First remove all system colList for Tank
			string sql =
				"delete from columnListSelection where columnListId IN (select id from columnList where sysCol=1 and colType=1); " +
				"delete from columnList where sysCol=1 and colType=1; ";
			await DB.ExecuteNonQuery(sql);
			// Create lists all over
			string newDefaultColListId = "";
			newDefaultColListId = await NewSystemTankColList_Default(-10);
            await NewSystemTankColList_Grinding(-9);
            await NewSystemTankColList_Credit(-8);
            await NewSystemTankColList_WN8(-7);
            // Sort lists
            await ColListHelper.ColListSort(1);
            // Set default if missing
            await SetFavListAsDefaultIfMissing(newDefaultColListId, 1);
			// get default gridfilter, might be new
			MainSettings.GridFilterTank = await GridFilter.GetDefault(GridView.Views.Tank);
		}

		private async static Task<string> NewSystemTankColList_Default(int position)
		{
			string sql = "insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (1,'Default', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
			sql = "select id from columnList where sysCol=1 and colType=1 and name='Default' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
			// Insert columns
			sql =
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (12," + id + ",1,35);" + // Tier
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (181," + id + ",2,90);" + // Tank Image
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (1," + id + ",3,120);" + // Tank
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (44," + id + ",4,50);" + // Type
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (57," + id + ",5,50);" + // Nation
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (900," + id + ",6,3);" + //  - Separator 0 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (54," + id + ",7,100);" + // Last Battle
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (50," + id + ",8,50);" + // Battles
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (95," + id + ",9,50);" + // Win Rate
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (901," + id + ",10,3);" + //  - Separator 1 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (219," + id + ",11,47);" + // K/D Ratio
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (220," + id + ",12,47);" + // Dmg C/R
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (903," + id + ",13,3);" + //  - Separator 3 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (155," + id + ",14,50);" + // Frags Max
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (154," + id + ",15,50);" + // Dmg Max
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (156," + id + ",16,50);" + // XP Max
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (902," + id + ",17,3);" + //  - Separator 2 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (216," + id + ",18,50);" + // Mastery Badge
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (105," + id + ",19,50);" + // WN9
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (49," + id + ",20,50);" + // WN8
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (187," + id + ",21,50);" + // WN7
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (48," + id + ",22,50);"; // EFF
            await DB.ExecuteNonQuery(sql);
			return id;
		}

		private async static Task<string> NewSystemTankColList_Grinding(int position)
		{
			string sql = "insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (1,'Grinding', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
			sql = "select id from columnList where sysCol=1 and colType=1 and name='Grinding' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
			// Insert columns
			sql =
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (12," + id + ",1,35);" +    // tier
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (181," + id + ",2,90);" +   // smallImg
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (1," + id + ",3,106);" +    // name
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (175," + id + ",4,140);" +  // gComment
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (171," + id + ",5,70);" +   // gGrindXP
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (173," + id + ",6,67);" +   // gPogressXp
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (177," + id + ",7,40);" +   // gProgressPercent
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (176," + id + ",8,66);" +   // gRestXP
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (178," + id + ",9,40);" +   // gRestBattles
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (174," + id + ",10,40);" +  // gBattlesDay
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (179," + id + ",11,40);";   // gRestDays
            await DB.ExecuteNonQuery(sql);
			return id;
		}

		private async static Task<string> NewSystemTankColList_WN8(int position)
		{
			string sql = "insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (1,'WN8', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
			sql = "select id from columnList where sysCol=1 and colType=1 and name='WN8' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
			// Insert columns
			sql =
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (12," + id + ",1,35);" + // Tier
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (181," + id + ",2,90);" + // Tank Image
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (1," + id + ",3,120);" + // Tank
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (50," + id + ",4,50);" + // Battles
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (49," + id + ",5,60);" + // WN8
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (900," + id + ",6,3);" + //  - Separator 0 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (188," + id + ",7,60);" + // Avg Dmg
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (192," + id + ",8,60);" + // Exp Dmg
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (901," + id + ",9,3);" + //  - Separator 1 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (95," + id + ",10,47);" + // Win Rate
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (193," + id + ",11,47);" + // Exp Win Rate
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (902," + id + ",12,3);" + //  - Separator 2 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (205," + id + ",13,40);" + // Avg Spot
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (194," + id + ",14,40);" + // Exp Spot
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (903," + id + ",15,3);" + //  - Separator 3 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (191," + id + ",16,40);" + // Avg Frags
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (195," + id + ",17,40);" + // Exp Frags
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (904," + id + ",18,3);" + //  - Separator 4 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (204," + id + ",19,40);" + // Avg Def
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (196," + id + ",20,40);"; // Exp Def
            await DB.ExecuteNonQuery(sql);
			return id;
		}

        private async static Task<string> NewSystemTankColList_Credit(int position)
		{
			string sql = "insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (1,'Credits', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
            sql = "select id from columnList where sysCol=1 and colType=1 and name='Credits' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
			// Insert columns
            sql =
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (12," + id + ",1,35);" + // Tier
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (181," + id + ",2,90);" + // Tank Image
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (1," + id + ",3,140);" + // Tank
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (44," + id + ",4,50);" + // Type
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (57," + id + ",5,50);" + // Nation
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (900," + id + ",6,3);" + //  - Separator 0 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (50," + id + ",7,50);" + // Battles
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (533," + id + ",8,50);" + // Credit Btl Count
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (901," + id + ",9,3);" + //  - Separator 1 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (534," + id + ",10,54);" + // Average Income
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (535," + id + ",11,54);" + // Average Cost
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (536," + id + ",12,54);" + // Average Earned
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (902," + id + ",13,3);" + //  - Separator 2 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (537," + id + ",14,54);" + // Max Income
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (538," + id + ",15,54);" + // Max Cost
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (539," + id + ",16,54);" + // Max Earned
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (903," + id + ",17,3);" + //  - Separator 3 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (540," + id + ",18,72);" + // Tot Income
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (541," + id + ",19,72);" + // Tot Cost
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (542," + id + ",20,72);" + // Tot Earned
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (904," + id + ",21,3);" + //  - Separator 4 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (543," + id + ",22,54);" + // Avg Btl Lifetime
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (544," + id + ",23,54);"; // Earned per min
            await DB.ExecuteNonQuery(sql);
			return id;
		}

		// *** BATTLE SYSTEM COL LIST *** //

		public async static Task NewSystemBattleColList()
		{
			// First remove all system colList for Battle
			string sql =
				"delete from columnListSelection where columnListId IN (select id from columnList where sysCol=1 and colType=2); " +
				"delete from columnList where sysCol=1 and colType=2; ";
            await DB.ExecuteNonQuery(sql);
			// Create lists all over
			string colListId = await NewSystemBattleColList_Default(-10);
            await NewSystemBattleColList_WN8(-9);
            await NewSystemBattleColList_Skirmish(-8);
            // Set default if missing
            await SetFavListAsDefaultIfMissing(colListId, 2);
            // Sort lists
            await ColListHelper.ColListSort(2);
            // Change to default in case selected no longer exists
			MainSettings.GridFilterBattle = await GridFilter.GetDefault(GridView.Views.Battle);

		}

		private async static Task<string> NewSystemBattleColList_Default(int position)
		{
			// Create new default colList
			string sql = "insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (2,'Default', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
			sql = "select id from columnList where sysCol=1 and colType=2 and name='Default' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
            // Insert columns 
            sql =
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (59," + id + ",1,35);" + // Tier
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (184," + id + ",2,90);" + // Tank Image
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (58," + id + ",3,93);" + // Tank
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (8," + id + ",4,104);" + // Finished
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (10," + id + ",5,59);" + // Result
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (11," + id + ",6,53);" + // Survived
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (900," + id + ",7,3);" + //  - Separator 0 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (531," + id + ",8,47);" + // Team Result
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (902," + id + ",9,3);" + //  - Separator 2 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (19," + id + ",10,54);" + // Dmg
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (21," + id + ",11,47);" + // Dmg Spot
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (22," + id + ",12,47);" + // Dmg Track
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (214," + id + ",13,50);" + // Dmg Blocked
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (901," + id + ",14,3);" + //  - Separator 1 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (18," + id + ",15,35);" + // Frags
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (35," + id + ",16,35);" + // Spot
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (24," + id + ",17,35);" + // Cap
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (25," + id + ",18,35);" + // Def
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (905," + id + ",19,3);" + //  - Separator 5 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (519," + id + ",20,55);" + // Total XP
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (508," + id + ",21,52);" + // Credits Result
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (904," + id + ",22,3);" + //  - Separator 4 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (224," + id + ",23,47);" + // Dmg Rank
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (223," + id + ",24,52);" + // Dmg Rank Progress
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (903," + id + ",25,3);" + //  - Separator 3 -
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (47," + id + ",26,55);" + // WN8
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (520," + id + ",27,50);" + // Mastery Badge
                "insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (512," + id + ",28,86);"; // Map
            await DB.ExecuteNonQuery(sql);
			return id;
		}

		private async static Task<string> NewSystemBattleColList_WN8(int position)
		{
			string sql = "insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (2,'WN8', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
			sql = "select id from columnList where sysCol=1 and colType=2 and name='WN8' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
			// Insert columns
			sql =
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (59," + id + ",1,35);" + // Tier
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (184," + id + ",2,90);" + // Tank Image
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (58," + id + ",3,120);" + // Tank
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (8," + id + ",4,100);" + // DateTime
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (47," + id + ",5,60);" + // WN8
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (900," + id + ",6,3);" + //  - Separator 0 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (19," + id + ",7,60);" + // Dmg
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (197," + id + ",8,60);" + // Exp Dmg
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (901," + id + ",9,3);" + //  - Separator 1 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (35," + id + ",10,40);" + // Spot
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (199," + id + ",11,40);" + // Exp Spot
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (902," + id + ",12,3);" + //  - Separator 2 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (18," + id + ",13,40);" + // Frags
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (200," + id + ",14,40);" + // Exp Frags
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (903," + id + ",15,3);" + //  - Separator 3 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (25," + id + ",16,40);" + // Def
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (201," + id + ",17,40);"; // Exp Def
            await DB.ExecuteNonQuery(sql);
			return id;
		}

		private async static Task<string> NewSystemBattleColList_Skirmish(int position)
		{
			// Create new default colList
			string sql =
				"insert into columnList (colType,name,colDefault,position,sysCol,defaultFavListId) values (2,'Skirmish', 0, " + position.ToString() + ", 1, -1); ";
            await DB.ExecuteNonQuery(sql);
			// Find id for new list
			sql = "select id from columnList where sysCol=1 and colType=2 and name='Skirmish' order by position;";
			string id = (await DB.FetchData(sql)).Rows[0][0].ToString();
			// Insert columns
			sql =
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (59," + id + ",1,35);" + // Tier
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (184," + id + ",2,90);" + // Tank Image
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (58," + id + ",3,96);" + // Tank
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (8," + id + ",4,104);" + // DateTime
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (10," + id + ",5,59);" + // Result
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (11," + id + ",6,53);" + // Survived
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (526," + id + ",7,73);" + // Killed By
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (513," + id + ",8,78);" + // Finish Reason
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (902," + id + ",9,3);" + //  - Separator 2 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (19," + id + ",10,47);" + // Dmg
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (18," + id + ",11,35);" + // Frags
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (904," + id + ",12,3);" + //  - Separator 4 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (519," + id + ",13,55);" + // Total XP
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (508," + id + ",14,52);" + // Credits Result
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (901," + id + ",15,3);" + //  - Separator 1 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (523," + id + ",16,38);" + // IR
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (524," + id + ",17,49);" + // Clan IR
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (900," + id + ",18,3);" + //  - Separator 0 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (525," + id + ",19,50);" + // Enemy Clan IR
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (521," + id + ",20,55);" + // Enemy Clan
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (903," + id + ",21,3);" + //  - Separator 3 -
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (47," + id + ",23,47);" + // WN8
				"insert into columnListSelection (columnSelectionId,columnListId,sortorder,colWidth) values (512," + id + ",25,97);"; // Map
            await DB.ExecuteNonQuery(sql);
			return id;
		}


		// *** SET NEW DEFAULT COL LIST IF MISSING ***/

		private async static Task SetFavListAsDefaultIfMissing(string favListId, int colTypeId)
		{
			string sql = "select count(id) from columnList where colDefault=1 and colType=" + colTypeId.ToString() + ";";
            DataTable dt = await DB.FetchData(sql);
            int count = 0;
            if (dt != null || dt.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt.Rows[0][0]);
            }
			if (count == 0)
			{
				sql = "update columnList set colDefault=1 where id=" + favListId + " and colType= " + colTypeId.ToString();
                await DB.ExecuteNonQuery(sql);
                if (colTypeId == 1)
                {
                    MainSettings.GridFilterTank.ColListId = Convert.ToInt32(favListId);
                    MainSettings.GridFilterTank.ColListName = "Default";
                }
                else
                {
                    MainSettings.GridFilterBattle.ColListId = Convert.ToInt32(favListId);
                    MainSettings.GridFilterBattle.ColListName = "Default";
                }
			}
		}

		private async static Task AddMissingTank(int tankId, string name, int countryid, int tier, int tanktypeid, int premium)
		{
			DataRow dr = (await DB.FetchData("select count(id) from tank where id=" + tankId.ToString())).Rows[0];
			string sql = "insert into tank (id, name, countryid, tier, tanktypeid, premium) values (@id, @name, @countryid, @tier, @tanktypeid, @premium);";
			if (dr[0] != DBNull.Value && Convert.ToInt32(dr[0]) > 0)
			{
				sql = "update tank set name=@name, countryid=@countryid, tier=@tier, tanktypeid=@tanktypeid, premium=@premium where id=@id;";
			}
			DB.AddWithValue(ref sql, "@id", tankId, DB.SqlDataType.Int);
			DB.AddWithValue(ref sql, "@name", name, DB.SqlDataType.VarChar);
			DB.AddWithValue(ref sql, "@countryid", countryid, DB.SqlDataType.Int);
			DB.AddWithValue(ref sql, "@tier", tier, DB.SqlDataType.Int);
			DB.AddWithValue(ref sql, "@tanktypeid", tanktypeid, DB.SqlDataType.Int);
			DB.AddWithValue(ref sql, "@premium", premium, DB.SqlDataType.Int);
            await DB.ExecuteNonQuery(sql);
		}
	}
}
