var hello = "Hello";
var sb = new System.Text.StringBuilder();
sb.Append("<p>");
sb.Append(hello);
sb.Append("</p>");
System.Console.WriteLine(sb.ToString());

var words = new[] { "Hello", "from", "C#", "12" };
sb.Clear();
sb.Append("<ul>");
foreach (var word in words)
{
    sb.AppendFormat("<li>{0}</li>", word);
}
sb.Append("</ul>");
System.Console.WriteLine(sb.ToString());