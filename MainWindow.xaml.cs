using DEMO_WPF.NET8.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEMO_WPF.NET8
{
    public partial class MainWindow : Window
    {
        public MainWindow(int s)
        {
            InitializeComponent();

            if (s == 1)
                MainFrame.Navigate(new AdminPage());
            else
                MainFrame.Navigate(new WorkerPage());

        }
    }
}