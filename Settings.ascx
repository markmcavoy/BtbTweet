<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="BiteTheBullet.Modules.BtbTweet.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="ModuleName1 Settings Design Table">
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblUsername" runat="server" controlname="txtUsername" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtUsername" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblCount" runat="server" controlname="txtCount" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtCount" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblQuery" runat="server" controlname="txtQuery" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtQuery" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="SubHead" width="150" valign="top"><dnn:label id="lblAvatarSize" runat="server" controlname="txtAvatarSize" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtAvatarSize" cssclass="NormalTextBox" columns="30" runat="server" />
        </td>
    </tr>
</table>