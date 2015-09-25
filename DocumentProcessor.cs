using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class DocumentProcessor
	{
		public event EventHandler<ProcessEventArgs> Processing;
		public event EventHandler<ProcessEventArgs> Processed;

		public Func<Document, string> LogTextProvider
		{
			get;
			set;
		}

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
			ProcessEventArgs e = new ProcessEventArgs(doc);
			OnProcessing(e);

			foreach (ActionCheckPair process in processes)
			{
				if (process.QuickCheck != null && !process.QuickCheck(doc))
				{
					Console.WriteLine("処理は成功しないでしょう。");
					if (LogTextProvider != null)
					{
						Console.WriteLine(LogTextProvider(doc));
					}
					OnProcessed(e);
					return;
				}
			}
			foreach (ActionCheckPair process in processes)
			{
				process.Action(doc);
				if (LogTextProvider != null)
				{
					Console.WriteLine(LogTextProvider(doc));
				}
			}
			OnProcessed(e);
		}

		private void OnProcessing(ProcessEventArgs e)
		{
			if (Processing != null)
			{
				Processing(this, e);
			}
		}

		private void OnProcessed(ProcessEventArgs e)
		{
			if (Processed != null)
			{
				Processed(this, e);
			}
		}
	}
}
