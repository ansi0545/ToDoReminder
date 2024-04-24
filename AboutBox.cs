// AboutBox.cs
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ToDoReminder
{
    /// <summary>
    /// Retrieves the first <see cref="AssemblyTitleAttribute"/> from the assembly's custom attributes.
    /// </summary>
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

            var assembly = Assembly.GetExecutingAssembly();
            var titleAttribute = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).FirstOrDefault() as AssemblyTitleAttribute;
            var title = titleAttribute != null ? titleAttribute.Title : "Unknown";
            var version = assembly.GetName().Version.ToString();
            lblPicture.Text = $"Title: {title}, Version: {version}";
        }
    }
}