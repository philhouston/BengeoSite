<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NewsletterInfo.aspx.cs" Inherits="NewsletterInfo" Title="Untitled Page" %>
<%@ OutputCache Duration="10800" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_newsletters.png" alt="Newsletters" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <p>
-                <asp:Panel ID="selection" runat="server" Visible="true" >
                    <p>
                        <asp:Literal ID="litSeason" Text="Season:" runat="server"/>
                        <asp:DropDownList runat="server" ID="cbSeason" AutoPostBack="true" OnSelectedIndexChanged="cbSeason_SelectedIndexChanged" />
                    </p>
                </asp:Panel>
            </p>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="NewslettersData" PageSize="1" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="date" HeaderText="Date"></asp:BoundField>
                            <asp:TemplateField HeaderText="File">
                                <ItemTemplate>
                                    <a id="file" runat="server" href='<%# Eval("file") %>' target="_blank" ><img id="preview" runat="server" alt="Newletter Picture" src='<%# Eval("preview") %>'/></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="NewslettersData" runat="server" 
                                            onselecting="NewslettersData_Selecting" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>