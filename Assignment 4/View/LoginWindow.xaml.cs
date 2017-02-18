using Assignment_4.Controller;
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
using System.Windows.Shapes;

namespace Assignment_4.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IView
    {
        private IController _controller;
        private Window main;
        private bool sucess;
        private string user;

        //consturctor
        public LoginWindow(Window m, IController c)
        {
            _controller = c;
            main = m;
            InitializeComponent();
            status.Items.Add("שותף במודעה");
            status.Items.Add("בעל מודעה");
            status.Items.Add("מחפש מודעה");
            sucess = false;
            user = "";
        }
        // login function 
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((username.Text == "") || (password.Text == "" )|| (status.SelectedItem==null))
            {
                MessageBox.Show(" יש למלא שם משתמש, סיסמא וסטטוס התחברות");
            }
            else
            {
                bool ans = _controller.getModel().Login(username.Text, password.Text,status.SelectedItem.ToString());
                if (ans)
                {
                    MessageBox.Show(" ברוך הבא " + username.Text);
                    user = username.Text;
                    _controller.getModel().updateLastLogin(username.Text);
                    sucess = true;
                    this.Close();
                }
                else
                    MessageBox.Show(" התחברות נכשלה-המשתמש לא קיים במערכת או אינו בעל הרשאות מתאימות ");
            }
        }

        //closing window
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public bool Sucess
        {
            get { return this.sucess; }
        }

        public string User
        {
            get { return this.user; }

        }

        // function which shown the window
        public void display()
        {
            this.ShowDialog();
        }
    }
}
