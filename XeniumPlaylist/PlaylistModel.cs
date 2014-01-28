using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace XeniumPlaylist
{
    public class StringListFile
    {
        protected int blockSize;

        protected List<string> items = new List<string>();
        public List<string> Items { get { return items; } }

        public StringListFile(int blockSize)
        {
            this.blockSize = blockSize;
        }

        public void Load(string fileName)
        {
            items.Clear();

            if (!File.Exists(fileName))
                return;
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                byte[] nameBuffer;
                char[] charsToTrim = { '\0' };
                while ((nameBuffer = reader.ReadBytes(blockSize)).Length == blockSize)
                {
                    string itemName = Encoding.Unicode.GetString(nameBuffer).TrimEnd(charsToTrim);
                    items.Add(itemName);
                }
            }
        }

        public void Save(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            FileAttributes fileAttributes = fileInfo.Attributes;
            fileInfo.Attributes &= ~FileAttributes.Hidden;
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    foreach (string itemName in items)
                    {
                        byte[] nameBuffer = Encoding.Unicode.GetBytes(itemName);
                        Array.Resize(ref nameBuffer, blockSize);
                        writer.Write(nameBuffer);
                    }
                }
            }
            finally
            {
                fileInfo.Attributes = fileAttributes;
            }
        }
    }

    public class PlaylistSet
    {
        protected StringListFile stringListFile = new StringListFile(512);
        protected string driveName = null;

        public List<string> Items { get { return stringListFile.Items; } }

        public static string GetPlaylistSetFileName(string driveName)
        {
            return Path.Combine(driveName, "@playlist@", "audio_play_playlist_name.txt");
        }

        public void Load(string driveName)
        {
            this.driveName = driveName;
            if (driveName != null)
            {
                stringListFile.Load(GetPlaylistSetFileName(driveName));
                Items.Sort();
            }
        }

        public void Load()
        {
            Load(driveName);
        }

        public void Save()
        {
            if (driveName != null)
                stringListFile.Save(GetPlaylistSetFileName(driveName));
        }

        public void Add(string itemName)
        {
            if (driveName != null)
            {
                Items.Add(itemName);
                Items.Sort();
                Save();
                
                string fileName = Playlist.GetPlaylistFileName(driveName, itemName);
                File.Create(fileName).Close();
                FileInfo fileInfo = new FileInfo(fileName);
                fileInfo.Attributes |= FileAttributes.Hidden;
            }
        }

        public void Delete(int itemIndex)
        {
            if ((driveName != null) && (itemIndex >= 0))
            {
                string itemName = Items[itemIndex];
                Items.RemoveAt(itemIndex);
                Save();

                string fileName = Playlist.GetPlaylistFileName(driveName, itemName);
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
        }

        public void Rename(int itemIndex, string itemName)
        {
            if ((driveName != null) && (itemIndex >= 0) && (!Items.Contains(itemName)))
            {
                string oldItemName = Items[itemIndex];

                Items[itemIndex] = itemName;
                Items.Sort();
                Save();

                string oldFileName = Playlist.GetPlaylistFileName(driveName, oldItemName);
                string fileName = Playlist.GetPlaylistFileName(driveName, itemName);
                if (File.Exists(oldFileName))
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    File.Move(oldFileName, fileName);
                }
            }
        }
    }

    public class Playlist
    {
        protected StringListFile stringListFile = new StringListFile(522);
        protected string driveName = null;

        public List<string> Items { get { return stringListFile.Items; } }

        public static string GetPlaylistFileName(string driveName, string playlistName)
        {
            return Path.Combine(driveName, "@playlist@", playlistName + "00.txt");
        }

        public void Load(string driveName, string playlistName)
        {
            if (driveName != null)
                //stringListFile.Load(Directory.GetFiles(Path.Combine(driveName, "@playlist@"), playlistName + "*.txt").First());
                stringListFile.Load(GetPlaylistFileName(driveName, playlistName));
        }

        public void Save(string driveName, string playlistName)
        {
            if (driveName != null)
                stringListFile.Save(GetPlaylistFileName(driveName, playlistName));
        }
    }    
}
