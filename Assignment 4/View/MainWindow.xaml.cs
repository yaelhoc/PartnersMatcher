using Assignment_4.Controller;
using Assignment_4.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private IController _c;
        private string _connectedUser;

        //consturctor
        public MainWindow(IController control)
        {
            InitializeComponent();
            _c = control;
            domain.Items.Add("דיור");
            domain.Items.Add("דייטים");
            domain.Items.Add("משחקי ספורט");
            domain.Items.Add("טיולים");
            DataTable dt = _c.getModel().Initiliaze();
            dataGrid1.ItemsSource = dt.DefaultView;
            button_close.IsEnabled = false;
            lblname.Content = "שלום אורח";
            buttonNewAd.IsEnabled = true;
            search.IsEnabled = true;
            _connectedUser = "";

        }

        //activating the login window
        private void button_login_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow _loginWindow = new LoginWindow(this, _c);
            _loginWindow.display();
            if (_loginWindow.Sucess)
                login(_loginWindow.User);
        }

        //function which enable other thing in the system after login
        public void login(string user)
        {
            _connectedUser = user;
            lblname.Content = user + " :שלום";
            buttonNewAd.IsEnabled = true;
            buttManagAd.IsEnabled = true;
            location.IsEnabled = true;
            button_login.IsEnabled = false;
            button_reg.IsEnabled = false;
            button_close.IsEnabled = true;
            domain.IsEnabled = true;
            search.IsEnabled = true;
        }

        public void display()
        {
            this.ShowDialog();
        }

        //function for adding new ad
        private void buttonNewAd_Click(object sender, RoutedEventArgs e)
        {
            if ((!lblname.Content.Equals("שלום אורח")) && (_c.getModel().checkOwnership(_connectedUser)))
            {
                Window1 advertisment = new Window1(_c, _connectedUser);
                advertisment.display();
            }
            else if (lblname.Content.Equals("שלום אורח"))
                MessageBox.Show("משתמשים לא רשומים למערכת לא יכולים לבצע הוספת מודעות");
            else
                MessageBox.Show("רק בעלי מודעות או שותפים יכולים להוסיף מודעות במערכת");
        }

        //not in use- mangement functions
        private void buttManagAd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("שירות ניהול מודעות לא זמין לשימוש ");
        }

        //registretion function
        private void button_reg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow _RegWindow = new RegWindow(_c);
            _RegWindow.display();
        }

        //not in use
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("השירות לא זמין כרגע");
        }

        //search ad in the system by location and domain
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            string query;
            if (lblname.Content == null)
                MessageBox.Show("משתמש לא מחובר לא יכול לבצע חיפוש במערכת");
            if ((location.Text == "") && (domain == null))
                MessageBox.Show("הכנס את כל השדות הדרושים לפני ביצוע חיפוש ");
            if (domain == null && location.Text != "")
            {
                query = "SELECT adNumber,adStatus,publishDate,location,domain,size,elevator,porch,numOfRooms,parking,garden,building,saferoom, isCosher,hostingHabits,cleanHabits,typeOfDate,paymentOnDate,purposeOfDate,music,quietPerson,typeOfGame,purposeOfGame,LevelOfProffesionality,LevalOfpisical,countryOfTrip,typeOfTrip,purposeOfTrip,purposeOfTrip,numOfParticipants,Owner FROM Ads Where adStatus='active' and location = '" + location.Text + "'";
                dt = _c.getModel().Search(query);
            }

            else
            {
                Preferences filters = new Preferences(_c, _connectedUser, true);
                string[] domains = new string[domain.SelectedItems.Count];
                
                for (int i = 0; i < domain.SelectedItems.Count; i++)
                {
                    domains[i] = domain.SelectedItems[i].ToString();
                }
                string dom = "'" + domains[0] + "'";
                for(int i = 1; i< domains.Length;i++)
                {
                    dom += " , '" + domains[i] + "'";
                }
                filters.EnableByDomain(domains);
                filters.display();
                string pref = filters.QueryFilter;
                
                //filters.Close();
                if (location.Text == "")
                {
                    query = string.Format("SELECT adNumber,publishDate,location,domain FROM Ads Where domain in(" + dom + ")" + " and adStatus='active' and " + pref);
                    dt = _c.getModel().Search(query);
                }
                else
                {
                    query = "adNumber,publishDate,location,domain FROM Ads Where adStatus='active' and domain in(" + dom + ")"  + "and location='" + location.Text + "' and " + pref;
                    dt = _c.getModel().Search(query);
                }
            }
            // מוסיף לטבלה עמודה נוספת דינאמית והיא מורכבת מכפתור הגשת בקשה ???
            /*DataGridTemplateColumn col = new DataGridTemplateColumn();
            Button button = new Button();
            button.Content = "הגשת בקשה";
            button.Click += new RoutedEventHandler(Apply_Click);
            col.CellTemplate = new DataTemplate(button);*/
            dataGrid1.ItemsSource = dt.DefaultView;
            //dataGrid1.Columns.Add(col);
        }

        // apply for ad click function
        public void Apply_Click(object sender, EventArgs e)
        {
            MessageBox.Show("שירות הגשת בקשה אינו זמין");
        }

        // disconnect function which reset the functionality to guest
        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            _connectedUser = "";
            lblname.Content = " שלום: אורח";
            buttonNewAd.IsEnabled = false;
            buttManagAd.IsEnabled = false;
            location.IsEnabled = false;
            button_login.IsEnabled = true;
            button_reg.IsEnabled = true;
            domain.IsEnabled = true;
            search.IsEnabled = false;
        }
    }

}
