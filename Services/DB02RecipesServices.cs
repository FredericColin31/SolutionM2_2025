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
        public override void DeleteById(Guid recipeID)
        {
            throw new NotImplementedException();
        }

        public override List<Recipe> GetAll()
        {
            var cs = "appsettings:RecipesConnectionString".GetConfigValue();
            return GetInternalAll(cs, "sSelectRecipes", System.Data.CommandType.StoredProcedure);
        }

        public override List<Recipe> GetByTitle(string title)
        {
            var cs = "appsettings:RecipesConnectionString".GetConfigValue();
            return GetInternalAll(cs, "sSelectRecipes", System.Data.CommandType.StoredProcedure, title);

        }
    }
}
