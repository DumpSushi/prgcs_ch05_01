using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class TrademarkFilter
	{
		readonly List<string> trademarks = new List<string>();

		public List<string> Trademarks
		{
			get
			{
				return trademarks;
			}
		}

		public void HighlightTradeMarks(Document doc)
		{
			// 英語の文書を個々の単語に分割します。
			string[] words = doc.Text.Split(' ', '.', ',');
			foreach (string word in words)
			{
				if (Trademarks.Contains(word))
				{
					Console.WriteLine("'{0}'をハイライトします。", word);
				}
			}
		}
	}
}
