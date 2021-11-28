using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteTheBullet.BtbTweet.Twitter
{
    public class PublicMetrics
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
        public int followers_count { get; set; }
        public int following_count { get; set; }
        public int tweet_count { get; set; }
        public int listed_count { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public List<Image> images { get; set; }
        public int? status { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string unwound_url { get; set; }
    }

    public class Annotation
    {
        public int start { get; set; }
        public int end { get; set; }
        public double probability { get; set; }
        public string type { get; set; }
        public string normalized_text { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
    }

    public class Entities
    {
        public List<Url> urls { get; set; }
        public List<Annotation> annotations { get; set; }
        public List<Mention> mentions { get; set; }
        public Url url { get; set; }
        public Description description { get; set; }
    }

    public class ReferencedTweet
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Domain
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ContextAnnotation
    {
        public Domain domain { get; set; }
        public Entity entity { get; set; }
    }

    public class Datum
    {
        public PublicMetrics public_metrics { get; set; }
        public string source { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public string conversation_id { get; set; }
        public string text { get; set; }
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
        public string reply_settings { get; set; }
        public string lang { get; set; }
        public List<ContextAnnotation> context_annotations { get; set; }
        public bool possibly_sensitive { get; set; }
        public string in_reply_to_user_id { get; set; }
    }

    public class Url2
    {
        public List<Url> urls { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Description
    {
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
    }

    public class User
    {
        public string profile_image_url { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string name { get; set; }
        public Entities entities { get; set; }
        public string username { get; set; }
        public string location { get; set; }
        public bool verified { get; set; }
        public bool @protected { get; set; }
        public string description { get; set; }
        public string pinned_tweet_id { get; set; }
        public DateTime created_at { get; set; }
    }

    public class Tweet
    {
        public PublicMetrics public_metrics { get; set; }
        public string source { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public string conversation_id { get; set; }
        public string text { get; set; }
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
        public string reply_settings { get; set; }
        public string lang { get; set; }
        public List<ContextAnnotation> context_annotations { get; set; }
        public bool possibly_sensitive { get; set; }
    }

    public class Includes
    {
        public List<User> users { get; set; }
        public List<Tweet> tweets { get; set; }
    }

    public class Error
    {
        public string resource_id { get; set; }
        public string parameter { get; set; }
        public string resource_type { get; set; }
        public string section { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public string detail { get; set; }
        public string type { get; set; }
    }

    public class Meta
    {
        public string oldest_id { get; set; }
        public string newest_id { get; set; }
        public int result_count { get; set; }
        public string next_token { get; set; }
    }

    public class Root
    {
        public List<Datum> data { get; set; }
        public Includes includes { get; set; }
        public List<Error> errors { get; set; }
        public Meta meta { get; set; }
    }
}