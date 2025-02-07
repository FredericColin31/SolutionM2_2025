using DataContracts;
using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DB02RecipesServices : AbstractRecipesServices 
    {
        public override List<Recipe> GetAll()
        {
            var cs = "appsettings:RecipesConnectionString".GetConfigValue();
            return GetInternalAll(cs, "sSelectRecipes", System.Data.CommandType.StoredProcedure);
        }
    }
}
