// EXERCICE 1 : Démontre la différence Class vs Struct
// Crée une class "UserProfile" et une struct "Point2D"
// Montre que modifier la classe affecte toutes les références
// Et que modifier le struct ne l'affecte qu'une seule

// CODE À FAIRE :
public class UserProfile
{
    public string Name { get; set; }
    // À toi d'ajouter ce qui manque
}

public struct Point2D
{
    public int X { get; set; }
    public int Y { get; set; }
    // À toi d'ajouter ce qui manque
}

public readonly struct Point2DReadonly
{
    public int X { get; init; } // init = immutable après construction
    public int Y { get; init; }

    public Point2DReadonly(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Program
{
    public static void Main()
    {
        // Test :
        var user1 = new UserProfile { Name = "Alice" };
        var user2 = user1;
        user2.Name = "Bob";
        // Affiche : Alice était modifié à Bob ? Pourquoi ?
        Console.WriteLine($"user1.Name = {user1.Name}"); // Affichera "Bob" car user1 et user2 pointent vers le même objet

        var point1 = new Point2D { X = 10, Y = 20 };
        var point2 = point1;
        point2.X = 999;
        // Affiche : Point1.X est-il 999 ou 10 ? Pourquoi ?
        Console.WriteLine($"point1.X = {point1.X}"); // Affichera "10" car point2 est une copie de point1

        var point2R = new Point2DReadonly(10, 20);
        //point2R.X = 999;
    }
}