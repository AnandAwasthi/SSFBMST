using System;
using System.Configuration;

namespace AwasthiSM.Mongo.DatabaseFactory
{
    public sealed class DatabaseConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        }
        [ConfigurationProperty("DatabaseName")]
        public string DatabaseName
        {
            get { return (string)base["DatabaseName"]; }
        }
        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }
        [ConfigurationProperty("IsSSL")]
        public bool IsSSL
        {
            get { return (bool)base["IsSSL"]; }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception excep)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in config. " + excep.Message);
                }
            }
        }
    
    }
}
