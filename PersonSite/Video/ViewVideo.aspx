<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="ViewVideo.aspx.cs" Inherits="PersonSite.Video.ViewVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AC_RunActiveContent.js" type="text/javascript"></script>
    <script type="text/javascript">
        var rateFinish = function (data) {
            if (data == "duplicate") {
                alert("同一段视频24小时之内只能打分一次");
            }
            else {
                alert("打分成功");
            }
        }
        $(function () {
            $("#btnDing").button({
                icons: { primary: 'ui-icon-check' }
            }).click(function () {
                $.post("/Video/RateVideo.ashx",
                { "videoId": "<%=VideoId %>", "action": 1 }, rateFinish);
            });
            $("#btnCai").button({
                icons: { primary: 'ui-icon-closethick' }
            }).click(function () {
                $.post("/Video/RateVideo.ashx",
                { "videoId": "<%=VideoId %>", "action": -1 }, rateFinish);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderMain" runat="server">
    <p><%=VideoTitle%></p>
    <script language='javascript'>
        AC_FL_RunContent('codebase', 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0', 'width', '400', 'height', '325', 'src', ((!DetectFlashVer(9, 0, 0) && DetectFlashVer(8, 0, 0)) ? 'OSplayer' : 'OSplayer'), 'pluginspage', 'http://www.macromedia.com/go/getflashplayer', 'id', 'flvPlayer', 'allowFullScreen', 'true', 'allowScriptAccess', 'always', 'movie', ((!DetectFlashVer(9, 0, 0) && DetectFlashVer(8, 0, 0)) ? 'OSplayer' : 'OSplayer'), 'FlashVars', 'movie=<%=VideoUrl %>&btncolor=0x333333&accentcolor=0x31b8e9&txtcolor=0xdddddd&volume=30&autoload=on&autoplay=off&vTitle=Super Mario Brothers Lego Edition&showTitle=yes');
    </script>

    <noscript>
 <object width='400' height='325' id='flvPlayer'>
  <param name='allowFullScreen' value='true'>
   <param name="allowScriptAccess" value="always"> 
  <param name='movie' value='OSplayer.swf?movie=<%=VideoUrl %>&btncolor=0x333333&accentcolor=0x31b8e9&txtcolor=0xdddddd&volume=30&autoload=on&autoplay=off&vTitle=Super Mario Brothers Lego Edition&showTitle=yes'>
  <embed src='OSplayer.swf?movie=<%=VideoUrl %>&btncolor=0x333333&accentcolor=0x31b8e9&txtcolor=0xdddddd&volume=30&autoload=on&autoplay=off&vTitle=Super Mario Brothers Lego Edition&showTitle=yes' width='400' height='325' allowFullScreen='true' type='application/x-shockwave-flash' allowScriptAccess='always'>
 </object>
</noscript>
    <p>
        <a id="btnDing">顶</a>
        <a id="btnCai">踩</a>
    </p>
</asp:Content>
