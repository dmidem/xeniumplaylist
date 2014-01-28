using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;


namespace XeniumPlaylist
{
    public partial class frmPlaylist : Form
    {
        class DriveItem
        {
            public string Name { get; set; }
            public int? InternalIndex { get; set; }
        };

        //ResourceManager rm = new ResourceManager("XeniumPlaylist.PlaylistResource", typeof(PlaylistResource).Assembly);

        PlaylistSet playlistSet = new PlaylistSet();
        Playlist playlist = new Playlist();        

        /*
            Form actions
        */

        public frmPlaylist()
        {
            InitializeComponent();
        }

        private void frmPlaylist_Load(object sender, EventArgs e)
        {
            btnCreatePlaylist.Enabled = false;
            btnRemovePlaylist.Enabled = false;
            btnRenamePlaylist.Enabled = false;

            btnSavePlaylistChanges.Enabled = false;
            btnCancelPlaylistChanges.Enabled = false;

            LoadDrives();
        }

        private void frmPlaylist_Resize(object sender, EventArgs e)
        {
            AdjustPlaylistControl();
        }

        /*
            Phone drive actions
        */

        private void LoadDrives()
        {
            try
            {
                // Get drive list and detect internal drive name by it's size
                var driveItems = DriveInfo.GetDrives().Where(d => (d.DriveType == DriveType.Removable) && (d.IsReady == true) && Directory.Exists(Path.Combine(d.Name, "@playlist@"))).Select(d => new { Name = d.Name, Size = d.TotalSize }).ToArray();                
                long minSize = (driveItems.Length > 0 ? driveItems.Min(d => d.Size) : 0);
                long maxSize = (driveItems.Length > 0 ? driveItems.Max(d => d.Size) : 0);

                cboDrive.Items.Clear();
                cboDrive.DisplayMember = "Name";
                cboDrive.ValueMember = "InternalIndex";
                cboDrive.Items.AddRange(driveItems.Select(d => new DriveItem { Name = d.Name, InternalIndex = (d.Size == minSize ? (int?)0 : (d.Size == maxSize ? (int?)1 : null)) }).ToArray());
                cboDrive.SelectedIndex = (cboDrive.Items.Count > 0 ? 0 : -1);
                if (cboDrive.SelectedIndex == -1)
                    cboDrive_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void cboDrive_DropDown(object sender, EventArgs e)
        {
            if (cboDrive.Items.Count == 0)
                LoadDrives();
        }

        private void cboDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboIntDrive.SelectedIndex = ((cboDrive.SelectedItem != null) && (((DriveItem)cboDrive.SelectedItem).InternalIndex != null) ? (int)((DriveItem)cboDrive.SelectedItem).InternalIndex : -1);
            cboIntDrive.Enabled = (cboDrive.SelectedIndex >= 0);
            LoadPlaylistSet(cboDrive.Text);
        }


        /*
            Playlist set actions
        */

        private void LoadPlaylistSet(string driveName)
        {
            try
            {
                cboPlaylistSet.Items.Clear();
                playlistSet.Load(driveName);
                cboPlaylistSet.Items.AddRange(playlistSet.Items.ToArray());
                cboPlaylistSet.SelectedIndex = (cboPlaylistSet.Items.Count > 0 ? 0 : -1);
                if (cboPlaylistSet.SelectedIndex == -1)
                    cboPlaylistSet_SelectedIndexChanged(null, null);
                cboPlaylistSet.Enabled = (cboDrive.SelectedIndex >= 0);
                btnCreatePlaylist.Enabled = (cboDrive.SelectedIndex >= 0);
                btnRemovePlaylist.Enabled = (cboPlaylistSet.SelectedIndex >= 0);
                btnRenamePlaylist.Enabled = (cboPlaylistSet.SelectedIndex >= 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void SavePlaylistSet(string driveName)
        {
            try
            {
                playlistSet.Items.Clear();
                playlistSet.Items.AddRange(cboPlaylistSet.Items.OfType<string>());
                playlistSet.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void CreatePlaylist()
        {
            try
            {
                //string playlistName = InputBox.Show(ttpCommon.GetToolTip(btnCreatePlaylist), "Playlist name:", "");
                //string playlistName = InputBox.Show(ttpCommon.GetToolTip(btnCreatePlaylist), rm.GetString("strPlaylistNamePrompt"), "");
                string playlistName = InputBox.Show(ttpCommon.GetToolTip(btnCreatePlaylist), PlaylistResource.PlaylistNamePrompt, "");
                if (playlistName != "")
                {
                    playlistSet.Add(playlistName);
                    LoadPlaylistSet(cboDrive.Text);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void RemovePlaylist(int playlistIndex)
        {
            try
            {
                //if (MessageBox.Show("Are you sure to remove playlist?", ttpCommon.GetToolTip(btnRemovePlaylist), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                if (MessageBox.Show(PlaylistResource.PlaylistRemoveConfirmPrompt, ttpCommon.GetToolTip(btnRemovePlaylist), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    playlistSet.Delete(playlistIndex);
                    LoadPlaylistSet(cboDrive.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void RenamePlaylist(int playlistIndex)
        {
            try
            {
                //string playlistName = InputBox.Show(ttpCommon.GetToolTip(btnRenamePlaylist), "Playlist name:", cboPlaylistSet.Text);
                string playlistName = InputBox.Show(ttpCommon.GetToolTip(btnRenamePlaylist), PlaylistResource.PlaylistNamePrompt, cboPlaylistSet.Text);
                if (playlistName != "")
                {
                    playlistSet.Rename(playlistIndex, playlistName);
                    LoadPlaylistSet(cboDrive.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void cboPlaylistSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlaylist(cboDrive.Text, cboPlaylistSet.Text);
        }

        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            CreatePlaylist();
        }

        private void btnRemovePlaylist_Click(object sender, EventArgs e)
        {
            RemovePlaylist(cboPlaylistSet.SelectedIndex);
        }

        private void btnRenamePlaylist_Click(object sender, EventArgs e)
        {
            RenamePlaylist(cboPlaylistSet.SelectedIndex);
        }


        /*
            Playlist actions
        */

        private void LoadPlaylist(string driveName, string playlistName)
        {
            try
            {
                playlist.Load(driveName, playlistName);

                lvwPlaylist.BeginUpdate();
                lvwPlaylist.Items.Clear();                
                foreach (string s in playlist.Items)
                    //lvwPlaylist.Items.Add(new ListViewItem(s));
                    lvwPlaylist.Items.Add(s);                
                if (lvwPlaylist.Items.Count > 0)
                    lvwPlaylist.Items[0].Selected = true;
                AdjustPlaylistControl();
                lvwPlaylist.EndUpdate();

                lvwPlaylist.Enabled = ((cboDrive.SelectedIndex >= 0) && (cboPlaylistSet.SelectedIndex >= 0));
                btnSavePlaylistChanges.Enabled = false;
                btnCancelPlaylistChanges.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void SavePlaylist(string driveName, string playlistName)
        {
            try
            {
                playlist.Items.Clear();
                //playlist.Items.AddRange(lstPlaylist.Items.OfType<string>());
                playlist.Items.AddRange(lvwPlaylist.Items.OfType<ListViewItem>().Select(i => i.Text));
                playlist.Save(driveName, playlistName);
                btnSavePlaylistChanges.Enabled = false;
                btnCancelPlaylistChanges.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, PlaylistResource.ErrorMessageBoxCaption);
            }
        }

        private void AdjustPlaylistControl()
        {
            lvwPlaylist.Columns[0].Width = lvwPlaylist.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4;
        }

        private void btnSavePlaylistChanges_Click(object sender, EventArgs e)
        {
            SavePlaylist(cboDrive.Text, cboPlaylistSet.Text);
        }

        private void btnCancelPlaylistChanges_Click(object sender, EventArgs e)
        {
            LoadPlaylist(cboDrive.Text, cboPlaylistSet.Text);
        }

        private void lvwPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) && (e.Modifiers == Keys.None))
                foreach (int i in lvwPlaylist.SelectedIndices.OfType<int>().OrderByDescending(i => i))
                    lvwPlaylist.Items.RemoveAt(i);
            btnSavePlaylistChanges.Enabled = true;
            btnCancelPlaylistChanges.Enabled = true;
        }

        private void lvwPlaylist_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvwPlaylist.DoDragDrop(lvwPlaylist.SelectedIndices, DragDropEffects.Move);
        }

        private void lvwPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            if (cboPlaylistSet.SelectedIndex == -1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(typeof(ListView.SelectedIndexCollection)))
                e.Effect = DragDropEffects.Move;
            else
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                    e.Effect = DragDropEffects.All;
                else
                    e.Effect = DragDropEffects.None;
        }

        private void lvwPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            //Point p = lvwPlaylist.PointToClient(new Point(e.X, e.Y));
            ListViewItem lvi = lvwPlaylist.GetItemAt(0, lvwPlaylist.PointToClient(new Point(e.X, e.Y)).Y);
            int dropIndex = (lvi != null ? lvi.Index : lvwPlaylist.Items.Count);
            int dropCount = 0;

            lvwPlaylist.BeginUpdate();

            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files != null)
            {
                int fileCount = 0;
                foreach (string s in files)
                    if (s.StartsWith(cboDrive.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (Directory.Exists(s))
                            //lvwPlaylist.Items.AddRange(Directory.GetFiles(s).Select(f => cboIntDrive.Text + f.Substring(cboDrive.Text.Length)).ToArray());
                            foreach (string f in Directory.GetFiles(s).Select(f => cboIntDrive.Text + f.Substring(cboDrive.Text.Length)))
                            {
                                lvwPlaylist.Items.Insert(dropIndex++, f);
                                dropCount++;
                            }
                        else
                        {
                            lvwPlaylist.Items.Insert(dropIndex++, cboIntDrive.Text + s.Substring(cboDrive.Text.Length));
                            dropCount++;
                        }
                        fileCount++;
                    }
                if (fileCount == 0)
                    MessageBox.Show(String.Format(PlaylistResource.PlaylistFileDragDropErrorText, cboDrive.Text), PlaylistResource.ErrorMessageBoxCaption);
            }

            var items = (ListView.SelectedIndexCollection)e.Data.GetData(typeof(ListView.SelectedIndexCollection));
            if (items != null)
            {
                int delta = 0;
                foreach (int selectedIndex in items)
                {
                    int i = selectedIndex - delta;
                    if (dropIndex != i)
                    {
                        lvwPlaylist.Items.Insert(dropIndex, new ListViewItem(lvwPlaylist.Items[i].Text)).Selected = true;
                        if (dropIndex < i)
                        {
                            lvwPlaylist.Items.RemoveAt(i + 1);
                            dropIndex++;
                        }
                        else
                        {
                            lvwPlaylist.Items.RemoveAt(i);
                            delta++;
                        }
                    }
                    dropCount++;
                }
            }

            if (dropCount > 0)
            {
                btnSavePlaylistChanges.Enabled = true;
                btnCancelPlaylistChanges.Enabled = true;
            }

            //AdjustPlaylistControl();
            lvwPlaylist.EndUpdate();
        }

        private void lvwPlaylist_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {            
            const int scroll_margin = 5;

            Point p = lvwPlaylist.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            ListViewItem lvi = lvwPlaylist.GetItemAt(0, p.Y);
            int i = (lvi != null ? lvi.Index : lvwPlaylist.Items.Count);
            int h = lvwPlaylist.ClientRectangle.Height;

            if ((p.Y < scroll_margin) && (i > 0))
                lvwPlaylist.Items[i - 1].EnsureVisible();
            else
                if ((p.Y > h - scroll_margin) && (i < lvwPlaylist.Items.Count - 1))
                    lvwPlaylist.Items[i + 1].EnsureVisible();
        }
    }
}
