<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="WebApplication37.Grid" %>
<%@ Import Namespace="WebApplication37" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    
    <table class="table"> 
        <asp:Repeater ID="rGrid" runat="server"> 
            <ItemTemplate>
                <tr> 
                    <td><%#((Campaign) Container.DataItem).Name %></td> 
                    <td><%#((Campaign) Container.DataItem).TemplateName %></td> 
                    <td><%#((Campaign) Container.DataItem).Category %></td> 
                    <td><%#((Campaign) Container.DataItem).Email %></td> 
                    <td><%# string.Format("{0:MM/dd/yyyy}",((Campaign) Container.DataItem).Date) %></td>
                </tr>
            </ItemTemplate> 
        </asp:Repeater>
    </table>
    
     
    <ul class="pagination pagination-lg">  
        <asp:Repeater ID="rPager" runat="server"> 
            <ItemTemplate>
                <li class="<%#((Pager) Container.DataItem).Style %>"> 
                    
                    <asp:LinkButton ID="lnkPage" runat="server" OnClick="Page_Changed" 
                        CommandArgument="<%#((Pager) Container.DataItem).PageValue %>" 
                        Text='<%#Eval("Text") %>' ></asp:LinkButton>

                </li>
            </ItemTemplate> 
        </asp:Repeater> 
    </ul> 

    
    

</asp:Content>
