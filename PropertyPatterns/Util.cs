/*
Problème : Les NullReferenceException sont la cause n°1 de bugs.

Solution : Activer les nullable reference types.
*/
// ❌ Avant C# 8
public class User
{
    public string Name { get; set; } // Peut être null sans warning
}

User user = new User();
Console.WriteLine(user.Name.ToUpper()); // ❌ NullReferenceException !  

// ✅ Avec Nullable Reference Types (C# 8+)
#nullable enable

public class User
{
    public string Name { get; set; } = string.Empty; // ✅ Doit être initialisé
    public string? MiddleName { get; set; } // ✅ Peut être null (explicite)
}

User user = new User();
Console.WriteLine(user.Name.ToUpper()); // ✅ Safe (jamais null)
Console.WriteLine(user.MiddleName.ToUpper()); // ⚠️ Warning du compilateur ! 

// ✅ Gestion correcte
if (user.MiddleName != null)
{
    Console.WriteLine(user.MiddleName.ToUpper()); // ✅ Plus de warning
}

// OU avec null-conditional operator
Console.WriteLine(user.MiddleName?.ToUpper()); // ✅ Retourne null si MiddleName est null