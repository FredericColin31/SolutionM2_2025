using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Core;
using ServicesContracts;

namespace Services
{
    public static class Factory
    {
        static Factory()
        {
            var afn = "appsettings:AssemblyFileName".GetConfigValue();
            var cn = "appsettings:ClassName".GetConfigValue();

            Instance = Activator.CreateInstance(afn, cn).Unwrap() as AbstractRecipesServices;
        }
        public static AbstractRecipesServices? Instance { get; set; }
    }
}
