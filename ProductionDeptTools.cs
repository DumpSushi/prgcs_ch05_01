using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class ProductionDeptTool1
	{
		public void Subscribe(DocumentProcessor processor)
		{
			processor.Processing += processor_Processing;
			processor.Processed += processor_Processed;
		}

		public void Unsubscribe(DocumentProcessor processor)
		{
			processor.Processing -= processor_Processing;
			processor.Processed -= processor_Processed;
		}

		private void processor_Processing(object sender, ProcessCancelEventArgs e)
		{
			Console.WriteLine("ツール1が処理の開始を確認しました。処理を続行します。");
		}

		void processor_Processed(object sender, EventArgs e)
		{
			Console.WriteLine("ツール1が処理の終了を確認しました。");
		}
	}

	class ProductionDeptTool2
	{
		public void Subscribe(DocumentProcessor processor)
		{
			processor.Processing +=
				(sender, e) =>
				{
					if (e.Document.Text.Contains("document"))
					{
						Console.WriteLine("ツール2が処理の開始を確認しました。処理をキャンセルします。");
						e.Cancel = true;
					}
					else
					{
						Console.WriteLine("ツール2が処理の開始を確認しました。処理を続行します。");
					}
				};
			processor.Processed +=
				(sender, e) =>
					Console.WriteLine("ツール2が処理の終了を確認しました。");
		}
	}
}
