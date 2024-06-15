using DEMO_WPF.NET8.Models;
using DEMO_WPF.NET8.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEMO_WPF.NET8.Views
{
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            DataContext = new AdminVM();
            
            InitializeComponent();
        }

        private void ForwardClick(object sender, RoutedEventArgs e)
        {
            BorderStats.Visibility = Visibility.Visible;
        }

        private void BackCkick(object sender, RoutedEventArgs e)
        {
            BorderStats.Visibility = Visibility.Hidden;
        }
    }

    public class AdminVM : ViewModelBase
    {
        private readonly ServiceHardContext _db;

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get { return _requests; }
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        private Request _selectedItem;
        public Request SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }

        private int _averageTime;
        public int AverageTime
        {
            get { return _averageTime; }
            set
            {
                _averageTime = value;
                OnPropertyChanged(nameof(AverageTime));
            }
        }
        private int _allCount;
        public int AllCount
        {
            get { return _allCount; }
            set
            {
                _allCount = value;
                OnPropertyChanged(nameof(AllCount));
            }
        }

        public ICommand AddCommand {  get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ReloadCommand { get; set; }


        public AdminVM()
        {
            _db = new ServiceHardContext();

            ReloadList();
            AddCommand = new RelayCommand(AddExecute);
            SaveCommand = new RelayCommand(SaveExecute);
            ReloadCommand = new RelayCommand(ReloadExecute);
        }

        public void ReloadExecute(object parameter)
        {
            ReloadList();
        }

        public void AddExecute(object parameter)
        {
            Window window = new AddRequestWindow();
            window.Show();
        }

        public void SaveExecute(object parameter)
        {
            if (SelectedItem.Worker != null && SelectedItem.Status != "Выполнено")
            {
                SelectedItem.DateAllows = DateTime.Now;
                SelectedItem.Status = "В работе";
            }

            _db.SaveChanges();
        }

        public void ReloadList()
        {
            _db.Requests.Load();
            Requests = _db.Requests.ToObservableCollection();
        }
    }
}
