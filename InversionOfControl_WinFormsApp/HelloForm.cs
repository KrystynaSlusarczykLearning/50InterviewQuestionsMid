namespace InversionOfControl_WinFormsApp
{
    public partial class HelloForm : Form
    {
        public HelloForm()
        {
            InitializeComponent();
        }

        private void YearOfBirthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            YearOfBirthTextBox.BackColor = Color.White;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SetBackColor(NameTextBox);
            SetBackColor(YearOfBirthTextBox);

            if(!string.IsNullOrEmpty(NameTextBox.Text) &&
               !string.IsNullOrEmpty(YearOfBirthTextBox.Text))
            {
                int age = DateTime.Now.Year - int.Parse(
                    YearOfBirthTextBox.Text);
                ResultTextBox.Text = $"Hello {NameTextBox.Text}! You are " +
                    $"{age} years old!";
            }
        }

        private void SetBackColor(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BackColor = Color.IndianRed;
            }
            else
            {
                textBox.BackColor = Color.White;
            }
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NameTextBox.BackColor = Color.White;
        }
    }
}