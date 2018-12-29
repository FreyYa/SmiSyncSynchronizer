using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreyYa.SmiSyncSynchronizer.RawModels
{
	public class Subtitles
	{
		/// <summary>
		/// 지원하는 자막파일 종류
		/// </summary>
		public static Dictionary<string, SubtitlesType> Types { get; set; }

		/// <summary>
		/// 자막 파일 전체 경로
		/// </summary>
		public string FullPath { get; private set; }

		/// <summary>
		/// 파일명
		/// </summary>
		public string FileName
		{
			get { return Path.GetFileName(this.FullPath); }
		}
		/// <summary>
		/// 파일명(확장자 포함)
		/// </summary>
		public string FileNameWithoutExtension
		{
			get { return Path.GetFileNameWithoutExtension(this.FullPath); }
		}
		/// <summary>
		/// 자막파일이 있는 폴더 경로
		/// </summary>
		public string DirPath
		{
			get { return Path.GetDirectoryName(this.FullPath); }
		}
		/// <summary>
		/// 자막 파일 종류
		/// </summary>
		public SubtitlesType Type { get; private set; }

		public bool IsAvailable { get; private set; }

		public Subtitles(string fullPath)
		{
			this.FullPath = fullPath;
			Debug.WriteLine(Path.GetExtension(this.FullPath).ToUpper());
			if (Subtitles.Types.ContainsKey(Path.GetExtension(this.FullPath).ToUpper()))
				this.Type = Subtitles.Types[Path.GetExtension(this.FullPath).ToUpper()];
			else
				this.Type = SubtitlesType.Etc;
		}
		/// <summary>
		/// 파일 정보를 Array정보로 출력. FileName, DirPath, Type 순
		/// </summary>
		/// <returns></returns>
		public string[] ToArray()
		{
			return new string[] { this.FileName, this.DirPath, this.Type.ToString() };
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
	public enum SubtitlesType
	{
		Etc = -1,
		SMI,
		SRT,
	}
}
