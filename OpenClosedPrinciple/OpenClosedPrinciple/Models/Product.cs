using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.Models
{
    public enum Color
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public interface IsSpecification<T>
    {
        bool IsSatisfied(T item);
    }
    internal class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        
        public Product(string name, Color color, Size size)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be null or empty.", nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }
    }
}
