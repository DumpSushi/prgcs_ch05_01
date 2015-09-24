using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class DocumentProcessor
	{
		class ActionCheckPair
		{
			public Action<Document> Action { get; set; }
			public Predicate<Document> QuickCheck { get; set; }
		}
		private readonly List<ActionCheckPair> processes =
			new List<ActionCheckPair>();

		public void AddProcess(Action<Document> action)
		{
			AddProcess(action, null);
		}

		public void AddProcess(Action<Document> action, Predicate<Document> quickCheck)
		{
			processes.Add(
				new ActionCheckPair { Action = action, QuickCheck = quickCheck });
		}

		public void Process(Document doc)
		{
			foreach (ActionCheckPair process in processes)
			{
				if (process.QuickCheck != null && !process.QuickCheck(doc))
				{
					Console.WriteLine("処理は成功しないでしょう。");
					return;
				}
			}
			foreach (ActionCheckPair process in processes)
			{
				process.Action(doc);
			}
		}
	}
}
