﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace ServicesContracts
{
    public abstract class AbstractRecipesServices
    {
        public abstract List<Recipe> GetAll();
    }
}
