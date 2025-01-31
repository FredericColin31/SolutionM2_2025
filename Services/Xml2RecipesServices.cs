﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataContracts;
using ServicesContracts;

namespace Services
{
    public class Xml2RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var recipes = XDocument.Load("recipes.xml");

            var recipeList = recipes.Descendants("recipe").Select(@node => new Recipe()
            {
                Id = Guid.Parse(@node.Attribute("id").Value),
                Title = @node.Attribute("title").Value
            }).ToList();
            
            return recipeList;
        }
    }
}
