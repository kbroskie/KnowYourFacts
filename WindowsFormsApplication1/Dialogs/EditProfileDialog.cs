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
		
		public EditProfileDialog ()
		{
			InitializeComponent ();
			loadUserProfileData ();
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

			MathOperation operation = new MathOperation ((MathOperationTypeEnum) Enum.Parse (typeof (MathOperationTypeEnum), speedTestComboBox.Text.ToUpper ()));

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

		public void saveChanges ()
		{
			bool updateUserProfile = false;

			if (!String.IsNullOrEmpty(passwordTextBox.Text) && validatePassword (passwordTextBox.Text))
			{
				// Update the username
				if (!usernameMaskedTextBox.Text.Equals (usernameMaskedTextBox.Tag))
				{
					User newUser = new User (usernameMaskedTextBox.Text);
					if (files.userDirectoryExists (newUser))
					{
						MessageBox.Show ("Sorry, that username is already taken.\nPlease try again with a different username.",
								"Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
						usernameMaskedTextBox.Text = MathFactsForm.userProfile.user.name;
					}
					else
					{
						updateUsernameInFilesAndSettings (newUser.name);
					}
				}

				// Update usage of custom speed facts.
				if (!customFactsCheckBox.Checked.ToString ().Equals (customFactsCheckBox.Tag))
				{
					updateUseOfCustomFacts ();
					customFactsCheckBox.Tag = customFactsCheckBox.Checked.ToString ();
				}

				// Update the duration between speed tests
				if (!speedTestDaysMaskedTextBox.Text.Equals (speedTestDaysMaskedTextBox.Tag))
				{
					MathFactsForm.userProfile.maxDaysBetweenSpeedTests 
						= System.Convert.ToInt16 (speedTestDaysMaskedTextBox.Text);
					speedTestDaysMaskedTextBox.Tag = speedTestDaysMaskedTextBox.Text;
					updateUserProfile = true;
				}

				// Update max fact numbers
				if (!additionMaxFactNumberMaskedTextBox.Text.Equals (additionMaxFactNumberMaskedTextBox.Tag))
				{
					updateFactFiles (MathOperationTypeEnum.ADDITION, System.Convert.ToInt16 (additionMaxFactNumberMaskedTextBox.Text));
					updateUserProfile = true;
					additionMaxFactNumberMaskedTextBox.Tag = additionMaxFactNumberMaskedTextBox.Text;
				}
				if (!subtractionMaxFactNumberMaskedTextBox.Text.Equals (subtractionMaxFactNumberMaskedTextBox.Tag))
				{
					updateFactFiles(MathOperationTypeEnum.SUBTRACTION, System.Convert.ToInt16 (subtractionMaxFactNumberMaskedTextBox.Text));
					updateUserProfile = true;
					subtractionMaxFactNumberMaskedTextBox.Tag = subtractionMaxFactNumberMaskedTextBox.Text;
				}
				if (!multiplicationMaxFactNumberMaskedTextBox.Text.Equals (multiplicationMaxFactNumberMaskedTextBox.Tag))
				{
					updateFactFiles (MathOperationTypeEnum.MULTIPLICATION, System.Convert.ToInt16 (multiplicationMaxFactNumberMaskedTextBox.Text));
					updateUserProfile = true;
					multiplicationMaxFactNumberMaskedTextBox.Tag = multiplicationMaxFactNumberMaskedTextBox.Text;
				}
				if (!divisionMaxFactNumberMaskedTextBox.Text.Equals (divisionMaxFactNumberMaskedTextBox.Tag))
				{
					updateFactFiles (MathOperationTypeEnum.DIVISION, System.Convert.ToInt16 (divisionMaxFactNumberMaskedTextBox.Text));
					updateUserProfile = true;
					divisionMaxFactNumberMaskedTextBox.Tag = divisionMaxFactNumberMaskedTextBox.Text;
				}

				if (updateUserProfile)
				{
					files.updateUserProfile (MathFactsForm.userProfile);
				}

				// Check if the password should be updated
				if (!String.IsNullOrEmpty (changePasswordTextBox.Text) 
					&& !String.IsNullOrEmpty (passwordConfirmTextBox.Text))
				{
					if (changePasswordTextBox.Text == passwordConfirmTextBox.Text)
					{
						savePassword (changePasswordTextBox.Text);
					}
					else
					{
						// TODO Make this check happen automatically once the confirm box loses focus
						MessageBox.Show ("The passwords you entered do not match.",
						"Password Do Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
						passwordTextBox.Clear ();
						passwordConfirmTextBox.Clear ();
						passwordTextBox.Focus ();
					}
				}
			}
			else
			{
				MessageBox.Show ("No changes could be made. Please enter a valid password.",
							"Missing or Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/*
		 * Check if the entered password matches the stored password.
		 */
		public bool validatePassword (string input)
		{
			byte[] salt = null;
			byte[] key = null;

			string cmdString = "SELECT [Salt],[Key] FROM [dbo].[UserData] WHERE (Username = @Username)";

			using (SqlConnection conn = new SqlConnection (connString))
			{
				using (SqlCommand command = new SqlCommand (cmdString, conn))
				{
					command.Parameters.AddWithValue ("@Username", MathFactsForm.userProfile.user.name);

					conn.Open ();
					SqlDataReader reader = command.ExecuteReader ();
					if (reader.Read ())
					{
						salt = (byte[]) reader["Salt"];
						key = (byte[]) reader["Key"];
					}
				}
			}

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
			files.updateUserProfile (MathFactsForm.userProfile);
			files.updateCurrentUser (newUsername);

			MainMenuControl mainMenuControl = MainMenuControl.Instance;
			mainMenuControl.setUserButtonText ("Welcome " + newUsername + "!" + "\nNot " + newUsername + "?\nClick here to change users");

			usernameMaskedTextBox.Tag = newUsername;
		}

		private void updateUsernameInDatabase (String newUsername, String oldUsername)
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
						// TODO Handle exceptions
						Console.WriteLine (e.ToString ());
					}
				}
			}
		}

		private void updateUseOfCustomFacts ()
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

		// Add a new entry for the password.
		private void savePassword (String password)
		{
			using (var deriveBytes = new Rfc2898DeriveBytes (password, 20))
			{
				byte[] salt = deriveBytes.Salt;
				byte[] generatedKey = deriveBytes.GetBytes (20);
				string username = MathFactsForm.userProfile.user.name;

				string cmdString = "INSERT INTO [dbo].[UserData] ([Username], [Salt], [Key]) VALUES (@Username, @Salt, @Key)";
			
				using (SqlConnection conn = new SqlConnection (connString))
				{
					using (SqlCommand comm = new SqlCommand (cmdString, conn))
					{
						comm.Parameters.AddWithValue ("@Username", username);
						comm.Parameters.AddWithValue ("@Salt", salt);
						comm.Parameters.AddWithValue ("@Key", generatedKey);

						try
						{
							conn.Open ();
							comm.ExecuteNonQuery ();
						}
						catch (SqlException e)
						{
							// TODO Handle exceptions
							Console.WriteLine (e.ToString ());
						}
					}
				}
			}
		}
	}
}
