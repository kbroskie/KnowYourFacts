using System;
using System.Linq;
using System.Windows.Forms;

namespace KnowYourFacts.Dialogs
{
	public partial class ReviewResponseDataDialog : Form
	{
		public ReviewResponseDataDialog ()
		{
			InitializeComponent ();
		}

		/*
		 * Load the response data, dividing operations into separate tabs, and dates into separate groups within each tab.
		 */ 
		public void loadResponseData (String username)
		{
			Data.UserDataSetTableAdapters.ResponseDataTableAdapter responseDataTableAdapter = new Data.UserDataSetTableAdapters.ResponseDataTableAdapter ();	
			Data.UserDataSet.ResponseDataRow[] responseDataRows = responseDataTableAdapter.GetData ().ToArray ();

			for (int index = 0; index < responseDataRows.Count (); ++index)
			if (responseDataRows[index][0].ToString () == username)
			{
				String responseDate = responseDataRows[index][1].ToString ();
				String responseString = responseDataRows[index][3].ToString ();
				ListView listView;

				Math.MathOperationTypeEnum operation = (Math.MathOperationTypeEnum) responseDataRows[index][2];

				if (operation == Math.MathOperationTypeEnum.ADDITION)
				{
					listView = additionListView;
				}
				else if (operation == Math.MathOperationTypeEnum.SUBTRACTION)
				{
					listView = subtractionListView;
				}
				else if (operation == Math.MathOperationTypeEnum.MULTIPLICATION)
				{
					listView = multiplicationListView;
				}
				else
				{
					listView = divisionListView;
				}

				createListView (listView, responseDate, responseString);
			}
		}

		public void createListView (ListView listView, String responseDate, String responseString)
		{
			// Add the group, using the date for the response data as the group name.
			ListViewGroup responseDateGroup = new ListViewGroup (responseDate);
			listView.Groups.Add (responseDateGroup);

			// This ensures that each entry is put on a separate line.
			listView.AutoResizeColumns (ColumnHeaderAutoResizeStyle.ColumnContent);

			// Without clearing the listview first, duplicate elements will appear.
			if (listView.Groups.Count == 1)
			{
				listView.Clear ();
			}

			// Display each response on a separate line.
			ListViewItem responseStringItem;
			String[] responses = responseString.Split ('\n');
			foreach (string word in responses)
			{
				responseStringItem = new ListViewItem (word, responseDateGroup);
				listView.Items.Add (responseStringItem);
			}
		}
	}
}
