using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.Misc;
using System.IO;
using System.Threading;
using TagLib;
using LastFmLib.Scrobbler;
using LastFmLib.TypeClasses;
using LastFmLib;
using Infragistics.Win.AppStyling;
using CueSharp;
using C5;

namespace CraftyScrobbler
{
	public partial class CraftyScrobbler : Form
	{
		#region Own Variables

		long timeStarted;

		TextBox info = new TextBox();

		TextBox login = new TextBox();
		TextBox password = new TextBox();
		Label loginL = new Label();
		Label passL = new Label();

		UltraButton confirm = new UltraButton();

		Label ok = new Label();

		TableLayoutPanel panel = new TableLayoutPanel();

		//dropdown subbuttons
		UltraButton scrobbleDate = new UltraButton();
		UltraButton scrobbleConfig = new UltraButton();
		TableLayoutPanel dropdownPanelScrobble = new TableLayoutPanel();
		UltraButton removeAll = new UltraButton();

		//last.fm utilities
		private LastFmClient client;
		private ScrobblerManager sm; 

		string userLogin = "";
		string userPassword = "";

		bool scrobblerInit = false;

		//additional controls
		//ContextMenu addMenu = new ContextMenu();

		UltraButton addAll = new UltraButton();
		UltraButton addByPattern = new UltraButton();

		TableLayoutPanel addMenu = new TableLayoutPanel();

		//
		UltraButton inverseSelection = new UltraButton();
		UltraButton findButton = new UltraButton();

		TableLayoutPanel selectionMenu = new TableLayoutPanel();


		#endregion

		public CraftyScrobbler()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			OwnInitializers();

			//StartMarqueeProgressBar();

			RefreshFoldersList();
		}

		#region Own Methods

		private void UpdateStats()
		{
			int count = trackList.Items.Count;
			int countScrobble = 0;

			object[] items = trackList.Items.All;

			TimeSpan total = new TimeSpan(0, 0, 0);
			TimeSpan toScrobble = new TimeSpan(0, 0, 0);

			try
			{

				foreach (object item in items)
				{
					UltraListViewItem current = (UltraListViewItem)item;
					total = total.Add(TimeSpan.Parse(current.SubItems[3].Value.ToString()));

					toScrobble = toScrobble.Add(new TimeSpan(TimeSpan.Parse(current.SubItems[3].Value.ToString()).Ticks * (int)current.SubItems[4].Value));
					countScrobble += (int)current.SubItems[4].Value;
				}
			}
			catch { }

			labelStats.Text = "Total items: " + count + "   " + "Scrobbles count: " + countScrobble + "   " + "Total time: " + total.ToString() +
				"   " + "Scrobble time: " + toScrobble.ToString();
		}

		private void StartMarqueeProgressBar()
		{
			infoLabel.Visible = false;
			progressBar.Visible = true;
			progressBar.MarqueeAnimationSpeed = 10;
		}

		private void StopMarqueeProgressBar()
		{
			if (infoLabel.InvokeRequired == true)
			{
				this.infoLabel.Invoke((MethodInvoker)delegate()
				{
					StopMarqueeProgressBar();
				});
			}
			else
			{
				infoLabel.Visible = true;
				progressBar.Visible = false;
				progressBar.MarqueeAnimationSpeed = 0;
			}
		}

