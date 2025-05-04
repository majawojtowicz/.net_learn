## 📚 BookApi – ASP.NET Core 8 Minimal API

Prosta aplikacja REST API do zarządzania książkami, stworzona w ASP.NET Core 8 z użyciem Entity Framework Core i bazy danych SQLite.

## ✅ Funkcje API

| Funkcja                  | Metoda | Endpoint              | Opis                                           |
|--------------------------|--------|-----------------------|------------------------------------------------|
| Pobierz listę książek    | GET    | /api/books            | Zwraca wszystkie książki z bazy                |
| Pobierz książkę po ID    | GET    | /api/books/{id}     | Zwraca szczegóły książki o podanym ID          |
| Dodaj nową książkę       | POST   | /api/books            | Dodaje książkę na podstawie danych z żądania   |
| Zaktualizuj książkę      | PUT    | /api/books/{id}     | Edytuje książkę na podstawie danych z żądania  |
| Usuń książkę             | DELETE | /api/books/{id}     | Usuwa książkę o podanym ID z bazy              |

## 🛠️ Uruchomienie

```bash
dotnet restore
dotnet build
dotnet run
```

Aplikacja będzie dostępna pod adresem:
```
http://localhost:5226
```

## 🧪 Testowanie API w Postmanie

### 1. GET /api/books
- **Opis**: Pobiera wszystkie książki
- **Metoda**: `GET`
- **URL**: `http://localhost:5226/api/books`

### 2. GET /api/books/{id}
- **Opis**: Pobiera książkę o konkretnym ID
- **Metoda**: `GET`
- **URL**: `http://localhost:5226/api/books/1`

### 3. POST /api/books
- **Opis**: Dodaje nową książkę
- **Metoda**: `POST`
- **URL**: `http://localhost:5226/api/books`
- **Body (JSON)**:
```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "publishedYear": 2008,
  "isRead": true
}
```

### 4. PUT /api/books/{id}
- **Opis**: Aktualizuje książkę
- **Metoda**: `PUT`
- **URL**: `http://localhost:5226/api/books/1`
- **Body (JSON)**:
```json
{
  "title": "Clean Code (Updated)",
  "author": "Robert C. Martin",
  "publishedYear": 2010,
  "isRead": true
}
```

### 5. DELETE /api/books/{id}
- **Opis**: Usuwa książkę
- **Metoda**: `DELETE`
- **URL**: `http://localhost:5226/api/books/1`

## 🧱 Baza danych

Baza danych SQLite `books.db` tworzona jest automatycznie przy pierwszym uruchomieniu.