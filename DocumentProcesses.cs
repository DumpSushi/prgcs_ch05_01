using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch05_01
{
	static class DocumentProcesses
	{
		public static void Spellcheck(Document doc)
		{
			Console.WriteLine("文書のスペルチェックを実行しました。");
		}

		public static void Repaginate(Document doc)
		{
			Console.WriteLine("文書のページ番号を振り直しました。");
		}

		public static void TranslateIntoFrench(Document doc)
		{
			Console.WriteLine("文書を日本語に翻訳しました。");
		}
	}
}
