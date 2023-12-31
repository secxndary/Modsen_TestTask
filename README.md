# Тестовое задание в Modsen на позицию Intern .NET developer
## Назначение проектов в решении:
    Entities — все сущности приложения, в том числе модели базы данных и исключений
    Contracts — интерфейсы репозиториев, логгера и прочие общие контракты
    LoggerService — реализация сервиса для логгирования, дающий абстракцию над выбранным пакетом
    Repository — репозитории, методы расширения, конфигурация сущностей и контекст, наследуемый от DbContext
    Application – уровень бизнес-логики приложения, содержит Запросы, Команды и Обработчики
    BookLibrary — основной проект, содержащий Program.cs, методы расширения, логи и MappingProfile
    BookLibrary.Presentation — реализация уровеня представления: контроллеры и используемые в них фильтры
    Shared — содержит Data Transfer Objects. Есть отдельные DTO для Input, Output, Update и Manipulation
## Реализованный функционал и интересные фичи:
    Onion-архитектура проекта (Domain, Application and Presentation layers)
    Паттерн CQRS применяется для бизнес-логики
    Аутентификация и авторизация реализованы с помощью Identity и JWT (Access + Refresh)
    Глобальная обработка исключений с помощью кастомного middleware
    ORM Entity Framework Core, для конфигурации используется Fluent API
    Присутствует конфигурация стартовых данных в базу данных
    Используются фичи C#12 (primary constructors)
    Соблюдены принципы DRY, KISS и SOLID
    Присутствует Swagger-документация
## Запуск проекта:
1. Добавить через Командную строку от имени **Администратора** переменную окружения для `JWT Secret`:
   ```
   setx SECRET "your_jwt_secret_that_is_at_least_32_symbols_long" /M
   ```
2. (Опционально) Обновить строку подключения в `appsettings.json`. По умолчанию PostgreSQL:
   ```"Server=localhost;Port=5432;Database=book_library;UserId=postgres;Password=1111"```
3. Провести миграцию (dotnet ef migrations add, dotnet ef database update) из основного проекта `BookLibrary`.
