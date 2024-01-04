namespace iVertion.Infra.Data.Context
{
    public interface IDatabaseInitializer
    {
         void MigrateDatabase();
    }
}