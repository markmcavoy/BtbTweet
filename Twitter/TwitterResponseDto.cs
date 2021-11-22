using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteTheBullet.BtbTweet.Twitter
{

    public class TwitterResponseDto
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities entities { get; set; }
        public string source { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public User user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public long quoted_status_id { get; set; }
        public string quoted_status_id_str { get; set; }
        public Quoted_Status quoted_status { get; set; }
        public int retweet_count { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public bool possibly_sensitive { get; set; }
        public string lang { get; set; }
    }

    public class Entities
    {
        public Hashtag[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public object[] user_mentions { get; set; }
        public Url[] urls { get; set; }
    }

    public class Hashtag
    {
        public string text { get; set; }
        public int[] indices { get; set; }
    }

    public class Url
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public int[] indices { get; set; }
    }

    public class User
    {
        public long id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Entities1 entities { get; set; }
        public bool _protected { get; set; }
        public int followers_count { get; set; }
        public int friends_count { get; set; }
        public int listed_count { get; set; }
        public string created_at { get; set; }
        public int favourites_count { get; set; }
        public object utc_offset { get; set; }
        public object time_zone { get; set; }
        public bool geo_enabled { get; set; }
        public bool verified { get; set; }
        public int statuses_count { get; set; }
        public object lang { get; set; }
        public bool contributors_enabled { get; set; }
        public bool is_translator { get; set; }
        public bool is_translation_enabled { get; set; }
        public string profile_background_color { get; set; }
        public string profile_background_image_url { get; set; }
        public string profile_background_image_url_https { get; set; }
        public bool profile_background_tile { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_banner_url { get; set; }
        public string profile_link_color { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string profile_text_color { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool has_extended_profile { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public object following { get; set; }
        public object follow_request_sent { get; set; }
        public object notifications { get; set; }
        public string translator_type { get; set; }
        public object[] withheld_in_countries { get; set; }
    }

    public class Entities1
    {
        public Url1 url { get; set; }
        public Description description { get; set; }
    }

    public class Url1
    {
        public Url2[] urls { get; set; }
    }

    public class Url2
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public int[] indices { get; set; }
    }

    public class Description
    {
        public object[] urls { get; set; }
    }

    public class Quoted_Status
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities2 entities { get; set; }
        public string source { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public User1 user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public int retweet_count { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public bool possibly_sensitive { get; set; }
        public string lang { get; set; }
    }

    public class Entities2
    {
        public Hashtag1[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public object[] user_mentions { get; set; }
        public Url3[] urls { get; set; }
    }

    public class Hashtag1
    {
        public string text { get; set; }
        public int[] indices { get; set; }
    }

    public class Url3
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public int[] indices { get; set; }
    }

    public class User1
    {
        public long id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Entities3 entities { get; set; }
        public bool _protected { get; set; }
        public int followers_count { get; set; }
        public int friends_count { get; set; }
        public int listed_count { get; set; }
        public string created_at { get; set; }
        public int favourites_count { get; set; }
        public object utc_offset { get; set; }
        public object time_zone { get; set; }
        public bool geo_enabled { get; set; }
        public bool verified { get; set; }
        public int statuses_count { get; set; }
        public object lang { get; set; }
        public bool contributors_enabled { get; set; }
        public bool is_translator { get; set; }
        public bool is_translation_enabled { get; set; }
        public string profile_background_color { get; set; }
        public string profile_background_image_url { get; set; }
        public string profile_background_image_url_https { get; set; }
        public bool profile_background_tile { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string profile_banner_url { get; set; }
        public string profile_link_color { get; set; }
        public string profile_sidebar_border_color { get; set; }
        public string profile_sidebar_fill_color { get; set; }
        public string profile_text_color { get; set; }
        public bool profile_use_background_image { get; set; }
        public bool has_extended_profile { get; set; }
        public bool default_profile { get; set; }
        public bool default_profile_image { get; set; }
        public object following { get; set; }
        public object follow_request_sent { get; set; }
        public object notifications { get; set; }
        public string translator_type { get; set; }
        public object[] withheld_in_countries { get; set; }
    }

    public class Entities3
    {
        public Url4 url { get; set; }
        public Description1 description { get; set; }
    }

    public class Url4
    {
        public Url5[] urls { get; set; }
    }

    public class Url5
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public int[] indices { get; set; }
    }

    public class Description1
    {
        public object[] urls { get; set; }
    }

}