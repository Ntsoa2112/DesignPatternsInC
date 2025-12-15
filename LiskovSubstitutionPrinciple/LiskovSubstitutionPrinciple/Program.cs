using System.Drawing;
using LiskovSubstitutionPrinciple.Models;
using Rectangle = LiskovSubstitutionPrinciple.Models.Rectangle;

static int Area(Rectangle r) => r.Width * r.Height;

Rectangle rectangle = new Rectangle { Width = 2, Height = 3 };
Console.WriteLine($"{rectangle} has area {Area(rectangle)}");

Rectangle sq = new Square();
sq.Width = 2;
Console.WriteLine($"{sq} has area {Area(sq)}");