		private void OwnInitializers()
		{
			scrobbleDropdown.PopupItem = scrobbleDropdownPopup;
			removeDropdown.PopupItem = removePopup;

			progressBar.Visible = false;

			//
			info.Size = new Size(240, 320);
			info.Multiline = true;

			//
			panel.Size = new Size(140, 175);
			int offSet = 8;

			password.UseSystemPasswordChar = true;
			loginL.Text = "Login";
			loginL.Size = new Size(panel.Size.Width - offSet, loginL.Size.Height);
			loginL.TextAlign = ContentAlignment.MiddleCenter;
			login.Size = new Size(panel.Size.Width - offSet, login.Size.Height);
			panel.Controls.Add(loginL);
			panel.Controls.Add(login);

			passL.Text = "Password";
			passL.Size = new Size(panel.Size.Width - offSet, passL.Size.Height);
			passL.TextAlign = ContentAlignment.MiddleCenter;
			password.Size = new Size(panel.Size.Width - offSet, password.Size.Height);

			panel.Controls.Add(passL);
			panel.Controls.Add(password);

			confirm.Click += new EventHandler(onConfirm);
			confirm.Text = "Update";
			confirm.Size = new Size(panel.Size.Width - offSet, confirm.Size.Height);

			panel.Controls.Add(confirm);

			ok.Text = "Saved!";
			ok.TextAlign = ContentAlignment.MiddleCenter;
			ok.Size = new Size(panel.Size.Width - offSet, ok.Size.Height);
			ok.Visible = false;
			panel.Controls.Add(ok);

			panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

			//
			scrobbleDate.Text = "Specify scrobble date!";
			scrobbleDate.Size = scrobbleDropdown.Size;
			scrobbleDate.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			scrobbleDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;

			scrobbleDate.Click += new EventHandler(scrobbleDate_Click);

			//
			removeAll.Text = "Remove All";
			removeAll.Size = removeDropdown.Size;
			removeAll.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			removeAll.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;

			removeAll.Click += new EventHandler(removeAll_Click);

			/*
			scrobbleConfig.Text = "Initialize & check scrobbler";
			scrobbleConfig.Size = scrobbleDropdown.Size;
			scrobbleConfig.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			scrobbleConfig.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			
			dropdownPanelScrobble.Controls.Add(scrobbleDate);
			dropdownPanelScrobble.Controls.Add(scrobbleConfig);
			dropdownPanelScrobble.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
			dropdownPanelScrobble.Size = new Size(scrobbleConfig.Size.Width, scrobbleConfig.Size.Height * 2);
			 * */

			//
			//trackList.ContextMenuStrip = new ContextMenuStrip();

			addAll.Size = new Size(addDropButton.Size.Width, addDropButton.Size.Height);
			addAll.Text = "Add All";
			addAll.Margin = new Padding(0, 0, 0, 0);
			addAll.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			addAll.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			addAll.Click += new EventHandler(addAll_Click);

			addByPattern.Size = new Size(addDropButton.Size.Width, addDropButton.Size.Height);
			addByPattern.Text = "Add by Pattern";
			addByPattern.Margin = new Padding(0, 0, 0, 0);
			addByPattern.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			addByPattern.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			addByPattern.Click += new EventHandler(addByPattern_Click);

			addDropButton.PopupItem = addDropdownPopup;
			selectionDropdown.PopupItem = selectionDropdownPopup;

			addMenu.Controls.Add(addAll);
			addMenu.Controls.Add(addByPattern);
			addMenu.Size = new Size(addDropButton.Size.Width, addDropButton.Size.Height * 2);
			addMenu.Padding = new Padding(0, 0, 0, 0);
			addMenu.Margin = new Padding(0, 0, 0, 0);

			//
			inverseSelection.Size = new Size(selectionDropdown.Size.Width, selectionDropdown.Size.Height);
			inverseSelection.Text = "Invert Selection";
			inverseSelection.Margin = new Padding(0, 0, 0, 0);
			inverseSelection.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			inverseSelection.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			inverseSelection.Click += new EventHandler(inverseSelection_Click);

			findButton.Size = new Size(selectionDropdown.Size.Width, selectionDropdown.Size.Height);
			findButton.Text = "Find";
			findButton.Margin = new Padding(0, 0, 0, 0);
			findButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			findButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			findButton.Click += new EventHandler(findButton_Click);

			selectionMenu.Controls.Add(inverseSelection);
			selectionMenu.Controls.Add(findButton);
			selectionMenu.Size = new Size(selectionDropdown.Size.Width, selectionDropdown.Size.Height * 2);
			selectionMenu.Padding = new Padding(0, 0, 0, 0);
			selectionMenu.Margin = new Padding(0, 0, 0, 0);

			Infragistics.Win.AppStyling.StyleManager.Load(".//themes//NoirModerne.isl");

		}

