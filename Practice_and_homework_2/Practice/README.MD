# Task 1
1. Create a new Web API project.
2. Delete if there is a default WeatherForecastController.
3. In the Controllers folder, create an ItemsController based on ControllerBase.
4. Set the [ApiController] attribute and the route of the view api/[controller].
5. Add two actions: GET /api/items and GET /api/items/{id}, returning 200 OK with stubs in the first step.
6. Run the application and verify that both routes respond 200 OK.

# Task 2
1. Create a Models folder and an Item class with Id and Name fields.
2. Inside the ItemsController, prepare a list of items in memory of at least three entries with Id = 1, 2, 3 and different Name values.
3. Update the GET /api/items action to return a list of items.
4. Update the GET /api/items/{id} action to return 404 Not Found with the text Item not found if no entry is present.
5. Set the route constraint for the {id} parameter as an integer.
6. Check the route responses and the 200 and 404 statuses.

# Task 3
1. In the ItemsController, add a GET /api/items/search route with the mandatory name query string parameter.
2. If the name parameter is missing, return a 400 Bad Request with an understandable error message.
3. If the name parameter is present, return a filtered list by case-insensitive name occurrence.
4. If there is no match, return an empty list with a status of 200 OK.
5. Check the results at addresses like /api/items/search?name=pen and /api/items/search (without the parameter).

Task 4
1. Add a POST /api/items action to create the item.
- Accepts an object with a mandatory name text field.
- If the name is empty, it returns 400 Bad Request with an error message.
- On successful creation, adds the entry to the list with the new Id and returns 201 Created with a link to GET /api/items/{id}.
2. Add a PUT action /api/items/{id} to update an existing item.
- The {id} parameter is an integer (route restriction).
- If the item is missing, it returns 404 Not Found.
- If the name in the request is empty, it returns 400 Bad Request.
- If the update is successful, returns 200 OK with the updated object.
3. Add a DELETE /api/items/{id} action to delete an item.
- The {id} parameter is an integer (route restriction).
- If the item is missing, it returns 404 Not Found.
- On successful deletion, returns 204 No Content.
4. Run a mini validation script (any HTTP client).
- Creating an element -> 201 Created and a new Id is expected.
- Reading in a new way Id -> 200 OK and correct data is expected.
- Name update on this Id -> 200 OK and updated data is expected.
- Deletion by this Id -> 204 No Content is expected.
- Re-reading the same Id -> expected 404 Not Found.