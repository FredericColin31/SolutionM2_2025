using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using ServicesContracts;

namespace Services
{
    public class ObjectRecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            return new List<Recipe>() 
            {
                new Recipe() { Id = Guid.NewGuid(), Title = "Object 01" },
                new Recipe() { Id = Guid.NewGuid(), Title = "Object 02" },
                new Recipe() { Id = Guid.NewGuid(), Title = "Object 03" }
            };
        }
    }
}
