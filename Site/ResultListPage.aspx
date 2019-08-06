<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResultListPage.aspx.cs" Inherits="ResultListPage" Title="Untitled Page" %>
<%@ OutputCache Duration="10800" VaryByParam="id" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_results.png" alt="Results" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server"/>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <p>
                <asp:Literal ID="litSeason" Text="Season:" runat="server" />
                <asp:DropDownList runat="server" ID="cbSeason" AutoPostBack="true" OnSelectedIndexChanged="cbSeason_SelectedIndexChanged" DataSourceID="SeasonDataSource" />
                <asp:LinqDataSource ID="SeasonDataSource" runat="server" OnSelecting="SeasonDataSource_Selecting" />
                <asp:Literal ID="litFixture" Text="Fixture:" runat="server" />
                <asp:DropDownList runat="server" ID="cbFixture" AutoPostBack="true" OnSelectedIndexChanged="cbFixture_SelectedIndexChanged" DataSourceID="FixtureDataSource" DataTextField="Display" DataValueField="Reference" />
                <asp:LinqDataSource ID="FixtureDataSource" runat="server" OnSelecting="FixtureDataSource_Selecting" />
                <asp:Literal ID="Category" Text="Category:" runat="server" /> <asp:DropDownList runat="server" ID="cbDivision" AutoPostBack="true" OnSelectedIndexChanged="cbDivision_SelectedIndexChanged" DataSourceID="DivisionDataSource" />
                <asp:LinqDataSource ID="DivisionDataSource" runat="server" OnSelecting="DivisionDataSource_Selecting" />
            </p>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="ResultsDataSource" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="position" HeaderText="Position"></asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
                            <asp:BoundField DataField="points" HeaderText="Points"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="ResultsDataSource" runat="server" 
                                         OnSelecting="ResultsData_Selecting" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
 </asp:Content>