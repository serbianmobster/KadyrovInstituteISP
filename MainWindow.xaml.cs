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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KadyrovInstituteISP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        InstituteEntities db = new InstituteEntities();

        void Update()
        {
            dg.ItemsSource = db.Students.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.ShowDialog();
            Update();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var currentStudent = dg.SelectedItem as Students;
            if (currentStudent != null)
            {
                db.Students.Remove(currentStudent);
                db.SaveChanges();
                Update();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var currentStudent = dg.SelectedItem as Students;
            if (currentStudent != null)
            {
                Window1 w = new Window1();
                w.ShowDialog();
                Update();
            }
        }
    }
}
