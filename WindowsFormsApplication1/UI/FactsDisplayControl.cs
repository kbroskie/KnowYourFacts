using System;
using System.Windows.Forms;

namespace KnowYourFacts.UI
{
	public partial class FactsDisplayControl : UserControl
	{
		static FactsDisplayControl instanceFactsDisplayControl;
		public static FactsDisplayControl Instance
		{
			get
			{
				if (instanceFactsDisplayControl == null)
				{
					instanceFactsDisplayControl = new FactsDisplayControl ();
				}
				return instanceFactsDisplayControl;
			}
		}

		private FactsDisplayControl ()
		{
			InitializeComponent ();
		}

		private void maskedTextBoxKeyUpEvent (object sender, KeyEventArgs e)
		{
			//this.InputDetected += c_InputDetected;

			//MathFactsForm.processInput(this, e);
			triggerInputEvent (e);
		}

		private void messageLabel_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				messageLabel.Text = "";
				(this.Parent as MathFactsForm).logUserInput ("space");
			}
		}

		public void triggerInputEvent (KeyEventArgs keyEvent)
		{
			if (keyEvent.KeyCode == Keys.Return)
			{
				// Check if no answer was entered.
				if (inputMaskedTextBox.Text == "")
				{
					messageLabel.Text = "Oops! You forgot to enter an answer!";
				}
				else
				{
					InputDetectedEventArgs args = new InputDetectedEventArgs ();
					args.input = inputMaskedTextBox.Text;
					//args.TimeReached = DateTime.Now;
					OnInputDetected (args);
				}
			}

			// The event was triggered by input being entered. Clear the status area of messages.
			else
			{
				messageLabel.Text = "";
			}
		}

		protected virtual void OnInputDetected (InputDetectedEventArgs e)
		{
			EventHandler<InputDetectedEventArgs> handler = InputDetected;
			if (handler != null)
			{
				handler (this, e);
			}
		}

		public event EventHandler<InputDetectedEventArgs> InputDetected;

		private void inputMaskedTextBox_KeyPress (object sender, KeyPressEventArgs e)
		{
			// Suppress the sound generated when the user presses enter.
			if (e.KeyChar == (char) Keys.Enter)
			{
				e.Handled = true;
			}
		}
	}

	public class InputDetectedEventArgs : EventArgs
	{
		public string input { get; set; }
	}
}
