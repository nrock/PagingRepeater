<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="WebApplication37.Grid" %>

<%@ Import Namespace="WebApplication37" %>
<%@ Register Src="~/ucCampaign.ascx" TagPrefix="uc1" TagName="ucCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

     
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
            <table class="table">
                <asp:Repeater ID="rGrid" runat="server" OnItemDataBound="rGrid_OnItemDataBound">
                    <ItemTemplate>
                        <uc1:ucCampaign runat="server" id="ucCampaign"  />
                    </ItemTemplate>
                </asp:Repeater>
            </table>  
            <asp:LinkButton ID="lnkAdd" runat="server" OnClick="Add_Record"  Text="Add" ></asp:LinkButton> 
            
             

            <asp:HiddenField runat="server" ID="CurrentPage"   />   
            


            <ul class="pagination pagination-lg"> 
                <asp:Repeater ID="rPager" runat="server">
                    <ItemTemplate>
                        <li class="<%#((Pager) Container.DataItem).Style %>">
                            <asp:LinkButton ID="lnkPage" runat="server" OnClick="Page_Changed"
                                CommandArgument="<%#((Pager) Container.DataItem).PageValue %>"
                                Text='<%#Eval("Text") %>'></asp:LinkButton> 
                        </li>
                    </ItemTemplate>
                </asp:Repeater> 
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
