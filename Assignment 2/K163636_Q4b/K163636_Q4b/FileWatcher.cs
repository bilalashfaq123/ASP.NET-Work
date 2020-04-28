using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q4b
{
    public class FileWatcher
    {
        private FileSystemWatcher _fileSystemWatcher;

        public FileWatcher()
        {
            this._fileSystemWatcher = new FileSystemWatcher(getPath());
            _fileSystemWatcher.Changed += new FileSystemEventHandler(fileSystemWatcher_changed);
        }

        public string getPath()
        {
            string path = ConfigurationSettings.AppSettings["Path"].ToString();
            return path;
        }

        private void fileSystemWatcher_changed(object sender, FileSystemEventArgs e)
        {
            
        }
    }
}
