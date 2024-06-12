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

namespace DEMO_WPF.NET8.Template
{
    /// <summary>
    /// Логика взаимодействия для ViewTemplate.xaml
    /// </summary>
    public partial class ViewTemplate : Window
    {
        public ViewTemplate()
        {
            InitializeComponent();
            DataContext = new ViewModelTemplate();
        }
    }
}
