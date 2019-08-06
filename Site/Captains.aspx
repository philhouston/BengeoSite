<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Captains.aspx.cs" Inherits="Captains" %>
<%@ OutputCache Duration="10800" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <img src="images/design/label_pastCaptains.png" alt="Past Captains" width="750" height="40" />
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="CaptainsSource" PageSize="3" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="Season" HeaderText="Season"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                            <asp:TemplateField HeaderText="Picture">
                                <ItemTemplate>
                                    <img id="captainImage" runat="server" alt="Captain" src='<%# Eval("Picture") %>' height="93"/></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="CaptainsSource" runat="server" 
                                            onselecting="CaptainsSource_Selecting" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>