		private void RefreshFoldersList()
		{
			StartTimer();
			//StartMarqueeProgressBar();

			folderTree.Nodes.Clear();

			string[] drives = Directory.GetLogicalDrives();

			UltraTreeNode rootNode = new UltraTreeNode();
			rootNode.Text = System.Environment.MachineName.ToString();

			foreach (string drive in drives)
			{
				UltraTreeNode nodeDrive = new UltraTreeNode();
				nodeDrive.Text = drive;

				try
				{
					if (Directory.Exists(drive))
					{
						foreach (string dir in Directory.GetDirectories(drive))
						{
							UltraTreeNode node = new UltraTreeNode();
							node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
							nodeDrive.Nodes.Add(node);
						}
					}
				}
				catch (Exception) { }

				rootNode.Nodes.Add(nodeDrive);
			}

			folderTree.Nodes.Add(rootNode);
			folderTree.Refresh();

			StopTimer();
			//StopMarqueeProgressBar();
		}

		private void StartTimer()
		{
			timeStarted = DateTime.Now.Ticks;
		}

		private void StopTimer()
		{
			long elapsed = DateTime.Now.Ticks - timeStarted;

			if (timeLabel.InvokeRequired == true)
			{
				this.timeLabel.Invoke((MethodInvoker)delegate()
				{
					StopTimer();
				});
			}else timeLabel.Text = (elapsed / TimeSpan.TicksPerMillisecond).ToString() + " ms";
		}
	
		#endregion

		#region Event Handlers

		private void Size_Changed(object sender, EventArgs e)
		{
			folderTree.Size = new Size(folderTree.Size.Width, this.Size.Height - 120);
			trackList.Size = new Size(this.Size.Width - folderTree.Size.Width - 50, trackList.Size.Height);
			fileList.Size = new Size(this.Size.Width - folderTree.Size.Width - 50, this.Size.Height - trackList.Size.Height - 175);

			int bottomPadding = 71;

			addDropButton.Location = new Point(addDropButton.Location.X, this.Size.Height - bottomPadding);
			selectionDropdown.Location = new Point(selectionDropdown.Location.X, this.Size.Height - bottomPadding);
			openCue.Location = new Point(openCue.Location.X, this.Size.Height - bottomPadding);
			quitButton.Location = new Point(quitButton.Location.X, this.Size.Height - bottomPadding);

			treeFullButton.Size = new Size(treeFullButton.Size.Width, folderTree.Size.Height);
			tracksFullButton.Size = new Size(trackList.Size.Width, tracksFullButton.Size.Height);
		}

		private void folderTree_AfterActivate(object sender, NodeEventArgs e)
		{
			StartTimer();

			string path = e.TreeNode.FullPath.Replace(e.TreeNode.RootNode.FullPath + "\\", "");

			if (!e.TreeNode.HasNodes)
			{
				if(Directory.Exists(path)) 
				{
					try
					{
						foreach (string dir in Directory.GetDirectories(path))
						{
							UltraTreeNode node = new UltraTreeNode();
							node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
							e.TreeNode.Nodes.Add(node);
						}
					}
					catch (UnauthorizedAccessException) { }
				}
			}
			try
			{
				fileList.Items.Clear();
				string[] files = Directory.GetFiles(path);    //search does not allow multiple patterns

				foreach (string file in files)
				{
					string ext = Path.GetExtension(file);

					object[] subItemsValues = new string[] { };
					UltraListViewItem item = new UltraListViewItem();

					switch (ext)
					{
						case ".mp3":
							subItemsValues = new string[] { "MP3" };
							item = new UltraListViewItem(Path.GetFileName(file), subItemsValues);

							item.Key = file;
							fileList.Items.Add(item);
							break;
						case ".ogg":
							subItemsValues = new string[] { "OGG" };
							item = new UltraListViewItem(Path.GetFileName(file), subItemsValues);

							item.Key = file;
							fileList.Items.Add(item);
							break;
						case ".flac":
							subItemsValues = new string[] { "FLAC" };
							item = new UltraListViewItem(Path.GetFileName(file), subItemsValues);

							item.Key = file;
							fileList.Items.Add(item);
							break;
						case ".ape":
							subItemsValues = new string[] { "APE" };
							item = new UltraListViewItem(Path.GetFileName(file), subItemsValues);

							item.Key = file;
							fileList.Items.Add(item);
							break;
					}
				}
			}
			catch (Exception) {}

			StopTimer();
		}

