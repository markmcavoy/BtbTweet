import React, { useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import request from 'SuperAgent';

import Loading from './loading';
import Tweet from './tweet';

const Main = () => {

    const [isLoaded, setIsLoaded] = useState(false);
    const [tweets, setTweets] = useState([]);

    useEffect(() =>{
        loadTweets();
    }, 
    []);

    const loadTweets = () => {
        var data = {...btbContext};

        request
          .post('/DesktopModules/BtbTweet/WebServices/Twitter.asmx/LoadTweets')
          .send(data)
          .then((res) => {
            setTweets(res.body.d);
            setIsLoaded(true);
          })
          .catch((err) => {
            console.log(err);
          });
    };

    if(!isLoaded){
        return(<Loading/>);
    }

    return tweets.map((v, i) => <Tweet key={i} tweet={v} />);
};

ReactDOM.render(<Main />, document.getElementById('btbTweets'));