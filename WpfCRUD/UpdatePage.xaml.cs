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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCRUDEntities myDB = new wpfCRUDEntities();
        int Id;
        public UpdatePage(int memberID)
        {
            InitializeComponent();
            Id = memberID;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            MEMBER upmember = (from m in myDB.MEMBERS
                               where m.ID == Id
                               select m).Single();
                
            upmember.NAME = nameTextBox.Text;
            upmember.AGE = Convert.ToInt32(ageTextBox.Text);
            upmember.GENDER = genderComboBox.Text;
            myDB.SaveChanges();
            MainWindow.dataGrid.ItemsSource = myDB.MEMBERS.ToList();
            this.Hide();
        }
    }
}
