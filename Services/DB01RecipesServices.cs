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
    public class DB01RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection("appsettings:RecipesConnectionString".GetConfigValue()))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = "SELECT * FROM Recipes";
                cmd.CommandType = System.Data.CommandType.Text;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var title = reader["Title"].ToString();

                    recipes.Add(new Recipe { Id = id, Title = title });
                }
            }

            return recipes;
        }
    }
}
