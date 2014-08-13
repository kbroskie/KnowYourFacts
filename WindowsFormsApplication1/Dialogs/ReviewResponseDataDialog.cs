using System;
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
	public partial class ReviewResponseDataDialog : Form
	{
		public ReviewResponseDataDialog ()
		{
			InitializeComponent ();
		}

		private void loadResponseData (String username)
		{
			Data.UserDataSetTableAdapters.ResponseDataTableAdapter responseDataTableAdapter = new Data.UserDataSetTableAdapters.ResponseDataTableAdapter ();
			Console.WriteLine (responseDataTableAdapter.GetData ().ToArray ()[0][3].ToString ());

			// TODO: Add Groups to relevant tab, with each group name set to the response data date
			// TODO: Add Items that correspond to each group for each response data set.
			Data.UserDataSet.ResponseDataRow[] responseDataRows = responseDataTableAdapter.GetData ().ToArray ();
			
			for (int index = 0; index < responseDataRows.Count (); ++index)
			if (responseDataRows[index][0].ToString () == username)
			{
				String groupName = responseDataRows[index][1].ToString ();
				ListViewGroup responseDataGroup = new ListViewGroup (groupName);
				responseDataGroup.Items.Add (responseDataRows[index][3].ToString ());
				
				Math.MathOperationTypeEnum operation = (Math.MathOperationTypeEnum) responseDataRows[index][2];
				if (operation == Math.MathOperationTypeEnum.ADDITION)
				{
					additionListView.Groups.Add (responseDataGroup);
				}
				else if (operation == Math.MathOperationTypeEnum.SUBTRACTION)
				{
					subtractionListView.Groups.Add (responseDataGroup);
				}
				else if (operation == Math.MathOperationTypeEnum.MULTIPLICATION)
				{
					multiplicationListView.Groups.Add (responseDataGroup);
				}
				else
				{
					divisionListView.Groups.Add (responseDataGroup);
				}
			}
		}

		private void additionListView_SelectedIndexChanged (object sender, EventArgs e)
		{

		}
	}
}
