using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Util
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        public const int indentSize = 2;
        public HtmlElement() { }

        public HtmlElement(string name, string text) 
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
