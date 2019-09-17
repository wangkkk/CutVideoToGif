using CutVideoToGif.ViewModel;
using System.Windows;

namespace CutVideoToGif
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
