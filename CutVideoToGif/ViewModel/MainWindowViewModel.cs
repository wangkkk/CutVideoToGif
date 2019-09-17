using CutVideoToGif.Helper;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CutVideoToGif.ViewModel
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Property
       
        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                OnPropertyChanged();
            }
        }
        private double _VideoWidth;

        public double VideoWidth
        {
            get { return _VideoWidth; }
            set
            {
                _VideoWidth = value;
                OnPropertyChanged();
            }
        }

        private string _Filter;

        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                OnPropertyChanged();
            }
        }
        private string _Minute;

        public string Minute
        {
            get { return _Minute; }
            set
            {
                _Minute = value;
                OnPropertyChanged();
            }
        }

        private bool _MainEnable;

        public bool MainEnabled
        {
            get { return _MainEnable; }
            set
            {
                _MainEnable = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand StartCutVideoToGifCommand { get; set; }
        public MainWindowViewModel()
        {
            MainEnabled = true;
            FilePath = @"E:\shell\test";
            Filter = "mp4";
            Minute = "2.2";
            VideoWidth = 300;
            StartCutVideoToGifCommand=new RelayCommand(StartCutVideoToGifInvoke);
        }

        private void StartCutVideoToGifInvoke()
        {
            MainEnabled = false;
            Task.Factory.StartNew(() => { MainEnabled=VideoHelper.GenerateGif(FilePath, Filter, Minute, IsRandSelect); });
        }
    }
}
