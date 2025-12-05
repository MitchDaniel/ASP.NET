# Task 1
1. Create a new Web API project.
2. Delete if there is a default WeatherForecastController.
3. In the Controllers folder, create a BooksController based on ControllerBase.
4. Set the [ApiController] attribute and the route of the view api/[controller].
5. Add two stall actions, GET /api/books and GET /api/books/{id}, returning 200 OK.
6. Run the application and verify that both routes respond 200 OK.

# Task 2
1. Create a Models folder and a Book class with the following fields: Id (int), Title (string), Author (string), Year (int).
2. In the BooksController, prepare a list of books in memory of at least three records with unique Ids and different field values.
3. Update GET /api/books to return a list of books.
4. Update GET /api/books/{id} to return 404 Not Found with the text Book not found if there is no entry .
5. Set the route constraint for the {id} parameter as an integer.
6. Check the responses and statuses 200 and 404 for the existing and non-existing identifier.

# Task 3
1. In the BooksController, add a GET /api/books/search route with query string parameters:
- Mandatory title parameter (case insensitive substring search).
- Optional parameter author (if specified — additionally filter by author).
2. If there is no mandatory title , return a 400 Bad Request with an understandable message.
3. If the parameters are correct, return 200 OK and a list of results (it is allowed to return an empty list).
4. Check the scripts:
- Search by title only (there are matches).
- Search by title + author (narrowing the result).
- Request without title ( 400 Bad Request expected).

# Task 4
1. Add a POST route /api/books to create a book:
- Accepts a book object from the request body.
- Title and Author fields are mandatory, Year should be reasonable (e.g. at least 1800).
- For empty/incorrect values, return 400 Bad Request with an error message.
- On successful creation, assign a new Id, add the record to the list, and return 201 Created with a link to GET /api/books/{id}.
2. Add a PUT route /api/books/{id} to update the book:
- If the book is not found — 404 Not Found.
- With empty/incorrect values — 400 Bad Request.
- If successful, 200 OK with an updated book.
3. Add a DELETE route /api/books/{id} to delete a book:
- If the book is not found — 404 Not Found.
- If successful, 204 No Content.
4. Check the minimal script in its entirety (any HTTP client):
- Create book -> expected 201 Created with correct link and new Id.
- Read the created book by Id -> 200 OK, data match.
- Update book by Id -> 200 OK, changes applied.
- Delete book by Id -> 204 No Content.
- Re-read on the same Id -> 404 Not Found.