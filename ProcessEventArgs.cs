using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class ProcessEventArgs : EventArgs
	{
		public ProcessEventArgs(Document document)
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
