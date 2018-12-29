using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreyYa.SmiSyncSynchronizer.RawModels
{
	public class SAMI : Subtitles
	{
		public SAMI(string fullPath) : base(fullPath)
		{
			var text = File.ReadAllText(fullPath).Replace("\r", "").Replace("\n", "");

			int start_body_idx = text.ToUpper().IndexOf("<BODY>") + 6;
			int end_body_idx = text.ToUpper().IndexOf("</BODY>");

			var in_body = text.Substring(start_body_idx, end_body_idx - start_body_idx);

			Syncs = new List<Sync>();

			while (in_body.Length != 0)
			{
				int start_sync_idx = in_body.ToUpper().IndexOf("<SYNC");
				int end_sync_idx = in_body.ToUpper().IndexOf("<SYNC", start_sync_idx + 5);
				if (end_sync_idx == -1)
					end_sync_idx = in_body.Length;

				var raw_data = in_body.Substring(start_sync_idx, end_sync_idx);
				in_body = in_body.Replace(raw_data, "").Replace("</SYNC>", "").Replace("</Sync>", "").Replace("</sync>", "");
				Debug.WriteLine(string.Format("raw_data : {0}", raw_data));

				int timestamp_start_idx = raw_data.ToUpper().IndexOf("START") + 5;
				int timestamp_end_idx = raw_data.IndexOf('>');
				var strTimestamp = raw_data.Substring(timestamp_start_idx, timestamp_end_idx - timestamp_start_idx).Replace("=", "").Trim();

				int timeStamp = Convert.ToInt32(strTimestamp);
				raw_data = raw_data.Substring(timestamp_end_idx + 1, raw_data.Length - timestamp_end_idx - 1);
				List<SubLine> Sublines = new List<SubLine>();
				while (raw_data.Length != 0)
				{
					int p_start_idx = raw_data.ToUpper().IndexOf("<P");
					int p_end_idx = raw_data.ToUpper().IndexOf("<P", p_start_idx + 2);
					if (p_end_idx == -1)
						p_end_idx = raw_data.Length - p_start_idx;

					var raw_p_data = raw_data.Substring(p_start_idx, p_end_idx);
					Debug.WriteLine(string.Format("raw_p_data : {0}", raw_p_data));
					raw_data = raw_data.Replace(raw_p_data, "").Replace("</P>", "").Replace("</p>", "");


					int p_close_idx = raw_p_data.IndexOf(">") + 1;
					var context = raw_p_data.Substring(p_close_idx, raw_p_data.Length - p_close_idx);
					Debug.WriteLine(string.Format("context : {0}", context));
					raw_p_data = raw_p_data.Replace(context, "").Replace("<P", "").Trim().Replace("<p", "").Trim().Replace(">", "").Trim();
					Debug.WriteLine(string.Format("raw_p_data : {0}", raw_p_data));

					int p_class_start_idx = raw_p_data.ToUpper().IndexOf("CLASS");
					int p_id_start_idx = raw_p_data.ToUpper().IndexOf("ID");

					int find_class_idx = -1;
					int find_id_idx = -1;
					Language lang = Language.Korean;
					if (p_class_start_idx != -1)
					{
						find_class_idx = raw_p_data.IndexOf("=", p_class_start_idx) + 1;

						var raw_class = raw_p_data.Substring(find_class_idx).Trim();
						int end_class_idx = raw_class.IndexOf(" ");

						if (end_class_idx == -1)
							end_class_idx = raw_class.Length;

						find_class_idx = raw_class.IndexOf("=") + 1;

						raw_class = raw_class.Substring(find_class_idx, end_class_idx).Trim().ToUpper();

						switch (raw_class)
						{
							case "KRCC":
								lang = Language.Korean;
								break;
							case "ENCC":
								lang = Language.English;
								break;
						}

					}
					if (p_id_start_idx != -1)
					{
						find_id_idx = raw_p_data.IndexOf("=", p_id_start_idx + 1);

						var raw_id = raw_p_data.Substring(find_class_idx).Trim();
						int end_class_idx = raw_id.IndexOf(" ");

						if (end_class_idx == -1)
							end_class_idx = raw_id.Length;

						find_class_idx = raw_id.IndexOf("=") + 1;

						raw_id = raw_id.Substring(find_class_idx, end_class_idx).Trim();

						SubLine target_item = new SubLine(lang, raw_id, context);
						Sublines.Add(target_item);

						continue;
					}

					SubLine item = new SubLine(lang, context);
					Sublines.Add(item);
				}
				Sync sync_data = new Sync(timeStamp, Sublines.ToArray());
				Syncs.Add(sync_data);
			}
		}

		public List<Sync> Syncs { get; set; }
	}
}
