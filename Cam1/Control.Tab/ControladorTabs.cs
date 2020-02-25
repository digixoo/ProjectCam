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
        public Button BtnApagarCam { private set; get; }
        public Button BtnCerrarTab { private set; get; }

        private TabPage Pagina;

        public ControladorTabs(Cam.Cam Camara, TabPage tabPage)
        {
            if (Camara != null)
            {
                this.Camara = Camara;
                this.Pagina = tabPage;
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

                //============================================
                //Activar Desactivar camara               
                BtnApagarCam = new Button ();
                BtnApagarCam.Name = "BtnApagarAccion";
                BtnApagarCam.Text = "Desactivar";
                point = new System.Drawing.Point();
                point.X = 6;
                point.Y = 342;
                BtnApagarCam.Location = point;
                BtnApagarCam.Click += new EventHandler(BtnApagarCam_Click);

                //============================================
                //Cerrar Tab
                BtnCerrarTab = new Button();
                BtnCerrarTab.Name = "BtnCerrarTab";
                BtnCerrarTab.Text = "Cerrar Camara";
                point = new System.Drawing.Point();
                point.X = 80;
                point.Y = 342;
                BtnCerrarTab.Location = point;
                BtnCerrarTab.Click += new EventHandler(BtnCerrarTab_Click);
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
                
                if (Camara.NivelDeDeteccion > 0.02)
                {
                    //Variable para la imagen
                    Bitmap img;
                    img = PantallaCam.GetCurrentVideoFrame();
                    if (img != null)
                    {
                        string ruta = System.Configuration.ConfigurationManager.AppSettings["sourceImg"].ToString() + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpeg";

                        //Guardar imagen en la ruta
                        img.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //borramos imagen de memoria
                        img.Dispose();
                    }
                }
            }
            catch
            {

            }
        }

        private void BtnApagarCam_Click(object sender, EventArgs e)
        {
            int accion = -1;

            accion = Camara.DesactivarActivarCam();

            switch (accion)
            {
                case 0:
                    BtnApagarCam.Text = "Activar";
                    break;
                case 1:
                    BtnApagarCam.Text = "Desactivar";
                    break;
                    
            }
        }

        private void BtnCerrarTab_Click(object sender, EventArgs e)
        {
            Camara.DesactivarCam();
            Pagina.Dispose();
        }
    }
}
