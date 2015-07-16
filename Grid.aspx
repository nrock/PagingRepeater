<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="WebApplication37.Grid" %>
<%@ Import Namespace="WebApplication37" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    
    
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
        <ContentTemplate>
            
            

    <table class="table"> 
        <asp:Repeater ID="rGrid" runat="server" OnItemCommand="rGrid_OnItemCommand" OnItemDataBound="rGrid_OnItemDataBound"  > 
            <ItemTemplate>
                <tr> 
                    <td><asp:Label runat="server" Text="<%#((Campaign) Container.DataItem).Name %>"></asp:Label> </td> 
                    <td><asp:Label runat="server" Text="<%#((Campaign) Container.DataItem).TemplateName %>"></asp:Label>  </td> 
                    <td><asp:Label runat="server" Text="<%#((Campaign) Container.DataItem).Category %>"></asp:Label> </td> 
                    <td><asp:Label runat="server" Text="<%#((Campaign) Container.DataItem).Email %>"></asp:Label> </td> 
                    <td> <%# string.Format("{0:MM/dd/yyyy}",((Campaign) Container.DataItem).Date) %></td>
                    <td>
                        <asp:LinkButton runat="server" CommandArgument="<%#((Campaign) Container.DataItem).Id %>"
                            CommandName="Delete">delete</asp:LinkButton> 
                    </td>
                </tr>
            </ItemTemplate>  
        </asp:Repeater>
          <tr class=" new-record"   > 
            <td><asp:TextBox ID="tbName" runat="server" ></asp:TextBox> </td> 
            <td><asp:TextBox ID="tbTemplateName"  runat="server" ></asp:TextBox>  </td> 
            <td><asp:TextBox ID="tbCategory"  runat="server" ></asp:TextBox> </td> 
            <td><asp:TextBox ID="tbEmail"  runat="server" ></asp:TextBox> </td> 
            <td>  </td>
            <td>
                <asp:LinkButton runat="server"  CssClass="save-click"  OnClick="Add_Record"    >save</asp:LinkButton>
                <a   class="cancel-add-record" >cancel</a> 
            </td>
        </tr>
    </table>
    <asp:label ID="lblError"  ForeColor="Red" runat="server"></asp:label>  
    <asp:Label Id="hEditMode" CssClass="hEditMode hidden"   runat="server" Text="false"></asp:Label>
    <a class="add-record toggle-click toggle-record"  >add</a>  
    <br />
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
    

</ContentTemplate>
   </asp:UpdatePanel>
    

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.new-record').hide(); 
        });

        function AddRecordMode() {
            console.log('AddRecordMode');
            $('.add-record').hide();
            $('.new-record').show();
            $('.hEditMode').text('true');
        }

        function NonAddMode() {
            console.log('NonAddMode');
            $('.add-record').show();
            $('.new-record').hide();
            $('.hEditMode').text('false');
        }

        function pageLoad() {
            var editMode = $('.hEditMode').text();
            console.log('pageload ' + editMode); 
            if (editMode === 'true') {
                AddRecordMode();
            } else {
                NonAddMode();
            }

            $('.add-record').click(function () {
                AddRecordMode();
            });
            $('.cancel-add-record').click(function () {
                NonAddMode();
            }); 

        }

    </script>
</asp:Content>