### Programowanie asynchroniczne

#### Zadanie 1

1. Sprawdź jakie metody Entity Framework są dostępne w wersji asynchronicznej.
2. Zmodyfikuj projekt `FilmDB`, tak żeby `FilmManager` i kontrolery korzystały tam gdzie to możliwe z asynchronicznych wersji metod.

np.
```
await context.MyEntities.AddAsync(newEntity);
await context.SaveChangesAsync();

var entities = await context.MyEntities.ToListAsync();
```
Chociaż metoda Update sama w sobie nie jest asynchroniczna, 
jest często używana w połączeniu z asynchronicznym zapisem zmian. Nie ma dedykowanej asynchronicznej wersji Update, ponieważ EF Core śledzi zmiany w encjach automatycznie.
```
var entity = await context.MyEntities.FirstOrDefaultAsync(e => e.Id == id);
entity.SomeProperty = "New Value";
await context.SaveChangesAsync();
```
Podobnie jak w przypadku Update, metoda Remove nie jest asynchroniczna, ale jest używana razem z asynchronicznym zapisem zmian.
```
var entity = await context.MyEntities.FirstOrDefaultAsync(e => e.Id == id);
context.MyEntities.Remove(entity);
await context.SaveChangesAsync();
```

