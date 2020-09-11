using System;
using System.Diagnostics;
using System.Windows.Forms;
using Caliburn.Micro;
using mmBackup.ViewModels.Base;
using Screen = Caliburn.Micro.Screen;

namespace mmBackup.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        #region private fields

        private IWindowManager _windowManager;

        #endregion private fields

        public MainViewModel()
        {
            _windowManager = new WindowManager();
            Log = new BindableCollection<string>();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        #region properties

        public override string DisplayName
        {
            get
            {
                return "MainView";
            }
        }

        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public string FileMask { get; set; }
        public string CommandTextBlock { get; set; }
        public bool SubDirectories { get; set; }
        public bool EmptySubDirectories { get; set; }
        public bool Purge { get; set; }
        public bool Mirror { get; set; }
        public bool MoveFiles { get; set; }
        public bool Move { get; set; }
        public bool Archive { get; set; }
        public bool ArchiveReset { get; set; }
        public bool ExcludeChangedFiles{ get; set; }
        public bool ExcludeNewFiles { get; set; }
        
        public IObservableCollection<string> Log { get; set; }
        
        #endregion properties
        
        #region public methods

        public void OnSourcePathChanged()
        {
            GenerateCommand();
        }

        public void OnDestinationPathChanged()
        {
            GenerateCommand();
        }

        public void OnFileMaskChanged()
        {
            GenerateCommand();
        }

        public void OnSubDirectoriesChanged()
        {
            GenerateCommand();
        }

        public void OnEmptySubDirectoriesChanged()
        {
            GenerateCommand();
        }
        
        public void OnPurgeChanged()
        {
            GenerateCommand();
        }
        
        public void OnMirrorChanged()
        {
            GenerateCommand();
        }
        
        public void OnMoveFilesChanged()
        {
            GenerateCommand();
        }
        
        public void OnMoveChanged()
        {
            GenerateCommand();
        }
        
        public void OnArchiveChanged()
        {
            GenerateCommand();
        }
        
        public void OnArchiveResetChanged()
        {
            GenerateCommand();
        }
        
        public void OnExcludeChangedFilesChanged()
        {
            GenerateCommand();
        }
        
        public void OnExcludeNewFilesChanged()
        {
            GenerateCommand();
        }
        
        public override void New()
        {
            Reset();
        }
        
        public void OpenSourceDirectory()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SourcePath = dialog.SelectedPath;
                }
            }
        }

        public void OpenDestinationDirectory()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DestinationPath = dialog.SelectedPath;
                }
            }
        }

        public void Execute()
        {
            Log.Clear();
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.Arguments = CommandTextBlock;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                startInfo.FileName = "Robocopy.exe";
                startInfo.RedirectStandardOutput = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    AddToLog(line);
                }
            }
            catch (Exception ex)
            {
                AddToLog(ex.ToString());
            }
        }
        
        #endregion public methods

        #region private methods

        private void AddToLog(string message)
        {
            Log.Add(message);
            while (Log.Count > 1000)
            {
                Log.RemoveAt(0);
            }
        }

        private void Reset()
        {
            SourcePath = string.Empty;
            DestinationPath = string.Empty;
            FileMask = string.Empty;
            CommandTextBlock = string.Empty;
            SubDirectories = false;
            EmptySubDirectories = false;
            Purge = false;
            Mirror = false;
            MoveFiles = false;
            Move = false;
            Archive = false;
            ArchiveReset= false;
            ExcludeChangedFiles= false;
            ExcludeNewFiles= false;
        }

        private void GenerateCommand()
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(SourcePath) 
                || string.IsNullOrEmpty(DestinationPath))
            {
                CommandTextBlock = result;
                return;
            }
            else
            {
                result = $"{SourcePath} {DestinationPath} {FileMask}";
            }

            if (SubDirectories)
            {
                result = $"{result} /s";
            }

            if (EmptySubDirectories)
            {
                result = $"{result} /e";
            }

            if (Purge)
            {
                result = $"{result} /purge";
            }

            if (Mirror)
            {
                result = $"{result} /mir";
                EmptySubDirectories = false;
                Purge = false;
                result = result.Replace("/e", "");
                result = result.Replace("/purge", "");
            }

            if (MoveFiles)
            {
                result = $"{result} /mov";
            }
            
            if (Move)
            {
                result = $"{result} /move";
            }
            
            if (Archive)
            {
                result = $"{result} /a";
            }
            
            if (ArchiveReset)
            {
                result = $"{result} /m";
            }
            
            if (ExcludeChangedFiles)
            {
                result = $"{result} /xc";
            }

            if (ExcludeNewFiles)
            {
                result = $"{result} /xn";
            }

            CommandTextBlock = result;
        }

        #endregion private methods

        
    }
}
