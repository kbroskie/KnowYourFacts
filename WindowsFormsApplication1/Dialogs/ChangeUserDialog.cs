﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowYourFacts.Dialogs
{
	public partial class ChangeUserDialog : Form
	{
		public ChangeUserDialog ()
		{
			InitializeComponent ();
		}

		public void setUserChoices (List <String> users)
		{
			usersListBox.Items.Add ("<New User>");

			foreach (String user in users)
			{
				usersListBox.Items.Add (user);
			}
			usersListBox.SelectedIndex = 0;	
		}

		public String getSelectedUser ()
		{
			return usersListBox.SelectedItem.ToString ();
		}
	}
}
