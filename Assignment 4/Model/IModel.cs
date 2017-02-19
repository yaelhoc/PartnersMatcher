using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Model
{
    // the model interface
    public interface IModel
    {
        DataTable Initiliaze();

        bool checkOwnership(string username);

        bool Login(string username, string password,string status);

        bool Register(string username, string password, string firstName, string lastName, string email, string telephone, string sex, string age, string lastLogin, string lastStatus, string familyStat, bool smoking, bool friendly, bool animal);

        void addPrefenencesByDomain(string query);

        DataTable Search(string query);

        bool publishAd(string query);

        bool UserExist(string mail);

        bool alreadyRegistered(string _user);

        void updateLastLogin(string user);

        int countAds();

        void insertToUserAds(string qur);
    }
}
