using DataContracts;
using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DB04RecipesServices : AbstractRecipesServices
    {
        public override void DeleteById(Guid recipeID)
        {
            throw new NotImplementedException();
        }

        public override List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();
            var cs = "appsettings:RecipesConnectionString".GetConfigValue();

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            using (var cn = factory.CreateConnection())
            {
                cn.ConnectionString = cs;
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = "SELECT * FROM Recipes";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var title = reader["Title"].ToString();

                    recipes.Add(new Recipe { Id = id, Title = title });
                }

                return recipes;
            }

        }

        public override List<Recipe> GetByTitle(string ptitle)
        {
            var recipes = new List<Recipe>();
            var cs = "appsettings:RecipesConnectionString".GetConfigValue();

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            using (var cn = factory.CreateConnection())
            {
                cn.ConnectionString = cs;
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM Recipes WHERE title LIKE '%{ptitle}%'";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var title = reader["Title"].ToString();

                    recipes.Add(new Recipe { Id = id, Title = title });
                }

                return recipes;
            }
        }
    }
}
