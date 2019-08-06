<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" Title="Untitled Page" %>
<%@ OutputCache Duration="10800" VaryByParam="none" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentDetails" Runat="Server">

    <div id="history">
        <img alt="History" src="images/design/label_history.png" style="width: 575px; height: 40px;" />
        <p>
            The Society was formed in October 1981 following a chance meeting between Ron Bassam and Stan Kelley at the Bengeo Working Men's Club annual dinner.
            The dinner was held at Castle Hall, Hertford in September 1981.  Ron and Stan happened to be placed at same table and a couple of drinks 
            into the conversation Ron said: "It's about time The Working Men's Club had its own golf section." 
            Stan protested: "But I've never actually played, I've only had a few lessons." However, several more drinks later Stan agreed to place an 
            invitation on the club's notice board. There was surprisingly very good support for the idea, for over 30 turned up for the meeting – 
            and a similar number turned out for the inaugural game at Chadwell Springs Golf Club.  
        </p><p>
                Ron Bassam (he was a member of Knebworth) took on the captaincy for both 1982/3 and rank novice Stan Kelley became secretary.
                "You're mad," exclaimed Dennis Dawson who has merely been having golf lessons with Stan. But Dennis was also jumping in the deep end as treasurer.
                It was back to Chadwell Springs for the first proper contest. That was April 14, 1982 and handicaps ranged from 17 to 60. 
                Among those founder members were David Morris (Handicap 60), Gordon Morris (27) Barry Ruskin (20) Brian Ruskin 34, Stan Kelley (36), 
                Dennis Dawson 45. Those lofty figures were capped to 36 a month later, it wasn't until 1984 that the Bengeo limited the maximum handicap to 28.  
            </p><p>
                    A year earlier we had asked the Bengeo Workings Men's Club committee to provide us with a trophy. They refused.  That resulted in the Society 
                    going its own way. Re-naming it Bengeo Golf Society also allowed the many guests who had been playing to actually become full members – 
                    and they included Tom Coleman who supplied our first trophy, the "Spring Plate".  Alas Tom died soon after. Others followed, like the "Autumn Cup" 
                    which Stan Kelley donated in 1983 (First winner was David Morris). The Three-Club trophy was donated by Peter Morris in 1986, after which 
                    Concorde Darts & Trophies put up our Pairs Cup in 1987, followed by the Singles Championship Cup donated by McMullen Brewery in 1989.
                    We now have trophies for practically every event – all kindly donated, but very much the odd one out, yet undoubtedly the most popular event, 
                    is the Xmas Scramble. But that's because everyone is a winner.
                </p>
    </div>
    <div id="societylinks">
        <asp:Image ID="Image1" ImageUrl="images/design/label_societylinks.png" runat="server" AlternateText="Society Links" Width="175" Height="40" />
        <p>
            <a href="AgmInfo.aspx" class="creambutton">AGM</a>
            <br /><br /><br />                    
            <a href="NewsletterInfo.aspx" class="creambutton">Newsletter</a>
            <br /><br /><br />   
            <a href="Captains.aspx" class="creambutton">Captains</a>
            <br /><br /><br />   
            <a href="CupHistory.aspx" class="creambutton">Cups</a>
            <br /><br /><br />   
            <a href="ClubInfo.aspx" class="creambutton">Courses</a>
            <br /><br /><br />   
            <a href="PlayerOfTheYear.aspx" class="creambutton">Player Year</a>
            <br /><br /><br />   
        </p>
    </div>
</asp:Content>