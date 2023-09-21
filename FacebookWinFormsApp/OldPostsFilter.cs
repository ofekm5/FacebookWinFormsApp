using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class OldPostsFilter : IFilteredPostsStrategy
    {
        public List<Post> BringFilteredPosts(FacebookObjectCollection<Post> i_ListOfPosts, int i_EarliestYear)
        {
            List<Post> filteredList = i_ListOfPosts.Where(post => ((post.CreatedTime.Value.Year >= i_EarliestYear) && (post.CreatedTime.Value.Year <= i_EarliestYear + 5)) && ((post.Type == Post.eType.photo) || (post.Type == Post.eType.status)) && !post.Equals("")).ToList();
            return filteredList;
        }
    }
}
