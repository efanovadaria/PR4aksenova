using System.Windows;
using System.Windows.Navigation;

namespace PR4aksenova
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page1());
        }
    }
}
