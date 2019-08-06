<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MembersHistory.aspx.cs" Inherits="Handicap" Title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_members.png" alt="Tour Info" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <p>
                <b>Member's Name : </b>
                <asp:DropDownList runat="server" ID="cbMember" AutoPostBack="true" DataSourceID="MembersDataSource" DataTextField="DisplayName" DataValueField="Name" OnSelectedIndexChanged="cbMember_SelectedIndexChanged"  />
                <asp:LinqDataSource ID="membersDataSource" runat="server" OnSelecting="MembersDataSource_Selecting" />                
                &nbsp;&nbsp;
                <b>Member's Club : </b>
                <asp:Literal ID="litMembersClubValue" runat="server" />
                &nbsp;&nbsp;
                <b>Playing Handicap : </b>
                <asp:Literal ID="litPlayingHandicapValue" runat="server" />
                <div>
                    <img id="MemberPicture" class="Photo" runat="server" src="" alt="photo" />
<%--                    <dxe:ASPxImage ID="MemberPicture"  runat="server" AlternateText="Members Photo" Height="62" />--%>
                </div>

                <p>
                    <br/>
                    <dxtc:ASPxPageControl runat="server" ID="tabs" AutoPostBack="true" EnableCallBacks="false" width="100%" OnActiveTabChanged="tabs_ActiveTabChanged" 
                                          ActiveTabIndex="0">
                        <TabPages>
                            <dxtc:TabPage Text="Playing History">
                                <ContentCollection>
                                    <dxw:ContentControl>
                                        <div class="gridmargin1">
                                            <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="PlayingHistorySource" PageSize="10" EnableModelValidation="True" AllowPaging="True">
                                                <Columns>
                                                    <asp:BoundField DataField="Season" HeaderText="Season"></asp:BoundField>
                                                    <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}"></asp:BoundField>
                                                    <asp:BoundField DataField="location" HeaderText="Fixture"></asp:BoundField>
                                                    <asp:BoundField DataField="division" HeaderText="Division"></asp:BoundField>
                                                    <asp:BoundField DataField="position" HeaderText="Position"></asp:BoundField>
                                                    <asp:BoundField DataField="points" HeaderText="Points"></asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <asp:LinqDataSource ID="PlayingHistorySource" runat="server" 
                                                             onselecting="PlayingHistorySource_Selecting" />
                                    </dxw:ContentControl>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Handicap History" >
                                <ContentCollection>
                                    <dxw:ContentControl>
                                        <div class="gridmargin1">
                                            <asp:GridView ID="grid1" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="HandicapHistorySource" PageSize="10" EnableModelValidation="True" AllowPaging="True">
                                                <Columns>
                                                    <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}"></asp:BoundField>
                                                    <asp:BoundField DataField="description" HeaderText="Description"></asp:BoundField>
                                                    <asp:BoundField DataField="handicap" HeaderText="Handicap"></asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <asp:LinqDataSource ID="HandicapHistorySource" runat="server" 
                                                             onselecting="HandicapHistorySource_Selecting" />
                                    </dxw:ContentControl>
                                </ContentCollection>
                           
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Handicap Adjustments">
                                <ContentCollection>
                                    <dxw:ContentControl>
                                        <div class="gridmargin1">
                                            <h1>Only handicap adjustments that are still in effect are displayed</h1>
                                            <asp:GridView ID="grid2" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="PlayingAdjustmentSource" PageSize="10" EnableModelValidation="True" AllowPaging="True">
                                                <Columns>
                                                    <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" ></asp:BoundField>
                                                    <asp:BoundField DataField="expiry" HeaderText="Expiry" DataFormatString="{0:d}"></asp:BoundField>
                                                    <asp:BoundField DataField="location" HeaderText="Fixture"></asp:BoundField>
                                                    <asp:BoundField DataField="reason" HeaderText="Reason"></asp:BoundField>
                                                    <asp:BoundField DataField="adjustment" HeaderText="Adjustment"></asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <asp:LinqDataSource ID="PlayingAdjustmentSource" runat="server" 
                                                             onselecting="PlayingAdjustmentSource_Selecting" />
                                    </dxw:ContentControl>
                                </ContentCollection>
                            </dxtc:TabPage>
                        </TabPages>
                    
                    </dxtc:ASPxPageControl>
                </p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>