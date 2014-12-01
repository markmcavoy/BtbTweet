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

        public string Text 
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                ProcessedText = AddHyperlinks(value);
            } 
        }

        public string ProcessedText { get; set; }

        public DateTime Created { get; set; }

        public long StatusId { get; set; }

        public string ProfileName { get; set; }

        public string ProfileImage { get; set; }

        private string AddHyperlinks(string input)
        {
            var temp = Regex.Replace(input, @"\b((http|https)://\S*)\b", "<a href=\"$1\">$1</a>");
            temp = Regex.Replace(temp, @"(#(\b\S*\b))", "<a href=\"https://twitter.com/search?q=%23$2\">$1</a>");
            temp = Regex.Replace(temp, @"(@(\b\S*\b))", "<a href=\"https://twitter.com/$2\">$1</a>");

            return temp;

        }

    }
}