		private void addAll_Click(object sender, EventArgs e)
		{
			StartTimer();

			object[] files = fileList.Items.All;

			ArrayList errors = new ArrayList();

			foreach (object file in files)
			{
				try
				{
					UltraListViewItem item = (UltraListViewItem)file;

					TagLib.File tagFile = TagLib.File.Create(item.Key.ToString());

					ArrayList subItemValues = new ArrayList();

					subItemValues.Add(tagFile.Tag.Title);
					subItemValues.Add(tagFile.Tag.FirstPerformer);
					subItemValues.Add(tagFile.Tag.Album);
					subItemValues.Add(tagFile.Properties.Duration.ToString());
					subItemValues.Add(1);

					UltraListViewItem track = new UltraListViewItem(tagFile.Name, subItemValues.ToArray());

					trackList.Items.Add(track);

				}
				catch (Exception exp)
				{
					errors.Add(((UltraListViewItem)file).Value.ToString() + " : " + exp.Message.ToString());
				}
			}
			if (errors.Count > 0)
			{
				info.Clear();
				info.AppendText("Following errors have occured:\r\n\r\n");

				foreach (string error in errors.ToArray())
				{
					info.AppendText(error);
					info.AppendText("\r\n");
				}

				errorPopup.Show(new Point(this.Size.Width + this.Location.X, this.Location.Y + this.Size.Height / 3));
			}

			UpdateStats();

			StopTimer();
		}

		private void addByPattern_Click(object sender, EventArgs e)
		{
  
		}

		private void inverseSelection_Click(object sender, EventArgs e)
		{

		}

		private void findButton_Click(object sender, EventArgs e)
		{
 
		}

		private void ultraPopupControlContainer1_Opening(object sender, CancelEventArgs e)
		{
			errorPopup.PopupControl = info;
		}

