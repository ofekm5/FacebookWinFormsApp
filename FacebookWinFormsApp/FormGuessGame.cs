using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormGuessGame : Form
    {
        private User m_TheLoggedInUser;
        private  const int k_MaxNumberOfTries = 10;
        private int m_CurrNumberOfTries = 1;
        private string m_SelectedRandomPageName;
        public FormGuessGame(User i_TheLoggedInUser)
        {
            m_TheLoggedInUser = i_TheLoggedInUser;
            InitializeComponent();
            presentLikedPagesAndChooseRandom();
        }

        private void presentLikedPagesAndChooseRandom()
        {
            try
            {
                Page[] likedPagesArr = m_TheLoggedInUser.LikedPages.ToArray();

                if (likedPagesArr.Count() == 0)
                {
                    MessageBox.Show("No liked pages exist.");
                }
                else
                {
                    foreach (Page currentPage in likedPagesArr)
                    {
                        listBoxLikedPages.Items.Add(currentPage);
                        listBoxLikedPages.DisplayMember = "Name";
                    }
                    Random random = new Random();
                    int randomLikedPageIndex = random.Next(0, likedPagesArr.Count() - 1);
                    m_SelectedRandomPageName = likedPagesArr[randomLikedPageIndex].Name;
                }
            }
            catch (Exception generalException)
            {

            }
        }

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page selectedPage = listBoxLikedPages.SelectedItem as Page;
            if(selectedPage.Name == m_SelectedRandomPageName)
            {
                MessageBox.Show("You won!!! :)");
                this.Close();
            }
            else if(m_CurrNumberOfTries == k_MaxNumberOfTries)
            {
                MessageBox.Show("You lost :(");
                this.Close();
            }
            else
            {
                m_CurrNumberOfTries++;
            }
        }
    }
}
