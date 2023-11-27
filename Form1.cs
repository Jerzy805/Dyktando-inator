using System.Media;
using Dictations.Interfaces;

namespace Dictations
{
    public partial class Form1 : Form
    {
        private readonly IRepository repository;

        public Form1()
        {
            InitializeComponent();

            repository = new Repository();

            IndexInput.Text = string.Empty;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IndexInput.Text, out int index))
            {
                repository.PlaySound(index);

                IndexInput.Text = string.Empty;
            }
        }
    }
}
