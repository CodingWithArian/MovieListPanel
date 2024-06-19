using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieList
{
    public partial class Form1 : Form
    {
        string _path;
        BackgroundWorker worker;
        private delegate void DELEGATE();
        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            this.Text = "Movie List \U0001F497";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          
                SelectDirectory();
            
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

       

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Delegate del = new DELEGATE(createLayout);
            this.Invoke(del);
        }

        private void SelectDirectory()
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.Description = "Select Your Movie Folder";
                DialogResult result = fb.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _path = fb.SelectedPath;
                }
                else
                {
                    MessageBox.Show("No folder selected. Application will exit.");
                    Application.Exit();
                }
            }
        }

        private void EnsureCoversFolderExists()
        {
            string coversFolderPath = Path.Combine(_path, "Covers");
            if (!Directory.Exists(coversFolderPath))
            {
                Directory.CreateDirectory(coversFolderPath);
            }
        }


        public void createLayout()
        {
            EnsureCoversFolderExists();
            // Define supported movie and image file extensions
            string[] movieExtensions = { "*.mkv", "*.mp4", "*.avi" };
            string[] imageExtensions = { ".jpeg", ".jpg", ".png", ".bmp" };

            // Get all movie files from the directory
            var movieFiles = movieExtensions.SelectMany(ext => Directory.GetFiles(_path, ext)).Select(Path.GetFileName).ToArray();

           

            foreach (string movieFile in movieFiles)
            {
                MoviePanel movie = new MoviePanel
                {
                    Title = Path.GetFileNameWithoutExtension(movieFile),
                    Link = Path.Combine(_path, movieFile),
                    Height = 230,
                    Width = 150
                };

             

                // Find the first matching cover image file
                foreach (string imageExtension in imageExtensions)
                {
                    string imagePath = Path.Combine(_path, "Covers", Path.GetFileNameWithoutExtension(movieFile) + imageExtension);
                    if (File.Exists(imagePath))
                    {
                        movie.Image = imagePath;
                        break;
                    }
                }

                // Add movie panel to the flow layout panel
                flowLayoutPanel1.Controls.Add(movie);
            }
        }

    }
}
