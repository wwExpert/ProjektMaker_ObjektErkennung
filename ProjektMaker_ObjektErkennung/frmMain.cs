using Microsoft.VisualBasic.Logging;
using Microsoft.ML.Data;
using static ProjektMaker_ObjektErkennung.MLModelObj;
using System.Security.Cryptography;

namespace ProjektMaker_ObjektErkennung
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBildLaden_Click(object sender, EventArgs e)
        {
            // OpenFileDialog erstellen
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Filter auf Dateityp JPG
            openFileDialog.Filter = "JPG-Dateien (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            // Nur ein Bild auswählbar
            openFileDialog.Multiselect = false;

            // Dialog anzeigen
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Bild laden
                Image image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.ImageLocation = openFileDialog.FileName;

                // Bild in PictureBox anzeigen
                pictureBox1.Image = image;
            }
        }

        private void Prediction()
        {
            if (!File.Exists(pictureBox1.ImageLocation))
            {
                MessageBox.Show("Bitte wählen Sie ein Bild aus!");
                return;
            }

            //Load sample data from pictureBox1 and convert to MLImage if is not null or empty
            var image = MLImage.CreateFromFile(pictureBox1.ImageLocation);

            MLModelObj.ModelInput sampleData = new MLModelObj.ModelInput()
            {
                Image = image,
            };

            ////Load model and predict output
            //log.AppendText("Model laden und Objecterkennung ausführen." + Environment.NewLine);

            var result = MLModelObj.Predict(sampleData);

            //log.AppendText("Prediction durchgeführt" + Environment.NewLine);

            //Messagebox with prediction result
            if (result.PredictedLabel == null || result.PredictedLabel.FirstOrDefault() == null)
            {
                MessageBox.Show("Es wurde kein Objekt erkannt!");
                return;
            }
            else
            {
                MessageBox.Show("Es wurde ein Objekt " + result.PredictedLabel.FirstOrDefault().ToString() + "mit einem Score: " + result.Score.FirstOrDefault().ToString() + " ermittelt.");
            }

            DrawBoxes(pictureBox1.Image, result, 0.45);

            pictureBox1.Invalidate();

        }
        //Draw bounding box on image
        private static Image DrawBoxes(Image img, ModelOutput output, double threshold)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                // Erstellen Sie einen roten Stift zum Zeichnen der Begrenzungsrahmen
                using (Pen pen = new Pen(Color.Yellow, 3))
                {
                    {
                        // Iterieren Sie über alle vorhergesagten Begrenzungsrahmen
                        for (int i = 0; i < output.PredictedBoundingBoxes.Length; i += 4)
                        {
                            // Extrahieren Sie die Koordinaten des Begrenzungsrahmens
                            float x = output.PredictedBoundingBoxes[i];
                            float y = output.PredictedBoundingBoxes[i + 1];
                            float width = output.PredictedBoundingBoxes[i + 2] - x;
                            float height = output.PredictedBoundingBoxes[i + 3] - y;

                            // Extrahieren Sie den Score und das Label für diese Vorhersage
                            float score = output.Score[i / 4];
                            string label = output.PredictedLabel[i / 4];

                            // Zeichnen Sie den Begrenzungsrahmen und beschriften Sie ihn, wenn der Score größer als 45% ist
                            if (score > threshold)
                            {
                                g.DrawRectangle(pen, x, y, width, height);
                                g.DrawString($"{label}: {score:P1}", new Font("Arial", 10), Brushes.Red, new PointF(x, y));
                            }
                        }
                    }
                }
            }
            return img;
        }

        private void btnObjekterkennung_Click(object sender, EventArgs e)
        {
            Prediction();
        }
    }
}
