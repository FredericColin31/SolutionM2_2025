using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataContracts;
using ServicesContracts;

namespace Services
{
    public class Xml1RecipesServices : AbstractRecipesServices
    {
        public override void DeleteById(Guid recipeID)
        {
            throw new NotImplementedException();
        }

        public override List<Recipe> GetAll()
        {
            var xdoc = new XmlDocument();

            xdoc.Load("recipes.xml");

            var nodes = xdoc.SelectNodes("/recipes/recipe");

            var recipes = new List<Recipe>();

            foreach (XmlNode node in nodes)
            {
                recipes.Add(
                    new Recipe()
                    {
                        Id = Guid.Parse(node.Attributes["id"].Value),
                        Title = node.Attributes["title"].Value
                    }
                    );
            }

            return recipes;
        }

        public override List<Recipe> GetByTitle(string title)
        {
            var recipes = GetAll();

            return recipes.Where(@recipe => @recipe.Title.Contains(title)).ToList();
        }
    }
}
