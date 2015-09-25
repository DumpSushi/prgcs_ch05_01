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
				Text = "This is the new millennium, I promise you."
			};
			Document doc3 = new Document
			{
				Author = "Matthew Adams",
				DocumentDate = new DateTime(2002, 01, 01),
				Text = "Another year, another document."
			};

			string documentBeingProcessed = "（文書未設定）";
			DocumentProcessor processor = Configure();

			ProductionDeptTool1 tool1 = new ProductionDeptTool1();
			tool1.Subscribe(processor);
			ProductionDeptTool2 tool2 = new ProductionDeptTool2();
			tool2.Subscribe(processor);

			int processCount = 0;
			processor.LogTextProvider = (doc =>
				{
					processCount += 1;
					return documentBeingProcessed;
				});

			documentBeingProcessed = "（文書1）";
			processor.Process(doc1);
			Console.WriteLine();
			documentBeingProcessed = "（文書2）";
			processor.Process(doc2);
			Console.WriteLine();
			documentBeingProcessed = "（文書3）";
			processor.Process(doc3);

			Console.WriteLine();
			Console.WriteLine(processCount + "個の処理を実行しました。");


			Console.ReadKey();
		}

		static DocumentProcessor Configure()
		{
			DocumentProcessor rc = new DocumentProcessor();
			rc.AddProcess(DocumentProcesses.TranslateIntoFrench,
				delegate(Document doc)
				{
					return !doc.Text.Contains("?");
				});
			rc.AddProcess(DocumentProcesses.Spellcheck);
			rc.AddProcess(DocumentProcesses.Repaginate);

			TrademarkFilter trademarkFilter = new TrademarkFilter();
			trademarkFilter.Trademarks.Add("O'Reilly");
			trademarkFilter.Trademarks.Add("millennium");

			rc.AddProcess(trademarkFilter.HighlightTradeMarks);

			return rc;
		}
	}
}
