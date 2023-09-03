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
        //private User m_LoggedInUser;
        private GuessingGameUI m_GuessingGameUI;
        private LoginManager m_LoginManager;
        private AppSettings m_AppSettings;
        private List<Post> m_ListOfPosts;
        private FacebookDataProxy m_FacebookDataProxy;

        public FormMain()
        {
            InitializeComponent();
            m_LoginManager = new LoginManager();
            m_AppSettings = AppSettings.LoadFromFile();
            m_ListOfPosts = null;
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
            presentLikedPages();
        }

        private void presentLikedPages()
        {
            
           
            //listBoxLikedPages.DisplayMember = "Name";
            //listBoxLikedPages.DataSource = pageBindingSource;
            //try
            //{
            //    List<Page> likedPages = m_LoggedInUser.LikedPages.ToList();

            //    if (likedPages.Count == 0)
            //    {
            //        MessageBox.Show("No liked pages exist.");
            //    }
            //    else
            //    {
            //        foreach (Page currentPage in likedPages)
            //        {
            //            listBoxLikedPages.Items.Add(currentPage);
            //            listBoxLikedPages.DisplayMember = "Name";
            //        }
            //    }
            //}
            //catch (Exception generalException)
            //{
            //    MessageBox.Show("Error trying to fetch liked pages.");
            //}
        }

        //private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    displaySelectedPage();
        //}

        //private void displaySelectedPage()
        //{
        //    Page selectedLikedPage = listBoxLikedPages.SelectedItem as Page;
        //    pictureBoxLikedPages.LoadAsync(selectedLikedPage.PictureNormalURL);
        //}

        private void presentAllAlbums()
        {
            //albumBindingSource.DataSource = m_LoggedInUser.Albums;
            //try
            //{
            //    List<Album> allAlbums = m_LoggedInUser.Albums.ToList();
            //    if (allAlbums.Count == 0)
            //    {
            //        MessageBox.Show("User has no albums.");
            //    }
            //    else
            //    {
            //        foreach (Album cuurentAlbum in allAlbums)
            //        {
            //            listBoxAlbums.Items.Add(cuurentAlbum);
            //            listBoxAlbums.DisplayMember = "Name";
            //        }
            //    }
            //}
            //catch (Exception generalException)
            //{
            //    MessageBox.Show("Error trying to fetch albums.");
            //}
        }

        //private void presentSelectedAlbum()
        //{
        //    Album selectedAlbum = listBoxAlbums.SelectedItem as Album;
        //    pictureBoxAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
        //}

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            presentAllAlbums();
        }

        //private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    presentSelectedAlbum();
        //}

        private void handleAllToolsAfterLogin()
        {
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
            m_FacebookDataProxy = new FacebookDataProxy(m_LoginManager.LoggedInUser, postBindingSource);
            //postBindingSource.DataSource = m_FacebookDataProxy.Posts;
            //albumBindingSource.DataSource = m_FacebookDataProxy.Albums;
            //pageBindingSource.DataSource = m_FacebookDataProxy.LikedPages;
            labelWelcome.Visible = false;
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
            labelBasicDetails.Text = m_FacebookDataProxy.FetchBasicInfo();
            pictureBoxProfile.LoadAsync(m_FacebookDataProxy.FetchProfilePicURL());
            //m_GuessingGameUI = new GuessingGameUI(m_FacebookDataProxy.LikedPages.ToList(), textBoxGuess, buttonGuess, labelOutcome, buttonPlayAgain, labelPage);
            //tabPage2.Controls.AddRange(m_GuessingGameUI.LabelChars);
        }

        private void handleAllToolsAfterLogout()
        {
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
            listBoxPosts.Visible = false;
            labelBasicDetails.Visible = false;
            labelWhatsOnYourMind.Visible = true;
            textBoxPostStatus.Visible = true;
            textBoxPostStatus.Enabled = true;
            buttonPost.Visible = true;
            buttonPost.Enabled = true;
            buttonPast.Visible = true;
            buttonPast.Enabled = true;
            labelWhatsOnYourMind.Visible = false;
            textBoxPostStatus.Visible = false;
            textBoxPostStatus.Enabled = false;
            buttonPost.Visible = false;
            buttonPost.Enabled = false;
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
            presentAllPosts();
        }

        private void presentAllPosts()
        {
            Thread postsThread = new Thread(()=>
            {
                try
                {
                    FacebookObjectCollection<Post> fetchedposts = m_FacebookDataProxy.FetchPosts();
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(fetchedposts)));
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });

            postsThread.Start();
                //fetchPosts();
                //foreach (Post post in m_ListOfPosts)
                //{
                //    listBoxPosts.Items.Add(post);
                //    listBoxPosts.DisplayMember = "Name";
                //}
        }

        //private void fetchPosts()
        //{
        //    try
        //    {
        //        if (m_ListOfPosts == null)
        //        {

        //            m_ListOfPosts = m_FacebookDataProxy.FetchPosts();

        //            if (m_ListOfPosts.Count == 0)
        //            {
        //                MessageBox.Show("User has no posts");
        //            }
        //        }
        //    }
        //    catch (Exception generalException)
        //    {
        //        MessageBox.Show("Error trying to fetch posts.");
        //    }
        //}

        //private void fetchBasicInfo()
        //{
        //    labelBasicDetails.Text = "Name: " + m_LoggedInUser.FirstName + " " + m_LoggedInUser.LastName + "\n\n";
        //    fetchBirthdayAndCalculateCountdown();
        //    labelBasicDetails.Text += "Gender: " + m_LoggedInUser.Gender + "\n\n";
        //    labelBasicDetails.Text += "Email: " + m_LoggedInUser.Email + "\n\n";
        //    pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
        //}

        //private void fetchBirthdayAndCalculateCountdown()
        //{
        //    try
        //    {
        //        string userBirthday = m_LoggedInUser.Birthday;
        //        DateTime today = DateTime.Today;
        //        DateTime formatedUserBirthday;
        //        if (DateTime.TryParseExact(userBirthday, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out formatedUserBirthday))
        //        {
        //            DateTime birthdayThisYear = new DateTime(today.Year, formatedUserBirthday.Month, formatedUserBirthday.Day);
        //            if (today > birthdayThisYear)
        //            {
        //                birthdayThisYear = birthdayThisYear.AddYears(1);
        //            }

        //            TimeSpan daysDifference = birthdayThisYear.Subtract(today);
        //            if (daysDifference.Days == 0)
        //            {
        //                labelBasicDetails.Text += "Happy birthday!!!\n\n";
        //            }
        //            else
        //            {
        //                labelBasicDetails.Text += $"Your birthday is in {userBirthday}\n\nYou have {daysDifference.Days} days until your birthday\n\n";
        //            }
        //        }
        //        else
        //        {
        //            labelBasicDetails.Text += "You havent provided a birthday\n\n";

        //        }
        //    }
        //    catch (Exception generalException)
        //    {
        //        MessageBox.Show("Error trying to fetch birthday");
        //    }
        //}

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
                    Status postedStatus = m_FacebookDataProxy.PostStatus(textBoxPostStatus.Text);
                    MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
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
            presentAllFriends();
        }

        private void presentAllFriends()
        {
            try
            {
                List<User> allFriends = m_FacebookDataProxy.FetchFriends().ToList();
                if (allFriends.Count == 0)
                {
                    MessageBox.Show("User has no friends");
                }
                else
                {
                    foreach (User friend in allFriends)
                    {
                        listBoxFriends.Items.Add(friend);
                        listBoxFriends.DisplayMember = "Name";
                    }
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
            try
            {
                m_FacebookDataProxy.FetchPosts();
                randomOldPost = getRandomOldPost();
                showRandomOldPost(randomOldPost);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Post getRandomOldPost()
        {
            int earliestYear;
            List<Post> oldestPosts;
            Random random = new Random();
            int randInd;

            earliestYear = findEarliestYear();
            oldestPosts = m_ListOfPosts.Where(post => ((post.CreatedTime.Value.Year >= earliestYear) && (post.CreatedTime.Value.Year <= earliestYear + 5)) && ((post.Type == Post.eType.photo) || (post.Type == Post.eType.status)) && !post.Equals("")).ToList();
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


        private int findEarliestYear()
        {
            DateTime earliestDate = DateTime.Now;
            int currentYear;

            foreach (Post currentPost in m_ListOfPosts)
            {
                currentYear = ((DateTime)currentPost.CreatedTime).Year;
                if (currentYear >= 2009 && currentPost.CreatedTime < earliestDate)
                {
                    earliestDate = (DateTime)currentPost.CreatedTime;
                }
            }

            return earliestDate.Year;
        }

        private void buttonGuess_Click(object sender, EventArgs e)
        {
            m_GuessingGameUI.PlayTurn();
        }

        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            foreach (Label labelChar in m_GuessingGameUI.LabelChars)
            {
                tabPage2.Controls.Remove(labelChar);
            }

            m_GuessingGameUI.Rematch();
            tabPage2.Controls.AddRange(m_GuessingGameUI.LabelChars);
        }
    }
}

        
