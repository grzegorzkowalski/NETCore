### API

#### Zadanie 1

1. Stwórz kontroler `MovieAPI`.
1. Korzystając z klasy FilmManager stwórz odpowiednie endpointy.
1. Pamiętajcie o dodaniu odpowiedniego rodzaju odpowiedzi. 
1. Opatrz je odpowiednimi atrybutami metod typu `[HttpPost]`.
1. Wykorzystaj narzędzie Postman do przetestowania kodu.

1. Dodaj obsługę routingu dla kontrolera api. 
```
routes.MapHttpRoute(
    name: "ActionApi",
    routeTemplate: "api/{controller}/{action}/{id}",
    defaults: new { id = RouteParameter.Optional }
);
```
1. Stwórz kontroler `MovieRestAPI`.
1. Opatrz kontroler atrybutami `[Route("api/[controller]")]` i `[ApiController]`.
1. Korzystając z klasy FilmManager stwórz akcje `Create`, `Get`, `GetAll`, `Update`, `Delete`.
1. Wykorzystaj narzędzie Postman do przetestowania kodu.
1. Dla chętnych - wykorzystaj bibliotekę Swagger do testowania swojego API.