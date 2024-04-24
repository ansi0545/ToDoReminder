// AboutBox.cs
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ToDoReminder
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            try
            {
                pictureBoxHelp.Image = Image.FromFile("C:\\source\\repos\\c#\\ToDoReminder\\IMG_0527.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}");
            }

            // Get the assembly that contains the code that is currently executing
            var assembly = Assembly.GetExecutingAssembly();

            // Get the assembly title
            var titleAttribute = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).FirstOrDefault() as AssemblyTitleAttribute;
            var title = titleAttribute != null ? titleAttribute.Title : "Unknown";

            // Get the assembly version
            var version = assembly.GetName().Version.ToString();

            lblPicture.Text = $"Title: {title}, Version: {version}";
        }
    }
}