<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCampaign.ascx.cs" Inherits="WebApplication37.ucCampaign" %>
<%@ Import Namespace="WebApplication37" %>
<tr>
    <td><%=Campaign.Name %></td>
    <td><%=Campaign.TemplateName %></td>
    <td><%=Campaign.Category %></td>
    <td><%=Campaign.Email %></td>
    <td><%= string.Format("{0:MM/dd/yyyy}",Campaign.Date) %></td>
    <td><asp:LinkButton runat="server" OnClick="Delete_Record" CommandArgument="<%=Campaign.Name %>">delete</asp:LinkButton></td> 
</tr>