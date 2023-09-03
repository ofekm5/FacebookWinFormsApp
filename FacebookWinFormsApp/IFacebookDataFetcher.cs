using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    interface IFacebookDataFetcher
    {
        FacebookObjectCollection<Page> FetchLikedPages();
        FacebookObjectCollection<Post> FetchPosts();
        List<Album> FetchAlbums();
        string FetchBasicInfo();
        string FetchProfilePicURL();
        Status PostStatus(string i_Text);
        List<User> FetchFriends();
    }
}
