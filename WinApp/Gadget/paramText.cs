﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinApp.Code;

namespace WinApp.Gadget
{
	public partial class paramText : FormCloseOnEsc
    {
        bool _saveOk = false;
        int _gadgetId = -1;
		
		public paramText(int gadgetId = -1)
		{
			InitializeComponent();
			_gadgetId = gadgetId;
		}

		private async void paramText_Load(object sender, EventArgs e)
		{
			object[] currentParameters = new object[] { null, null, null, null, null };
			if (_gadgetId > -1)
			{
				// Lookup value for current gadget
				string sql = "select * from gadgetParameter where gadgetId=@gadgetId order by paramNum;";
				DB.AddWithValue(ref sql, "@gadgetId", _gadgetId, DB.SqlDataType.Int);
				DataTable dt = await DB.FetchData(sql, Config.Settings.showDBErrors);
				foreach (DataRow dr in dt.Rows)
				{
		 			object paramValue = dr["value"];
					int paramNum = Convert.ToInt32(dr["paramNum"]);
					currentParameters[paramNum] = paramValue;
				}
                if (currentParameters[0] != null)
                    txtText.Text = currentParameters[0].ToString();
			}
		}
        
		private void btnSelect_Click(object sender, EventArgs e)
		{
            txtText.Text = txtText.Text.Trim();
            if (txtText.Text == "")
			{
				MsgBox.Show("Please add a text", "Missing text");
			}
            else
			{
                GadgetHelper.newParameters[0] = txtText.Text;
                GadgetHelper.newParametersOK = true;
                _saveOk = true;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void paramText_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_saveOk)
            {
                // Cancel saving
                GadgetHelper.newParameters = new object[] { null, null, null, null, null };
                GadgetHelper.newParametersOK = false;
            }
        }
    }
}
