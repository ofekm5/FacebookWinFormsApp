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
        public List<Post> BringFilteredPosts(FacebookObjectCollection<Post> i_ListOfPosts)
        {
            int earliestYear = findEarliestYear(i_ListOfPosts);
            List<Post> filteredList = i_ListOfPosts.Where(post => ((post.CreatedTime.Value.Year >= earliestYear) && (post.CreatedTime.Value.Year <= earliestYear + 5)) && ((post.Type == Post.eType.photo) || (post.Type == Post.eType.status)) && !post.Equals("")).ToList();
            return filteredList;
        }

        private int findEarliestYear(FacebookObjectCollection<Post> i_Posts)
        {
            DateTime earliestDate = DateTime.Now;
            int currentYear;

            foreach (Post currentPost in i_Posts)
            {
                currentYear = ((DateTime)currentPost.CreatedTime).Year;
                if (currentYear >= 2009 && currentPost.CreatedTime < earliestDate)
                {
                    earliestDate = (DateTime)currentPost.CreatedTime;
                }
            }

            return earliestDate.Year;
        }
    }
}
