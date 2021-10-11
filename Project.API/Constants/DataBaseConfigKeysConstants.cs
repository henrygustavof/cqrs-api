namespace Project.API.Constants
{
    public static class DataBaseConfigKeysConstants
    {
        public static class SqlDB
        {
            public const string ConnectionString = "ConnectionString";
        }

        public static class CosmosDB
        {
            public const string ConnectionString = "CosmosDB:ConnectionString";
            public const string DataBaseName = "CosmosDB:DataBaseName";
        }
    }
}
