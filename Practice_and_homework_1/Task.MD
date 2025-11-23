Задание 2
Откройте файл Program.cs.

Найдите строку с кодом:
app.MapGet("/", () => "Hello from ASP.NET Core!");

Измените текст внутри кавычек на свой вариант, например:
app.MapGet("/", () => "Welcome to my first ASP.NET Core app!");

Сохраните изменения и снова выполните команду:
dotnet run

Проверьте в браузере, что страница теперь отображает ваш новый текст.

Задание 3
В том же файле Program.cs добавьте строку:
app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");

Сохраните изменения и перезапустите приложение.

Откройте в браузере адрес https://localhost:7XXX/hello/Bob.

Убедитесь, что в ответе отображается Hello, Bob!

Измените имя в адресе и проверьте, что ответ меняется.

Задание 4
В том же файле Program.cs добавьте строку:
app.MapGet("/api/info", () => new { message = "My first ASP.NET Core app is running!", time = DateTime.Now });

Сохраните изменения и перезапустите приложение.

В браузере откройте адрес https://localhost:7XXX/api/info.

Убедитесь, что в ответе отображается JSON с полями message и time.