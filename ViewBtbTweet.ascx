<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewBtbTweet.ascx.cs" Inherits="BiteTheBullet.Modules.BtbTweet.ViewBtbTweet" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnJsInclude runat="server" FilePath="~/DesktopModules/CVNewsModule/JS/angular.min.js" />
<dnn:DnnJsInclude runat="server" FilePath="~/DesktopModules/BtbTweet/js/moment.js" />

<div class="row">
    <div class="col-sm-12">

        <div id="btbTwitterContainer" ng-controller="BtbTwitterAppCtrl" ng-Init="loadTweets()">
            <h2 ng-Hide="tweets.length > 0">Loading Tweets...</h2>
        
            <ul class="tweet-list" ng-Show="tweets.length > 0">
                <li ng-Repeat="t in tweets">
                    <div class="tweet-avatar">
                        <img ng-src="{{t.ProfileImage}}" alt="" />
                    </div>
                    <div class="tweet-body">
                        <span ng-bind-html="t.ProcessedText | to_trusted"></span>
                        <tweetage ng-Model="t.Created"></tweetage>
                    </div>

                </li>
            </ul>
        
        </div>
    </div>
</div>



<script type="text/javascript">
/* <![CDATA[ */
    'use strict';

    var BtbtwitterApp = angular.module('BtbtwitterApp', []);


    BtbtwitterApp.controller('BtbTwitterAppCtrl', function BtbTwitterAppCtrl($scope, $http) {

        $scope.pageUrl = '/DesktopModules/BtbTweet/WebServices/Twitter.asmx';
        $scope.tweets = [];

        $scope.loadTweets = function () {

            var data = {};
            data.portalId = <%= PortalId %>;
            data.tabModuleId = <%= TabModuleId %>;

            $http({
                method: 'POST',
                url: $scope.pageUrl + '/LoadTweets',
                data: data,
                headers: {
                    'Accept': 'application/json, text/javascript, */*; q=0.01',
                    'Content-Type': 'application/json; charset=utf-8'
                }
            }).success(function (data) {
                $scope.tweets = data.d;
            });
        };
    });

    BtbtwitterApp.filter('to_trusted', ['$sce', function($sce){
        return function(text) {
            return $sce.trustAsHtml(text);
        };
    }]);

    BtbtwitterApp.directive('tweetage', function ($parse) {
        return {
            restrict: 'E',
            require: 'ngModel',
            link: function ($scope, $element, $attrs, $ngModelCtrl) {  
                var d = $scope.$eval($attrs.ngModel);
                
                var timeDiffMin = moment().diff(d, "minutes");
                var timeDiffHours = moment().diff(d, 'hours');
                var timeDiffDay = moment().diff(d, 'days');

                if(timeDiffDay >= 1)
                    $element.html("<p>About " + timeDiffDay +" days ago</p>");
                else if(timeDiffHours >0)
                    $element.html("<p>About " + timeDiffHours +" hours ago</p>");
                else 
                    $element.html("<p>About " + timeDiffMin +" minutes ago</p>");

            }
        };
    });

    angular.element(document).ready(function () {
        angular.bootstrap(document.getElementById('btbTwitterContainer'), ['BtbtwitterApp']);
    });



/* ]]> */
</script>
