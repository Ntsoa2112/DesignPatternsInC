// Modèle simple représentant un utilisateur
public class User
{
    public bool IsActive { get; set; }
    public string Role { get; set; }
}

// Version classique (if / else)
public class AccessServiceIfElse
{
    public static string GetAccessLevel(User user)
    {
        if (user.IsActive && user.Role == "Admin")
            return "Full access";
        else if (user.IsActive)
            return "Limited access";
        else
            return "No access";
    }
}

// Version moderne (switch sur objet)
public class AccessServiceSwitch
{
    public static string GetAccessLevel(User user)
    {
        return user switch
        {
            { IsActive: true, Role: "Admin" } => "Full access",
            { IsActive: true } => "Limited access",
            _ => "No access"
        };
    }
}