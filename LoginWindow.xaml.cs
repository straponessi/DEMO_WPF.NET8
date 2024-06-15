using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DEMO_WPF.NET8
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            if (loginTB.Text == "admin" && passwordTB.Text == "admin")
            {
                App.IsAdmin = true;
                MainWindow window = new MainWindow(1);
                window.Show();
                this.Close();
            }
            else if (loginTB.Text == "worker" && passwordTB.Text == "worker")
            {
                App.IsAdmin = false;
                MainWindow window = new MainWindow(2);
                window.Show();
                this.Close();
            }
            else
                MessageBox.Show("Введите корректные значения");

        }
    }
}
