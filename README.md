dotnet ef migrations add ChangeIdType3 --project Infrastructure --startup-project WebApi --output-dir Migrations
dotnet ef database update --project Infrastructure --startup-project WebApi

http://localhost:5281/swagger/v1/index.html