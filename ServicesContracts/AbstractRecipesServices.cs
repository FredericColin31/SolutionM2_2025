using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace ServicesContracts
{
    public abstract class AbstractRecipesServices
    {
        public abstract List<Recipe> GetAll();

        public abstract List<Recipe> GetByTitle(String title);

        public abstract void DeleteById(Guid recipeID);

        public abstract void Create(DataContracts.Recipe recipe);

        protected List<Recipe> GetInternalAll(String connectionString, String commandText, System.Data.CommandType commandType, string title = null)
        {
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = commandText;
                cmd.CommandType = commandType; ;
                if (title != null)
                {
                    cmd.Parameters.AddWithValue("@title", title);
                }
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var titre = reader["Title"].ToString();

                    recipes.Add(new Recipe { Id = id, Title = titre });
                }
            }

            return recipes;
        }
    }
}
