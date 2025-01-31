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
            var recipes = Factory.Instance.GetAll();

            dataGridView1.DataSource = recipes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var recipes = Factory.Instance.GetAll();

            var json = JsonConvert.SerializeObject(recipes);

            File.WriteAllText("recipes.json", json);
        }
    }
}
