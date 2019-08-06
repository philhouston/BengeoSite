<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClubInfo.aspx.cs" Inherits="ClubInfo" Title="Untitled Page" %>
<%@ OutputCache Duration="10800" VaryByParam="id" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_clubinfo.png" alt="Club Information" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div>
                <p>
                    <asp:Literal ID="litClub" runat="server" Text="Club:" />
                    <asp:DropDownList runat="server" ID="cbClub" AutoPostBack="true" OnSelectedIndexChanged="cbClub_SelectedIndexChanged" DataSourceID="ClubListDataSource" DataTextField="Display" DataValueField="Reference" />
                    <asp:LinqDataSource ID="ClubListDataSource" runat="server" OnSelecting="ClubListDataSource_Selecting" />
                </p>
            </div>
            <div class="gridmargin1">
                <h1>Club Information</h1>
                <p>
                    <asp:Panel CssClass="scrollArea2" runat="server" ID="Panel1" ScrollBars="Vertical">
                        <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="clubSource" PageSize="1" EnableModelValidation="True" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td valign="top">
                                                            <table ID="infotable" runat="server" border="0" cellpadding="0" cellspacing="4">
                                                                <tr>
                                                                    <td class="dxcp_tCategory">Name:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblName" runat="server"><%# Eval("Name") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">Address:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblAddress" runat="server"><%# Eval("Address") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">Secretary:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblSecretary" runat="server"><%# Eval("Secretary") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="SecretaryLabel" runat="server" --%>
<%--                                                                                        Text='<%# Eval("Secretary") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">Secretary Phone:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblSecretaryPhone" runat="server"><%# Eval("SecretaryPhone") %></asp:Label>
                                                                        
<%--                                                                        <dxe:ASPxLabel ID="SecretaryPhoneLabel" runat="server" 
                                                                                        Text='<%# Eval("SecretaryPhone") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">Club Professional:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblPro" runat="server"><%# Eval("Pro") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="ProLabel" runat="server" Text='<%# Eval("Pro") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">Professional Phone:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblProPhone" runat="server"><%# Eval("ProPhone") %></asp:Label>
                                                                        
<%--                                                                        <dxe:ASPxLabel ID="ProPhoneLabel" runat="server" 
                                                                                        Text='<%# Eval("ProPhone") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">
                                                                        WebSite:</td>
                                                                    <td class="dxcp_tInfo">
                                                                            <a href="<%# Eval("WebSite") %>" target="_blank"><%# Eval("WebSite") %></a>
<%--                                                                        <dxe:ASPxHyperLink ID="WebSite" runat="server" Target="_blank"  NavigateUrl='<%# Eval("WebSite") %>' Text='<%# Eval("WebSite") %>' >--%>
<%--                                                                        </dxe:ASPxHyperLink>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory">
                                                                        Course Designer:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblDesigner" runat="server"><%# Eval("Designer") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="DesignerLabel" runat="server" 
                                                                                        Text='<%# Eval("Designer") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory" valign="top">Yardage:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblYardage" runat="server"><%# Eval("Yardage") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="YardageLabel" runat="server" Text='<%# Eval("Yardage") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory" valign="top">Par:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblPar" runat="server"><%# Eval("Par") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="ParLabel" runat="server" Text='<%# Eval("Par") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dxcp_tCategory" valign="top">Visitor Information:</td>
                                                                    <td class="dxcp_tInfo">
                                                                        <asp:Label ID="lblVisitor" runat="server"><%# Eval("Visitor") %></asp:Label>
<%--                                                                        <dxe:ASPxLabel ID="VisitorLabel" runat="server" Text='<%# Eval("Visitor") %>' />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr ID="directionrow" runat="server">
                                                                    <td class="dxcp_tCategory" valign="top">Directions:</td>
                                                                    <td ID="directioncell" runat="server" class="dxcp_tInfo" colspan="4">
                                                                        <asp:GridView ID="grid2" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="DirectionDataSource" EnableModelValidation="True" AllowPaging="True">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Reference" HeaderText="From"></asp:BoundField>
                                                                                <asp:BoundField DataField="Display" HeaderText="Instructions"></asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        
<%--                                                                        <dxwgv:ASPxGridView ID="grid2" runat="server" AutoGenerateColumns="False" 
                                                                                            ClientInstanceName="grid2" DataSourceID="DirectionDataSource"  
                                                                                            EnableCallBacks="False" Width="100%">
                                                                            <Columns>
                                                                                <dxwgv:GridViewDataColumn Caption="From" FieldName="Reference" 
                                                                                                            VisibleIndex="0" />
                                                                                <dxwgv:GridViewDataColumn Caption="Instructions" FieldName="Display" 
                                                                                                            VisibleIndex="1" />
                                                                            </Columns>
                                                                        </dxwgv:ASPxGridView>--%>
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
                    <a href="FixtureHistory.aspx" id="lnkHistory" runat="server" class="middlebutton">History</a>
                </p>
            </div>
            <asp:LinqDataSource ID="clubSource" runat="server" 
                        OnSelecting="clubSource_Selecting" />
            <asp:LinqDataSource ID="DirectionDataSource" runat="server" 
                                    OnSelecting="DirectionDataSource_Selecting" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>