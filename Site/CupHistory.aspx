<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CupHistory.aspx.cs" Inherits="CupHistory" %>
<%@ OutputCache Duration="10800" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <img src="images/design/label_cupHistory.png" alt="Cup History" width="750" height="40" />
            <p>
                <asp:Literal ID="cupPrompt" runat="server" Text="Cup:" />
                <asp:DropDownList ID="ddlCup" DataSourceID="cupDataSource" DataTextField="Display" DataValueField="Reference"
                                  runat="server" onselectedindexchanged="ddlCup_SelectedIndexChanged" 
                                  AutoPostBack="true"
                    />
                <asp:LinqDataSource ID="cupDataSource" runat="server" OnSelecting="cupDataSource_Selecting" />
                &nbsp; 
                <asp:Literal ID="donationLabel" runat="server" Text="Donated By:" />
                <asp:Literal ID="donationValue" runat="server" Text="-" />
                &nbsp; 
                <asp:Literal ID="donationDateLabel" runat="server" Text="Date:" />
                <asp:Literal ID="donationDateValue" runat="server" Text="-" />
            </p>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="FixturesSource" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="date" HeaderText="Date"></asp:BoundField>
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