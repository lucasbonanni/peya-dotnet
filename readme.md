## Renew certificates

https://stackoverflow.com/questions/53300480/unable-to-configure-https-endpoint-no-server-certificate-was-specified-and-the

```dotnet dev-certs https --trust```

## db initialize 
 dotnet ef migrations add Initial --project D:\Multimedia\TaskAPI\Services\Services.csproj  --context SQLliteDbContext

## db schema update 
 dotnet ef database update --project D:\Multimedia\TaskAPI\Services\Services.csproj  --context SQLliteDbContext