using DEMO_WPF.NET8.Models;
using System;
using System.Collections.Generic;
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

namespace DEMO_WPF.NET8.Views
{
    /// <summary>
    /// Логика взаимодействия для AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {
        private readonly ServiceHardContext _db;

        public AddRequestWindow()
        {
            InitializeComponent();
            _db = new ServiceHardContext();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {

            var objcet = new Request
            {
                TechType = techTypeTB.Text,
                TechName = techNameTB.Text,
                Customer = techNameTB.Text,
                DateStart = DateTime.Now,
                Status = "В ожидании"
            };
            _db.Requests.Add(objcet);
            _db.SaveChanges();
            AdminVM adminVM = new AdminVM();

            App.IsAdmin = false;
            adminVM.ReloadList();
            this.Close();
        }
    }
}
