using Assignment_4.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for Preferences.xaml
    /// </summary>
    public partial class Preferences : Window, IView
    {
        private IController _controller;
        private string _user;
        private string[] selectedSearch;
        private string _queryFilter;

        //consturctor
        //register bool= false
        //serching bool =true
        public Preferences(IController c, string username, bool filtering)
        {
            InitializeComponent();
            initializeWindow();
            if (filtering)
            {
                save.IsEnabled = false;
                domainName.IsEnabled = false;
            }
            else
                filter.IsEnabled = false;
            _user = username;
            _controller = c;
        }

        //לאפשר שדות רק שקשורים לתחום
        public void EnableByDomain(string[] domains)
        {
            selectedSearch = domains;
            foreach (string s in domains)
            {
                if (s.Equals("דיור"))
                {
                    domainName.IsEnabled = false;
                    kosher.IsEnabled = true;
                    quiet.IsEnabled = false;
                    age.IsEnabled = true; ;
                    hosting.IsEnabled = true;
                    cleaning.IsEnabled = true;
                    music.IsEnabled = false;
                    favorite.IsEnabled = false;
                    gameType.IsEnabled = false;
                    level.IsEnabled = false;
                    speciality.IsEnabled = false;
                    location.IsEnabled = true;
                    language.IsEnabled = false;
                    purpose.IsEnabled = false;
                    break;
                }
                if (s.Equals("דייטים"))
                {
                    domainName.IsEnabled = false;
                    kosher.IsEnabled = false;
                    quiet.IsEnabled = true;
                    age.IsEnabled = true; ;
                    hosting.IsEnabled = false;
                    cleaning.IsEnabled = false;
                    music.IsEnabled = true;
                    favorite.IsEnabled = true;
                    gameType.IsEnabled = false;
                    level.IsEnabled = false;
                    speciality.IsEnabled = false;
                    location.IsEnabled = false;
                    language.IsEnabled = false;
                    purpose.IsEnabled = false;
                    break;
                }
                if (s.Equals("משחקי ספורט"))
                {
                    domainName.IsEnabled = false;
                    kosher.IsEnabled = false;
                    quiet.IsEnabled = false;
                    age.IsEnabled = false; ;
                    hosting.IsEnabled = false;
                    cleaning.IsEnabled = false;
                    music.IsEnabled = false;
                    favorite.IsEnabled = false;
                    gameType.IsEnabled = true;
                    level.IsEnabled = true;
                    speciality.IsEnabled = true;
                    location.IsEnabled = true;
                    language.IsEnabled = false;
                    purpose.IsEnabled = false;
                    break;
                }
                if (s.Equals("טיולים"))
                {
                    domainName.IsEnabled = false;
                    kosher.IsEnabled = false;
                    quiet.IsEnabled = false;
                    age.IsEnabled = false; ;
                    hosting.IsEnabled = false;
                    cleaning.IsEnabled = false;
                    music.IsEnabled = false;
                    favorite.IsEnabled = false;
                    gameType.IsEnabled = false;
                    level.IsEnabled = false;
                    speciality.IsEnabled = false;
                    location.IsEnabled = true;
                    language.IsEnabled = true;
                    purpose.IsEnabled = true;
                    break;
                }
            }

        }


        private void initializeWindow()
        {
            domainName.Items.Add("דייטים");
            domainName.Items.Add("דיור");
            domainName.Items.Add("משחקי ספורט");
            domainName.Items.Add("טיולים");
            hosting.Items.Add("מדי יום");
            hosting.Items.Add(" פעמיים-שלוש בשבוע");
            hosting.Items.Add(" פעם בשבוע");
            hosting.Items.Add(" פעם בחודש");
            cleaning.Items.Add("נקי מאוד");
            cleaning.Items.Add("נקי");
            cleaning.Items.Add("נקי במקצת");
            cleaning.Items.Add("לא נקי");
            music.Items.Add("מטאל");
            music.Items.Add("רוק");
            music.Items.Add("פופ");
            music.Items.Add("ישראלי");
            music.Items.Add("מזרחית");
            favorite.Items.Add("סרט");
            favorite.Items.Add("מסעדה");
            favorite.Items.Add("פאב");
            favorite.Items.Add("סנוקר");
            level.Items.Add("גבוהה");
            level.Items.Add("בינונית");
            level.Items.Add("נמוכה");
            level.Items.Add("אין צורך בכושר");
            speciality.Items.Add("גבוהה");
            speciality.Items.Add("בינונית");
            speciality.Items.Add("נמוכה");
            speciality.Items.Add("גבוהה");
            speciality.Items.Add("אין צורך במומחיות");
            purpose.Items.Add("חופשה בחול");
            purpose.Items.Add("טיול אחרי צבא");
            purpose.Items.Add("חופשה בארץ");
            location.Items.Add("איזור הצפון");
            location.Items.Add("איזור השפלה");
            location.Items.Add("איזור המרכז");
            location.Items.Add("איזור ירושלים");
            location.Items.Add("באר שבע והסביבה");
            location.Items.Add("אילת והסביבה");
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            domainName.SelectedItem = "";
            kosher.IsChecked = false;
            quiet.IsChecked = false;
            age.Text = "";
            hosting.SelectedItem = "";
            cleaning.SelectedItem = "";
            music.SelectedItems.Clear();
            favorite.SelectedItems.Clear();
            gameType.Text = "";
            level.SelectedItem = "";
            speciality.SelectedItem = "";
            location.Text = "";
            language.Text = "";
            purpose.SelectedItem = "";
        }

        // if from registration so we save its preferences in the database
        private void save_Click(object sender, RoutedEventArgs e)
        {
            string q = string.Format(domainName.SelectedItem.ToString(), hosting.ToString(), cleaning.ToString(), kosher.IsChecked.Value, music.SelectedItem.ToString(), favorite.SelectedItem.ToString(), quiet.IsChecked.Value, gameType.ToString(), level.SelectedItem.ToString(), speciality.SelectedItem.ToString(), state.Text, location.SelectedItem.ToString(), language.Text, purpose.SelectedItem.ToString(), age.Text);
            string query = "INSERT into UserPrefferences(username,domainName,hostingHabits,cleanHabits,kosher,music,favoriteHobby,quietPerson,typeOfGame,levelOfPhysical,levelOfProfessionality,country,location,language,aimOfTrip) VALUES('" + q + "')";
            _controller.getModel().addPrefenencesByDomain(query);
            MessageBox.Show("העדפותייך בתחומים נשמרו בהצלחה במערכת !");
            this.Close();
        }

        //search for ads by the preferences which the user entered
        public void filter_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder filter = new StringBuilder();
            
            if(kosher.IsEnabled  && kosher.IsChecked.Value)
            {
                filter.Append("kosher = 'True' ");
            }
            if(quiet.IsEnabled && quiet.IsChecked.Value)
            {
                if(filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append("quietPerson = 'True' ");
            }
            if (hosting.IsEnabled && hosting.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append(String.Format("hostingHabits = '{0}' ", hosting.SelectedItem));
            }
            if(cleaning.IsEnabled && cleaning.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append(String.Format("cleanHabits = '{0}' ", cleaning.SelectedItem));
            }
            if(music.IsEnabled && music.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                string[] vals = ItemsToStringArray(music.SelectedItems);

                filter.Append(String.Format("music in '({0})' ", String.Join(",", vals)));
            }
            if(favorite.IsEnabled && favorite.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                string[] vals = ItemsToStringArray(favorite.SelectedItems);

                filter.Append(String.Format("favoriteHobby in '({0})' ", String.Join(",", vals)));
            }

            //if(gameType.IsEnabled && gameType

            if(level.IsEnabled && level.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append(String.Format("levelOfPhysical = '{0}' ", level.SelectedValue));
            }

            if(speciality.IsEnabled && speciality.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append(String.Format("levelOfProfessionality = '{0}' ", speciality.SelectedValue));
            }

            //location.IsEnabled = true;

            if(language.IsEnabled && language.Text != "")
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append(String.Format("language = '{0}' ", language.Text));

            }
            if(purpose.IsEnabled && purpose.SelectedIndex != -1)
            {
                if (filter.Length > 0)
                {
                    filter.Append("and ");
                }
                filter.Append(String.Format("aimOfTrip = '{0}' ", purpose.Text));
            }


            _queryFilter = filter.ToString();
            this.Close();
        }

        private string[] ItemsToStringArray(IList items)
        {
            String[] vals = new String[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                vals[i] = "'" + items[i].ToString() + "'";
            }

            return vals;
        }

        private bool validateInputs()
        {
            if (!Regex.IsMatch(gameType.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("סוג משחק צריך להכיל אותיות בלבד");
                return false;
            }
            if (!Regex.IsMatch(state.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("מדינה צריכה להכיל אותיות בלבד");
                return false;
            }
            if (!Regex.IsMatch(state.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("מיקום צריך להכיל אותיות בלבד");
                return false;
            }
            if (!Regex.IsMatch(language.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("שפה צריכה להכיל אותיות בלבד");
                return false;
            }
            return true;
        }

        public void display()
        {
            this.ShowDialog();
        }

        public String QueryFilter
        { get { return this._queryFilter; } }
    }
}
