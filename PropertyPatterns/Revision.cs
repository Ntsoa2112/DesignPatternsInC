/*
1️⃣ Class vs Struct (tu as 50% raison)

La vraie différence :

Class = Reference Type (alloué en Heap, pointeur en Stack)
Struct = Value Type (alloué entièrement en Stack)
*/
// CLASS = Reference Type
public class PersonClass
{
    public string Name { get; set; }
}

// STRUCT = Value Type
public struct PersonStruct
{
    public string Name { get; set; }
}

// DÉMONSTRATION
var classObj = new PersonClass { Name = "Alice" };
var structObj = new PersonStruct { Name = "Bob" };

var classRef = classObj;  // ← Copie la RÉFÉRENCE (même objet)
var structVal = structObj; // ← Copie la VALEUR (nouvel objet)

classRef.Name = "Charlie";
structVal.Name = "David";

Console.WriteLine(classObj.Name);  // "Charlie" ✅ Affecté
Console.WriteLine(structObj.Name); // "Bob" ❌ Pas affecté (copie indépendante)
/*
Class : Métier complexe (User, Order, Product) — entités qui doivent être partagées
Struct : Petits types immuables (Point, Color, Temperature) — pas de mutation, juste du stockage
Structs sont plus performants pour les petits types, mais attention à ne pas les utiliser pour des objets complexes ou mutables (risque de confusion et de bugs).
*/

/*
2️⃣ Closures 
Définition simple : Une fonction qui "capture" des variables de sa portée extérieure.
Ce n’est pas la valeur qui est capturée, c’est la variable elle-même
*/
int x = 10;

Func<int> getX = () => x;

x = 20;

Console.WriteLine(getX()); // 20