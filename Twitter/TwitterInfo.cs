﻿using BiteTheBullet.BtbTweet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BiteTheBullet.BtbTweet.Twitter
{
    public class TwitterInfo
    {
        string text;
        string profileImage;

        public string Text
        {
            get
            {
                return text;
            }

            set
            {

                text = value;
                if (text != null)
                {
                    ProcessedText = AddHyperlinks(value);
                } else
                {
                    //do nothing
                }
            }
        }

        public string[] HashTags { get; set; }

        public string ProcessedText { get; set; }

        public DateTime Created { get; set; }

        public string TweetAge
        {
            get => Created.ApproxAge();
        }

        public long StatusId { get; set; }

        public string ProfileName { get; set; }

        public string TwitterUsername { get; set; }

        public int RetweetCount { get; set; }

        public int FavouriteCount { get; set; }

        public bool Verified { get; set; }

        public string[] MediaUrl { get; set; }

        public string ProfileImage {
            get
            {
                return profileImage;
            }

            set
            {
                profileImage = value.Replace("http://", "https://");
                profileImage = value.Replace("_normal", "_400x400");
            }
        }

        private string AddHyperlinks(string input)
        {
            var temp = Regex.Replace(input, @"\b((http|https)://\S*)\b", "<a href=\"$1\">$1</a>");
            temp = Regex.Replace(temp, @"(#(\b\S*\b))", "<a href=\"https://twitter.com/search?q=%23$2\">$1</a>");
            temp = Regex.Replace(temp, @"(@(\b\S*\b))", "<a href=\"https://twitter.com/$2\">$1</a>");

            return temp;

        }
    }
}