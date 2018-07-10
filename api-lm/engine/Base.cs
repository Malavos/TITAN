namespace Engine
{
    public interface Base
    {

        bool SetConnectionString(string connectionString);
        string GetConnectionString();


    }

    //public static class Configuration
    //{

    //    public static string ConnectionString { get; set; } = String.Empty;

    //    public static bool SetConnectionString(string connectionString)
    //    {
    //        if (string.IsNullOrWhiteSpace(connectionString))
    //            throw new ArgumentNullException(Mensagens.Excecoes.ARGUMENTOS_NULOS);
    //        ConnectionString = connectionString;
    //        return true;
    //    }

    //    public static string GetConnectionString()
    //    {
    //        return ConnectionString;
    //    }
    //}
}