using System.Reflection;
using System.Windows.Forms;

namespace PerformanceComparison
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            this.labelAssemblyVersion.Text = AssemblyVersion;
            try
            {
                this.textBoxWaffle.LoadFile("abouttext.rtf");
            }
            catch (System.IO.FileNotFoundException)
            {
                this.textBoxWaffle.Text = "[Oooops!! Cant find abouttext.rtf file!]";
            }
        }


        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

    }
}
