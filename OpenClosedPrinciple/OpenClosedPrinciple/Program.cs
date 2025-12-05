
using OpenClosedPrinciple.Models;

var apple = new Product("Apple", Color.Green, Size.Small);
var tree = new Product("Tree", Color.Green, Size.Large);
var house = new Product("House", Color.Blue, Size.Large);

Product[] products = { apple, tree, house };

var bf = new BetterFilter();
Console.WriteLine("Green products (new):");
foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
{
    Console.WriteLine($" - {p.Name} is green");
}

Console.WriteLine("Large blue products:");
foreach (var p in bf.Filter(products,
    new AndSpecification<Product>(
        new ColorSpecification(Color.Blue),
        new SizeSpecification(Size.Large))))
{
    Console.WriteLine($" - {p.Name} is large and blue");
}

// Open closed principle states that "software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification."