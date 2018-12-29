namespace FreyYa.SmiSyncSynchronizer.Forms
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView_fileList = new System.Windows.Forms.ListView();
			this.Column_FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Column_DirPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Column_FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_OpenFile = new System.Windows.Forms.Button();
			this.btn_removeFile = new System.Windows.Forms.Button();
			this.btn_ENGTest = new System.Windows.Forms.Button();
			this.btn_Convert = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView_fileList
			// 
			this.listView_fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_FileName,
            this.Column_DirPath,
            this.Column_FileType});
			this.listView_fileList.FullRowSelect = true;
			this.listView_fileList.GridLines = true;
			this.listView_fileList.Location = new System.Drawing.Point(12, 12);
			this.listView_fileList.Name = "listView_fileList";
			this.listView_fileList.Size = new System.Drawing.Size(994, 317);
			this.listView_fileList.TabIndex = 0;
			this.listView_fileList.UseCompatibleStateImageBehavior = false;
			this.listView_fileList.View = System.Windows.Forms.View.Details;
			this.listView_fileList.SelectedIndexChanged += new System.EventHandler(this.listView_fileList_SelectedIndexChanged);
			// 
			// Column_FileName
			// 
			this.Column_FileName.Text = "File Name";
			this.Column_FileName.Width = 300;
			// 
			// Column_DirPath
			// 
			this.Column_DirPath.Text = "File Path";
			this.Column_DirPath.Width = 550;
			// 
			// Column_FileType
			// 
			this.Column_FileType.Text = "Sub Type";
			this.Column_FileType.Width = 100;
			// 
			// btn_OpenFile
			// 
			this.btn_OpenFile.Location = new System.Drawing.Point(776, 335);
			this.btn_OpenFile.Name = "btn_OpenFile";
			this.btn_OpenFile.Size = new System.Drawing.Size(112, 23);
			this.btn_OpenFile.TabIndex = 1;
			this.btn_OpenFile.Text = "button1";
			this.btn_OpenFile.UseVisualStyleBackColor = true;
			this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
			// 
			// btn_removeFile
			// 
			this.btn_removeFile.Location = new System.Drawing.Point(894, 335);
			this.btn_removeFile.Name = "btn_removeFile";
			this.btn_removeFile.Size = new System.Drawing.Size(112, 23);
			this.btn_removeFile.TabIndex = 2;
			this.btn_removeFile.Text = "button1";
			this.btn_removeFile.UseVisualStyleBackColor = true;
			this.btn_removeFile.Click += new System.EventHandler(this.btn_removeFile_Click);
			// 
			// btn_ENGTest
			// 
			this.btn_ENGTest.Location = new System.Drawing.Point(658, 335);
			this.btn_ENGTest.Name = "btn_ENGTest";
			this.btn_ENGTest.Size = new System.Drawing.Size(112, 23);
			this.btn_ENGTest.TabIndex = 3;
			this.btn_ENGTest.Text = "TEST";
			this.btn_ENGTest.UseVisualStyleBackColor = true;
			this.btn_ENGTest.Click += new System.EventHandler(this.btn_ENGTest_Click);
			// 
			// btn_Convert
			// 
			this.btn_Convert.Location = new System.Drawing.Point(12, 382);
			this.btn_Convert.Name = "btn_Convert";
			this.btn_Convert.Size = new System.Drawing.Size(118, 40);
			this.btn_Convert.TabIndex = 4;
			this.btn_Convert.Text = "btn_convert";
			this.btn_Convert.UseVisualStyleBackColor = true;
			this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1018, 434);
			this.Controls.Add(this.btn_Convert);
			this.Controls.Add(this.btn_ENGTest);
			this.Controls.Add(this.btn_removeFile);
			this.Controls.Add(this.btn_OpenFile);
			this.Controls.Add(this.listView_fileList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "MainWindow";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView_fileList;
		private System.Windows.Forms.Button btn_OpenFile;
		private System.Windows.Forms.ColumnHeader Column_FileName;
		private System.Windows.Forms.ColumnHeader Column_DirPath;
		private System.Windows.Forms.ColumnHeader Column_FileType;
		private System.Windows.Forms.Button btn_removeFile;
		private System.Windows.Forms.Button btn_ENGTest;
		private System.Windows.Forms.Button btn_Convert;
	}
}