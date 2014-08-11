using KnowYourFacts.Data;
using KnowYourFacts.Math;
using KnowYourFacts.UI;
using KnowYourFacts.Users;
using KnowYourFacts.Utility;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace KnowYourFacts.Dialogs
{
	public partial class EditProfileDialog : Form
	{
		FactsFiles files = FactsFiles.Instance;
		String connString = System.Configuration.ConfigurationManager.ConnectionStrings["KnowYourFacts.Properties.Settings.KnowYourFactsDatabaseConnectionString"].ConnectionString;
		readonly private String SAVE_NEW_PROFILE_BUTTON_TEXT = "Save Profile";
		private List<MaskedTextBox> maxFactNumberMaskedTextBoxes;
		private UserDataSet userDataSet;
		private KnowYourFacts.Data.UserDataSetTableAdapters.UserDataTableAdapter userDataTableAdapter;
		
		public EditProfileDialog ()
		{
			InitializeComponent ();
			loadUserProfileData ();
			userDataSet = new UserDataSet ();
			userDataTableAdapter = new Data.UserDataSetTableAdapters.UserDataTableAdapter ();
		}

		private void loadUserProfileData ()
		{
			KnowYourFacts.Users.UserProfile profile = MathFactsForm.userProfile;
			usernameMaskedTextBox.Text = profile.user.name;
			usernameMaskedTextBox.Tag = usernameMaskedTextBox.Text;

			speedTestDaysMaskedTextBox.Text = profile.maxDaysBetweenSpeedTests.ToString ();
			speedTestDaysMaskedTextBox.Tag = speedTestDaysMaskedTextBox.Text;

			if (profile.hasCustomSpeedFacts)
			{
				customFactsCheckBox.Checked = true;
			}
			customFactsCheckBox.Tag = customFactsCheckBox.Checked.ToString ();

			additionMaxFactNumberMaskedTextBox.Text = 
				profile.maxFactNumbers[(int) MathOperationTypeEnum.ADDITION].ToString ();
			additionMaxFactNumberMaskedTextBox.Tag = additionMaxFactNumberMaskedTextBox.Text;

			subtractionMaxFactNumberMaskedTextBox.Text = 
				profile.maxFactNumbers[(int) MathOperationTypeEnum.SUBTRACTION].ToString ();
			subtractionMaxFactNumberMaskedTextBox.Tag = subtractionMaxFactNumberMaskedTextBox.Text;

			multiplicationMaxFactNumberMaskedTextBox.Text = 
				profile.maxFactNumbers[(int) MathOperationTypeEnum.MULTIPLICATION].ToString ();
			multiplicationMaxFactNumberMaskedTextBox.Tag = multiplicationMaxFactNumberMaskedTextBox.Text;

			divisionMaxFactNumberMaskedTextBox.Text = 
				profile.maxFactNumbers[(int) MathOperationTypeEnum.DIVISION].ToString ();
			divisionMaxFactNumberMaskedTextBox.Tag = divisionMaxFactNumberMaskedTextBox.Text;

			maxFactNumberMaskedTextBoxes = new List <MaskedTextBox> {additionMaxFactNumberMaskedTextBox, subtractionMaxFactNumberMaskedTextBox, multiplicationMaxFactNumberMaskedTextBox, divisionMaxFactNumberMaskedTextBox };
		}

		public void prepareFieldsForNewProfileEntry ()
		{
			// Prepare the dialog to create a profile rather than editing an existing one.
			this.Text = "New User Profile";
			saveChangesButton.Text = SAVE_NEW_PROFILE_BUTTON_TEXT;

			changePasswordTextBox.Visible = false;
			changePasswordLabel.Visible = false;

			passwordConfirmTextBox.TabIndex = 10;
			saveChangesButton.TabIndex = 11;
			saveChangesButton.TabIndex = 12;

			usernameMaskedTextBox.Clear ();
			additionMaxFactNumberMaskedTextBox.Clear ();
			subtractionMaxFactNumberMaskedTextBox.Clear ();
			multiplicationMaxFactNumberMaskedTextBox.Clear ();
			divisionMaxFactNumberMaskedTextBox.Clear ();
			customFactsCheckBox.Checked = false;
			speedTestDaysMaskedTextBox.Text = "30";
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

		private void editSpeedFactsButton_MouseClick (object sender, MouseEventArgs e)
		{
			if (speedTestComboBox.Text == "")
			{
				MessageBox.Show ("You didn't select the type of speed test facts.\nPlease select the fact type before continuing.",
					"No Speed Test Chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MathOperation operation = new MathOperation ((MathOperationTypeEnum) Enum.Parse (typeof (MathOperationTypeEnum), speedTestComboBox.Text, true));

			SpeedFactEditDialog speedFactEditDialog = new SpeedFactEditDialog ();
			speedFactEditDialog.Text = operation.ToString () + speedFactEditDialog.Text;
			DataGridView speedFactDataGridView = speedFactEditDialog.speedFactsDataGridView;

			List<Fact> speedFacts;
			if ((speedFacts = FactsFiles.loadCustomSpeedFacts (operation)).Count () == 0)
			{
				// Load the default speed fact data for creation of the speed facts.
				speedFacts = FactsFiles.loadDefaultSpeedFacts (operation);
			}

			// Load the current speed facts.
			for (int index = 0; index < speedFacts.Count (); ++index)
			{
				speedFactDataGridView.Rows.Add (speedFacts[index].leftNum, speedFacts[index].rightNum);
			}

			// Update the current selected cell to a new row.
			speedFactDataGridView.CurrentCell =
				speedFactDataGridView.Rows[speedFactDataGridView.Rows.Count - 1].Cells[0];

			if (speedFactEditDialog.ShowDialog () == DialogResult.OK)
			{
				speedFacts.Clear ();

				String topNumber;
				String bottomNumber;

				DataGridViewCell cell1;
				DataGridViewCell cell2;

				for (int rowIndex = 0; rowIndex < speedFactDataGridView.RowCount; ++rowIndex)
				{
					try
					{
						cell1 = speedFactDataGridView[rowIndex, 0];
						cell2 = speedFactDataGridView[rowIndex, 1];

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
			}

			if (speedFactEditDialog != null)
			{
				speedFactEditDialog.Dispose ();
			}
		}

		private void saveProfileChanges ()
		{
			bool updateUserProfileData = false;

			if (!String.IsNullOrEmpty(passwordTextBox.Text) && validatePassword (passwordTextBox.Text))
			{
				bool fieldProcessed;

				// Update the username
				if (!usernameMaskedTextBox.Text.Equals (usernameMaskedTextBox.Tag))
				{
					String newUsername = processUsernameField (out fieldProcessed);

					if (fieldProcessed)
					{
						if (files.userDirectoryExists (new User (newUsername)))
						{
							MessageBox.Show ("Sorry, that username is already taken.\nPlease try again with a different username.",
									"Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
							usernameMaskedTextBox.Text = MathFactsForm.userProfile.user.name;
						}
						else
						{
							updateUsernameInFilesAndSettings (newUsername);
							updateUserProfileData = true;
						}
					}
				}

				// Update usage of custom speed facts.
				if (!customFactsCheckBox.Checked.ToString ().Equals (customFactsCheckBox.Tag))
				{
					MathFactsForm.userProfile.hasCustomSpeedFacts = customFactsCheckBox.Checked;
					customFactsCheckBox.Tag = customFactsCheckBox.Checked.ToString ();
					updateUserProfileData = true;
				}

				// Update the duration between speed tests
				if (!speedTestDaysMaskedTextBox.Text.Equals (speedTestDaysMaskedTextBox.Tag))
				{
					processMaxDaysBetweenSpeedTestField (out fieldProcessed);
					if (fieldProcessed)
					{
						speedTestDaysMaskedTextBox.Tag = speedTestDaysMaskedTextBox.Text;
						updateUserProfileData = true;
					}
				}

				// Update max fact numbers
				for (int index = 0; index < maxFactNumberMaskedTextBoxes.Count (); ++index)
				{
					Int16 newMaxFactNumber;
					if (!maxFactNumberMaskedTextBoxes[index].Tag.ToString() .Equals (maxFactNumberMaskedTextBoxes[index].Text))
					{

						if ((newMaxFactNumber = Convert.ToInt16 (maxFactNumberMaskedTextBoxes[index].Text)) <= 0)
						{
							MessageBox.Show ("Please enter a number greater than 0.", "Invalid Maximum Fact Number",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							maxFactNumberMaskedTextBoxes[index].SelectAll ();
						}
						else
						{
							updateUserProfileData = true;
							updateFactFiles ((MathOperationTypeEnum) Enum.Parse (typeof (MathOperationTypeEnum), maxFactNumberMaskedTextBoxes[index].AccessibleDescription, true), System.Convert.ToInt16 (additionMaxFactNumberMaskedTextBox.Text));
							maxFactNumberMaskedTextBoxes[index].Tag = maxFactNumberMaskedTextBoxes[index].Text;
						}
					}
				}

				// Check if the password should be updated
				if (!String.IsNullOrEmpty (changePasswordTextBox.Text) 
					&& !String.IsNullOrEmpty (passwordConfirmTextBox.Text))
				{
					if (changePasswordTextBox.Text == passwordConfirmTextBox.Text)
					{
						if (!updatePassword (MathFactsForm.userProfile.user.name))
						{
							MessageBox.Show ("An error occurred and your password could not be updated. Please try again", "Password Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						else
						{
							MessageBox.Show ("Your password was successfully updated!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						// TODO Make this check happen automatically once the confirm box loses focus
						MessageBox.Show ("The passwords you entered do not match.",
						"Passwords Do Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
						changePasswordTextBox.Clear ();
						passwordConfirmTextBox.Clear ();
						changePasswordTextBox.Focus ();
						return;
					}
				}

				if (updateUserProfileData)
				{
					files.updateUserProfile (MathFactsForm.userProfile);
					MessageBox.Show ("Your profile has been successfully updated!",
					"Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.None);
				}
				this.Close ();
			}
			else
			{
				MessageBox.Show ("No changes could be made. Please enter a valid password.",
							"Missing or Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void saveNewProfile ()
		{
			String username = usernameMaskedTextBox.Text;
			UserProfile newUserProfile = new UserProfile (new User ());
			bool fieldProcessed;

			newUserProfile.user.name = processUsernameField (out fieldProcessed);
			if (!fieldProcessed)
			{
				return;
			}

			newUserProfile.hasCustomSpeedFacts = customFactsCheckBox.Checked;

			newUserProfile.maxDaysBetweenSpeedTests = processMaxDaysBetweenSpeedTestField (out fieldProcessed);
			if (!fieldProcessed)
			{
				return;
			}

			newUserProfile.maxFactNumbers = processMaxFactNumberFields (out fieldProcessed, true);
			if (!fieldProcessed)
			{
				return;
			}

			if (passwordTextBox != passwordConfirmTextBox)
			{
				if (!processNewPassword (newUserProfile.user.name))
				{
					return;
				}
			}
			else
			{
				MessageBox.Show ("The passwords you entered do not match.",	"Passwords Do Not Match", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Valid data was entered.
			MathFactsForm.userProfile = newUserProfile;
			files.createNewUserDirectory (newUserProfile);
			files.updateUserProfile (newUserProfile);
			MessageBox.Show ("Your profile has been successfully created!", "Profile Created", MessageBoxButtons.OK, MessageBoxIcon.None);
			this.Close ();
		}

		private String processUsernameField (out bool fieldProcessed)
		{
			String username = usernameMaskedTextBox.Text;
			fieldProcessed = false;

			// Check that a username was entered.
			if (String.IsNullOrEmpty (username))
			{
				MessageBox.Show ("You didn't enter a username to create.\nPlease enter a username before continuing.", "No Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// Ensure the username does not exist.
			else if (files.userDirectoryExists (new User (username)))
			{
				// TODO Need to ensure name conforms to windows naming conventions. 
				MessageBox.Show ("Sorry, that username is already taken.\nPlease try again with a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
				usernameMaskedTextBox.SelectAll ();
			}
			else 
			{
				fieldProcessed = true;
			}

			return username;
		}

		private int processMaxDaysBetweenSpeedTestField (out bool fieldsProcessed)
		{
			int maxDays = 0;
			fieldsProcessed = false;

			if (String.IsNullOrEmpty (speedTestDaysMaskedTextBox.Text))
			{
				MessageBox.Show ("You didn't enter the maximum number of days between speed tests.\nPlease enter a value before continuing.", "No Speed Test Interval", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				maxDays = System.Convert.ToInt16 (speedTestDaysMaskedTextBox.Text);
				fieldsProcessed = true;
			}

			return maxDays;
		}

		// Check that non-negative values were entered for all max fact number fields.
		private int[] processMaxFactNumberFields (out bool fieldsProcessed, bool isNewProfile)
		{
			fieldsProcessed = true;
			int[] maxFactNumbers = { 0,0,0,0 };
			if (isNewProfile && String.IsNullOrEmpty (maxFactNumberMaskedTextBoxes[0].Text) || String.IsNullOrEmpty (maxFactNumberMaskedTextBoxes[1].Text)
				|| String.IsNullOrEmpty (maxFactNumberMaskedTextBoxes[2].Text) || String.IsNullOrEmpty (maxFactNumberMaskedTextBoxes[3].Text))
			{
				MessageBox.Show ("One or more maximum fact numbers were left blank.\nPlease enter a number for all four fields before continuing.", "Missing Maximum Fact Number(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
				fieldsProcessed = false;
			}
			else
			{
				for (int index = 0; index < maxFactNumbers.Count (); ++index)
				{
					if ((maxFactNumbers[index] = Convert.ToInt16 (maxFactNumberMaskedTextBoxes[index].Text)) <= 0)
					{
						MessageBox.Show ("Please enter a number greater than 0.", "Invalid Maximum Fact Number",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						maxFactNumberMaskedTextBoxes[index].SelectAll ();
						fieldsProcessed = false;
					}
				}
			}

			return maxFactNumbers;
		}

		// Add a new entry for the password.
		private bool processNewPassword (String username)
		{
			using (var deriveBytes = new Rfc2898DeriveBytes (passwordConfirmTextBox.Text, 20))
			{
				byte[] salt = deriveBytes.Salt;
				byte[] generatedKey = deriveBytes.GetBytes (20);

				try
				{	
					userDataTableAdapter.Insert (username, salt, generatedKey);

				   return true;
				}
				catch (Exception e)
				{
					// TODO Handle exceptions
					Console.WriteLine (e.StackTrace);
					return false;
				}
			}
		}

		/*
		 * Check if the entered password matches the stored password.
		 */
		private bool validatePassword (string input)
		{
			byte[] key = userDataTableAdapter.GetData ().FindByUsername (MathFactsForm.userProfile.user.name).Key;
			byte[] salt = userDataTableAdapter.GetData ().FindByUsername (MathFactsForm.userProfile.user.name).Salt;

			// Determine if the stored key matches the key generated by the input.
			using (var deriveBytes = new Rfc2898DeriveBytes (input, salt))
			{
				byte[] generatedKey = deriveBytes.GetBytes (20);
				return (generatedKey.SequenceEqual (key));
			}
		}

		private void updateUsernameInFilesAndSettings (String newUsername)
		{
			files.updateUserDirectoryName (newUsername);
			updateUsernameInDatabase (newUsername, MathFactsForm.userProfile.user.name);
			MathFactsForm.userProfile.user.name = newUsername;
			files.updateCurrentUser (newUsername);

			MainMenuControl mainMenuControl = MainMenuControl.Instance;
			mainMenuControl.setUserButtonText ("Welcome " + newUsername + "!" + "\nNot " + newUsername + "?\nClick here to change users");

			usernameMaskedTextBox.Tag = newUsername;
		}

		private void updateUsernameInDatabase (String newUsername, String oldUsername)
		{
			 try
			 {
				 string cmdString = "UPDATE [dbo].[UserData] SET Username = @NewUsername WHERE Username = @OldUsername";
				 using (SqlConnection conn = new SqlConnection (connString))
				 {
					 using (SqlCommand comm = new SqlCommand (cmdString, conn))
					 {
						 comm.Parameters.AddWithValue ("@NewUsername", newUsername);
						 comm.Parameters.AddWithValue ("@OldUsername", oldUsername);

						 try
						 {
							 conn.Open ();
							 comm.ExecuteNonQuery ();
						 }
						 catch (SqlException e)
						 {
							 Console.WriteLine (e.StackTrace);
							 // TODO hande exception
						 }
					 }
				 }
			 }
			 catch (Exception e)
			 {
				 // TODO Handle exceptions
				 Console.WriteLine (e.StackTrace);
			 }
		}

		// TODO test this function
		private bool updatePassword (String username)
		{
			try
			{
				using (var deriveBytes = new Rfc2898DeriveBytes (passwordConfirmTextBox.Text, 20))
				{
					byte[] salt = deriveBytes.Salt;
					byte[] key = deriveBytes.GetBytes (20);

					string cmdString = "UPDATE [dbo].[UserData] SET Salt = @Salt, [Key] = @Key WHERE Username = @Username";
					using (SqlConnection conn = new SqlConnection (connString))
					{
						using (SqlCommand comm = new SqlCommand (cmdString, conn))
						{
							comm.Parameters.AddWithValue ("@Username", username);
							comm.Parameters.AddWithValue ("@Salt", salt);
							comm.Parameters.AddWithValue ("@Key", key);

							try
							{
								conn.Open ();
								comm.ExecuteNonQuery ();
								return true;
							}
							catch (SqlException e)
							{
								Console.WriteLine (e.StackTrace);
								// TODO handle exception
								return false;
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine (e.StackTrace);
				return false;
			}
		}

		private void updateFactFiles (MathOperationTypeEnum operationType, int maxFactNumber)
		{
			MathFactsForm.userProfile.maxFactNumbers[(int) operationType] = maxFactNumber;

			// Delete the files so new facts will be generated the next time daily facts is selected.
			String unknownFactsFile = FactsFiles.getDailyFactsFilename (operationType, false);
			if (System.IO.File.Exists (unknownFactsFile))
			{
				System.IO.File.Delete (unknownFactsFile);
			}

			String knownFactsFile = FactsFiles.getDailyFactsFilename (operationType, true);
			if (System.IO.File.Exists (knownFactsFile))
			{
				System.IO.File.Delete (knownFactsFile);
			}

			// Also clear any existing date data
			String dailyFactsDataFile = FactsFiles.getDailyFactsDataFilename (operationType);
			System.IO.File.Create (dailyFactsDataFile);
		}

		private void saveChanges_Click (object sender, EventArgs e)
		{
			if (saveChangesButton.Text == SAVE_NEW_PROFILE_BUTTON_TEXT)
			{
				saveNewProfile ();
			}
			else
			{
				saveProfileChanges ();
			}
		}
	}
}
