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
               "user_likes",
               ""
               );

                if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
                {
                    buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                    handleAllToolsAfterLogin();
                }
                else
                {
                    MessageBox.Show("Error logging in");
                }
            }
            catch (Exception generalException)
            {
                //MessageBox.Show("Error logging in");
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
            catch(Exception generalException)
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
            catch(Exception generalException)
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
            labelBirthday.Visible = true;
            pictureBoxAlbum.Visible = true;
            pictureBoxProfile.Visible = true;
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            labelSingleOrTaken.Visible = true;
            buttonGuessingGame.Visible = true;
            buttonGuessingGame.Enabled = true;
            labelWelcome.Visible = false;
            labelBirthday.Text = $"Your birthday is on: {m_LoggedInUser.Birthday}";

            if (m_LoggedInUser.RelationshipStatus == User.eRelationshipStatus.None)
            {
                labelSingleOrTaken.Text = "You are currently single :( Go find someone";
            }
            else
            {
                labelSingleOrTaken.Text = "You are currently taken :)";
            }
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
            labelBirthday.Visible = false;
            pictureBoxAlbum.Visible = false;
            pictureBoxAlbum.Image = null;
            pictureBoxProfile.Visible = false;
            labelSingleOrTaken.Visible = false;
            buttonGuessingGame.Visible = false;
            buttonGuessingGame.Enabled = false;
            labelWelcome.Visible = true;
        }

        private void buttonGuessingGame_Click(object sender, EventArgs e)
        {
            try
            {
                FormGuessGame guessGame = new FormGuessGame(m_LoggedInUser);
                guessGame.ShowDialog();
            }
            catch(Exception generalException)
            {

            }
        }

       
    }
}
