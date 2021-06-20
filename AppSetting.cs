using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GestionTâche
{
    public class AppSetting
    {
        Configuration config;

        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public string GetConnectionString(string Key)
        {
            return config.ConnectionStrings.ConnectionStrings[Key].ConnectionString;
        }
        public void SaveConnectionString(string Key,string value)
        {

            config.ConnectionStrings.ConnectionStrings[Key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[Key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);

        }


    }
}
