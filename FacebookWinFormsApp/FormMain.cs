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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private const string k_AppId = "607328698057381";
        private User m_LoggedInUser;
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        FacebookWrapper.LoginResult m_LoginResult;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            try
            {
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
                    MessageBox.Show("Error logging in.");
                    m_LoginResult = null;
                }
                else
                {
                    handleAllToolsAfterLogin();
                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error logging in");
                m_LoginResult = null;
            }

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            handleAllToolsAfterLogout();
        }

        private void buttonLikedPages_Click(object sender, EventArgs e)
        {
            presentLikedPages();
        }

        private void presentLikedPages()
        {
            try
            {
                List<Page> likedPages = m_LoggedInUser.LikedPages.ToList();

                if (likedPages.Count == 0)
                {
                    MessageBox.Show("No liked pages exist.");
                }
                else
                {
                    foreach (Page currentPage in likedPages)
                    {
                        listBoxLikedPages.Items.Add(currentPage);
                        listBoxLikedPages.DisplayMember = "Name";
                    }
                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error trying to fetch liked pages.");
            }
        }

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedPage();
        }

        private void displaySelectedPage()
        {
            Page selectedLikedPage = listBoxLikedPages.SelectedItem as Page;
            pictureBoxLikedPages.LoadAsync(selectedLikedPage.PictureNormalURL);
        }

        private void presentAllAlbums()
        {
            try
            {
                List<Album> allAlbums = m_LoggedInUser.Albums.ToList();
                if (allAlbums.Count == 0)
                {
                    MessageBox.Show("User has no albums.");
                }
                else
                {
                    foreach (Album cuurentAlbum in allAlbums)
                    {
                        listBoxAlbums.Items.Add(cuurentAlbum);
                        listBoxAlbums.DisplayMember = "Name";
                    }
                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error trying to fetch albums.");
            }
        }

        private void presentSelectedAlbum()
        {
            Album selectedAlbum = listBoxAlbums.SelectedItem as Album;
            pictureBoxAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            presentAllAlbums();
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentSelectedAlbum();
        }

        private void handleAllToolsAfterLogin()
        {
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            buttonLikedPages.Visible = true;
            buttonLikedPages.Enabled = true;
            listBoxLikedPages.Visible = true;
            pictureBoxLikedPages.Visible = true;
            listBoxAlbums.Visible = true;
            buttonAlbums.Visible = true;
            buttonAlbums.Enabled = true;
            labelDetailsHeadline.Visible = true;
            pictureBoxAlbum.Visible = true;
            pictureBoxProfile.Visible = true;
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            //buttonGuessingGame.Visible = true;
            //buttonGuessingGame.Enabled = true;
            labelWelcome.Visible = false;
            listBoxGroups.Visible = true;
            pictureBoxGroups.Visible = true;
            buttonGroups.Visible = true;
            buttonGroups.Enabled = true;
            buttonPosts.Enabled = true;
            buttonPosts.Visible = true;
            listBoxPosts.Visible = true;
            labelBasicDetails.Visible = true;
            labelWhatsOnYourMind.Visible = true;
            textBoxPostStatus.Visible = true;
            textBoxPostStatus.Enabled = true;
            buttonPost.Visible = true;
            buttonPost.Enabled = true;
            buttonPast.Visible = true;
            buttonPast.Enabled = true;
            buttonAlbumCreator.Visible = true;
            buttonAlbumCreator.Enabled = true;
            fetchBasicInfo();
        }

        private void handleAllToolsAfterLogout()
        {
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            buttonLikedPages.Visible = false;
            buttonLikedPages.Enabled = false;
            listBoxLikedPages.Visible = false;
            listBoxLikedPages.Items.Clear();
            pictureBoxLikedPages.Visible = false;
            pictureBoxLikedPages.Image = null;
            listBoxAlbums.Visible = false;
            listBoxAlbums.Items.Clear();
            buttonAlbums.Visible = false;
            buttonAlbums.Enabled = false;
            labelDetailsHeadline.Visible = false;
            pictureBoxAlbum.Visible = false;
            pictureBoxAlbum.Image = null;
            pictureBoxProfile.Visible = false;
            buttonGuessingGame.Visible = false;
            buttonGuessingGame.Enabled = false;
            labelWelcome.Visible = true;
            listBoxGroups.Visible = false;
            pictureBoxGroups.Visible = false;
            buttonGroups.Visible = false;
            buttonGroups.Enabled = false;
            buttonPosts.Enabled = false;
            buttonPosts.Visible = false;
            listBoxPosts.Visible = false;
            labelBasicDetails.Visible = false;
            labelWhatsOnYourMind.Visible = true;
            textBoxPostStatus.Visible = true;
            textBoxPostStatus.Enabled = true;
            buttonPost.Visible = true;
            buttonPost.Enabled = true;
            buttonPast.Visible = true;
            buttonPast.Enabled = true;
            buttonAlbumCreator.Visible = true;
            buttonAlbumCreator.Enabled = true;
        }

        private void buttonGuessingGame_Click(object sender, EventArgs e)
        {
            try
            {
                FormGuessGame guessGame = new FormGuessGame(m_LoggedInUser);
                guessGame.ShowDialog();
            }
            catch (Exception generalException)
            {

            }
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            presentAllGroups();
        }

        private void presentAllGroups()
        {
            try
            {
                List<Group> allGroups = m_LoggedInUser.Groups.ToList();
                if (allGroups.Count == 0)
                {
                    MessageBox.Show("User has no groups.");
                }
                else
                {
                    foreach (Group currentGroup in allGroups)
                    {
                        listBoxGroups.Items.Add(currentGroup);
                        listBoxGroups.DisplayMember = "Name";
                    }
                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error trying to fetch groups.");
            }
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentSingleGroup();
        }

        private void presentSingleGroup()
        {
            Group selectedGroup = listBoxGroups.SelectedItem as Group;
            pictureBoxGroups.LoadAsync(selectedGroup.PictureNormalURL);
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            presentAllPosts();
        }

        private void presentAllPosts()
        {
            try
            {
                List<Post> allPosts = m_LoggedInUser.Posts.ToList();
                if (allPosts.Count == 0)
                {
                    MessageBox.Show("User has no posts");
                }
                else
                {
                    foreach (Post post in allPosts)
                    {
                        listBoxPosts.Items.Add(post);
                        //listBoxPosts.DisplayMember = "Name";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error trying to fetch posts.");
            }
        }

        private void fetchBasicInfo()
        {
            labelBasicDetails.Text = "Name: " + m_LoggedInUser.FirstName + " " + m_LoggedInUser.LastName + "\n\n";
            fetchBirthdayAndCalculateCountdown();
            labelBasicDetails.Text += "Gender: " + m_LoggedInUser.Gender + "\n\n";
            labelBasicDetails.Text += "Email: " + m_LoggedInUser.Email + "\n\n";
            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
        }

        private void fetchBirthdayAndCalculateCountdown()
        {
            try
            {
                string userBirthday = m_LoggedInUser.Birthday;
                DateTime today = DateTime.Today;
                DateTime formatedUserBirthday;
                if (DateTime.TryParseExact(userBirthday, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out formatedUserBirthday))
                {
                    DateTime birthdayThisYear = new DateTime(today.Year, formatedUserBirthday.Month, formatedUserBirthday.Day);
                    if (today > birthdayThisYear)
                    {
                        birthdayThisYear = birthdayThisYear.AddYears(1);
                    }

                    TimeSpan daysDifference = birthdayThisYear.Subtract(today);
                    if (daysDifference.Days == 0)
                    {
                        labelBasicDetails.Text += "Happy birthday!!!\n\n";
                    }
                    else
                    {
                        labelBasicDetails.Text += $"Your birthday is in {userBirthday}\n\nYou have {daysDifference.Days} days until your birthday\n\n";
                    }
                }
                else
                {
                    labelBasicDetails.Text += "You havent provided a birthday\n\n";

                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error trying to fetch birthday");
            }
        }

    }
}
