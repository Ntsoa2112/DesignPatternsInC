/*
1.1 – Les 4 piliers de la POO
Pilier	            Définition	                                                                Usage
Encapsulation	    Cacher les détails internes, exposer seulement ce qui est nécessaire	Properties privées, méthodes publiques
Héritage	        Réutiliser du code d'une classe parent	                                class Dog : Animal
Polymorphisme	    Même interface, comportements différents	                            Overriding, interfaces
Abstraction	        Définir des contrats sans implémentation	                            Interfaces, classes abstraites

Principe Senior : Favorise la composition plutôt que l'héritage ("Composition over inheritance").

1.2 – Interface vs Classe abstraite (CRITIQUE)
Question classique en test : "Quelle est la différence entre une interface et une classe abstraite ? 
Quand utiliser l'une ou l'autre ?"

Critère	                    Interface	                                                    Classe abstraite
Héritage multiple	        ✅ Oui (une classe peut implémenter plusieurs interfaces)	❌ Non (une classe ne peut hériter que d'une seule classe)
Implémentation	            ❌ Pas de code (seulement signatures)*	                    ✅ Peut contenir du code (méthodes concrètes)
État (fields)	            ❌ Pas de fields (seulement properties depuis C# 8)	        ✅ Peut avoir des fields privés
Constructeur	            ❌ Pas de constructeur	                                    ✅ Peut avoir un constructeur
Modificateurs d'accès	    ❌ Tout est public	                                        ✅ Peut avoir private, protected, etc.
Quand utiliser	            Définir un contrat (comportement)	                          Partager du code commun entre classes liées

*Depuis C# 8, les interfaces peuvent avoir des implémentations par défaut, mais c'est rare.

Règle Senior :

    C#
    // ✅ INTERFACE pour le COMPORTEMENT (verbe)
    ICanFly, ICanSwim, IPaymentProcessor, IEmailService

    // ✅ CLASSE ABSTRAITE pour l'IDENTITÉ (nom)
    Animal, Vehicle, Document, BaseRepository


En test, si on te demande de choisir :

➡️ Interface si plusieurs classes non liées doivent implémenter le même comportement
➡️ Classe abstraite si tu veux partager du code entre classes d'une même hiérarchie


1.3 – SOLID Principles (LES 5 PILIERS)
SOLID = 5 principes pour du code maintenable et extensible

S – Single Responsibility Principle (SRP)
Définition : Une classe doit avoir une seule raison de changer (une seule responsabilité).
En test : Si on te montre une classe qui fait trop de choses, tu dois identifier qu'elle viole SRP et proposer de la découper.

O – Open/Closed Principle (OCP)
Définition : Les classes doivent être ouvertes à l'extension, fermées à la modification.

Traduction : Tu dois pouvoir ajouter des fonctionnalités sans modifier le code existant.

Avantage : Pour ajouter un nouveau type de client (ex: "Gold"), tu crées simplement une nouvelle classe GoldDiscountStrategy sans toucher au code existant.

L – Liskov Substitution Principle (LSP)
Définition : Les classes dérivées doivent pouvoir remplacer leurs classes de base sans casser le programme.

Traduction : Si Dog hérite d'Animal, tu dois pouvoir utiliser un Dog partout où un Animal est attendu.

I – Interface Segregation Principle (ISP)
Définition : Ne pas forcer une classe à implémenter des méthodes qu'elle n'utilise pas.
Principe : Interfaces petites et spécialisées plutôt qu'une grosse interface monolithique.

D – Dependency Inversion Principle (DIP)
Définition : Dépendre d'abstractions (interfaces), pas d'implémentations concrètes.
Injection de dépendance : Utiliser des frameworks ou patterns pour injecter les dépendances au lieu de les instancier directement.


1.4 – Design Patterns essentiels
Pattern 1 : Repository (le plus courant)
Usage : Abstraire l'accès aux données.

    public interface IUserRepository
    public class UserRepository : IUserRepository

Pattern 2 : Strategy (pour OCP)
Usage : Changer de comportement à l'exécution.

    public interface IDiscountStrategy
    public class GoldDiscountStrategy : IDiscountStrategy
    public class SilverDiscountStrategy : IDiscountStrategy

Pattern 3 : Factory (création d'objets)
Usage : Centraliser la création d'objets complexes.

public interface INotificationService
{
    void Send(string message);
}

public class EmailNotificationService : INotificationService
{
    public void Send(string message) => Console.WriteLine($"Email:  {message}");
}

public class SmsNotificationService : INotificationService
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

// ✅ Factory
public class NotificationFactory
{
    public INotificationService Create(string type)
    {
        return type. ToLower() switch
        {
            "email" => new EmailNotificationService(),
            "sms" => new SmsNotificationService(),
            _ => throw new ArgumentException($"Unknown notification type:  {type}")
        };
    }
}

// Usage
var factory = new NotificationFactory();
var service = factory.Create("email");
service.Send("Hello!");

Une classe statique est une classe dont on n’instancie jamais d’objet.
    Caractéristiques :
    tout est static
    pas de new

Garbage collector : la libération des ressources (resource management):
    connexion DB
    fichier
    socket  
    stream
    ==> Dispose()


La méthode Agile (résumé clair)

L’Agile est une manière de gérer un projet en avançant par petites itérations, avec :
    des livraisons fréquentes
    des retours rapides
    une adaptation continue
Les rôles importants (version utile, pas théorique)

Product Owner (PO)
    Responsable de la valeur du produit.
    définit les besoins
    priorise le backlog

Scrum Master
    Responsable du processus.
    s’assure que l’équipe suit Scrum
    enlève les obstacles

Équipe de développement
    Responsable du développement.
    conçoit
    développe
    teste
    livre

Un DTSX est un package SSIS (SQL Server Integration Services) qui définit un flux ETL (Extract, Transform, Load) pour déplacer et 
transformer des données dans l’écosystème SQL Server. C’est un pipeline de données.
*/