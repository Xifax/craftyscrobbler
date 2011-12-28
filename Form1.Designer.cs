namespace CraftyScrobbler
{
    partial class CraftyScrobbler
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn1 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("titleColumn");
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn2 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("artistColumn");
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn3 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("albumColumn");
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn4 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("lengthColumn");
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn5 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("countColumn");
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Click left mouse button on item to increment play counts by one.\\nClick right but" +
                    "ton do decrement.\\nClick scroller to set count to one.", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Some directories may appear as if not having subfolders - click on them to refres" +
                    "h its substructure", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn6 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("codecColumn");
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("You may select multiple tracks by using Ctrl or Shift", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Duration of previous action in ms", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Does not change tag of a real file!", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.trackList = new Infragistics.Win.UltraWinListView.UltraListView();
            this.folderTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.fileList = new Infragistics.Win.UltraWinListView.UltraListView();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.timeLabel = new Infragistics.Win.Misc.UltraLabel();
            this.applyEdit = new Infragistics.Win.Misc.UltraButton();
            this.optionsButton = new Infragistics.Win.Misc.UltraButton();
            this.errorPopup = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.optionsPopup = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.scrobbleDropdown = new Infragistics.Win.Misc.UltraDropDownButton();
            this.scrobbleDropdownPopup = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.removeDropdown = new Infragistics.Win.Misc.UltraDropDownButton();
            this.RefreshButton = new Infragistics.Win.Misc.UltraButton();
            this.infoLabel = new Infragistics.Win.Misc.UltraLabel();
            this.removePopup = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.addDropButton = new Infragistics.Win.Misc.UltraDropDownButton();
            this.selectionDropdown = new Infragistics.Win.Misc.UltraDropDownButton();
            this.openCue = new Infragistics.Win.Misc.UltraButton();
            this.quitButton = new Infragistics.Win.Misc.UltraButton();
            this.addDropdownPopup = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.selectionDropdownPopup = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.labelStats = new Infragistics.Win.Misc.UltraLabel();
            this.treeFullButton = new Infragistics.Win.Misc.UltraButton();
            this.tracksFullButton = new Infragistics.Win.Misc.UltraButton();
            this.editFields = new Infragistics.Win.Misc.UltraButton();
            this.editPanel = new Infragistics.Win.Misc.UltraPanel();
            this.checkAlbum = new System.Windows.Forms.CheckBox();
            this.checkArtist = new System.Windows.Forms.CheckBox();
            this.checkTrack = new System.Windows.Forms.CheckBox();
            this.trackLabel = new System.Windows.Forms.Label();
            this.albumLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.trackNew = new System.Windows.Forms.TextBox();
            this.albumNew = new System.Windows.Forms.TextBox();
            this.artistNew = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileList)).BeginInit();
            this.editPanel.ClientArea.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            this.trackList.ItemSettings.HotTracking = true;
            this.trackList.Location = new System.Drawing.Point(278, 42);
            this.trackList.MainColumn.Text = "Path to track";
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(604, 179);
            ultraListViewSubItemColumn1.Key = "titleColumn";
            ultraListViewSubItemColumn1.Text = "Title";
            ultraListViewSubItemColumn2.Key = "artistColumn";
            ultraListViewSubItemColumn2.Text = "Artist";
            ultraListViewSubItemColumn3.Key = "albumColumn";
            ultraListViewSubItemColumn3.Text = "Album";
            ultraListViewSubItemColumn4.Key = "lengthColumn";
            ultraListViewSubItemColumn4.Text = "Length";
            ultraListViewSubItemColumn4.Width = 50;
            ultraListViewSubItemColumn5.DataType = typeof(int);
            ultraListViewSubItemColumn5.Key = "countColumn";
            ultraListViewSubItemColumn5.NullText = "1";
            ultraListViewSubItemColumn5.Text = "Count";
            ultraListViewSubItemColumn5.Width = 52;
            this.trackList.SubItemColumns.AddRange(new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn[] {
            ultraListViewSubItemColumn1,
            ultraListViewSubItemColumn2,
            ultraListViewSubItemColumn3,
            ultraListViewSubItemColumn4,
            ultraListViewSubItemColumn5});
            this.trackList.TabIndex = 0;
            this.trackList.Text = "trackList";
            ultraToolTipInfo5.ToolTipText = "Click left mouse button on item to increment play counts by one.\\nClick right but" +
                "ton do decrement.\\nClick scroller to set count to one.";
            ultraToolTipInfo5.ToolTipTextStyle = Infragistics.Win.ToolTipTextStyle.Formatted;
            this.ultraToolTipManager1.SetUltraToolTip(this.trackList, ultraToolTipInfo5);
            this.trackList.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            this.trackList.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.trackList.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
            this.trackList.ViewSettingsDetails.FullRowSelect = true;
            this.trackList.ItemDoubleClick += new Infragistics.Win.UltraWinListView.ItemDoubleClickEventHandler(this.trackList_ItemDoubleClick);
            this.trackList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trackList_MouseClick);
            this.trackList.MouseEnter += new System.EventHandler(this.trackList_MouseEnter);
            // 
            // folderTree
            // 
            this.folderTree.Location = new System.Drawing.Point(13, 72);
            this.folderTree.Name = "folderTree";
            this.folderTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Inset;
            this.folderTree.Size = new System.Drawing.Size(257, 408);
            this.folderTree.TabIndex = 1;
            ultraToolTipInfo4.ToolTipText = "Some directories may appear as if not having subfolders - click on them to refres" +
                "h its substructure";
            this.ultraToolTipManager1.SetUltraToolTip(this.folderTree, ultraToolTipInfo4);
            this.folderTree.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Grid;
            this.folderTree.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.folderTree_AfterActivate);
            this.folderTree.MouseEnter += new System.EventHandler(this.folderTree_MouseEnter);
            // 
            // fileList
            // 
            this.fileList.ItemSettings.HotTracking = true;
            this.fileList.Location = new System.Drawing.Point(276, 276);
            this.fileList.MainColumn.Text = "Name";
            this.fileList.MainColumn.Width = 500;
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(603, 176);
            ultraListViewSubItemColumn6.Key = "codecColumn";
            ultraListViewSubItemColumn6.Text = "Codec";
            this.fileList.SubItemColumns.AddRange(new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn[] {
            ultraListViewSubItemColumn6});
            this.fileList.TabIndex = 2;
            this.fileList.Text = "ultraListView1";
            ultraToolTipInfo3.ToolTipText = "You may select multiple tracks by using Ctrl or Shift";
            this.ultraToolTipManager1.SetUltraToolTip(this.fileList, ultraToolTipInfo3);
            this.fileList.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
            this.fileList.ViewSettingsDetails.ColumnHeaderImageSize = new System.Drawing.Size(-1, -1);
            this.fileList.ViewSettingsDetails.FullRowSelect = true;
            this.fileList.ItemActivated += new Infragistics.Win.UltraWinListView.ItemActivatedEventHandler(this.fileList_ItemActivated);
            this.fileList.ItemDoubleClick += new Infragistics.Win.UltraWinListView.ItemDoubleClickEventHandler(this.fileList_ItemDoubleClick);
            this.fileList.MouseEnter += new System.EventHandler(this.fileList_MouseEnter);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.WindowsVista;
            // 
            // timeLabel
            // 
            appearance1.BackColor = System.Drawing.Color.Gray;
            appearance1.BorderColor = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.timeLabel.Appearance = appearance1;
            this.timeLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeLabel.Location = new System.Drawing.Point(780, 14);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 23);
            this.timeLabel.TabIndex = 14;
            this.timeLabel.Text = "0:0";
            ultraToolTipInfo2.ToolTipText = "Duration of previous action in ms";
            this.ultraToolTipManager1.SetUltraToolTip(this.timeLabel, ultraToolTipInfo2);
            this.timeLabel.UseAppStyling = false;
            // 
            // applyEdit
            // 
            this.applyEdit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.applyEdit.Location = new System.Drawing.Point(2, 138);
            this.applyEdit.Name = "applyEdit";
            this.applyEdit.Size = new System.Drawing.Size(597, 23);
            this.applyEdit.TabIndex = 2;
            this.applyEdit.Text = "Apply";
            ultraToolTipInfo1.ToolTipText = "Does not change tag of a real file!";
            this.ultraToolTipManager1.SetUltraToolTip(this.applyEdit, ultraToolTipInfo1);
            this.applyEdit.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.applyEdit.Click += new System.EventHandler(this.applyEdit_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.optionsButton.Location = new System.Drawing.Point(784, 247);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(96, 23);
            this.optionsButton.TabIndex = 15;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.optionsButton.Click += new System.EventHandler(this.ultraButton1_Click);
            this.optionsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.optionsButton_MouseClick);
            this.optionsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionsButton_MouseDown);
            // 
            // errorPopup
            // 
            this.errorPopup.Opening += new System.ComponentModel.CancelEventHandler(this.ultraPopupControlContainer1_Opening);
            // 
            // optionsPopup
            // 
            this.optionsPopup.Opening += new System.ComponentModel.CancelEventHandler(this.ultraPopupControlContainer2_Opening);
            // 
            // scrobbleDropdown
            // 
            this.scrobbleDropdown.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.scrobbleDropdown.Location = new System.Drawing.Point(594, 247);
            this.scrobbleDropdown.Name = "scrobbleDropdown";
            this.scrobbleDropdown.Size = new System.Drawing.Size(184, 23);
            this.scrobbleDropdown.TabIndex = 16;
            this.scrobbleDropdown.Text = "Scrobble!";
            this.scrobbleDropdown.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.scrobbleDropdown.Click += new System.EventHandler(this.ultraDropDownButton1_Click);
            this.scrobbleDropdown.MouseEnter += new System.EventHandler(this.scrobbleDropdown_MouseEnter);
            // 
            // scrobbleDropdownPopup
            // 
            this.scrobbleDropdownPopup.Opening += new System.ComponentModel.CancelEventHandler(this.ultraPopupControlContainer3_Opening);
            // 
            // removeDropdown
            // 
            this.removeDropdown.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.removeDropdown.Location = new System.Drawing.Point(278, 247);
            this.removeDropdown.Name = "removeDropdown";
            this.removeDropdown.Size = new System.Drawing.Size(199, 23);
            this.removeDropdown.TabIndex = 17;
            this.removeDropdown.Text = "Remove Selected Tracks";
            this.removeDropdown.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.removeDropdown.Click += new System.EventHandler(this.removeDropdown_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.RefreshButton.Location = new System.Drawing.Point(13, 42);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(257, 23);
            this.RefreshButton.TabIndex = 18;
            this.RefreshButton.Text = "Refresh Directories Tree";
            this.RefreshButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click_1);
            // 
            // infoLabel
            // 
            appearance2.BackColor = System.Drawing.Color.Gray;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.infoLabel.Appearance = appearance2;
            this.infoLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.infoLabel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(13, 14);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(765, 23);
            this.infoLabel.TabIndex = 19;
            this.infoLabel.Text = "Welcome to crafty scrobbler!";
            this.infoLabel.UseAppStyling = false;
            // 
            // removePopup
            // 
            this.removePopup.Opening += new System.ComponentModel.CancelEventHandler(this.removePopup_Opening);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 18);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(765, 15);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 20;
            this.progressBar.UseWaitCursor = true;
            this.progressBar.Visible = false;
            // 
            // addDropButton
            // 
            this.addDropButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.addDropButton.Location = new System.Drawing.Point(276, 457);
            this.addDropButton.Name = "addDropButton";
            this.addDropButton.Size = new System.Drawing.Size(147, 23);
            this.addDropButton.TabIndex = 21;
            this.addDropButton.Text = "Add Selected Files";
            this.addDropButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.addDropButton.Click += new System.EventHandler(this.addDropButton_Click);
            // 
            // selectionDropdown
            // 
            this.selectionDropdown.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.selectionDropdown.Location = new System.Drawing.Point(429, 457);
            this.selectionDropdown.Name = "selectionDropdown";
            this.selectionDropdown.Size = new System.Drawing.Size(159, 23);
            this.selectionDropdown.TabIndex = 22;
            this.selectionDropdown.Text = "Clear Selection";
            this.selectionDropdown.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.selectionDropdown.Click += new System.EventHandler(this.selectionDropdown_Click);
            // 
            // openCue
            // 
            this.openCue.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.openCue.Location = new System.Drawing.Point(594, 457);
            this.openCue.Name = "openCue";
            this.openCue.Size = new System.Drawing.Size(184, 23);
            this.openCue.TabIndex = 23;
            this.openCue.Text = "Add Tracks from .CUE";
            this.openCue.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.openCue.Click += new System.EventHandler(this.openCue_Click);
            // 
            // quitButton
            // 
            this.quitButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.quitButton.Location = new System.Drawing.Point(784, 457);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(96, 23);
            this.quitButton.TabIndex = 24;
            this.quitButton.Text = "Quit";
            this.quitButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // addDropdownPopup
            // 
            this.addDropdownPopup.Opening += new System.ComponentModel.CancelEventHandler(this.addDropdownPopup_Opening);
            // 
            // selectionDropdownPopup
            // 
            this.selectionDropdownPopup.Opening += new System.ComponentModel.CancelEventHandler(this.selectionDropdownPopup_Opening);
            // 
            // labelStats
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.labelStats.Appearance = appearance3;
            this.labelStats.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.labelStats.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.labelStats.Location = new System.Drawing.Point(278, 227);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(604, 14);
            this.labelStats.TabIndex = 25;
            this.labelStats.Text = "Total items: 0   Scrobbles count: 0    Total time: 0   Scrobble Time: 0";
            this.labelStats.UseAppStyling = false;
            // 
            // treeFullButton
            // 
            this.treeFullButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.treeFullButton.Location = new System.Drawing.Point(266, 72);
            this.treeFullButton.Name = "treeFullButton";
            this.treeFullButton.Size = new System.Drawing.Size(6, 408);
            this.treeFullButton.TabIndex = 26;
            this.treeFullButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.treeFullButton.Click += new System.EventHandler(this.treeFullButton_Click);
            // 
            // tracksFullButton
            // 
            this.tracksFullButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.tracksFullButton.Location = new System.Drawing.Point(278, 215);
            this.tracksFullButton.Name = "tracksFullButton";
            this.tracksFullButton.Size = new System.Drawing.Size(604, 6);
            this.tracksFullButton.TabIndex = 27;
            this.tracksFullButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tracksFullButton.Click += new System.EventHandler(this.tracksFullButton_Click);
            // 
            // editFields
            // 
            this.editFields.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.editFields.Location = new System.Drawing.Point(483, 246);
            this.editFields.Name = "editFields";
            this.editFields.Size = new System.Drawing.Size(105, 24);
            this.editFields.TabIndex = 28;
            this.editFields.Text = "Edit";
            this.editFields.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.editFields.Click += new System.EventHandler(this.editFields_Click);
            // 
            // editPanel
            // 
            // 
            // editPanel.ClientArea
            // 
            this.editPanel.ClientArea.Controls.Add(this.checkAlbum);
            this.editPanel.ClientArea.Controls.Add(this.checkArtist);
            this.editPanel.ClientArea.Controls.Add(this.checkTrack);
            this.editPanel.ClientArea.Controls.Add(this.applyEdit);
            this.editPanel.ClientArea.Controls.Add(this.trackLabel);
            this.editPanel.ClientArea.Controls.Add(this.albumLabel);
            this.editPanel.ClientArea.Controls.Add(this.artistLabel);
            this.editPanel.ClientArea.Controls.Add(this.trackNew);
            this.editPanel.ClientArea.Controls.Add(this.albumNew);
            this.editPanel.ClientArea.Controls.Add(this.artistNew);
            this.editPanel.Location = new System.Drawing.Point(276, 276);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(603, 175);
            this.editPanel.TabIndex = 29;
            this.editPanel.Visible = false;
            // 
            // checkAlbum
            // 
            this.checkAlbum.AutoSize = true;
            this.checkAlbum.Location = new System.Drawing.Point(504, 46);
            this.checkAlbum.Name = "checkAlbum";
            this.checkAlbum.Size = new System.Drawing.Size(92, 17);
            this.checkAlbum.TabIndex = 3;
            this.checkAlbum.Text = "Update album";
            this.checkAlbum.UseVisualStyleBackColor = true;
            // 
            // checkArtist
            // 
            this.checkArtist.AutoSize = true;
            this.checkArtist.Location = new System.Drawing.Point(504, 3);
            this.checkArtist.Name = "checkArtist";
            this.checkArtist.Size = new System.Drawing.Size(86, 17);
            this.checkArtist.TabIndex = 3;
            this.checkArtist.Text = "Update artist";
            this.checkArtist.UseVisualStyleBackColor = true;
            // 
            // checkTrack
            // 
            this.checkTrack.AutoSize = true;
            this.checkTrack.Location = new System.Drawing.Point(504, 92);
            this.checkTrack.Name = "checkTrack";
            this.checkTrack.Size = new System.Drawing.Size(80, 17);
            this.checkTrack.TabIndex = 3;
            this.checkTrack.Text = "Update title";
            this.checkTrack.UseVisualStyleBackColor = true;
            // 
            // trackLabel
            // 
            this.trackLabel.AutoSize = true;
            this.trackLabel.Location = new System.Drawing.Point(3, 89);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(35, 13);
            this.trackLabel.TabIndex = 1;
            this.trackLabel.Text = "Track";
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Location = new System.Drawing.Point(3, 50);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(36, 13);
            this.albumLabel.TabIndex = 1;
            this.albumLabel.Text = "Album";
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(2, 7);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(30, 13);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist";
            // 
            // trackNew
            // 
            this.trackNew.Location = new System.Drawing.Point(2, 112);
            this.trackNew.Name = "trackNew";
            this.trackNew.Size = new System.Drawing.Size(597, 20);
            this.trackNew.TabIndex = 0;
            // 
            // albumNew
            // 
            this.albumNew.Location = new System.Drawing.Point(2, 66);
            this.albumNew.Name = "albumNew";
            this.albumNew.Size = new System.Drawing.Size(597, 20);
            this.albumNew.TabIndex = 0;
            // 
            // artistNew
            // 
            this.artistNew.Location = new System.Drawing.Point(2, 23);
            this.artistNew.Name = "artistNew";
            this.artistNew.Size = new System.Drawing.Size(597, 20);
            this.artistNew.TabIndex = 0;
            // 
            // CraftyScrobbler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 489);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.editFields);
            this.Controls.Add(this.tracksFullButton);
            this.Controls.Add(this.treeFullButton);
            this.Controls.Add(this.labelStats);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.openCue);
            this.Controls.Add(this.selectionDropdown);
            this.Controls.Add(this.addDropButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.removeDropdown);
            this.Controls.Add(this.scrobbleDropdown);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.folderTree);
            this.Controls.Add(this.trackList);
            this.Name = "CraftyScrobbler";
            this.Text = "CraftyScrobbler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Size_Changed);
            ((System.ComponentModel.ISupportInitialize)(this.trackList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileList)).EndInit();
            this.editPanel.ClientArea.ResumeLayout(false);
            this.editPanel.ClientArea.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinListView.UltraListView trackList;
        private Infragistics.Win.UltraWinTree.UltraTree folderTree;
        private Infragistics.Win.UltraWinListView.UltraListView fileList;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel timeLabel;
        private Infragistics.Win.Misc.UltraButton optionsButton;
        private Infragistics.Win.Misc.UltraPopupControlContainer errorPopup;
        private Infragistics.Win.Misc.UltraPopupControlContainer optionsPopup;
        private Infragistics.Win.Misc.UltraDropDownButton scrobbleDropdown;
        private Infragistics.Win.Misc.UltraPopupControlContainer scrobbleDropdownPopup;
        private Infragistics.Win.Misc.UltraDropDownButton removeDropdown;
        private Infragistics.Win.Misc.UltraButton RefreshButton;
        private Infragistics.Win.Misc.UltraLabel infoLabel;
        private Infragistics.Win.Misc.UltraPopupControlContainer removePopup;
        private System.Windows.Forms.ProgressBar progressBar;
        private Infragistics.Win.Misc.UltraDropDownButton addDropButton;
        private Infragistics.Win.Misc.UltraDropDownButton selectionDropdown;
        private Infragistics.Win.Misc.UltraButton quitButton;
        private Infragistics.Win.Misc.UltraButton openCue;
        private Infragistics.Win.Misc.UltraPopupControlContainer addDropdownPopup;
        private Infragistics.Win.Misc.UltraPopupControlContainer selectionDropdownPopup;
        private Infragistics.Win.Misc.UltraLabel labelStats;
        private Infragistics.Win.Misc.UltraButton treeFullButton;
        private Infragistics.Win.Misc.UltraButton tracksFullButton;
        private Infragistics.Win.Misc.UltraButton editFields;
        private Infragistics.Win.Misc.UltraPanel editPanel;
        private Infragistics.Win.Misc.UltraButton applyEdit;
        private System.Windows.Forms.Label trackLabel;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.TextBox trackNew;
        private System.Windows.Forms.TextBox albumNew;
        private System.Windows.Forms.TextBox artistNew;
        private System.Windows.Forms.CheckBox checkAlbum;
        private System.Windows.Forms.CheckBox checkArtist;
        private System.Windows.Forms.CheckBox checkTrack;
    }
}

