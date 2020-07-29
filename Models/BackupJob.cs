using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmBackup.Models
{
    public class BackupJob
    {
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public string FileMask { get; set; }
        public bool SubDirectories { get; set; }
        public bool EmptySubDirectories { get; set; }
        public bool Purge { get; set; }
        public bool Mirror { get; set; }
        public bool MoveFiles { get; set; }
        public bool Move { get; set; }
        public bool Archive { get; set; }
        public bool ArchiveReset { get; set; }
        public bool ExcludeChangedFiles { get; set; }
        public bool ExcludeNewFiles { get; set; }
    }
}
