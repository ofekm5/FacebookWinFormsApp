using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    class PageableListBox : ListBox
    {
        private List<Post> m_ListOfPosts;
        private int m_CurrPage;
        private const int k_ItemsPerPage = 7;
        private Button m_NextPageButton, m_PrevPageButton;
        private int m_TotalPages;
        private TextBox m_NameTextBox;
        private TextBox m_CaptionTextBox;
        private DateTimePicker m_CreatedTimePosts;

        public PageableListBox()
        {
            m_ListOfPosts = new List<Post>();
            m_CurrPage = -1;
        }

        public void SetNextPrevButtons(Button i_BtnNext, Button i_BtnPrev)
        {
            this.m_NextPageButton = i_BtnNext;
            this.m_PrevPageButton = i_BtnPrev;
        }
        public void setComponentsPagebleListBox(TextBox i_NameTextBox, TextBox i_CaptionTextBox, DateTimePicker i_CreatedTimePosts)
        {
            m_NameTextBox = i_NameTextBox;
            m_CaptionTextBox = i_CaptionTextBox;
            m_CreatedTimePosts = i_CreatedTimePosts;
        }

        public void StoreFetchedPosts(List<Post> i_PostsList)
        {
            foreach (Post post in i_PostsList)
            {
                m_ListOfPosts.Add(post);
            }

            m_TotalPages = (int)Math.Ceiling((float)m_ListOfPosts.Count/k_ItemsPerPage);
        }

        public void PresentNextPage()
        {
            int itemsToTraverse;

            if (m_CurrPage < m_TotalPages)
            {
                this.Items.Clear();

                if (m_CurrPage < m_TotalPages - 1)
                {
                    m_CurrPage++;
                }

                if (m_CurrPage == m_TotalPages - 1)
                {
                    itemsToTraverse = m_ListOfPosts.Count - (m_CurrPage * k_ItemsPerPage);
                }
                else
                {
                    itemsToTraverse = k_ItemsPerPage;
                }

                for (int i = 0; i < itemsToTraverse; i++)
                {
                    this.Items.Add(m_ListOfPosts[i + (m_CurrPage*k_ItemsPerPage)]);
                }

                enableArrowButtonsIfNeeded();
            }
        }

        public void PresentPrevPage()
        {
            if (m_CurrPage > 0)
            {
                this.Items.Clear();
                m_CurrPage--;

                for (int i = 0; i < k_ItemsPerPage; i++)
                {
                    this.Items.Add(m_ListOfPosts[(m_CurrPage*k_ItemsPerPage) + i]);
                }
                
                enableArrowButtonsIfNeeded();
            }
        }

        private void enableArrowButtonsIfNeeded()
        {
            m_NextPageButton.Enabled = (m_CurrPage < m_TotalPages - 1) ? true : false;
            m_PrevPageButton.Enabled = (m_CurrPage <= 0) ? false : true;
        }

        public void displaySelectedPost()
        {
            Post selectedPost = this.SelectedItem as Post;
            m_CreatedTimePosts.Value = (DateTime)selectedPost.CreatedTime;
            m_CaptionTextBox.Text = selectedPost.Caption;
            m_NameTextBox.Text = selectedPost.Name;
        }

        
    }
}
