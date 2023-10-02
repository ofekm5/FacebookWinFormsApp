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
    public partial class FormMain : Form
    {
        private GuessingGameUI m_GuessingGameUI;
        private LoginManager m_LoginManager;
        private AppSettings m_AppSettings;
        private FacebookDataProxy m_FacebookDataProxy;
        private bool m_FetchedPresentedPosts;

        public FormMain()
        {
            InitializeComponent();
            m_LoginManager = new LoginManager();
            m_AppSettings = AppSettings.LoadFromFile();
            if (m_AppSettings.RememberMe && !string.IsNullOrEmpty(m_AppSettings.AccesToken))
            {
                m_LoginManager.ConnectToFacebook(m_AppSettings.AccesToken);
                handleAllToolsAfterLogin();
                checkBoxRememberMe.Checked = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            if (m_LoginManager.LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            try
            {
                if (!m_LoginManager.Login())
                {
                    MessageBox.Show("Error logging in.");
                }
                else
                {
                    handleAllToolsAfterLogin();
                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error logging in.");
                m_LoginManager.LoginResult = null;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginManager.LoginResult = null;
            handleAllToolsAfterLogout();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (m_AppSettings.RememberMe && m_LoginManager.LoginResult != null)
            {
                m_AppSettings.AccesToken = m_LoginManager.LoginResult.AccessToken;
                m_AppSettings.SaveToFile();
            }
            else
            {
                m_AppSettings.AccesToken = null;
                try
                {
                    m_AppSettings.deleteDetailsAndFile();
                }
                catch (Exception genetalException)
                {
                    MessageBox.Show(genetalException.Message);
                }
            }
        }

        private void buttonLikedPages_Click(object sender, EventArgs e)
        {
            new Thread(()=>presentLikedPages()).Start();
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            new Thread(() => presentAllAlbums()).Start();
        }

        private void presentAllAlbums()
        {
            FacebookObjectCollection<Album> albums;
            try
            {
                albums = m_FacebookDataProxy.FetchAlbums();
                listBoxAlbums.Invoke(new Action(() => albumBindingSource.DataSource = albums));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void handleAllToolsAfterLogin()
        {
            panelAlbums.Visible = true;
            panelPosts.Visible = true;
            m_FetchedPresentedPosts = false;
            buttonNext.Visible = true;
            buttonPrev.Visible = true;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            buttonLikedPages.Visible = true;
            buttonLikedPages.Enabled = true;
            listBoxLikedPages.Visible = true;
            listBoxAlbums.Visible = true;
            buttonAlbums.Visible = true;
            buttonAlbums.Enabled = true;
            pictureBoxFriends.Visible = true;
            buttonFriends.Visible = true;
            buttonFriends.Enabled = true;
            listBoxFriends.Visible = true;
            labelDetailsHeadline.Visible = true;
            pictureBoxProfile.Visible = true;
            m_FacebookDataProxy = new FacebookDataProxy(m_LoginManager.LoggedInUser);
            labelWelcome.Visible = false;
            buttonPosts.Enabled = true;
            buttonPosts.Visible = true;
            pageableListBox.Visible = true;
            labelBasicDetails.Visible = true;
            labelWhatsOnYourMind.Visible = true;
            textBoxPostStatus.Visible = true;
            textBoxPostStatus.Enabled = true;
            buttonPublishPost.Visible = true;
            buttonPublishPost.Enabled = true;
            buttonPast.Visible = true;
            buttonPast.Enabled = true;
            labelBasicDetails.Text = m_FacebookDataProxy.FetchBasicInfo();
            pictureBoxProfile.LoadAsync(m_FacebookDataProxy.FetchProfilePicURL());
            m_GuessingGameUI = new GuessingGameUI(m_FacebookDataProxy.FetchLikedPages().ToList(), textBoxGuess, buttonGuess, labelOutcome, buttonPlayAgain, labelPage);
            tabPage2.Controls.AddRange(m_GuessingGameUI.CharLabels);
            pageableListBox.SetNextPrevButtons(buttonNext, buttonPrev);
            pageableListBox.setComponentsPagebleListBox(nameTextBox, captionTextBox, createdTimePosts);
            
        }

        private void handleAllToolsAfterLogout()
        {
            panelAlbums.Visible = false;
            buttonNext.Visible = false;
            buttonPrev.Visible = false;
            panelPosts.Visible = false;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            buttonLikedPages.Visible = false;
            buttonLikedPages.Enabled = false;
            listBoxLikedPages.Visible = false;
            listBoxLikedPages.Items.Clear();
            listBoxAlbums.Visible = false;
            listBoxAlbums.Items.Clear();
            buttonAlbums.Visible = false;
            buttonAlbums.Enabled = false;
            labelDetailsHeadline.Visible = false;
            pictureBoxProfile.Visible = false;
            labelWelcome.Visible = true;
            buttonPosts.Enabled = false;
            buttonPosts.Visible = false;
            pageableListBox.Visible = false;
            labelBasicDetails.Visible = false;
            labelWhatsOnYourMind.Visible = true;
            textBoxPostStatus.Visible = true;
            textBoxPostStatus.Enabled = true;
            buttonPublishPost.Visible = false;
            buttonPublishPost.Enabled = false;
            buttonPast.Visible = true;
            buttonPast.Enabled = true;
            labelWhatsOnYourMind.Visible = false;
            textBoxPostStatus.Visible = false;
            textBoxPostStatus.Enabled = false;
            buttonPublishPost.Visible = false;
            buttonPublishPost.Enabled = false;
            buttonPast.Visible = false;
            buttonPast.Enabled = false;
            pictureBoxFriends.Visible = false;
            buttonFriends.Visible = false;
            buttonFriends.Enabled = false;
            listBoxFriends.Visible = false;
            m_GuessingGameUI.UserLogout();
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            new Thread(() => presentAllPosts()).Start();
        }

        private void presentAllPosts()
        {
            FacebookObjectCollection<Post> posts;
            try
            {
                if (!m_FetchedPresentedPosts)
                {
                    posts = m_FacebookDataProxy.FetchPosts();
                    pageableListBox.StoreFetchedPosts(posts.ToList());
                    pageableListBox.Invoke(new Action(() => pageableListBox.PresentNextPage()));
                    m_FetchedPresentedPosts = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void presentLikedPages()
        {
            FacebookObjectCollection<Page> pages;

            try
            {
                pages = m_FacebookDataProxy.FetchLikedPages();

                if (pages.Count == 0)
                {
                    MessageBox.Show("No liked pages exist.");
                }
                else
                {
                    listBoxLikedPages.Invoke(new Action(() =>
                    {
                        foreach (Page page in pages)
                        {
                            listBoxLikedPages.Items.Add(page);
                            listBoxLikedPages.DisplayMember = "Name";
                        }
                    }));
                }
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error trying to fetch liked pages.");
            }
        }

        private void displaySelectedPage()
        {
            Page selectedLikedPage = listBoxLikedPages.SelectedItem as Page;
            pictureBoxLikedPages.LoadAsync(selectedLikedPage.PictureNormalURL);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            if (textBoxPostStatus.Text == "")
            {
                MessageBox.Show("Cannot post an empty status.");
            }
            else
            {
                try
                {
                    Status postedStatus;
                    Thread statusThread = new Thread(() =>
                    {
                        try
                        {
                            postedStatus = m_FacebookDataProxy.PostStatus(textBoxPostStatus.Text);
                            MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message);
                        }
                    });
                }
                catch (Exception generalException)
                {
                    MessageBox.Show("There was a problem with posting the status");
                }
            }
        }

        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRememberMe.Checked)
            {
                m_AppSettings.RememberMe = true;
            }
            else
            {
                m_AppSettings.RememberMe = false;
            }
        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            new Thread(()=>presentAllFriends()).Start();
        }

        private void presentAllFriends()
        {
            FacebookObjectCollection<User> friends;
            try
            {
                friends = m_FacebookDataProxy.FetchFriends();
                if (friends.Count == 0)
                {
                    MessageBox.Show("User has no friends");
                }
                else
                {
                    listBoxFriends.Invoke(new Action(() =>
                    {
                        foreach (User friend in friends)
                        {
                            listBoxFriends.Items.Add(friend);
                            listBoxFriends.DisplayMember = "Name";
                        }
                    }));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error trying to fetch friends.");
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentSingleFriend();
        }

        private void presentSingleFriend()
        {
            User selectedFriend = listBoxFriends.SelectedItem as User;
            pictureBoxFriends.LoadAsync(selectedFriend.PictureNormalURL);
        }

        private void buttonPast_Click(object sender, EventArgs e)
        {
            Post randomOldPost;
            FacebookObjectCollection<Post> listOfPosts;
            try
            {
                Thread threadPostPresenter = new Thread(() =>
                {
                    listOfPosts = m_FacebookDataProxy.FetchPosts();
                    randomOldPost = getRandomOldPost(listOfPosts);
                    showRandomOldPost(randomOldPost);
                });
                threadPostPresenter.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Post getRandomOldPost(FacebookObjectCollection<Post> i_ListOfPosts)
        {
            int earliestYear;
            List<Post> oldestPosts;
            Random random = new Random();
            int randInd;
            Filter filter = new Filter(new OldPostsFilter());

            oldestPosts = filter.FilterPosts(i_ListOfPosts);
            randInd = random.Next(0, oldestPosts.Count - 1);

            return oldestPosts.ElementAt(randInd);
        }

        private void showRandomOldPost(Post i_RandomOldPost)
        {
            if (i_RandomOldPost.Type == Post.eType.status)
            {
                MessageBox.Show(i_RandomOldPost.Message);
            }
            else
            {
                presentImageInPopUp(i_RandomOldPost);
            }
        }

        private void presentImageInPopUp(Post i_RandomOldPost)
        {
            Form imagePopUpForm = new Form
            {
                Text = "Your Fadicha:",
                Width = 400,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(380, 240),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            pictureBox.LoadAsync(i_RandomOldPost.PictureURL);

            imagePopUpForm.Controls.Add(pictureBox);
            imagePopUpForm.ShowDialog();
        }

        private void buttonGuess_Click(object sender, EventArgs e)
        {
            m_GuessingGameUI.PlayTurn();
        }

        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            foreach (Label labelChar in m_GuessingGameUI.CharLabels)
            {
                tabPage2.Controls.Remove(labelChar);
            }

            m_GuessingGameUI.Rematch();
            tabPage2.Controls.AddRange(m_GuessingGameUI.CharLabels);
        }

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedPage();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            pageableListBox.Invoke(new Action(() => pageableListBox.PresentNextPage()));
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            pageableListBox.Invoke(new Action(() => pageableListBox.PresentPrevPage()));
        }

        private void pageableListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageableListBox.DisplaySelectedPost();
        }
    }
}
