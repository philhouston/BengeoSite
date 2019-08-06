<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<%--<%@ OutputCache Duration="10800" VaryByParam="none" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="contentDetails" Runat="Server">
    <div id="fixtureinfo">
        <img id="nextfixturelabel" runat="server" alt="Next Fixture" src="images/design/label_nextfixture.png" />
        <br />
        <h1>Next Scheduled Fixture</h1>
        <table>
            <tr>
                <td> 
                    <p>
                        <asp:Literal ID="litNextFixture" runat="server" />
                    </p>           
                </td>
                <td class="right">
                    <a href="FixtureInfo.aspx" id="linkNextFixture" runat="server" class="middlebutton">Fixture</a>
                    <br />
                    <a href="KnockoutInfo.aspx?id=Singles" class="middlebutton">Singles</a>
                    <br />
                    <a href="KnockoutInfo.aspx?id=Doubles" class="middlebutton">Doubles</a>
                    <br/>
                </td>
            </tr>
            <tr>
                <td>
                <h1>Lastest Results</h1>
                    <p>
                        <asp:Literal ID="litLastResults" runat="server" />
                    </p>
                </td>
                <td class="right">
                    <a href="ResultListPage.aspx" id="linkResults" runat="server" class="middlebutton">Last Result</a>
                    <br />
                    <a href="playeroftheyear.aspx" class="middlebutton">Player of the Year</a>
                    <br/>
                </td>
            </tr>
            <tr>
                <td>
                    <h1>Lastest Newsletter</h1>
                    <p>
                        <asp:Literal ID="litLastNewsLetter" runat="server" />
                    </p>
                </td>
                <td class="right">
                    <a href="NewsLetterInfo.aspx" class="middlebutton">Latest News</a>
                </td>
            </tr>
        </table>
    </div>
    <div id="testimonials">
        <asp:Image ID="Image1" ImageUrl="images/design/label_testimonials.png" runat="server" AlternateText="Testimonials" />
        <p>I love golf, and with Bengeo I get play at some of the best courses in the area. </p><br />
        <p>I don't belong to any club, but with Bengeo I get to play almost every month, at a price which includes meals that is very competitive.</p><br />
        <p>I am a pensioner, with Bengeo I get a handicap that means that I can be competitive.</p>
    </div>
    <div id="about">
        <div id="repeatlabelbackground" >
            <img src="images/design/label_about.png" alt="About Bengeo" />
        </div>
        <p>
            Bengeo is a society of like minded golfer who play at various courses around London and East Anglia. Aa a rather large society we
            are able to gain fantastic discounts at our venues. 
        </p>
        <p>
            Each event is held on a monthly basis between the months of March and December.
            Costs include meals, prizes and the green fees.
        </p>
        <p class="moreinfo">
            <a href="About.aspx" class="middlebutton">More Info</a>
        </p>
        
    </div>
</asp:Content>