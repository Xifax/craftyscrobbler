using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.Misc;
using System.Threading;
using LastFmLib.Scrobbler;
using LastFmLib.TypeClasses;
using LastFmLib;

namespace CraftyScrobbler
{
    public partial class DataScrobble : Form
    {

        private DateTime date = new DateTime();
        private TimeSpan time = new TimeSpan();

        private DateTime rTime = new DateTime();

        private object[] files = null;
        private string username = null;
        private string password = null;

        ScrobblerManager sm = new ScrobblerManager();

        public DataScrobble(object[] files, string username, string password, ScrobblerManager sm)
        {
            InitializeComponent();

            this.files = files;
            this.username = username;
            this.password = password;

            this.sm = sm;
        }

        private DateTime countTotalTime(DateTime beginning)
        {
            TimeSpan total = new TimeSpan(0,0,0);

            try {
                foreach (object file in this.files)
                {
                    UltraListViewItem item = (UltraListViewItem)file;
                    total = total.Add(new TimeSpan(TimeSpan.Parse(item.SubItems[3].Value.ToString()).Ticks * (int)item.SubItems[4].Value));
                }
            } catch {}

            return beginning.Add(total);
        }

        private void calendarDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {

                date = e.Start.Date;
                time = TimeSpan.Parse(timeField.Text);

                rTime = date.Add(time);

                resultingTime.Text = rTime.ToString() + " -- " + countTotalTime(rTime).ToString();
            }
            catch { }
        }

        private void cancelScrobble_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scrobbleOnThisDate_Click(object sender, EventArgs e)
        {
            if (files.Length > 50)
            {
                MessageBox.Show("Scrobbling more than 50 tracks - last.fm response may be lagged.", "Tracks, a lot!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            C5.ArrayList<TrackInfo> tracks = new C5.ArrayList<TrackInfo>();

            try
            {
                foreach (object file in this.files)
                {
                    UltraListViewItem item = (UltraListViewItem)file;

                    TrackInfo info = new TrackInfo(item.SubItems[1].Value.ToString(), item.SubItems[2].Value.ToString(), item.SubItems[0].Value.ToString());    //artist (!empty), album (may be empty), title (!empty)
                    info.Username = this.username;
                    info.Duration = (int)TimeSpan.Parse(item.SubItems[3].Value.ToString()).TotalSeconds;
                    info.SourceString = "P";

                    info.SetTimeStamp((long) UnixTime.GetUnixTimeOfDate(rTime).TotalSeconds);

                    rTime = rTime.AddSeconds(info.Duration + 10 * ( (new Random() ).NextDouble() ) );

                    for (int i = 0; i < (int)item.SubItems[4].Value; i++)
                        tracks.Add(info);
                }

                //for (int j = 0; j < files.Length; j++)
                //{
                    tracks.Shuffle();
                //}

                ScrobblerCache cache = new ScrobblerCache(this.username);
                cache.Append(new List<TrackInfo>(tracks.ToArray()), true);

                sm.Scrobble(ref cache);

                if (MessageBox.Show("Scrobbled successfully! Close date scrobble dialog? ", "Oll Korrect", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Something happened!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timeField_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                date = calendarDate.SelectionStart.Date;
                time = TimeSpan.Parse(timeField.Text);

                rTime = date.Add(time);

                resultingTime.Text = rTime.ToString() + " -- " + countTotalTime(rTime).ToString();
            }
            catch { }
        }
    }
}
