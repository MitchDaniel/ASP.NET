Задание 2
Откройте файл Program.cs.

Добавьте (или измените существующий) обработчик корневого маршрута:
var app = WebApplication.Create(args);
app.MapGet("/", () => "Welcome to MyHomeWeb!");
app.Run();

Сохраните изменения и снова выполните dotnet run.

Проверьте в браузере по адресу http://localhost:7XXX/, что отображается новый текст.

Задание 3
В файле Program.cs добавьте строку:
app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");

Перезапустите приложение (dotnet run).
Откройте https://localhost:7XXX/hello/Alex и убедитесь, что отображается Hello, Alex!

Измените имя в адресе и проверьте, что ответ меняется.

Задание 4
В файле Program.cs добавьте строку:
app.MapGet("/api/status", () => new { message = "MyHomeWeb is running", time = DateTime.Now });

Перезапустите приложение.

Откройте http://localhost:7XXX/api/status.

Убедитесь, что в ответе отображается JSON с полями message и time.