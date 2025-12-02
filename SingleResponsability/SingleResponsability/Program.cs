using System.Diagnostics;
using SingleResponsability.Models;

var j = new Journal();
j.AddEntry("I cried today.");
j.AddEntry("I ate a bug.");
Console.WriteLine(j);

var p = new Persistence();
var filename = @"F:\Projet\Design Patterns in C#\journal.txt";
p.SaveToFile(j, filename, true);
var psi = new ProcessStartInfo
{
    FileName = filename,
    UseShellExecute = true
};
Process.Start(psi);

// A typical class is responsible for one thing and has one reason to change.