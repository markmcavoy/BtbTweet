using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiteTheBullet.BtbTweet.Twitter
{
    public interface ICacheProvider
    {
        string GetBearer();

        void SetBearer(string bearerToken);

        IList<TwitterInfo> GetSearchResults(string query, int count);

        void SetSearchResults(string query, int count, IList<TwitterInfo> results);

        IList<TwitterInfo> GetUserTimeline(string username, int count);

        void SetUserTimeline(string username, int count, IList<TwitterInfo> results);
        void SetUserTimeline(string v, List<TwitterInfo> twitterResult);

        void GetTwitterMedia(long id);
    }
}
