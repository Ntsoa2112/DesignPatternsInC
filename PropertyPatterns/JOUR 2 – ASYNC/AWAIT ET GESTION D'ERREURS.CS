/*
1.1 – Pourquoi Async/Await ?
Problème : Les opérations I/O (appels API, DB, fichiers) sont lentes et bloquent le thread.
*/
// ❌ CODE SYNCHRONE (bloque le thread pendant l'appel)
var data = CallApi(); // Thread bloqué pendant 2 secondes
ProcessData(data);

// Solution : Asynchrone = libérer le thread pendant l'attente.
// ✅ CODE ASYNCHRONE (thread libéré pendant l'appel)
var data = await CallApiAsync(); // Thread disponible pour autres tâches
ProcessData(data);

/*
Bénéfices :

✅ Scalabilité : plus de requêtes simultanées (critique pour les APIs)
✅ Réactivité : UI ne freeze pas
✅ Performance : meilleure utilisation des ressources

1.2 – Task vs Task<T>

Type	Usage	                                    Exemple
Task	Opération async sans retour	                await SaveDataAsync();
Task<T>	Opération async avec retour de type T	    var user = await GetUserAsync();
void	❌ INTERDIT (sauf event handlers)	      async void DoWork() ❌

Règle Senior :
*/
// ✅ CORRECT
public async Task SaveUserAsync(User user) { }
public async Task<User> GetUserAsync(int id) { }

// ❌ INTERDIT (perd les exceptions, non attendable)
public async void SaveUserAsync(User user) { } // ❌ Jamais ! 

// Exception : Event handlers (obligatoire async void)
// ✅ SEUL CAS AUTORISÉ
button.Click += async (sender, args) => {
    await LoadDataAsync();
};

// 1.3 – await : Ce qui se passe vraiment
public async Task<string> GetDataAsync() {
    var result = await CallApiAsync(); // 👈 ICI
    return result.ToUpper();
}

/*
Que fait await ?

Lance l'opération async (CallApiAsync())
Libère le thread (retourne au caller)
Quand l'opération termine, reprend l'exécution
Retourne le résultat (unwrap le Task<string> en string)µ

Thread principal : 
1. Appelle GetDataAsync()
2. Arrive à "await CallApiAsync()"
3. ⬅️ Thread libéré (peut faire autre chose)
4. CallApiAsync termine
5. ➡️ Thread reprend l'exécution
6. Exécute "return result.ToUpper()"
*/
