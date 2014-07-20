using System;

namespace KnowYourFacts
{
	public interface IView
	{
		void FactsModelChange (object sender, FactsModelChangeEventArgs e);
	}
}