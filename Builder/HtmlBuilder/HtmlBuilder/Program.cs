﻿using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;
namespace HtmlBuilder
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {
            

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;

        }

        public string ToStringImple(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImple(indent + 1));
            }

            sb.AppendLine($"{i}/<{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImple(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        private HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement{Name = rootName};
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.AppendLine("<p>");
            sb.AppendLine(hello);
            sb.AppendLine("/<p>");
            WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }

            sb.Append("/<ul>");
            WriteLine(sb);
            //Using builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world"); //Fluent Interface
            WriteLine(builder.ToString());
            // Not using Builder
            var element = new HtmlElement{Name = "ul"};
            element.Elements.Add(new HtmlElement { Name = "li", Text = "Hello" });
            element.Elements.Add(new HtmlElement { Name = "li", Text = "World" });
            WriteLine(element);

        }
    }
}