using Assignment_4.Controller;
using Assignment_4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, IView
    {
        private IController _controller;
        private string _user;
        public Window1(IController c, string user)
        {
            InitializeComponent();
            initializeWindow();
            disableAll();
            _controller = c;
            _user = user;
        }

        private void disableAll()
        {
            chooseState.IsEnabled = false;
            area.IsEnabled = false;
            languge.IsEnabled = false;
            purpose.IsEnabled = false;
            kosher.IsEnabled = false;
            style.IsEnabled = false;
            numParticipants.IsEnabled = false;
            sportGame.IsEnabled = false;
            level.IsEnabled = false;
            professionality.IsEnabled = false;
            numInGame.IsEnabled = false;
            gamePurpose.IsEnabled = false;
            music.IsEnabled = false;
            datePurpose.IsEnabled = false;
            quiet.IsEnabled = false;
            favorite.IsEnabled = false;
            typeOfPay.IsEnabled = false;
            cleanHabits.IsEnabled = false;
            quiet.IsEnabled = false;
            hostingHabits.IsEnabled = false;
            size.IsEnabled = false;
            numOfRooms.IsEnabled = false;
            building.IsEnabled = false;
            porch.IsEnabled = false;
            elevator.IsEnabled = false;
            garden.IsEnabled = false;
            parking.IsEnabled = false;
            safeRoom.IsEnabled = false;
        }

        private void initializeWindow()
        {
            chooseDomain.Items.Add("דייטים");
            chooseDomain.Items.Add("דיור");
            chooseDomain.Items.Add("משחקי ספורט");
            chooseDomain.Items.Add("טיולים");
            chooseDomain.Items.Add("אחר");
            familyStatus.Items.Add("רווק");
            familyStatus.Items.Add("נשוי");
            familyStatus.Items.Add("גרוש");
            hostingHabits.Items.Add("מדי יום");
            hostingHabits.Items.Add(" פעמיים-שלוש בשבוע");
            hostingHabits.Items.Add(" פעם בשבוע");
            hostingHabits.Items.Add(" פעם בחודש");
            cleanHabits.Items.Add("נקי מאוד");
            cleanHabits.Items.Add("נקי");
            cleanHabits.Items.Add("נקי במקצת");
            cleanHabits.Items.Add("לא נקי");
            area.Items.Add("צפון");
            area.Items.Add("דרום");
            area.Items.Add("מרכז");
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
            professionality.Items.Add("גבוהה");
            professionality.Items.Add("בינונית");
            professionality.Items.Add("נמוכה");
            professionality.Items.Add("גבוהה");
            professionality.Items.Add("אין צורך במומחיות");
            purpose.Items.Add("חופשה בחול");
            purpose.Items.Add("טיול אחרי צבא");
            purpose.Items.Add("חופשה בארץ");
            chooseState.Items.Add("ישראל");
            chooseState.Items.Add("ארצות הברית");
            chooseState.Items.Add("יוון");
            chooseState.Items.Add("מקסיקו");
            chooseState.Items.Add("תאילנד");
            chooseState.Items.Add("ארגנטינה");
            chooseState.Items.Add("בוליביה");
            chooseState.Items.Add("קובה");
            chooseState.Items.Add("צרפת");
            chooseState.Items.Add("גרמניה");
            chooseState.Items.Add("הולנד");
            chooseState.Items.Add("אנגליה");
            sportGame.Items.Add("כדורגל");
            sportGame.Items.Add("כדורסל");
            sportGame.Items.Add("פוטבול");
            sportGame.Items.Add("טניס שולחן");
            sportGame.Items.Add("טניס");
            sportGame.Items.Add("שחיה");
            sportGame.Items.Add("שח-מט");
            sportGame.Items.Add("קט רגל");
            sportGame.Items.Add("מחניים");
            style.Items.Add("עסקים");
            style.Items.Add("חופשה");
            style.Items.Add("עבודה וחופשה");
            style.Items.Add("טיול שורשים");
            style.Items.Add("טיול טראקים וטבע");
            style.Items.Add("טיול טראקים ומלונות");
            gamePurpose.Items.Add("תחרות");
            gamePurpose.Items.Add("כיף");
            gamePurpose.Items.Add("ספורט");
            datePurpose.Items.Add("חד פעמי");
            datePurpose.Items.Add(" לא מחייב");
            datePurpose.Items.Add("קשר רציני");
            datePurpose.Items.Add("פתוח להצעות");
            location.Items.Add("איזור הצפון");
            location.Items.Add("איזור השפלה");
            location.Items.Add("איזור המרכז");
            location.Items.Add("איזור ירושלים");
            location.Items.Add("באר שבע והסביבה");
            location.Items.Add("אילת והסביבה");
            typeOfPay.Items.Add("חצי חצי");
            typeOfPay.Items.Add("גבר משלם");
            typeOfPay.Items.Add("אישה משלמת");
            typeOfPay.Items.Add("כל אחד על עצמו");
        }

        private void chooseDomain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseDomain.SelectedItem.Equals("דייטים"))
            {
                music.IsEnabled = true;
                datePurpose.IsEnabled = true;
                quiet.IsEnabled = true;
                favorite.IsEnabled = true;
                typeOfPay.IsEnabled = true;
            }
            else if (chooseDomain.SelectedItem.Equals("דיור"))
            {
                cleanHabits.IsEnabled = true;
                kosher.IsEnabled = true;
                quiet.IsEnabled = true;
                hostingHabits.IsEnabled = true;
                size.IsEnabled = true;
                numOfRooms.IsEnabled = true;
                building.IsEnabled = true;
                porch.IsEnabled = true;
                elevator.IsEnabled = true;
                garden.IsEnabled = true;
                parking.IsEnabled = true;
                safeRoom.IsEnabled = true;
            }
            else if (chooseDomain.SelectedItem.Equals("משחקי ספורט"))
            {
                sportGame.IsEnabled = true;
                level.IsEnabled = true;
                professionality.IsEnabled = true;
                numInGame.IsEnabled = true;
                gamePurpose.IsEnabled = true;
            }
            else if (chooseDomain.SelectedItem.Equals("טיולים"))
            {
                chooseState.IsEnabled = true;
                area.IsEnabled = true;
                languge.IsEnabled = true;
                purpose.IsEnabled = true;
                style.IsEnabled = true;
                numParticipants.IsEnabled = true;

            }
            else if (chooseDomain.SelectedItem.Equals("אחר"))
            {
                addDomain.Visibility = System.Windows.Visibility.Visible;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool ans = validateInputs();
            if (ans)
            {
                if (chooseDomain.SelectedItem.Equals("אחר"))
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress(" roommatcheraviv@gmail.com");
                        mail.To.Add("avivlitman21@gmail.com");
                        mail.Subject = "Add new Domain to the system";
                        mail.Body = "the user which owns the following username:" + _user + "wants to add the new domain" + addDomain.Text + " to the system.please approve or reject";
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("roomMatcher room", "yaelaviv123");
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.Send(mail);
                        MessageBox.Show("תחום המודעה החדש נשלח לאישור מנהל המערכת");
                        this.Close();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    return;
                }
                string query = "";
                int number = _controller.getModel().countAds() + 1;
                if (chooseDomain.SelectedItem.Equals("דייטים"))
                {
                    string q = string.Format(number + "', '" + "active" + "', '" + DateTime.Now + "', '" + location.SelectedItem.ToString() + "', '" + "דייטים" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "','" + favorite.SelectedItem.ToString() + "', '" + typeOfPay.SelectedItem.ToString() + "','" + datePurpose.SelectedItem.ToString() + "', '" + music.SelectedItem.ToString() + "', '" + quiet.IsChecked + "','" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + _user + "', '" + familyStatus.SelectedItem.ToString() + "', '" + smoking.IsChecked.Value + "', '" + friendly.IsChecked.Value + "', '" + animal.IsChecked.Value);
                    query = "INSERT INTO Ads( adNumber,adStatus,publishDate,location,domain,size,elevator,porch,numOfRooms,parking,garden,building,saferoom, isCosher,hostingHabits,cleanHabits,typeOfDate,paymentOnDate,purposeOfDate,music,quietPerson,typeOfGame,purposeOfGame,LevelOfProffesionality,LevalOfpisical,countryOfTrip,typeOfTrip,purposeOfTrip,numOfParticipants,Owner,FamilyStatus,IsSmoking,IsFriendly,IsAnimalLover) VALUES ('" + q + "')";
                }
                else if (chooseDomain.SelectedItem.Equals("דיור"))
                {
                    string q = string.Format(number + "', '" + "active" + "', '" + DateTime.Now + "', '" + location.SelectedItem.ToString() + "', '" + "דיור" + "', '" + size.Text + "', '" + elevator.IsChecked.Value + "', '" + porch.IsChecked.Value + "', '" + numOfRooms.Text + "', '" + parking.IsChecked.Value + "', '" + garden.IsChecked.Value + "', '" + building.IsChecked.Value + "', '" + safeRoom.IsChecked.Value + "', '" + kosher.IsChecked.Value + "', '" + hostingHabits.Text + "', '" + cleanHabits.Text + "','" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + _user + "', '" + familyStatus.SelectedItem.ToString() + "', '" + smoking.IsChecked.Value + "', '" + friendly.IsChecked.Value + "', '" + animal.IsChecked.Value);
                    query = "INSERT INTO Ads( adNumber,adStatus,publishDate,location,domain,size,elevator,porch,numOfRooms,parking,garden,building,saferoom, isCosher,hostingHabits,cleanHabits,typeOfDate,paymentOnDate,purposeOfDate,music,quietPerson,typeOfGame,purposeOfGame,LevelOfProffesionality,LevalOfpisical,countryOfTrip,typeOfTrip,purposeOfTrip,numOfParticipants,Owner,FamilyStatus,IsSmoking,IsFriendly,IsAnimalLover) VALUES ('" + q + "')";

                }
                else if (chooseDomain.SelectedItem.Equals("משחקי ספורט"))
                {
                    string q = string.Format(number + "', '" + "active" + "', '" + DateTime.Now + "', '" + location.SelectedItem.ToString() + "', '" + "משחקי ספורט" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "', '" + "null" + "','" + sportGame.Text + "', '" + gamePurpose.Text + "', '" + professionality.Text + "', '" + level.Text + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + _user + "', '" + familyStatus.SelectedItem.ToString() + "', '" + smoking.IsChecked.Value + "', '" + friendly.IsChecked.Value + "', '" + animal.IsChecked.Value);
                    query = "INSERT INTO Ads( adNumber,adStatus,publishDate,location,domain,size,elevator,porch,numOfRooms,parking,garden,building,saferoom, isCosher,hostingHabits,cleanHabits,typeOfDate,paymentOnDate,purposeOfDate,music,quietPerson,typeOfGame,purposeOfGame,LevelOfProffesionality,LevalOfpisical,countryOfTrip,typeOfTrip,purposeOfTrip,numOfParticipants,Owner,FamilyStatus,IsSmoking,IsFriendly,IsAnimalLover) VALUES ('" + q + "')";
                }
                else if (chooseDomain.SelectedItem.Equals("טיולים"))
                {
                    string q = string.Format(number + "', '" + "active" + "', '" + DateTime.Now + "', '" + location.SelectedItem.ToString() + "', '" + "טיולים" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "', '" + "null" + "','" + "null" + "', '" + "null" + "', '" + "null" + "', '" + "null" + "', '" + chooseState.Text + "', '" + style.Text + "', '" + purpose.Text + "', '" + numParticipants.Text + "', '" + _user + "', '" + familyStatus.SelectedItem.ToString() + "', '" + smoking.IsChecked.Value + "', '" + friendly.IsChecked.Value + "', '" + animal.IsChecked.Value);
                    query = "INSERT INTO Ads( adNumber,adStatus,publishDate,location,domain,size,elevator,porch,numOfRooms,parking,garden,building,saferoom, isCosher,hostingHabits,cleanHabits,typeOfDate,paymentOnDate,purposeOfDate,music,quietPerson,typeOfGame,purposeOfGame,LevelOfProffesionality,LevalOfpisical,countryOfTrip,typeOfTrip,purposeOfTrip,numOfParticipants,Owner,FamilyStatus,IsSmoking,IsFriendly,IsAnimalLover) VALUES ('" + q + "')";
                }
                if (_controller.getModel().publishAd(query))
                {
                    string qur = "INSERT into usersAds(username,adNumber) VALUES('" + _user + "','" + number + "')";
                    _controller.getModel().insertToUserAds(qur);
                    MessageBox.Show("המודעה נוספה למערכת בהצלחה!");
                    this.Close();
                }

            }
        }

        private bool validateInputs()
        {
            if (!age.Text.Equals(""))
                if ((!Regex.IsMatch(age.Text, "^[0-9]*$")) || ((Convert.ToInt32(age.Text) <= 1) && (Convert.ToInt32(age.Text) >= 100)))
                {
                    MessageBox.Show("גיל לא תקין ");
                    return false;
                }
                else if (age.Text.Equals(""))
                {
                    MessageBox.Show("שדה חובה גיל ריק ");
                    return false;
                }


            if (languge.IsEnabled && !Regex.IsMatch(languge.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("שפה צריכה להכיל אותיות בלבד ");
                return false;
            }
            if (!numParticipants.Text.Equals(""))
            {
                if (!Regex.IsMatch(numParticipants.Text, "^[0-9]*$"))
                {
                    MessageBox.Show("מספר משתתפים בטיול לא תקין");
                    return false;
                }
            }

            if (!numInGame.Text.Equals(""))
            {
                if (!Regex.IsMatch(numInGame.Text, "^[0-9]*$"))
                {
                    MessageBox.Show("מספר משתתפים במשחק לא תקין ");
                    return false;
                }
            }

            if (!size.Text.Equals(""))
            {
                if (!Regex.IsMatch(size.Text, "^[0-9]*$"))
                {
                    MessageBox.Show("גודל דירה לא תקין ");
                    return false;
                }
            }
            if (!numOfRooms.Text.Equals(""))
            {
                if (!Regex.IsMatch(numOfRooms.Text, "^[0-9]*$"))
                {
                    MessageBox.Show("מספר חדרים בדירה לא תקין ");
                    return false;
                }
            }
           
            if (!roomates.Text.Equals(""))
            {
                Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                string[] roomatesEmails = roomates.Text.Split(' ');
                foreach (string email in roomatesEmails)
                {
                    if (!rx.IsMatch(email))
                    {
                        MessageBox.Show("כתובת האימייל של השותפים שהוזנה אינה בפורמט תקין");
                        return false;
                    }
                    else if (!_controller.getModel().UserExist(email))
                    {
                        MessageBox.Show("כתובת מייל השותפים לא קיימת במערכת");
                        return false;
                    }
                }
            }
            return true;
        }

        public void display()
        {
            this.ShowDialog();
        }
    }
}