using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class ProcessCancelEventArgs : CancelEventArgs
	{
		public ProcessCancelEventArgs(Document document)
		{
			Document = document;
		}

		public Document Document
		{
			get;
			private set;
		}
	}
}
