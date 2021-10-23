import React from "react";
import moment from "moment";

const Tweet = ({tweet}) => {

    const tweetAge = (createdDate) => {

        var timeDiffMin = moment().diff(createdDate, "minutes");
        var timeDiffHours = moment().diff(createdDate, 'hours');
        var timeDiffDay = moment().diff(createdDate, 'days');

        if (timeDiffDay >= 1)
            return(<p>About {timeDiffDay} days ago</p>);
        else if (timeDiffHours > 0)
            return(<p>About {timeDiffHours} hours ago</p>);
        else
            return(<p>About {timeDiffMin} minutes ago</p>);

    };

    return(<div>
        <div className="tweet-avatar">
            <img src={tweet.ProfileImage} alt="" />
        </div>
        <div className="tweet-body">
            <div dangerouslySetInnerHTML={{ __html: tweet.ProcessedText }} />
            {tweetAge(tweet.Created)}
        </div>
    </div>);
    
};

export default Tweet;