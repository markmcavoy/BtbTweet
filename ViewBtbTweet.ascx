<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewBtbTweet.ascx.cs" Inherits="BiteTheBullet.Modules.BtbTweet.ViewBtbTweet" %>
<%@ Register TagPrefix="Tweet" Namespace="BiteTheBullet.BtbTweet.Controls" Assembly="BtbTweet" %>

<script type="text/javascript">
    if (typeof jQuery == 'undefined') {
        document.write(unescape("%3Cscript src='http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js' type='text/javascript'%3E%3C/script%3E"));
        document.write(unescape("%3Cscript type='text/javascript'%3EjQuery.noConflict();%3C/script%3E"));
    }
</script>

<Tweet:TweetControl ID="Tweet" runat="server" />
