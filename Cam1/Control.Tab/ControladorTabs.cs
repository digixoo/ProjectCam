using AForge.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cam1.Control.Tab
{
    public class ControladorTabs
    {
        public Label LblNivelDeteccion { private set; get; }
        public TextBox txtNivelDeteccion { private set; get; }
        public VideoSourcePlayer PantallaCam { private set; get; }
        public Cam.Cam Camara { private set; get; }


        public ControladorTabs(Cam.Cam Camara)
        {
            if (Camara != null)
            {
                this.Camara = Camara;
                System.Drawing.Point point;
                //Label de nivel de detección
                LblNivelDeteccion = new Label();
                LblNivelDeteccion.Text = "Nivel de detección";
                //LblNivelDeteccion.Width = 99;
                //LblNivelDeteccion.Height = 33;

                point = new System.Drawing.Point();
                point.X = 201;
                point.Y = 16;
                LblNivelDeteccion.Location = point;
                //============================================
                //Text Box de nivel de detección
                txtNivelDeteccion = new TextBox();
                txtNivelDeteccion.Name = "txtNivelDeteccion";
                point = new System.Drawing.Point();
                point.X = 306;
                point.Y = 16;
                txtNivelDeteccion.Location = point;
                txtNivelDeteccion.TabStop = false;
                txtNivelDeteccion.ReadOnly = true;
                txtNivelDeteccion.Height = 20;
                txtNivelDeteccion.Width = 100;

                //============================================
                //Pantalla de Camara
                VideoSourcePlayer.NewFrameHandler newFrameHandler = new VideoSourcePlayer.NewFrameHandler(videoSourcePlayer_NewFrame);
                PantallaCam = new VideoSourcePlayer();
                PantallaCam.Name = "VideoCam";
                PantallaCam.Tag = Camara;
                point = new System.Drawing.Point();
                point.X = 6;
                point.Y = 42;
                PantallaCam.Location = point;
                PantallaCam.Width = 400;
                PantallaCam.Height = 300;
                PantallaCam.NewFrame += newFrameHandler;
                //PantallaCam.NewFrame += videoSourcePlayer1_NewFrame();
            }
            else
            {
                throw new NullReferenceException("No existe camara referenciada");
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                Camara.NivelDeDeteccion = Camara.Detector.ProcessFrame(image);
            }
            catch
            {

            }
        }


    }
}
