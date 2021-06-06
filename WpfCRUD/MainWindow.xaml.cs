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
using WpfCRUD.Model;

namespace WpfCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wpfCRUDEntities myDB = new wpfCRUDEntities();
        public static DataGrid dataGrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = myDB.MEMBERS.ToList();
            dataGrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as MEMBER).ID;
            UpdatePage Upage = new UpdatePage(Id);
            Upage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as MEMBER).ID;
            var delmember = myDB.MEMBERS.Where(m => m.ID == Id).Single();
            myDB.MEMBERS.Remove(delmember);
            myDB.SaveChanges();
            myDataGrid.ItemsSource = myDB.MEMBERS.ToList();
        }
    }
}
