using FreyYa.SmiSyncSynchronizer.Models;
using FreyYa.SmiSyncSynchronizer.RawModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreyYa.SmiSyncSynchronizer.Forms
{
	public partial class MainWindow : Form
	{
		public Dictionary<string, SAMI> SAMI_SubList { get; private set; }
		public Dictionary<string, SRT> SRT_SubList { get; private set; }
		public Dictionary<string, Subtitles> SubList { get; private set; }

		public MainWindow()
		{
			InitializeComponent();

			#region Initialize

			SubList = new Dictionary<string, Subtitles>();
			SAMI_SubList = new Dictionary<string, SAMI>();
			SRT_SubList = new Dictionary<string, SRT>();

			this.Icon = Properties.Resources.Icon_App;
			this.Text = Program.ProductInfo.Description;

			#endregion

			#region Globalization

			this.btn_OpenFile.Text = Properties.Resources.Button_FileOpen;
			this.btn_removeFile.Text = Properties.Resources.Button_FileRemove;
			this.btn_Convert.Text = Properties.Resources.Button_DoConvert;

			this.Column_FileName.Text = Properties.Resources.Column_FileName;
			this.Column_DirPath.Text = Properties.Resources.Column_DirPath;
			this.Column_FileType.Text = Properties.Resources.Column_FileType;

			#endregion

			#region DEBUG

#if DEBUG
			this.btn_ENGTest.Visible = true;
#else
			this.btn_ENGTest.Visible = false;
#endif

			#endregion
		}

		private void btn_OpenFile_Click(object sender, EventArgs e)
		{
			StringBuilder filter = new StringBuilder();
			int count = 0;
			foreach (var item in Subtitles.Types)
			{
				filter.Append(item.Key);
				filter.Append(" Files (*");
				filter.Append(item.Key.ToLower());
				filter.Append(")|*");
				filter.Append(item.Key.ToLower());
				count++;
				if (count != Subtitles.Types.Count)
					filter.Append("|");
			}


			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = Properties.Resources.Title_OpenFile;
			dlg.Filter = filter.ToString();
			dlg.Multiselect = true;

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				//TODO : List에 파일을 추가
				foreach (var file in dlg.FileNames)
				{
					var target = new Subtitles(file);

					switch (target.Type)
					{
						case SubtitlesType.SMI:
							if (!SubList.ContainsKey(target.FullPath))
							{
								SAMI_SubList.Add(target.FullPath, new SAMI(target.FullPath));
								this.listView_fileList.Items.Add(new ListViewItem(target.ToArray()));
							}
							break;
						//case SubtitlesType.SRT:
						//	if (!SubList.ContainsKey(target.FullPath))
						//	{
						//		SRT_SubList.Add(target.FullPath, (SRT)target);
						//		this.listView_fileList.Items.Add(new ListViewItem(target.ToArray()));
						//	}
						//	break;
						default:
						case SubtitlesType.Etc:
							if (!SubList.ContainsKey(target.FullPath))
							{
								SubList.Add(target.FullPath, target);
								this.listView_fileList.Items.Add(new ListViewItem(target.ToArray()));
							}
							break;
					}
				}
			}
		}

		private void btn_removeFile_Click(object sender, EventArgs e)
		{
			if (listView_fileList.SelectedItems.Count > 0)
			{
				foreach (ListViewItem item in listView_fileList.SelectedItems)
				{
					Debug.WriteLine(item);
					listView_fileList.Items.Remove(item);
					if (this.SubList.ContainsKey(Path.Combine(item.SubItems[1].Text, item.SubItems[0].Text)))
						this.SubList.Remove(Path.Combine(item.SubItems[1].Text, item.SubItems[0].Text));
				}
			}
		}

		private void listView_fileList_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btn_ENGTest_Click(object sender, EventArgs e)
		{

		}

		private void btn_Convert_Click(object sender, EventArgs e)
		{

		}
	}
}
