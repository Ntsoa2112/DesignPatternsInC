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

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, IsSpecification<T> spec);
    }

    public class ColorSpecification : IsSpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Color == color;
        }
    }

    public class SizeSpecification : IsSpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Size == size;
        }
    }

    public class AndSpecification<T> : IsSpecification<T>
    {
        private IsSpecification<T> first, second;
        public AndSpecification(IsSpecification<T> first, IsSpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatisfied(T item)
        {
            return first.IsSatisfied(item) && second.IsSatisfied(item);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, IsSpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }

}
