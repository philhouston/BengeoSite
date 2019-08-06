<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KnockoutInfo.aspx.cs" Inherits="KnockoutInfo" %>
<%@ OutputCache Duration="10800" VaryByParam="id" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <img src="images/design/label_singlesKnockout.png" id="ScreenLabel" runat="server" alt="Knockout Competition" width="750" height="40" />
            <p>
                Season: <asp:DropDownList ID="ddlYear" DataSourceID="yearDataSource" DataTextField="Display" DataValueField="Reference"
                                          runat="server" onselectedindexchanged="ddlYear_SelectedIndexChanged" 
                                          AutoPostBack="true" />
                <asp:LinqDataSource ID="yearDataSource" runat="server" OnSelecting="yearDataSource_Selecting" />
                &nbsp; &nbsp;
                <a href="./Information/KnockoutCompetitionRules.pdf" target="_blank">Download Competition Rules</a>
<%--                <dxe:ASPxHyperLink ID="rules" Text="Download Competition Rules" NavigateUrl="./Information/KnockoutCompetitionRules.pdf" runat="server" Target="_blank"  />--%>
            </p>
            <p>
                <dxtc:ASPxTabControl runat="server" ID="tabs" AutoPostBack="true" width="100%" OnActiveTabChanged="tabs_ActiveTabChanged" 
                                     ActiveTabIndex="0" />
                      
                <div class="gridmargin1">
                    <br />      
                    Cutoff date: <asp:Literal ID="lblCutoff" runat="server" />
                    <br />
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="GamesSource" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="GameNo" HeaderText="Game No"></asp:BoundField>
                            <asp:TemplateField HeaderText="Home Team">
                                <ItemTemplate>
                                    <asp:Literal ID="Literal1" Text='<%# Eval("HomePlayer1") %>' runat="server"  />
                                    <asp:Literal ID="Literal2" Text="/" runat="server" Visible='<%# (string)Eval("HomePlayer2") != "" %>' />
                                    <asp:Literal ID="Literal3" Text='<%# Eval("HomePlayer2") %>' runat="server"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Away Team">
                                <ItemTemplate>
                                    <asp:Literal ID="Literal4" Text='<%# Eval("AwayPlayer1") %>' runat="server"  />
                                    <asp:Literal ID="Literal5" Text="/" runat="server" Visible='<%# (string)Eval("AwayPlayer2") != "" %>' />
                                    <asp:Literal ID="Literal6" Text='<%# Eval("AwayPlayer2") %>' runat="server"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Winner">
                                <ItemTemplate>
                                    <asp:Literal ID="Literal7" Text='<%# Eval("WinnerPlayer1") %>' runat="server"  />
                                    <asp:Literal ID="Literal8" Text="/" runat="server" Visible='<%# (string)Eval("WinnerPlayer2") != "" %>' />
                                    <asp:Literal ID="Literal9" Text='<%# Eval("WinnerPlayer2") %>' runat="server"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Score" HeaderText="Score"></asp:BoundField>
                        </Columns>
                        </asp:GridView>
                </div>
                <asp:LinqDataSource ID="GamesSource" runat="server" 
                                     onselecting="GamesSource_Selecting" />
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>