String.prototype.ToString = function (format) {
    var dateTime = new Date(parseInt(this.substring(6, this.length - 2)));
    format = format.replace("yyyy", dateTime.getFullYear());
    format = format.replace("yy", dateTime.getFullYear().toString().substr(2));
    format = format.replace("MM", dateTime.getMonth() + 1)
    format = format.replace("dd", dateTime.getDate());
    format = format.replace("hh", dateTime.getHours());
    format = format.replace("mm", dateTime.getMinutes());
    format = format.replace("ss", dateTime.getSeconds());
    format = format.replace("ms", dateTime.getMilliseconds())
    return format;
};


//ubb转html
var ubbToHtml = function (str) {

    str = str.replace(/</ig, '&lt;');
    str = str.replace(/>/ig, '&gt;');
    str = str.replace(/\n/ig, '<br />');
    str = str.replace(/\[code\](.+?)\[\/code\]/ig, function ($1, $2) { return phpcode($2); });

    str = str.replace(/\[hr\]/ig, '<hr />');
    str = str.replace(/\[\/(size|color|font|backcolor)\]/ig, '</font>');
    str = str.replace(/\[(sub|sup|u|i|strike|b|blockquote|li)\]/ig, '<$1>');
    str = str.replace(/\[\/(sub|sup|u|i|strike|b|blockquote|li)\]/ig, '</$1>');
    str = str.replace(/\[\/align\]/ig, '</p>');
    str = str.replace(/\[(\/)?h([1-6])\]/ig, '<$1h$2>');

    str = str.replace(/\[align=(left|center|right|justify)\]/ig, '<p align="$1">');
    str = str.replace(/\[size=(\d+?)\]/ig, '<font size="$1">');
    str = str.replace(/\[color=([^\[\<]+?)\]/ig, '<font color="$1">');
    str = str.replace(/\[backcolor=([^\[\<]+?)\]/ig, '<font style="background-color:$1">');
    str = str.replace(/\[font=([^\[\<]+?)\]/ig, '<font face="$1">');
    str = str.replace(/\[list=(a|A|1)\](.+?)\[\/list\]/ig, '<ol type="$1">$2</ol>');
    str = str.replace(/\[(\/)?list\]/ig, '<$1ul>');

    str = str.replace(/\[s:(\d+)\]/ig, function ($1, $2) { return smilepath($2); });
    str = str.replace(/\[img\]([^\[]*)\[\/img\]/ig, '<img src="$1" border="0" />');
    str = str.replace(/\[url=([^\]]+)\]([^\[]+)\[\/url\]/ig, '<a href="$1">' + '$2' + '</a>');
    str = str.replace(/\[url\]([^\[]+)\[\/url\]/ig, '<a href="$1">' + '$1' + '</a>');
    return str;
}