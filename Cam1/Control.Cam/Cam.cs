using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System.Drawing;

namespace Cam1.Control.Cam
{
    public class Cam
    {
        private bool _activo;
        public string NameCam { set; get; }
        public bool Activo {
            private set
            {
                _activo = value;
            }
            get
            {
                _activo = false;
                if (FuenteDeVideo != null)
                {
                    if (FuenteDeVideo.IsRunning)
                    {
                        _activo = true;
                    }
                }
                return _activo;
            }
        }        
        public string MonikeCam { set; get; }
        public float NivelDeDeteccion { set; get; }

        public Cam()
        {
            Activo = false;
        }
        
        public VideoCaptureDevice FuenteDeVideo { get; private set; }

        //Variables para la detección de movimiento
        public MotionDetector Detector { get; private set; }

        public VideoCaptureDevice ActivarCam()
        {
            FuenteDeVideo = new VideoCaptureDevice(MonikeCam);

            //Inicializar variable de detector
            Detector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionBorderHighlighting());
            Activo = true;
            
            return FuenteDeVideo;
        }

        public int DesactivarActivarCam()
        {
            int accion = -1;
            if(FuenteDeVideo.IsRunning)
            {   
                FuenteDeVideo.SignalToStop();
                FuenteDeVideo.WaitForStop();
                accion = 0;
            }
            else
            {
                FuenteDeVideo.Start();
                accion = 1;
            }

            return accion;
        }

        public void DesactivarCam()
        {  
            if (FuenteDeVideo.IsRunning)
            {
                FuenteDeVideo.SignalToStop();
                FuenteDeVideo.WaitForStop();                
            }
           
        }
    }
}
