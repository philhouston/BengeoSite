<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FixtureListPage.aspx.cs" Inherits="FixtueListPage" Title="Fixture List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_fixtures.png" alt="Fixtures" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <p>
                <asp:Literal ID="litSeason" Text="Season:" runat="server" />
                <asp:DropDownList ID="ddlYear" DataSourceID="yearDataSource" DataTextField="Display" DataValueField="Reference"
                                          runat="server" onselectedindexchanged="ddlYear_SelectedIndexChanged" 
                                          AutoPostBack="true"
                    />
                <asp:CheckBox ID="chkFuture" Text="View Future Fixtures" AutoPostBack="True" runat="server"
                              OnCheckedChanged="chkFuture_CheckedChanged"
                    />
                <asp:LinqDataSource ID="yearDataSource" runat="server" OnSelecting="yearDataSource_Selecting" />
            </p>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="FixturesSource" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>
                            <asp:TemplateField HeaderText="Fixture">
                                <ItemTemplate>
                                    <a href="FixtureInfo.aspx?id=<%# Eval("Reference") %>"><%# Eval("Location") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Cup" HeaderText="Cup"></asp:BoundField>
                            <asp:BoundField DataField="HoleCount" HeaderText="Holes"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="FixturesSource" runat="server" 
                                         onselecting="FixturesSource_Selecting" />
                </p>
                <p class="moreinfo">
                    &nbsp;&nbsp;
                    <a href="KnockoutInfo.aspx?id=Singles" class="middlebutton">Singles</a>
                    &nbsp;&nbsp;
                    <a href="KnockoutInfo.aspx?id=Doubles" class="middlebutton">Doubles</a>
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>