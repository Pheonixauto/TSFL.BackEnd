
using Microsoft.Extensions.Configuration;

namespace TSFL.Persistance
{
    static class Configurations
    {
        static public string GetConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../TSFL/TSFL.Api"));
                //configurationManager.AddJsonFile("appsettings.json");
                //configurationManager.GetConnectionString("DefaultConnectionStrings");
                return configurationManager.GetConnectionString("DefaultConnectionStrings");
            }

        }
    }
}
