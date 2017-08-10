using System;
using System.Configuration;


namespace __NAME__
{
    public class BusConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("HostAddress")]
        public string HostAddress
        {
            get { return (string)base["HostAddress"]; }
        }
        [ConfigurationProperty("VirtualHost")]
        public string VirtualHost
        {
            get { return (string)base["VirtualHost"]; }
        }
        [ConfigurationProperty("Username")]
        public string Username
        {
            get { return (string)base["Username"]; }
        }
        [ConfigurationProperty("Password")]
        public string Password
        {
            get { return (string)base["Password"]; }
        }
        [ConfigurationProperty("QueueName")]
        public string QueueName
        {
            get { return (string)base["QueueName"]; }
        }
    }
}