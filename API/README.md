# iVertion

# migration

```bash
dotnet ef  migrations add initial --project iVertion.Infra.Data -s iVertion.WebApi -c ApplicationDbContext --verbose
```
```bash
dotnet ef  database update --project iVertion.Infra.Data -s iVertion.WebApi -c ApplicationDbContext --verbose   
```