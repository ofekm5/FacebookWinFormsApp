using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading;

namespace BasicFacebookFeatures
{
    class FacebookDataProxy : IFacebookDataFetcher // a proxy that serves as proctective & cache a few large sized objects 
    {
        private const int k_MaxTriesToUpdate = 3;
        private Dictionary<string, int> m_UpdateTries;
        private BindingSource m_PostBindingSource;
        private readonly FacebookDataFetcher m_DataFetcher;
        private static readonly object r_UpdateTriesLock = new object(), r_LikedPagesLock = new object(), r_PostsLock = new object(), r_AlbumsLock = new object(), r_FriendsLock = new object();
        public FacebookObjectCollection<Page> LikedPages { get; set; }
        public FacebookObjectCollection<Post> Posts { get; set; }
        public FacebookObjectCollection<Album> Albums { get; set; }
        public FacebookObjectCollection<User> Friends { get; set; }

        public FacebookDataProxy(User i_LoggedInUser)
        {
            m_DataFetcher = FacebookDataFetcher.GetInstance(i_LoggedInUser);
            m_UpdateTries = new Dictionary<string, int>();
        }

        private int getTotalTries(string i_Command)
        {
            int tries;

            lock (r_UpdateTriesLock)
            {
                tries = m_UpdateTries[i_Command];
            }

            return tries;
        }

        private bool isCommandExists(string i_Command)
        {
            bool status;

            lock (r_UpdateTriesLock)
            {
                status = m_UpdateTries.ContainsKey(i_Command);
            }

            return status;
        }

        private void insertCommandToTries(string i_Command)
        {
            lock (r_UpdateTriesLock)
            {
                m_UpdateTries[i_Command] = 1;
            }
        }

        private void addTry(string i_Command)
        {
            lock (r_UpdateTriesLock)
            {
                m_UpdateTries[i_Command]++;
            }
        }

        private bool isTimeForUpdate(string i_Command)
        {
            bool status;

            if (!isCommandExists(i_Command))
            {
                insertCommandToTries(i_Command);
                status = true;
            }
            else if(getTotalTries(i_Command) == k_MaxTriesToUpdate)
            {
                status = true;
            }
            else
            {
                addTry(i_Command);
                status = false;
            }

            return status;
        }

        public FacebookObjectCollection<Page> FetchLikedPages()
        {
            bool isListEmpty = false;

            lock (r_LikedPagesLock)
            {
                if (isTimeForUpdate("FetchLikedPages"))
                {
                    LikedPages = m_DataFetcher.FetchLikedPages();
                }
                if (LikedPages.Count == 0)
                {
                    isListEmpty = true;
                }
            }

            if (isListEmpty)
            {
                throw new Exception("User has no liked pages");
            }

            return LikedPages;
        }

        public FacebookObjectCollection<Post> FetchPosts()
        {
            bool isListEmpty = false;

            lock (r_PostsLock)
            {
                if (isTimeForUpdate("FetchPosts"))
                {
                    Posts = m_DataFetcher.FetchPosts();
                }
                if (Posts.Count == 0)
                {
                    isListEmpty = true;
                }
            }

            if (isListEmpty)
            {
                throw new Exception("User has no posts");
            }

            return Posts;
        }

        public FacebookObjectCollection<Album> FetchAlbums()
        {
            bool isListEmpty = false;

            lock (r_AlbumsLock)
            {
                if (isTimeForUpdate("FetchAlbums"))
                {
                    Albums = m_DataFetcher.FetchAlbums();
                }
                if (Albums.Count == 0)
                {
                    isListEmpty = true;
                }
            }

            if (isListEmpty)
            {
                throw new Exception("User has no albums");
            }

            return Albums;
        }

        public string FetchBasicInfo()
        {
            return m_DataFetcher.FetchBasicInfo();
        }

        public string FetchProfilePicURL()
        {
            return m_DataFetcher.FetchProfilePicURL();
        }

        public Status PostStatus(string i_Text)
        {
            return m_DataFetcher.PostStatus(i_Text);
        }

        public FacebookObjectCollection<User> FetchFriends()
        {
            bool isListEmpty = false;

            lock (r_FriendsLock)
            {
                if (isTimeForUpdate("FetchFriends"))
                {
                    Friends = m_DataFetcher.FetchFriends();
                }
                if (Friends.Count == 0)
                {
                    isListEmpty = true;
                }
            }

            if (isListEmpty)
            {
                throw new Exception("User has no friends");
            }

            return Friends;
        }
    }
}
