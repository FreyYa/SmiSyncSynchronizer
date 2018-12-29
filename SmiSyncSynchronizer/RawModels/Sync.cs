using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreyYa.SmiSyncSynchronizer.RawModels
{
	/// <summary>
	/// 기본 구조는 <SYNC> <P> Text </P></SYNC>
	/// 문법을 정확히 지키지 않는 자막 제작 툴들이 많기 때문에 별도 처리로 해결해야함
	/// </summary>
	public class Sync
	{
		public Sync(int start,SubLine[] sublines)
		{
			this.Start = start;
			this.Contexts = new List<SubLine>(sublines);
		}
		public int Start { get; set; }
		List<SubLine> Contexts { get; set; }
	}
}
