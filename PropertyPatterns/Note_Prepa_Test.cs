// Question 1 (LINQ) 
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var result = numbers.Where(n => n > 2).Select(n => n * 2);
Console.WriteLine(result. Count());

/*
result n'est PAS encore matérialisé avant .Count() (exécution différée). C'est un IEnumerable<int>. La requête s'exécute seulement au moment du .Count().
*/

// Question 2 (Async/await) 
public async Task<string> GetDataAsync() {
    var result = await CallApiAsync();
    return result.ToUpper();
}
/*
✅ LE CODE ORIGINAL ÉTAIT DÉJÀ CORRECT.

Explication Senior :

Si CallApiAsync() retourne Task<string>, alors result est un string
.ToUpper() sur un string est valide
*/

/*
Question 3 (SOLID) – ✅ CORRECT
Ta réponse : SRP (Single Responsibility Principle) ✅

Explication :
Une classe qui fait validation + sauvegarde + envoi email a 3 responsabilités → viole SRP.
*/
// Séparer en 3 classes
public class UserValidator { }
public class UserRepository { }
public class EmailService { }

// Question 4 (EF Core) 
var orders = context.Orders.ToList();
foreach (var order in orders) {
    Console.WriteLine(order.Customer.Name);
}

/*
✅ LE VRAI PROBLÈME : N+1 QUERIES

Explication Lead Tech :

context.Orders.ToList() → 1 requête SQL pour charger tous les orders
Dans la boucle, order.Customer.Name → 1 requête SQL PAR ORDER pour charger le Customer
Si tu as 100 orders → 101 requêtes SQL au total (1 + 100) → CATASTROPHE DE PERFORMANCE

✅ SOLUTION SENIOR :

*/
var orders = context.Orders
    .Include(o => o.Customer) // ✅ Eager loading
    .ToList();

foreach (var order in orders) {
    Console.WriteLine(order. Customer.Name); // Pas de requête supplémentaire
}
/*
→ 1 seule requête SQL avec JOIN.

🔴 CRITIQUE : Ce problème N+1 est TRÈS FRÉQUENT dans les tests EF Core. Tu DOIS le maîtriser pour le test.

*/

/*
Question 5 (Collections) – ⚠️ IMPRÉCIS
Ta réponse : "IEnumerable est beaucoup plus précis que List"

❌ "Plus précis" ne veut rien dire ici.

✅ RÉPONSE SENIOR :

Critère	        IEnumerable<T>	                            List<T>
Type	        Interface (abstraction)	                    Classe concrète
Opérations	    Lecture seule (itération)	                Lecture + modification (Add, Remove)
Matérialisation	Pas forcément en mémoire (lazy)	            Toujours en mémoire
Flexibilité	    Accepte tout (array, list, query LINQ)	    Seulement List

Quand utiliser quoi ?
*/
// ✅ SIGNATURE DE MÉTHODE :  préfère IEnumerable<T>
public IEnumerable<User> GetActiveUsers() {
    return context. Users.Where(u => u. IsActive); // Pas de . ToList() ici
}

// ✅ SI TU DOIS MODIFIER LA COLLECTION :  utilise List<T>
public void ProcessUsers() {
    var users = GetActiveUsers().ToList(); // Matérialise en List
    users.Add(new User()); // Maintenant on peut ajouter
}

// Question 6 (Exception handling)
try {
    int result = 10 / 0;
} catch {
    // ignore
}
/*
✅ RÉPONSE SENIOR :

Problèmes :

Avaler l'exception : aucun log, aucun diagnostic possible → bug silencieux
Catch sans type : attrape TOUTES les exceptions (même OutOfMemoryException, StackOverflowException) → dangereux
Pas de relance : le programme continue comme si de rien n'était
Solution Senior :
*/
try {
    int result = 10 / 0;
} catch (DivideByZeroException ex) {
    // Log l'exception
    _logger.LogError($"Erreur de division par zéro : {ex.Message}");
    throw; // Relance l'exception pour ne pas masquer le problème
}

/*
Principe Senior :

✅ Catch des exceptions spécifiques
✅ Log l'erreur
✅ Relance avec throw; (pas throw ex; qui perd la stack trace)
*/

// Question 7 (POO)
/*
✅ RÉPONSE SENIOR :

Critère	            Interface	                                                   Classe abstraite
Héritage multiple	✅ Oui (une classe peut implémenter plusieurs interfaces)	❌ Non (une classe ne peut hériter que d'une seule classe)
Implémentation	    ❌ Pas de code (seulement signatures)	                    ✅ Peut contenir du code (méthodes avec implémentation)
État (fields)	    ❌ Pas de fields	                                            ✅ Peut avoir des fields
Usage	            Définir un contrat (comportement)	                          Partager du code commun entre classes liées
*/

// ✅ INTERFACE :  définir un contrat
public interface IPaymentProcessor {
    Task ProcessPaymentAsync(decimal amount);
}

// ✅ CLASSE ABSTRAITE : partager du code commun
public abstract class Animal {
    protected string Name { get; set; } // État partagé
    
    public abstract void MakeSound(); // Méthode abstraite
    
    public void Sleep() { // Implémentation commune
        Console.WriteLine($"{Name} is sleeping");
    }
}

/*
Principe Senior :

Interface → "Ce que l'objet peut faire" (comportement, contrat)
Classe abstraite → "Ce que l'objet est" (identité, hiérarchie)

*/

// Question 8 (Dependency Injection)
/*
✅ RÉPONSE SENIOR (tu DOIS connaître ça pour le test) :

Lifetime	Durée de vie	                        Usage typique
Transient	Nouvelle instance à chaque injection	Services légers, stateless (ex: validators)
Scoped	    Une instance par requête HTTP	        Services avec état temporaire (ex: DbContext, UnitOfWork)
Singleton	Une seule instance pour toute l'app	    Services partagés, thread-safe (ex: cache, logger factory)
*/

// Piège classique en test :

// ❌ ERREUR : DbContext en Singleton (partagé entre threads → crash)
builder.Services.AddSingleton<MyDbContext>();

// ✅ CORRECT : DbContext en Scoped (un par requête)
builder.Services.AddScoped<MyDbContext>();

//🔴 CRITIQUE : Ce sujet tombe SOUVENT en test. Tu dois le maîtriser.

// Question 10 (Performance)
var users = await context.Users.ToListAsync();
var activeUsers = users.Where(u => u.IsActive).ToList();

/*
✅ RÉPONSE SENIOR :
Problème :
Ici, on charge TOUS les users en mémoire avec ToListAsync(), puis on filtre en mémoire → inefficace si beaucoup de users
Solution :
*/  
var activeUsers = await context.Users
    .Where(u => u.IsActive) // Filtrage au niveau de la base
    .ToListAsync(); // Charge seulement les users actifs    
/*
Principe Senior :
Toujours filtrer au niveau de la base de données avec EF Core pour minimiser les données chargées en mémoire.

Principe : Filtre AVANT de matérialiser, pas après.

**Pourquoi c'est mieux ? **

✅ Moins de données transférées depuis la DB
✅ Moins de mémoire utilisée
✅ Plus rapide
*/

