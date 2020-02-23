using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Controls;
using Cam1.Control.Cam;

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
                PantallaCam = new VideoSourcePlayer();
                PantallaCam.Name = "VideoCam";
                point = new System.Drawing.Point();
                point.X = 6;
                point.Y = 42;
                PantallaCam.Location = point;
                PantallaCam.Width = 400;
                PantallaCam.Height = 300;
            }
            else
            {
                throw new NullReferenceException("No existe camara referenciada");
            }
            

        }

    }
}
