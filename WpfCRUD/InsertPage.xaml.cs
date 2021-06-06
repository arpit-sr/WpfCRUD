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
using WpfCRUD.Model;

namespace WpfCRUD
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        wpfCRUDEntities myDB = new wpfCRUDEntities();
        public InsertPage()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            MEMBER newmember = new MEMBER()
            {
                NAME = nameTextBox.Text,
                AGE = Convert.ToInt32(ageTextBox.Text),
                GENDER = genderComboBox.Text
            };
            myDB.MEMBERS.Add(newmember);
            myDB.SaveChanges();
            MainWindow.dataGrid.ItemsSource = myDB.MEMBERS.ToList();
            this.Hide();
        }
    }
}
