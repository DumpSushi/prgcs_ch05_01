﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class DocumentProcessor
	{
		private Dictionary<string, Delegate> events;

		public event EventHandler<ProcessCancelEventArgs> Processing
		{
			add
			{
				Delegate theDelegate =
					EnsureEvent("Processing");
				events["Processing"] =
					((EventHandler<ProcessCancelEventArgs>)
						theDelegate) + value;
			}
			remove
			{
				Delegate theDelegate =
					EnsureEvent("Processing");
				events["Processing"] =
					((EventHandler<ProcessCancelEventArgs>)
						theDelegate) - value;
			}
		}

		public event EventHandler<ProcessEventArgs> Processed
		{
			add
			{
				Delegate theDelegate =
					EnsureEvent("Processed");
				events["Processed"] =
					((EventHandler<ProcessEventArgs>)
						theDelegate) + value;
			}
			remove
			{
				Delegate theDelegate =
					EnsureEvent("Processed");
				events["Processed"] =
					((EventHandler<ProcessEventArgs>)
						theDelegate) - value;
			}
		}

		private Delegate EnsureEvent(string eventName)
		{
			if (events == null)
			{
				events = new Dictionary<string,Delegate>();
			}

			Delegate theDelegate = null;
			if (!events.TryGetValue(eventName, out theDelegate))
			{
				events.Add(eventName, null);
			}

			return theDelegate;
		}

		private void OnProcessing(ProcessCancelEventArgs e)
		{
			Delegate eh = null;
			if(events != null &&
				events.TryGetValue("Processing", out eh))
			{
				EventHandler<ProcessCancelEventArgs> pceh =
					eh as EventHandler<ProcessCancelEventArgs>;
				if (pceh != null)
				{
					pceh(this, e);
				}
			}
		}

		private void OnProcessed(ProcessEventArgs e)
		{
			Delegate eh = null;
			if (events != null &&
				events.TryGetValue("Processed", out eh))
			{
				EventHandler<ProcessEventArgs> pceh =
					eh as EventHandler<ProcessEventArgs>;
				if (pceh != null)
				{
					pceh(this, e);
				}
			}
		}

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
			ProcessCancelEventArgs ce = new ProcessCancelEventArgs(doc);
			OnProcessing(ce);
			if (ce.Cancel)
			{
				Console.WriteLine("処理はキャンセルされました。");
				if (LogTextProvider != null)
				{
					Console.WriteLine(LogTextProvider(doc));
				}
				return;
			}

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
	}
}
