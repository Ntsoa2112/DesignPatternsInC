/*
1. 1 – LINQ : Les fondamentaux
LINQ (Language Integrated Query) permet d'interroger des collections en C# de manière déclarative.

Deux syntaxes :
*/
// ✅ Syntaxe fluente (PRÉFÉRÉE EN PROD)
var result = users.Where(u => u.IsActive).Select(u => u.Name);

// ⚠️ Syntaxe query (moins utilisée, mais existe)
var result = from u in users
             where u.IsActive
             select u.Name;

// Principe Senior : **Utilise la syntaxe fluente. ** C'est ce que tu verras en entreprise.

/*

1.2 – Méthodes LINQ essentielles
Méthode	                    Usage	                            Exemple
Where	                    Filtrer	                    users.Where(u => u.Age > 18)
Select	                    Transformer/Projeter	    users.Select(u => u.Name)
OrderBy/OrderByDescending	Trier	                    users.OrderBy(u => u.Name)
GroupBy	                    Grouper	                    orders.GroupBy(o => o.CustomerId)
Join	                    Joindre deux collections	orders.Join(customers, ...)
First/FirstOrDefault	    Premier élément	            users.First(u => u.Id == 1)
Any/All	                    Vérifier existence	        users.Any(u => u.IsAdmin)
Count/Sum/Average	        Agrégats	                orders.Sum(o => o.Amount)
Distinct	                Supprimer doublons	        names.Distinct()
Take/Skip	                Pagination	                users.Skip(10).Take(5)
*/

/*
1.3 – Exécution différée (Deferred Execution) 🔥
CONCEPT CRITIQUE : LINQ n'exécute pas immédiatement, sauf si tu matérialises.
*/
// ❌ PIÈGE : multiple enumeration
var activeUsers = context.Users.Where(u => u.IsActive); // Pas encore exécuté
var count = activeUsers.Count(); // Exécute la requête
var first = activeUsers.First(); // RE-exécute la requête !  

// ✅ SOLUTION SENIOR : matérialiser une seule fois
var activeUsers = context.Users.Where(u => u.IsActive).ToList(); // Exécute UNE fois
var count = activeUsers.Count; // Compte en mémoire (propriété, pas méthode)
var first = activeUsers.First(); // Lit en mémoire

/*
Quand matérialiser ?

✅ .ToList() : quand tu dois énumérer plusieurs fois ou modifier
✅ .ToArray() : quand tu veux un tableau fixe
✅ .ToDictionary() : quand tu veux un accès par clé rapide
❌ Ne PAS matérialiser si tu passes le résultat directement (ex: return dans une API)

1.4 – Collections : IEnumerable vs List vs Dictionary

Type	            Quand utiliser
IEnumerable<T>	    Signature de méthode (lecture seule, flexible)
ICollection<T>	    Si tu as besoin de .Count ou .Add
List<T>	            Implémentation concrète, modifiable, accès par index
Dictionary<K,V>	    Accès rapide par clé (O(1))
HashSet<T>	        Collection unique, vérifier existence rapide (O(1))

1.5 – Pièges classiques en test
Piège 1 : Modification pendant énumération
*/
// ❌ CRASH : InvalidOperationException
var list = new List<int> { 1, 2, 3 };
foreach (var item in list) {
    if (item == 2) list.Remove(item); // ❌ Collection modifiée pendant foreach
}

// ✅ SOLUTION SENIOR
var list = new List<int> { 1, 2, 3 };
list.RemoveAll(x => x == 2); // Méthode dédiée

// Piège 2 : OrderBy ne modifie pas la collection
// ❌ ERREUR CONCEPTUELLE
var numbers = new List<int> { 3, 1, 2 };
numbers.OrderBy(x => x); // Ne fait RIEN (résultat non assigné)

// ✅ CORRECT
var sortedNumbers = numbers.OrderBy(x => x).ToList();
// OU si tu veux modifier la liste originale
numbers.Sort();

// Piège 3 : First vs FirstOrDefault
// ❌ CRASH si aucun élément
var user = users.First(u => u.Id == 999); // InvalidOperationException

// ✅ SENIOR :  gestion du cas "pas trouvé"
var user = users.FirstOrDefault(u => u.Id == 999);
if (user == null) {
    // Gérer le cas "pas trouvé"
}
