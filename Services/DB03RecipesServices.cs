using DataContracts;
using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DB03RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var cs = "appsettings:AzureRecipesConnectionString".GetConfigValue();

            return GetInternalAll(cs, $"SELECT * FROM Recipes", System.Data.CommandType.Text);
        }

        public override List<Recipe> GetByTitle(string title)
        {
            var cs = "appsettings:AzureRecipesConnectionString".GetConfigValue();

            return GetInternalAll(cs, $"SELECT * FROM Recipes WHERE Title LIKE '%{title}%'", System.Data.CommandType.Text);
        }
    }
}
