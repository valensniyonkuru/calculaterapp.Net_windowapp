using System.Data;
namespace calculaterapp
{
    public partial class calculater : Form
    {
        private string currentCalculation = "";

        public calculater()
        {
            InitializeComponent();
        }

        private void calculater_Load(object sender, EventArgs e)
        {
        }

        private void button_click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            txtOutput.Text = currentCalculation;
        }

        private void button_Equals_click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString();
            try
            {
                txtOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = txtOutput.Text;
            }
            catch (Exception ex)
            {
                txtOutput.Text = "ERROR";
                currentCalculation = "";
            }
        }

        private void button_Clear_click(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
            currentCalculation = "";
        }

        private void button_clearEntry_click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                // Remove the last character from the currentCalculation string
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            txtOutput.Text = currentCalculation;
        }

    }
}
