using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class Program
	{
		static void Main(string[] args)
		{
			Document doc1 = new Document
			{
				Author = "Matthew Adams",
				DocumentDate = new DateTime(2000, 01, 01),
				Text = "Am I a year early?"
			};
			Document doc2 = new Document
			{
				Author = "Ian Griffiths",
				DocumentDate = new DateTime(2001, 01, 01),
				Text = "This is the new millenium, I promise you."
			};

			Console.WriteLine("文書1を処理しています。");
			DocumentProcessor.Process(doc1);
			Console.WriteLine();
			Console.WriteLine("文書2を処理しています。");
			DocumentProcessor.Process(doc2);
			Console.ReadKey();
		}
	}
}
