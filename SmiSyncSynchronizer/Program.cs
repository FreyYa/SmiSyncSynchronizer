using SmiSyncSynchronizer.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmiSyncSynchronizer
{
	static class Program
	{
		public static MainWindow MainWindow { get; private set; }
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainWindow = new Forms.MainWindow();

			Application.Run(MainWindow);
		}
	}
}
