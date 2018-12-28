using FreyYa.SmiSyncSynchronizer.Forms;
using FreyYa.SmiSyncSynchronizer.Models;
using FreyYa.SmiSyncSynchronizer.RawModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreyYa.SmiSyncSynchronizer
{
	static class Program
	{
		public static MainWindow MainWindow { get; private set; }
		public static ProductInfo ProductInfo { get; private set; }
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ProductInfo = new ProductInfo();

			//TODO : 지원 목록을 늘리고 싶은 경우, 이 항목에 꼭 추가해주어야 함
			Subtitles.Types = new Dictionary<string, SubtitlesType>();
			Subtitles.Types.Add(".SMI", SubtitlesType.SMI);
			Subtitles.Types.Add(".SRT", SubtitlesType.SRT);


			MainWindow = new Forms.MainWindow();

			Application.Run(MainWindow);
		}
	}
}
