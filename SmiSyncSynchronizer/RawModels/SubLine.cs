using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreyYa.SmiSyncSynchronizer.RawModels
{
	public class SubLine
	{
		public Language Language { get; set; }
		public string Text { get; set; }
		public string Target { get; set; }

		public SubLine(Language lang, string text)
		{
			this.Language = lang;
			this.Text = text;
		}
		public SubLine(Language lang, string target, string text)
		{
			this.Language = lang;
			this.Text = text;
			this.Target = target;
		}
	}

	public enum Language
	{
		Korean,
		English,
	}
}
