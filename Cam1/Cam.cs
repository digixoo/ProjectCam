using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cam1
{
    public class Cam
    {
        public string NameCam { set; get; }

        public string MonikeCam { set; get; }

        public VideoCaptureDevice FuenteDeVideo { get; private set; }

        //Variables para la detección de movimiento
        public MotionDetector Detector { get; private set; }

        public VideoCaptureDevice ActivarCam()
        {
            FuenteDeVideo = new VideoCaptureDevice(MonikeCam);
            //Inicializar variable de detector
            Detector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionBorderHighlighting());

            return FuenteDeVideo;
        }

    }
}
