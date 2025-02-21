using DataContracts;
using Newtonsoft.Json;
using Services;

namespace Ihm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Recipe> recipes = null;

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                recipes = Factory.Instance.GetAll();
            }
            else
            {
                recipes = Factory.Instance.GetByTitle(textBox1.Text);
            }

            dataGridView1.DataSource = recipes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var recipes = Factory.Instance.GetAll();

            var json = JsonConvert.SerializeObject(recipes);

            File.WriteAllText("recipes.json", json);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedRecipe = dataGridView1.SelectedRows[0].DataBoundItem as DataContracts.Recipe;

            if (selectedRecipe != null)
            {
                Factory.Instance.DeleteById(selectedRecipe.Id);
                dataGridView1.DataSource = Factory.Instance.GetAll();
            }

        }
    }
}
