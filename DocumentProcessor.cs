using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	class DocumentProcessor
	{
		private readonly List<DocumentProcess> processes =
			new List<DocumentProcess>();

		public List<DocumentProcess> Processes
		{
			get
			{
				return processes;
			}
		}

		public void Process(Document doc)
		{
			foreach (DocumentProcess process in Processes)
			{
				process.Process(doc);
			}
		}
	}
}
