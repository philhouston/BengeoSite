<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AgmInfo.aspx.cs" Inherits="AgmInfo" %>
<%@ OutputCache Duration="10800" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentDetails" Runat="Server">
    <img src="images/design/label_agm.png" alt="AGM" width="750" height="40" />
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="gridmargin1">
                <p>
                    <asp:GridView ID="grid" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False" DataSourceID="AgmData" PageSize="1" EnableModelValidation="True" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="date" HeaderText="Date"></asp:BoundField>
                            <asp:TemplateField HeaderText="File">
                                <ItemTemplate>
                                    <a id="file" runat="server" href='<%# Eval("file") %>' target="_blank" ><img id="preview" runat="server" alt="Newletter Picture" src='<%# Eval("preview") %>'/></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="AgmData" runat="server" 
                                         onselecting="AgmData_Selecting" />
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>