		void onConfirm(object sender, EventArgs e)
		{
			StartMarqueeProgressBar();

			if (login.Text.Equals(""))
			{
				MessageBox.Show("You forgot to enter your username!", "Ooops, oook!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ok.Visible = false;
				StopMarqueeProgressBar();
			}
			else
			{
				userLogin = login.Text;

				if (password.Text.Equals(""))
				{
					MessageBox.Show("You forgot to enter your password!", "Ooops, oook!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					ok.Visible = false;
					StopMarqueeProgressBar();
				}
				else
				{
					userPassword = password.Text;

					Thread initSThread = new Thread(new ThreadStart(initializeScrobbler));
					initSThread.IsBackground = true;
					initSThread.Start();

					ok.Text = "Authorizing...";
					ok.Visible = true; 
				}
			}
		}

		private void initializeScrobbler()
		{
			StartTimer();
			//StartMarqueeProgressBar();

			client = new LastFmClient();
			client.User = new LastFmUser();

			client.User.Username = userLogin;
			client.User.Password = userPassword;

			LastFmLib.WebRequests.Handshake handshake = client.Login();

			if (handshake.succeeded)
			{
				sm = client.GetScrobblerManager();
				scrobblerInit = true;

				if (ok.InvokeRequired)
				{
					this.Invoke((MethodInvoker)delegate()
					{
						   ok.Text = "Confirmed!";
						   optionsPopup.Show(new Point(this.Size.Width + this.Location.X, this.Location.Y + this.Size.Height / 3));
					});
				}
				else ok.Text = "Cofirmed!";
			}
			else
			{
				if (ok.InvokeRequired)
				{
					this.Invoke((MethodInvoker)delegate()
					{
						ok.Text = "Failed!\n (" + handshake.errorMessage + ")";
						ok.Size = new Size(ok.Size.Width, ok.Size.Height * 2);
						panel.Size = new Size(panel.Width, panel.Height + ok.Size.Height / 2);
						optionsPopup.Show(new Point(this.Size.Width + this.Location.X, this.Location.Y + this.Size.Height / 3));
					});
				}
				else ok.Text = "Failed!";
			}

			StopTimer();
			StopMarqueeProgressBar();
		}
		
		private void ultraPopupControlContainer2_Opening(object sender, CancelEventArgs e)
		{
			optionsPopup.PopupControl = panel;
		}

		private void ultraButton1_Click(object sender, EventArgs e)
		{
			optionsPopup.Show(new Point(this.Size.Width + this.Location.X, this.Location.Y + this.Size.Height / 3));
		}

		private void ultraDropDownButton1_Click(object sender, EventArgs e)
		{
			if (scrobblerInit)
			{
				if (trackList.Items.Count > 0)
				{
					object[] files = trackList.Items.All;

					if (files.Length > 50)
					{
						MessageBox.Show("Scrobbling more than 50 tracks - last.fm response may be lagged.", "Tracks, a lot!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

					//UltraListViewItem item = (UltraListViewItem)files[0];

					C5.ArrayList<TrackInfo> tracks = new C5.ArrayList<TrackInfo>();

					try
					{
						foreach (object file in files)
						{
							UltraListViewItem item = (UltraListViewItem)file;

							TrackInfo info = new TrackInfo(item.SubItems[1].Value.ToString(), item.SubItems[2].Value.ToString(), item.SubItems[0].Value.ToString());    //artist (!empty), album (may be empty), title (!empty)
							info.Username = userLogin;
							info.Duration = (int)TimeSpan.Parse(item.SubItems[3].Value.ToString()).TotalSeconds;
							info.SourceString = "P";
							info.timeStampMe();

							for (int i = 0; i < (int)item.SubItems[4].Value; i++ )
								tracks.Add(info);
						}
						tracks.Shuffle();

						ScrobblerCache cache = new ScrobblerCache(userLogin);
						cache.Append(new List<TrackInfo>(tracks.ToArray()), true);

						sm.Scrobble(ref cache);
						MessageBox.Show("Scrobbled successfully!", "Oll Korrect", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(Exception exp)
					{
					}
				}
				else
				{
					MessageBox.Show("Alas, nothing to scrobble!", "Oops, no tracks at all", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				MessageBox.Show("Hold yer horses! Enter user info first - click 'options' and so on", "Methinks we're forgetting something...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		
		private void ultraPopupControlContainer3_Opening(object sender, CancelEventArgs e)
		{
			scrobbleDropdownPopup.PopupControl = scrobbleDate;
			//scrobbleDropdownPopup.PopupControl = dropdownPanelScrobble;
		}

		private void RefreshButton_Click_1(object sender, EventArgs e)
		{
			RefreshFoldersList();
		}

		private void trackList_ItemDoubleClick(object sender, ItemDoubleClickEventArgs e)
		{
			/*
			trackList.Items.RemoveAt(e.Item.Index);
			UpdateStats();
			 * */
		}

		private void fileList_ItemDoubleClick(object sender, ItemDoubleClickEventArgs e)
		{
			TagLib.File tagFile = TagLib.File.Create(e.Item.Key.ToString());

			ArrayList subItemValues = new ArrayList();

			subItemValues.Add(tagFile.Tag.Title);
			subItemValues.Add(tagFile.Tag.FirstPerformer);
			subItemValues.Add(tagFile.Tag.Album);
			subItemValues.Add(tagFile.Properties.Duration.ToString());
			subItemValues.Add(1);

			UltraListViewItem track = new UltraListViewItem(tagFile.Name, subItemValues.ToArray());

			trackList.Items.Add(track);

			UpdateStats();
		}

		private void scrobbleDate_Click(object sender, EventArgs e)
		{
			DataScrobble dScrobble = new DataScrobble(trackList.Items.All, userLogin, userPassword, sm);
			DialogResult dResult = dScrobble.ShowDialog(this);
		}

		private void folderTree_MouseEnter(object sender, EventArgs e)
		{
			infoLabel.Text = "Do select a folder with some audio files (mp3, ogg, flac, ape) in it";
		}

		private void folderTree_MouseLeave(object sender, EventArgs e)
		{
			if (fileList.Items.Count == 0)
			{
				infoLabel.Text = "Alas, this directory of yours is but empty: no compatible audio tracks detected";
			}
			else
			{
				infoLabel.Text = "Choose tracks you want to scrobble - add those to track (upper) list";
			}
		}

		private void fileList_ItemActivated(object sender, ItemActivatedEventArgs e)
		{
			//infoLabel.Text = "Good, you may now add selected files to scrobble list";
		}

		private void fileList_MouseEnter(object sender, EventArgs e)
		{
			infoLabel.Text = "Double click to add desired file to scrobble list";
		}

		private void trackList_MouseEnter(object sender, EventArgs e)
		{
			infoLabel.Text = "Left click to increment scrobble count, right click - to decrement count.";//"Double click to remove unwanted track from scrobble list";
		}

		private void scrobbleDropdown_MouseEnter(object sender, EventArgs e)
		{
			infoLabel.Text = "'Album' field may be empty, but the artist and track title must be filled out.";
		}

		private void removeDropdown_Click(object sender, EventArgs e)
		{
			object[] selected = trackList.SelectedItems.All;

			foreach(UltraListViewItem item in selected) {
				trackList.Items.Remove(item);
			}

			UpdateStats();
		}

		private void removeAll_Click(object sender, EventArgs e)
		{
			trackList.Items.Clear();
			UpdateStats();
		}

		private void removePopup_Opening(object sender, CancelEventArgs e)
		{
			removePopup.PopupControl = removeAll;
		}

		private void addDropButton_Click(object sender, EventArgs e)
		{
			StartTimer();

			object[] files = fileList.SelectedItems.All;

			ArrayList errors = new ArrayList();

			foreach (object file in files)
			{
				try
				{
					UltraListViewItem item = (UltraListViewItem)file;

					TagLib.File tagFile = TagLib.File.Create(item.Key.ToString());

					ArrayList subItemValues = new ArrayList();

					subItemValues.Add(tagFile.Tag.Title);
					subItemValues.Add(tagFile.Tag.FirstPerformer);
					subItemValues.Add(tagFile.Tag.Album);
					subItemValues.Add(tagFile.Properties.Duration.ToString());
					subItemValues.Add(1);

					UltraListViewItem track = new UltraListViewItem(tagFile.Name, subItemValues.ToArray());

					trackList.Items.Add(track);
				}
				catch (Exception exp)
				{
					errors.Add(((UltraListViewItem)file).Value.ToString() + " : " + exp.Message.ToString());
				}
			}
			if (errors.Count > 0)
			{
				info.Clear();
				info.AppendText("Following errors have occured:\r\n\r\n");

				foreach (string error in errors.ToArray())
				{
					info.AppendText(error);
					info.AppendText("\r\n");
				}

				errorPopup.Show(new Point(this.Size.Width + this.Location.X, this.Location.Y + this.Size.Height / 3));
			}

			UpdateStats();

			StopTimer();
		}

		#endregion

		private void addDropdownPopup_Opening(object sender, CancelEventArgs e)
		{
			addDropdownPopup.PopupControl = addMenu;
		}

		private void selectionDropdownPopup_Opening(object sender, CancelEventArgs e)
		{
			selectionDropdownPopup.PopupControl = selectionMenu;
		}

		private void quitButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Oh, leaving already?", "Abandon ship!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void selectionDropdown_Click(object sender, EventArgs e)
		{
			fileList.SelectedItems.Clear();
		}

		private void openCue_Click(object sender, EventArgs e)
		{
			StartTimer();

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = folderTree.ActiveNode.FullPath.Replace(folderTree.ActiveNode.RootNode.FullPath + "\\", "");

			dialog.Filter = "CUE'sheet lists (*.cue)|*.cue|Text sheet Files (*.txt)|*.txt";
			dialog.Title = "Select CUE'sheet to open";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					CueSheet sheet = new CueSheet(dialog.FileName);
					string artist = sheet.Performer;
					string album = sheet.Title;
 
					CueSharp.Track[] tracks = sheet.Tracks;

					//TagLib.File tagFile = TagLib.File.Create(dialog.FileName);
					//TimeSpan totalTime = new TimeSpan(tagFile.Length);

					TimeSpan totalTime = new TimeSpan();
					TimeSpan totalTrackTime = new TimeSpan();
					int totalTracks = tracks.Length;

					bool readFile = false;

					try
					{
						TagLib.File tagFile = TagLib.File.Create(Path.GetDirectoryName(dialog.FileName) + "\\" + tracks[0].DataFile.Filename);
						totalTime = tagFile.Properties.Duration;
						readFile = true;
					}
					catch
					{
					}

					foreach (object item in tracks)
					{
						try
						{
							CueSharp.Track track = (CueSharp.Track)item;

							ArrayList subItemValues = new ArrayList();

							subItemValues.Add(track.Title);
							subItemValues.Add(track.Performer);
							subItemValues.Add(album);

							TimeSpan trackTime = new TimeSpan();

							if (track.TrackNumber != totalTracks)
							{
								trackTime = new TimeSpan(0, tracks[track.TrackNumber].Indices[0].Minutes - track.Indices[0].Minutes, tracks[track.TrackNumber].Indices[0].Seconds - track.Indices[0].Seconds);
							}
							else if(readFile)
								trackTime = new TimeSpan(0, totalTime.Minutes - totalTrackTime.Minutes, totalTime.Seconds - totalTrackTime.Seconds);
							else trackTime = new TimeSpan(0, totalTrackTime.Minutes/totalTracks, totalTrackTime.Seconds/totalTracks);

							totalTrackTime = totalTrackTime.Add(trackTime);

							subItemValues.Add(trackTime.ToString());
							subItemValues.Add(1);

							UltraListViewItem listTrack = new UltraListViewItem("CUE'sheet item", subItemValues.ToArray());
							trackList.Items.Add(listTrack);
						}
						catch (Exception exp)
						{
							//errors.Add(((UltraListViewItem)file).Value.ToString() + " : " + exp.Message.ToString());
						}
					}
				}
				catch
				{
					MessageBox.Show("Ook!");
				}
			}

			UpdateStats();

			StopTimer();
		}

		private void trackList_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (trackList.SelectedItems.Count == 1)
				{
					//count column (main column does not count)
					trackList.SelectedItems[0].SubItems[4].Value = (int)trackList.SelectedItems[0].SubItems[4].Value + 1;
					trackList.Refresh();
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				if (trackList.SelectedItems.Count == 1)
				{
					if ((int)trackList.SelectedItems[0].SubItems[4].Value != 1)
						trackList.SelectedItems[0].SubItems[4].Value = (int)trackList.SelectedItems[0].SubItems[4].Value - 1;
					trackList.Refresh();
				}
			}
			else if (e.Button == MouseButtons.Middle)
			{
				if (trackList.SelectedItems.Count == 1)
				{
					if ((int)trackList.SelectedItems[0].SubItems[4].Value != 1)
						trackList.SelectedItems[0].SubItems[4].Value = 1;
					trackList.Refresh();
				}
			}

			UpdateStats();
		}

		private void treeFullButton_Click(object sender, EventArgs e)
		{
			if (folderTree.Size.Width < this.Size.Width / 3)
			{
				folderTree.Size = new Size(this.Size.Width - 40, this.Size.Height - 120);
				treeFullButton.Location = new Point(folderTree.Location.X + folderTree.Size.Width - treeFullButton.Size.Width + 5,
					treeFullButton.Location.Y);

				trackList.Visible = false;
				fileList.Visible = false;

				labelStats.Visible = false;
				dropdownPanelScrobble.Visible = false;
				removeDropdown.Visible = false;
				optionsButton.Visible = false;
				scrobbleDropdown.Visible = false;

				addDropButton.Visible = false;
				openCue.Visible = false;
				selectionDropdown.Visible = false;

				tracksFullButton.Visible = false;
				quitButton.Visible = false;

				editFields.Visible = false;
				editPanel.Visible = false;
			}
			else
			{
				folderTree.Size = new Size(257, this.Size.Height - 120);
				treeFullButton.Location = new Point(folderTree.Location.X + folderTree.Size.Width - treeFullButton.Size.Width + 5,
					treeFullButton.Location.Y);

				trackList.Visible = true;
				fileList.Visible = true;

				labelStats.Visible = true;
				dropdownPanelScrobble.Visible = true;
				removeDropdown.Visible = true;
				optionsButton.Visible = true;
				scrobbleDropdown.Visible = true ;

				addDropButton.Visible = true;
				openCue.Visible = true;
				selectionDropdown.Visible = true;

				tracksFullButton.Visible = true;
				quitButton.Visible = true;

				editFields.Visible = true;
				//editPanel.Visible = true;
			}

			Refresh();
		}

		private void tracksFullButton_Click(object sender, EventArgs e)
		{
			if (trackList.Size.Height < this.Size.Height / 2)
			{
				trackList.Size = new Size(trackList.Size.Width, this.Size.Height - 96);
				tracksFullButton.Location = new Point(tracksFullButton.Location.X, 
					trackList.Location.Y + trackList.Size.Height - tracksFullButton.Size.Height + 5);

				fileList.Visible = false;

				labelStats.Visible = false;
				dropdownPanelScrobble.Visible = false;
				removeDropdown.Visible = false;
				optionsButton.Visible = false;
				scrobbleDropdown.Visible = false;

				addDropButton.Visible = false;
				openCue.Visible = false;
				selectionDropdown.Visible = false;

				quitButton.Visible = false;

				editFields.Visible = false;
				editPanel.Visible = false;
			}
			else
			{
				trackList.Size = new Size(trackList.Size.Width, 179);
				tracksFullButton.Location = new Point(tracksFullButton.Location.X,
					trackList.Location.Y + trackList.Size.Height - tracksFullButton.Size.Height + 5);

				fileList.Visible = true;

				labelStats.Visible = true;
				dropdownPanelScrobble.Visible = true;
				removeDropdown.Visible = true;
				optionsButton.Visible = true;
				scrobbleDropdown.Visible = true;

				addDropButton.Visible = true;
				openCue.Visible = true;
				selectionDropdown.Visible = true;

				quitButton.Visible = true;
				editFields.Visible = true;
			}

			Refresh();
		}

		private void editFields_Click(object sender, EventArgs e)
		{
			if (trackList.SelectedItems.Count > 0)
			{
				if (!editPanel.Visible)
				{
					editPanel.Size = fileList.Size;
					editPanel.Location = fileList.Location;

					editPanel.Visible = true;

					try
					{
						UltraListViewItem item = (UltraListViewItem)trackList.SelectedItems.All[0];
							artistNew.Text = item.SubItems[1].Value.ToString();
							albumNew.Text = item.SubItems[2].Value.ToString();
							trackNew.Text = item.SubItems[0].Value.ToString();
					}
					catch { }
				}
				else
				{
					editPanel.Visible = false;
				}
			}
			else
			{
				MessageBox.Show("Select something first!", "Not like this!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void applyEdit_Click(object sender, EventArgs e)
		{
			try
			{
				for (int k = 0; k < trackList.SelectedItems.Count; k++)
				{
					if (checkTrack.Checked)
						trackList.SelectedItems[k].SubItems[0].Value = trackNew.Text;
					if (checkArtist.Checked)
						trackList.SelectedItems[k].SubItems[1].Value = artistNew.Text;
					if (checkAlbum.Checked)
						trackList.SelectedItems[k].SubItems[2].Value = albumNew.Text;
				}
			}
			catch { }
			finally { trackList.Refresh(); }
		}

		private void optionsButton_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void optionsButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Right))
			{
				SelectTheme tTheme = new SelectTheme();
				tTheme.ShowDialog(this);
			}
		}
	}
}
