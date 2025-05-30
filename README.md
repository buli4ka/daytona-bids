dotnet ef migrations add ChangeIdType3 --project Infrastructure --startup-project WebApi --output-dir Migrations
dotnet ef database update --project Infrastructure --startup-project WebApi