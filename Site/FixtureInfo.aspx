<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FixtureInfo.aspx.cs" Inherits="FixtureInfo" %>
<%@ OutputCache Duration="10800" VaryByParam="id" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_fixtureinfo.png" alt="Fixture Information" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <div >
        <asp:UpdatePanel ID="panel" runat="server">
        <ContentTemplate>
            <asp:LinqDataSource ID="SeasonDataSource" runat="server" OnSelecting="SeasonDataSource_Selecting" />
            <asp:LinqDataSource ID="FixtureDataSource" runat="server" OnSelecting="FixtureDataSource_Selecting" />
            <asp:LinqDataSource id="FixtureInfoDataSource" runat="server" onselecting="FixtureInfoDataSource_Selecting" />
            <div>
                <p>
                    <asp:Literal runat="server" ID="litSeason" Text = "Season:" />
                    <asp:DropDownList runat="server" ID="cbSeason" AutoPostBack="true" DataTextField="Display" DataValueField="Reference" OnSelectedIndexChanged="cbSeason_SelectedIndexChanged" DataSourceID="SeasonDataSource" />
                    <asp:Literal runat="server" ID="litFixture" Text="Fixture:" />
                    <asp:DropDownList runat="server" ID="cbFixture" AutoPostBack="true" DataTextField="Display" DataValueField="Reference" OnSelectedIndexChanged="cbFixture_SelectedIndexChanged" DataSourceID="FixtureDataSource" />
                </p>
            </div>
            <div class="gridmargin1">
                <p>
                    <asp:Panel CssClass="scrollArea1" runat="server" ID="scrollData" ScrollBars="Vertical">
                       <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="FixtureInfoDataSource" PageSize="1" EnableModelValidation="True" AllowPaging="True">
                            <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <table border="0" cellpadding="0" cellspacing="4">
                                                        <tr>
                                                            <td class="dxcp_tCategory">Date:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblDate" runat="server"><%# Eval("Date") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="ASPxLabel1" runat="server" Text='<%# Eval("Date") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Meeting Time:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblTime" runat="server"><%# Eval("MeetingTime") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="ASPxLabel5" runat="server" Text='<%# Eval("MeetingTime") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Club:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblClub" runat="server"><%# Eval("Location") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="lblClub" runat="server" Text='<%# Eval("Location") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Cup:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblCup" runat="server"><%# Eval("Cup") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="lblCup" runat="server" Text='<%# Eval("Cup") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Player Of The Year Event:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblPlayerYear" runat="server"><%# Eval("PlayerOfTheYear") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="ASPxLabel6" runat="server" Text='<%# Eval("PlayerOfTheYear") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Price:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblPrice" runat="server"><%# Eval("Price") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="lblPrice" runat="server" Text='<%# Eval("Price") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">No of Holes:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblHoleCount" runat="server"><%# Eval("HoleCount") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="lblHoleCount" runat="server" Text='<%# Eval("HoleCount") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Entries:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblEntries" runat="server"><%# Eval("Entries") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="ASPxLabel3" runat="server" Text='<%# Eval("Entries") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Entry Cut off Date:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblCutoff" runat="server"><%# Eval("CutOffDate") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="ASPxLabel2" runat="server" Text='<%# Eval("CutOffDate") %>' />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dxcp_tCategory">Cancellations:</td>
                                                            <td class="dxcp_tInfo">
                                                                <asp:Label ID="lblCancellations" runat="server"><%# Eval("Cancellations") %></asp:Label>
<%--                                                                <dxe:ASPxLabel id="ASPxLabel4" runat="server" Text='<%# Eval("Cancellations") %>' />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </p>
                <p class="moreinfo">
                    <a href="ClubInfo.aspx" id="ClubInfoLink" runat="server" class="middlebutton">Club Info</a>
<%--                        <dxe:ASPxHyperLink runat="server" ID="ClubInfoLink" ImageUrl="images/design/btn_clubinfo.png" Height="31" /> --%>
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>