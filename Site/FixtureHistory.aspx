<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FixtureHistory.aspx.cs" Inherits="FixtureHistory" %>
<%@ OutputCache Duration="10800" VaryByParam="id" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentDetails" Runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <img src="images/design/label_fixturehistory.png" alt="Fixture History" width="750" height="40" />
            <p>
                <asp:Literal ID="clubPrompt" runat="server" Text="Club:" />
                <asp:DropDownList ID="ddlClub" DataSourceID="clubDataSource" DataTextField="Display" DataValueField="Reference"
                                  runat="server" onselectedindexchanged="ddlClub_SelectedIndexChanged" 
                                  AutoPostBack="true"
                    />
                <asp:LinqDataSource ID="clubDataSource" runat="server" OnSelecting="clubDataSource_Selecting" />
            </p>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="FixturesSource" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>
                            <asp:BoundField DataField="Cup" HeaderText="Cup"></asp:BoundField>
                            <asp:BoundField DataField="Winner" HeaderText="Winner"></asp:BoundField>
                        </Columns>
                        </asp:GridView>

                    <asp:LinqDataSource ID="FixturesSource" runat="server" 
                                         onselecting="FixturesSource_Selecting" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>