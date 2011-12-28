namespace CraftyScrobbler
{
    partial class DataScrobble
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.calendarDate = new System.Windows.Forms.MonthCalendar();
            this.timeField = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.resultingTime = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.scrobbleOnThisDate = new Infragistics.Win.Misc.UltraButton();
            this.cancelScrobble = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // calendarDate
            // 
            this.calendarDate.Location = new System.Drawing.Point(18, 39);
            this.calendarDate.Name = "calendarDate";
            this.calendarDate.TabIndex = 1;
            this.calendarDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarDate_DateSelected);
            // 
            // timeField
            // 
            this.timeField.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista;
            this.timeField.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.timeField.InputMask = "{longtime}";
            this.timeField.Location = new System.Drawing.Point(18, 242);
            this.timeField.Name = "timeField";
            this.timeField.Size = new System.Drawing.Size(227, 20);
            this.timeField.TabIndex = 2;
            this.timeField.Text = "ultraMaskedEdit1";
            this.timeField.ValueChanged += new System.EventHandler(this.timeField_ValueChanged);
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(18, 13);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(227, 23);
            this.ultraLabel1.TabIndex = 3;
            this.ultraLabel1.Text = "Date";
            // 
            // ultraLabel2
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.Location = new System.Drawing.Point(18, 213);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(227, 23);
            this.ultraLabel2.TabIndex = 4;
            this.ultraLabel2.Text = "Time";
            // 
            // resultingTime
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.resultingTime.Appearance = appearance3;
            this.resultingTime.BorderStyle = Infragistics.Win.UIElementBorderStyle.WindowsVista;
            this.resultingTime.Location = new System.Drawing.Point(18, 268);
            this.resultingTime.Name = "resultingTime";
            this.resultingTime.ReadOnly = true;
            this.resultingTime.Size = new System.Drawing.Size(227, 62);
            this.resultingTime.TabIndex = 5;
            this.resultingTime.Value = "<span style=\"font-size:+2pt;\">Selected <span style=\"font-weight:bold;\">date <span" +
                " style=\"font-weight:normal;\">&amp; <span style=\"font-weight:bold;\">time</span></" +
                "span></span></span>";
            // 
            // scrobbleOnThisDate
            // 
            this.scrobbleOnThisDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.scrobbleOnThisDate.Location = new System.Drawing.Point(18, 337);
            this.scrobbleOnThisDate.Name = "scrobbleOnThisDate";
            this.scrobbleOnThisDate.Size = new System.Drawing.Size(227, 23);
            this.scrobbleOnThisDate.TabIndex = 6;
            this.scrobbleOnThisDate.Text = "Scrobble!";
            this.scrobbleOnThisDate.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.scrobbleOnThisDate.Click += new System.EventHandler(this.scrobbleOnThisDate_Click);
            // 
            // cancelScrobble
            // 
            this.cancelScrobble.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.cancelScrobble.Location = new System.Drawing.Point(18, 367);
            this.cancelScrobble.Name = "cancelScrobble";
            this.cancelScrobble.Size = new System.Drawing.Size(227, 23);
            this.cancelScrobble.TabIndex = 7;
            this.cancelScrobble.Text = "Cancel";
            this.cancelScrobble.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cancelScrobble.Click += new System.EventHandler(this.cancelScrobble_Click);
            // 
            // DataScrobble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 402);
            this.Controls.Add(this.cancelScrobble);
            this.Controls.Add(this.scrobbleOnThisDate);
            this.Controls.Add(this.resultingTime);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.timeField);
            this.Controls.Add(this.calendarDate);
            this.Name = "DataScrobble";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataScrobble";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendarDate;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit timeField;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor resultingTime;
        private Infragistics.Win.Misc.UltraButton scrobbleOnThisDate;
        private Infragistics.Win.Misc.UltraButton cancelScrobble;
    }
}