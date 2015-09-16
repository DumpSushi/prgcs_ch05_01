using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	public sealed class Document
	{
		// 取得又は設定可能な文書テキスト。
		public string Text
		{
			get;
			set;
		}

		// 文書の作成日時。
		public DateTime DocumentDate
		{
			get;
			set;
		}

		// 文書の著者。
		public string Author
		{
			get;
			set;
		}
	}
}
