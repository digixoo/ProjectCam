using AForge.Video.DirectShow;
using AForge.Vision.Motion;

namespace Cam1.Control.Cam
{
    public class Cam
    {
        public string NameCam { set; get; }
        public bool Activo { private set; get; }
        public string MonikeCam { set; get; }

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

    }
}
