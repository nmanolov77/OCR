using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Tesseract;

namespace cam
{
    public partial class Form1 : Form
    {
        VideoCaptureDevice frame;
        FilterInfoCollection Devices;

        public Form1()
        {
            InitializeComponent();
        }
        void Start_Cam() {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            frame = new VideoCaptureDevice(Devices[1].MonikerString);
            frame.NewFrame += new AForge.Video.NewFrameEventHandler(NewFrame_event);
            frame.Start();

        }
        
        void NewFrame_event(object send, NewFrameEventArgs e) {
            try
            {
                pictureBox1.Image = (Image)e.Frame.Clone();
            }

            catch(Exception ex)
            {

            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //START BUTTON
            Start_Cam();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //STOP BUTTON
            frame.Stop();
            pictureBox1.Image = null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //BROWSE BUTTON
           
        }

        string formatString(string input)
        {

            string formattedString = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input, i))
                {
                    formattedString += input[i];
                }   
            }
            return formattedString;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            //CAPTURE BUTTON
            Random rnd = new Random();
            int num = rnd.Next(1, 100000);
            String output = @"C:\Users\imano\OneDrive\Desktop\New Folder\image" + num + ".png";
            infoBox.Clear();
            if (output != "" && pictureBox1.Image != null) {

                pictureBox1.Image.Save(output);
                // pictureBox1.Image.Save(output + "\\Image.png");
                snapshotBox.Image = Image.FromFile(output);
                var img = new Bitmap(Image.FromFile(output));
                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(img);
                string tessOut = page.GetText();
                string gems = formatString(tessOut);

                txtOCROutput.Text = "\n GEMS_ID: " + gems;

                get_info(gems);
            }
        }
        void get_info(String id)
        {
            String name;
            String college;
            String manager;
            String role;
            
            

            if (id == "5951043")
            {
                name = "Jacob Storms\n";
                college = "University of Kentucky \n";
                manager = "Tom Cecil \n";
                role = "App Dev Intern \n";
                infoBox.AppendText("Name: " +name);
                infoBox.AppendText("College: " + college);
                infoBox.AppendText("Manager: " +manager);
                infoBox.AppendText("Role: " +role);

            }
            else if (id == "4158767")
            {
                //Chris
                name = "Chris Ellis\n";
                college = "Indiana University Southeast \n";
                manager = "Tom Cecil \n";
                role = "App Dev Co-op \n";
                infoBox.AppendText("Name: " + name);
                infoBox.AppendText("College: " + college);
                infoBox.AppendText("Manager: " + manager);
                infoBox.AppendText("Role: " + role);
            }
            else if (id == "5146103")
            {
                //Jeff
                name = "Jeff Davis\n";
                college = "University of Louisville \n";
                manager = "Tom Cecil \n";
                role = "Quality Assurance \n";
                infoBox.AppendText("Name: " + name);
                infoBox.AppendText("College: " + college);
                infoBox.AppendText("Manager: " + manager);
                infoBox.AppendText("Role: " + role);
            }
            else if (id == "3561590")
            {
                //Oumar
                name = "Oumar Sall\n";
                college = "University of Louisville \n";
                manager = "Steve Weir \n";
                role = "Application Developer \n";
                infoBox.AppendText("Name: " + name);
                infoBox.AppendText("College: " + college);
                infoBox.AppendText("Manager: " + manager);
                infoBox.AppendText("Role: " + role);
            }
            else
            {
                infoBox.AppendText("Invalid GemsID");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start_Cam();
        }

        private void SnapshotBox_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtOCROutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void InfoBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    } 
}
