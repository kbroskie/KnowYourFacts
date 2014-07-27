using KnowYourFacts.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using KnowYourFacts.Utility;
using KnowYourFacts.UI;

namespace KnowYourFacts.Dialogs
{	
	public partial class EditProfileDialog : Form
	{
		FactsFiles files = FactsFiles.Instance;

		public EditProfileDialog ()
		{
			InitializeComponent ();
			loadUserProfileData ();
		}

		private void loadUserProfileData ()
		{
			KnowYourFacts.Users.UserProfile profile = MathFactsForm.userProfile;
			usernameMaskedTextBox.Text = profile.user.name;
			speedTestDaysMaskedTextBox.Text = profile.maxDaysBetweenSpeedTests.ToString ();

			if (profile.hasCustomSpeedFacts)
			{
				customFactsCheckBox.Checked = true;
			}

			additionMaxFactNumberMaskedTextBox.Text = profile.maxFactNumbers[0].ToString ();
			subtractionMaxFactNumberMaskedTextBox.Text = profile.maxFactNumbers[1].ToString ();
			multiplicationMaxFactNumberMaskedTextBox.Text = profile.maxFactNumbers[2].ToString ();
			divisionMaxFactNumberMaskedTextBox.Text = profile.maxFactNumbers[3].ToString ();
		}

		private void maskedTextBoxKeyUpEvent (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				saveChangesButton.PerformClick ();
			}
		}

		private void inputMaskedTextBox_KeyPress (object sender, KeyPressEventArgs e)
		{
			// Suppress the sound generated when the user presses enter.
			if (e.KeyChar == (char) Keys.Enter)
			{
				e.Handled = true;
			}
		}

		private void customFactsCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			if (customFactsCheckBox.Checked)
			{
				MathFactsForm.userProfile.hasCustomSpeedFacts = true;
			}
			else
			{
				MathFactsForm.userProfile.hasCustomSpeedFacts = false;
			}

			files.updateUserProfile (MathFactsForm.userProfile);
		}

		private void editSpeedFactsButton_MouseClick (object sender, MouseEventArgs e)
		{
			if (speedTestComboBox.Text == "")
			{
				MessageBox.Show ("You didn't select the type of speed test facts.\nPlease select the fact type before continuing.",
					"No Speed Test Chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MathOperation operation = new MathOperation ((MathOperationTypeEnum) Enum.Parse(typeof(MathOperationTypeEnum), speedTestComboBox.Text.ToUpper ()));
			Console.WriteLine (speedTestComboBox.Text +  " "+ operation.ToString ());
			
			SpeedFactEditDialog speedFactEditDialog = new SpeedFactEditDialog ();
			speedFactEditDialog.Text = operation.ToString () + speedFactEditDialog.Text;

			List<Fact> speedFacts;
			if ((speedFacts = FactsFiles.loadCustomSpeedFacts (operation)).Count () == 0)
			{
				// Load the default speed fact data for creation of the speed facts.
				speedFacts = FactsFiles.loadDefaultSpeedFacts (operation);
			}

			// Load the current speed facts.
			for (int index = 0; index < speedFacts.Count (); ++index)
			{
				speedFactEditDialog.speedFactsDataGridView.Rows.Add (speedFacts[index].leftNum, speedFacts[index].rightNum);
			}
			
			// Update the current selected cell to a new row.
			speedFactEditDialog.speedFactsDataGridView.CurrentCell =  
				speedFactEditDialog.speedFactsDataGridView.Rows[speedFactEditDialog.speedFactsDataGridView.Rows.Count - 1].Cells[0];

			if (speedFactEditDialog.ShowDialog () == DialogResult.OK)
			{
				speedFacts.Clear ();

				String topNumber;
				String bottomNumber;

				DataGridViewCell cell1;
				DataGridViewCell cell2;

				for (int rowIndex = 0; rowIndex < speedFactEditDialog.speedFactsDataGridView.RowCount; ++rowIndex)
				{
					try
					{
						cell1 = speedFactEditDialog.speedFactsDataGridView[rowIndex, 0];
						cell2 = speedFactEditDialog.speedFactsDataGridView[rowIndex, 1];

						// TODO prompt to re-enter row with invalid input
						topNumber = cell1.Value.ToString ();
						bottomNumber = cell2.Value.ToString ();
						speedFacts.Add (new Fact (System.Convert.ToInt16 (topNumber), System.Convert.ToInt16 (bottomNumber), operation));
					}
					catch (Exception exception)
					{
						if (exception is System.FormatException || exception is System.ArgumentOutOfRangeException || exception is System.NullReferenceException)							
						{
							// Do nothing. No data entered in this row.
						}
						else
						{
							throw;
						}
					}
				}
				
				if (speedFacts.Count () < 4)
				{
					MessageBox.Show ("At least 4 speed facts are recommended.\nHaving less than 4 will affect the accuracy of determining the daily facts.\nPlease consider revising and adding more facts.",
							"Add More Speed Facts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				files.saveCustomSpeedFacts (operation, speedFacts);
				foreach (Fact fact in speedFacts)
				{
					Console.WriteLine (fact.ToString ());
				}
			}

			if (speedFactEditDialog != null)
			{
				speedFactEditDialog.Dispose ();
			}
		}
	}
}
 