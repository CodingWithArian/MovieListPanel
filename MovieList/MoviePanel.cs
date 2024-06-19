using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieList
{
     class MoviePanel:FlowLayoutPanel
    {
        private string _title;
        private string _image;
        private string _link;

        Label title=new Label();
        PictureBox image=new PictureBox();

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                if (_title != null) {
                    title.Text = _title;
                }
               
            }
        }
        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                if (_image != null)
                {
                    image.Load(_image);
                }
            }
        }
        public string Link
        {
            get 
            { return _link; }
            set
            {
                _link = value;
            }
        }

        public MoviePanel()
        {
           image.Width = 140;
            image.Height = 190;
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Click += new EventHandler(imClicked);
            title.Width = 140;
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            this.FlowDirection = FlowDirection.TopDown;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(title);
            this.Controls.Add(image);
        }

        private void imClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_link);
        }

        private void Create()
        {
            this.FlowDirection = FlowDirection.TopDown;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(title);
            this.Controls.Add(image);
        }
    }
}
