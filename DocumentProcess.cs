using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	delegate void DocumentProcess(Document doc);
	/*
	abstract class DocumentProcess
	{
		public abstract void Process(Document doc);
	}

	class SpellcheckProcess : DocumentProcess
	{
		public override void Process(Document doc)
		{
			DocumentProcesses.Spellcheck(doc);
		}
	}

	class RepaginateProcess : DocumentProcess
	{
		public override void Process(Document doc)
		{
			DocumentProcesses.Repaginate(doc);
		}
	}

	class TranslateInfoFrenchProcess : DocumentProcess
	{
		public override void Process(Document doc)
		{
			DocumentProcesses.TranslateIntoFrench(doc);
		}
	}
	 */
}
