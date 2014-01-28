namespace XeniumPlaylist
{
    partial class frmPlaylist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlaylist));
            this.dlgAudioFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.cboDrive = new System.Windows.Forms.ComboBox();
            this.cboPlaylistSet = new System.Windows.Forms.ComboBox();
            this.lblDrive = new System.Windows.Forms.Label();
            this.lblPlaylistSet = new System.Windows.Forms.Label();
            this.cboIntDrive = new System.Windows.Forms.ComboBox();
            this.lblIntDrive = new System.Windows.Forms.Label();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.btnRemovePlaylist = new System.Windows.Forms.Button();
            this.btnSavePlaylistChanges = new System.Windows.Forms.Button();
            this.btnCancelPlaylistChanges = new System.Windows.Forms.Button();
            this.btnRenamePlaylist = new System.Windows.Forms.Button();
            this.ttpCommon = new System.Windows.Forms.ToolTip(this.components);
            this.lvwPlaylist = new System.Windows.Forms.ListView();
            this.clhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // dlgAudioFolder
            // 
            resources.ApplyResources(this.dlgAudioFolder, "dlgAudioFolder");
            // 
            // cboDrive
            // 
            resources.ApplyResources(this.cboDrive, "cboDrive");
            this.cboDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrive.FormattingEnabled = true;
            this.cboDrive.Name = "cboDrive";
            this.ttpCommon.SetToolTip(this.cboDrive, resources.GetString("cboDrive.ToolTip"));
            this.cboDrive.DropDown += new System.EventHandler(this.cboDrive_DropDown);
            this.cboDrive.SelectedIndexChanged += new System.EventHandler(this.cboDrive_SelectedIndexChanged);
            // 
            // cboPlaylistSet
            // 
            resources.ApplyResources(this.cboPlaylistSet, "cboPlaylistSet");
            this.cboPlaylistSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlaylistSet.FormattingEnabled = true;
            this.cboPlaylistSet.Name = "cboPlaylistSet";
            this.ttpCommon.SetToolTip(this.cboPlaylistSet, resources.GetString("cboPlaylistSet.ToolTip"));
            this.cboPlaylistSet.SelectedIndexChanged += new System.EventHandler(this.cboPlaylistSet_SelectedIndexChanged);
            // 
            // lblDrive
            // 
            resources.ApplyResources(this.lblDrive, "lblDrive");
            this.lblDrive.Name = "lblDrive";
            this.ttpCommon.SetToolTip(this.lblDrive, global::XeniumPlaylist.PlaylistResource.PlaylistFileDragDropErrorText);
            // 
            // lblPlaylistSet
            // 
            resources.ApplyResources(this.lblPlaylistSet, "lblPlaylistSet");
            this.lblPlaylistSet.Name = "lblPlaylistSet";
            this.ttpCommon.SetToolTip(this.lblPlaylistSet, global::XeniumPlaylist.PlaylistResource.PlaylistFileDragDropErrorText);
            // 
            // cboIntDrive
            // 
            resources.ApplyResources(this.cboIntDrive, "cboIntDrive");
            this.cboIntDrive.BackColor = System.Drawing.SystemColors.Control;
            this.cboIntDrive.FormattingEnabled = true;
            this.cboIntDrive.Items.AddRange(new object[] {
            resources.GetString("cboIntDrive.Items"),
            resources.GetString("cboIntDrive.Items1")});
            this.cboIntDrive.Name = "cboIntDrive";
            this.ttpCommon.SetToolTip(this.cboIntDrive, resources.GetString("cboIntDrive.ToolTip"));
            // 
            // lblIntDrive
            // 
            resources.ApplyResources(this.lblIntDrive, "lblIntDrive");
            this.lblIntDrive.Name = "lblIntDrive";
            this.ttpCommon.SetToolTip(this.lblIntDrive, global::XeniumPlaylist.PlaylistResource.PlaylistFileDragDropErrorText);
            // 
            // btnCreatePlaylist
            // 
            resources.ApplyResources(this.btnCreatePlaylist, "btnCreatePlaylist");
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.TabStop = false;
            this.ttpCommon.SetToolTip(this.btnCreatePlaylist, resources.GetString("btnCreatePlaylist.ToolTip"));
            this.btnCreatePlaylist.UseVisualStyleBackColor = true;
            this.btnCreatePlaylist.Click += new System.EventHandler(this.btnCreatePlaylist_Click);
            // 
            // btnRemovePlaylist
            // 
            resources.ApplyResources(this.btnRemovePlaylist, "btnRemovePlaylist");
            this.btnRemovePlaylist.Name = "btnRemovePlaylist";
            this.btnRemovePlaylist.TabStop = false;
            this.ttpCommon.SetToolTip(this.btnRemovePlaylist, resources.GetString("btnRemovePlaylist.ToolTip"));
            this.btnRemovePlaylist.UseVisualStyleBackColor = true;
            this.btnRemovePlaylist.Click += new System.EventHandler(this.btnRemovePlaylist_Click);
            // 
            // btnSavePlaylistChanges
            // 
            resources.ApplyResources(this.btnSavePlaylistChanges, "btnSavePlaylistChanges");
            this.btnSavePlaylistChanges.Name = "btnSavePlaylistChanges";
            this.btnSavePlaylistChanges.TabStop = false;
            this.ttpCommon.SetToolTip(this.btnSavePlaylistChanges, resources.GetString("btnSavePlaylistChanges.ToolTip"));
            this.btnSavePlaylistChanges.UseVisualStyleBackColor = true;
            this.btnSavePlaylistChanges.Click += new System.EventHandler(this.btnSavePlaylistChanges_Click);
            // 
            // btnCancelPlaylistChanges
            // 
            resources.ApplyResources(this.btnCancelPlaylistChanges, "btnCancelPlaylistChanges");
            this.btnCancelPlaylistChanges.Name = "btnCancelPlaylistChanges";
            this.btnCancelPlaylistChanges.TabStop = false;
            this.ttpCommon.SetToolTip(this.btnCancelPlaylistChanges, resources.GetString("btnCancelPlaylistChanges.ToolTip"));
            this.btnCancelPlaylistChanges.UseVisualStyleBackColor = true;
            this.btnCancelPlaylistChanges.Click += new System.EventHandler(this.btnCancelPlaylistChanges_Click);
            // 
            // btnRenamePlaylist
            // 
            resources.ApplyResources(this.btnRenamePlaylist, "btnRenamePlaylist");
            this.btnRenamePlaylist.Name = "btnRenamePlaylist";
            this.btnRenamePlaylist.TabStop = false;
            this.ttpCommon.SetToolTip(this.btnRenamePlaylist, resources.GetString("btnRenamePlaylist.ToolTip"));
            this.btnRenamePlaylist.UseVisualStyleBackColor = true;
            this.btnRenamePlaylist.Click += new System.EventHandler(this.btnRenamePlaylist_Click);
            // 
            // ttpCommon
            // 
            this.ttpCommon.AutoPopDelay = 5000;
            this.ttpCommon.InitialDelay = 500;
            this.ttpCommon.ReshowDelay = 100;
            this.ttpCommon.ShowAlways = true;
            // 
            // lvwPlaylist
            // 
            resources.ApplyResources(this.lvwPlaylist, "lvwPlaylist");
            this.lvwPlaylist.AllowDrop = true;
            this.lvwPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhName});
            this.lvwPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwPlaylist.Name = "lvwPlaylist";
            this.ttpCommon.SetToolTip(this.lvwPlaylist, resources.GetString("lvwPlaylist.ToolTip"));
            this.lvwPlaylist.UseCompatibleStateImageBehavior = false;
            this.lvwPlaylist.View = System.Windows.Forms.View.Details;
            this.lvwPlaylist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwPlaylist_ItemDrag);
            this.lvwPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwPlaylist_DragDrop);
            this.lvwPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwPlaylist_DragEnter);
            this.lvwPlaylist.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.lvwPlaylist_QueryContinueDrag);
            this.lvwPlaylist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwPlaylist_KeyDown);
            // 
            // clhName
            // 
            resources.ApplyResources(this.clhName, "clhName");
            // 
            // frmPlaylist
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwPlaylist);
            this.Controls.Add(this.btnRenamePlaylist);
            this.Controls.Add(this.btnCancelPlaylistChanges);
            this.Controls.Add(this.btnSavePlaylistChanges);
            this.Controls.Add(this.btnRemovePlaylist);
            this.Controls.Add(this.btnCreatePlaylist);
            this.Controls.Add(this.lblIntDrive);
            this.Controls.Add(this.cboIntDrive);
            this.Controls.Add(this.lblPlaylistSet);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.cboPlaylistSet);
            this.Controls.Add(this.cboDrive);
            this.Name = "frmPlaylist";
            this.ttpCommon.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmPlaylist_Load);
            this.Resize += new System.EventHandler(this.frmPlaylist_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog dlgAudioFolder;
        private System.Windows.Forms.ComboBox cboDrive;
        private System.Windows.Forms.ComboBox cboPlaylistSet;
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.Label lblPlaylistSet;
        private System.Windows.Forms.ComboBox cboIntDrive;
        private System.Windows.Forms.Label lblIntDrive;
        private System.Windows.Forms.Button btnCreatePlaylist;
        private System.Windows.Forms.Button btnRemovePlaylist;
        private System.Windows.Forms.Button btnSavePlaylistChanges;
        private System.Windows.Forms.Button btnCancelPlaylistChanges;
        private System.Windows.Forms.ToolTip ttpCommon;
        private System.Windows.Forms.Button btnRenamePlaylist;
        private System.Windows.Forms.ListView lvwPlaylist;
        private System.Windows.Forms.ColumnHeader clhName;
    }
}

