<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlayerOfTheYear.aspx.cs" Inherits="PlayerOfTheYear" %>
<%@ OutputCache Duration="10800" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_playeroftheyear.png" alt="Player of the Year" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <p>
                <asp:Literal ID="litSeason" Text="Season:" runat="server" />
                <asp:DropDownList runat="server" ID="cbSeason" AutoPostBack="true" OnSelectedIndexChanged="cbSeason_SelectedIndexChanged" DataSourceID="SeasonDataSource" />
                <asp:LinqDataSource ID="SeasonDataSource" runat="server" OnSelecting="SeasonDataSource_Selecting" />
            </p>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="PlayerYearDataSource" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="Player" HeaderText="Player"></asp:BoundField>
                            <asp:BoundField DataField="Event1" HeaderText="Event1"></asp:BoundField>
                            <asp:BoundField DataField="Event2" HeaderText="Event2"></asp:BoundField>
                            <asp:BoundField DataField="Event3" HeaderText="Event3"></asp:BoundField>
                            <asp:BoundField DataField="Event4" HeaderText="Event4"></asp:BoundField>
                            <asp:BoundField DataField="Event5" HeaderText="Event5"></asp:BoundField>
                            <asp:BoundField DataField="Event6" HeaderText="Event6"></asp:BoundField>
                            <asp:BoundField DataField="Event7" HeaderText="Event7"></asp:BoundField>
                            <asp:BoundField DataField="Event8" HeaderText="Event8"></asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    
                    
                    

<%--                    <dxwgv:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" 
                                        ClientInstanceName="grid" DataSourceID="PlayerYearDataSource" 
                                        EnableCallBacks="False" Visible="true" Width="100%">
                        <Columns>
                            <dxwgv:GridViewDataColumn Caption="Player" FieldName="Player" VisibleIndex="0" />
                            <dxwgv:GridViewDataColumn Caption="Event1" FieldName="Event1" VisibleIndex="1" />
                            <dxwgv:GridViewDataColumn Caption="Event2" FieldName="Event2" VisibleIndex="2" />
                            <dxwgv:GridViewDataColumn Caption="Event3" FieldName="Event3" VisibleIndex="3" />
                            <dxwgv:GridViewDataColumn Caption="Event4" FieldName="Event4" VisibleIndex="4" />
                            <dxwgv:GridViewDataColumn Caption="Event5" FieldName="Event5" VisibleIndex="5" />
                            <dxwgv:GridViewDataColumn Caption="Event6" FieldName="Event6" VisibleIndex="6" />
                            <dxwgv:GridViewDataColumn Caption="Event7" FieldName="Event7" VisibleIndex="7" />
                            <dxwgv:GridViewDataColumn Caption="Event8" FieldName="Event8" VisibleIndex="8" />
                            <dxwgv:GridViewDataColumn Caption="Total" FieldName="Total" VisibleIndex="11" />
                        </Columns>
                    </dxwgv:ASPxGridView>--%>
                    <asp:LinqDataSource ID="PlayerYearDataSource" runat="server" 
                                         OnSelecting="PlayerYearData_Selecting" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>