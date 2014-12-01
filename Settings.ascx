<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="BiteTheBullet.Modules.BtbTweet.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="ModuleName1 Settings Design Table">
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblCount" runat="server" controlname="txtCount" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtCount" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblMode" runat="server" controlname="txtQuery" suffix=":"></dnn:label></td>
        <td>
            <asp:RadioButton runat="server" GroupName="tweetMode" ID="rbUserTimeline" CssClass="rbUserTimeline rbMode" resourcekey="rbUserTimeline" />
            <asp:RadioButton runat="server" GroupName="tweetMode" ID="rbSearch" CssClass="rbSearch rbMode" resourcekey="rbSearch"/>
        </td>
    </tr>
    <tr id="queryInput" style="display:none;">
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblQuery" runat="server" controlname="txtQuery" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtQuery" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
    <tr id="usernameInput" style="display:none;">
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblUsername" runat="server" controlname="txtUsername" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtUsername" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
</table>

<script type="text/javascript">

    jQuery(document).ready(function () {

        SetMode();

        jQuery(".rbMode :input").change(function () {
            SetMode();
        });
    });

    function SetMode() {
        if (jQuery(".rbSearch :input").is(":checked")) {
            jQuery("#queryInput").show();
            jQuery("#usernameInput").hide();
        } else {
            jQuery("#queryInput").hide();
            jQuery("#usernameInput").show();
        }
    }

</script>