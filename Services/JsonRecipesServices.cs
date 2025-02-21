using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using Newtonsoft.Json;
using ServicesContracts;

namespace Services
{
    public class JsonRecipesServices : AbstractRecipesServices
    {
        public override void DeleteById(Guid recipeID)
        {
            throw new NotImplementedException();
        }

        public override List<Recipe> GetAll()
        {
            var json = File.ReadAllText("recipes.json");
            return JsonConvert.DeserializeObject<List<Recipe>>(json);
        }

        public override List<Recipe> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
