using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    class LoginManager
    {
        private const string k_AppId = "607328698057381";
        private User m_LoggedInUser;
        private FacebookWrapper.LoginResult m_LoginResult;

        public User LoggedInUser
        {
            get
            {
                return m_LoggedInUser;
            }
        }

        public FacebookWrapper.LoginResult LoginResult
        {
            get
            {
                return m_LoginResult;
            }
            set
            {
                m_LoginResult = value;
            }
        }

        public bool Login()
        {
            bool loginRes = false;
            m_LoginResult = FacebookService.Login(
              k_AppId,
                /// requested permissions:
                "email",
               "public_profile",
               "user_birthday",
               "user_events",
               "user_gender",
               "user_hometown",
               "user_friends",
               "user_posts",
               "user_photos",
               "user_likes"
               );

            if (m_LoginResult.AccessToken == null)
            {
                m_LoginResult = null;
            }
            else
            {
                loginRes = true;
                m_LoggedInUser = m_LoginResult.LoggedInUser;
            }

            return loginRes;
        }

        public void connectToFacebook(string accesToken)
        {
            m_LoginResult = FacebookService.Connect(accesToken);
            m_LoggedInUser = m_LoginResult.LoggedInUser; 
        }

        public bool UserRemembered(AppSettings i_appSettings)
        {
            bool result;

            if(i_appSettings.AccesToken != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

        }
    }
}
