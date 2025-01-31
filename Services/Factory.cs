using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesContracts;

namespace Services
{
    public static class Factory
    {
        static Factory()
        {
            Instance = new ObjectRecipesServices();
        }
        public static AbstractRecipesServices Instance { get; set; }
    }
}
