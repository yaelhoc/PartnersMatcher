using Assignment_4.Controller;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment_4.View
{
    /// <summary>
    /// Interaction logic for RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window, IView
    {
        private IController _c;

        //consturctor
        public RegWindow(IController c)
        {
            _c = c;
            InitializeComponent();
            familyStatus.Items.Add("רווק");
            familyStatus.Items.Add("נשוי");
            familyStatus.Items.Add("גרוש");
            listAuto.Items.Add("שותף במודעה");
            listAuto.Items.Add("בעל מודעה");
            listAuto.Items.Add("מחפש מודעה");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Text == "" || firstName.Text == "" || lastName.Text == "" || email.Text == "" || phone.Text == "" || age.Text == "" || familyStatus.SelectedItem == null)
                MessageBox.Show("יש למלא את כל השדות");
            else
            {
                bool ans = ValidateDetails();
                if (ans)
                {
                    String[] vals = new String[listAuto.SelectedItems.Count];
                    for (int i = 0; i < listAuto.SelectedItems.Count; i++)
                    {
                        vals[i] =listAuto.SelectedItems[i].ToString();
                    }

                    string au = String.Join(",", vals);
                    if (_c.getModel().Register(username.Text, password.Text, firstName.Text, lastName.Text, email.Text, phone.Text, sex.Text, age.Text, "", au, familyStatus.SelectedItem.ToString(), smoking.IsChecked.Value, friendly.IsChecked.Value, animalLover.IsChecked.Value))
                        MessageBox.Show("ההרשמה למערכת התבצעה בהצלחה !");
                    else
                        MessageBox.Show("ההרשמה למערכת נכשלה");
                }
            }
        }

        private bool ValidateDetails()
        {
            if (!Regex.Match(phone.Text, @"^([0-9]{10})$").Success)
            {
                MessageBox.Show("מספר הטלפון שהוזן אינו בפורמט תקין");
                return false;
            }
            Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            if (!rx.IsMatch(email.Text))
            {
                MessageBox.Show("כתובת האימייל שהוזנה אינה בפורמט תקין");
                return false;
            }
            if (!Regex.IsMatch(firstName.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("שם פרטי צריך להכיל אותיות בלבד ");
                return false;
            }
            if (!Regex.IsMatch(lastName.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("שם משפחה צריך להכיל אותיות בלבד ");
                return false;
            }
            if ((!Regex.IsMatch(age.Text, "^[0-9]*$")) || ((Convert.ToInt32(age.Text) <= 1) && (Convert.ToInt32(age.Text) >= 100)))
            {
                MessageBox.Show("גיל לא תקין ");
                return false;
            }
            return true;
        }

        //if you want to fill preferences
        private void PreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            Preferences pref = new Preferences(_c, username.Text, false);
            pref.display();
        }

        //add photo
        private void photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(open.FileName));

            }
        }

        public void display()
        {
            this.Show();
        }

    }
}
