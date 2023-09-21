using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class Filter
    {
        private IFilteredPostsStrategy m_MyFilteredPostsStrategy;

        public Filter(IFilteredPostsStrategy i_filteredPostsStrategy)
        {
            this.m_MyFilteredPostsStrategy = i_filteredPostsStrategy;
        }

        public IFilteredPostsStrategy MyFilterer
        {
            get
            {
                return this.m_MyFilteredPostsStrategy;
            }
            set
            {
                this.m_MyFilteredPostsStrategy = value;
            }
        }

        public List<Post> FilterPosts(FacebookObjectCollection<Post> i_ListOfPosts, int i_EarliestYear)
        {
            List<Post> filteredPost = this.m_MyFilteredPostsStrategy.BringFilteredPosts(i_ListOfPosts, i_EarliestYear);
            return filteredPost;
        }
    }
}
