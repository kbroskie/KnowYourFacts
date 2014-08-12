using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowYourFacts.UI
{
	public partial class FactsReviewControl : UserControl
	{
		public List<int> incorrectResponses
		{
			set;
			get;
		}

		public List<Math.Fact> incorrectQuestions
		{
			set;
			get;
		}

		private Int16 currentQuestionIndex = 0;

		public FactsReviewControl ()
		{
			InitializeComponent ();
			incorrectQuestions = new List<Math.Fact> ();
			incorrectResponses = new List<int> ();
		}

		public void displayFirstFact ()
		{
			displayNextQuestion ();
			previousButton.Enabled = false;
		}

		private void toggleNextAndPreviousButtons ()
		{			
			if (currentQuestionIndex == incorrectQuestions.Count - 1)
			{
				nextButton.Enabled = false;
			}
			else
			{
				nextButton.Enabled = true;
			}
			if (currentQuestionIndex == 0)
			{
				previousButton.Enabled = false;
			}
			else
			{
				previousButton.Enabled = true;
			}
		}

		private void displayNextQuestion ()
		{
			if (currentQuestionIndex != incorrectQuestions.Count)
			{
				questionContentLabel.Text = incorrectQuestions[currentQuestionIndex].ToString ();
				correctAnswerContentLabel.Text = Math.MathOperation.calculateAnswer (incorrectQuestions[currentQuestionIndex].leftNum, incorrectQuestions[currentQuestionIndex].rightNum, incorrectQuestions[currentQuestionIndex].operation).ToString ();
				answerContentLabel.Text = incorrectResponses[currentQuestionIndex].ToString ();
			}
		}

		private void displayPreviousQuestion ()
		{
			if (currentQuestionIndex != 0)
			{
				questionContentLabel.Text = incorrectQuestions[--currentQuestionIndex].ToString ();
				correctAnswerContentLabel.Text = Math.MathOperation.calculateAnswer (incorrectQuestions[currentQuestionIndex].leftNum, incorrectQuestions[currentQuestionIndex].rightNum, incorrectQuestions[currentQuestionIndex].operation).ToString ();
				answerContentLabel.Text = incorrectResponses[currentQuestionIndex].ToString ();
			}
		}

		private void nextButton_Click (object sender, EventArgs e)
		{
			++currentQuestionIndex;
			displayNextQuestion ();
			toggleNextAndPreviousButtons ();
		}

		private void previousButton_Click (object sender, EventArgs e)
		{
			displayPreviousQuestion ();
			toggleNextAndPreviousButtons ();
		}

		private void mainMenuButton_Click (object sender, EventArgs e)
		{
			(this.Parent as MathFactsForm).logUserInput ("return to main menu");
		}
	}
}
