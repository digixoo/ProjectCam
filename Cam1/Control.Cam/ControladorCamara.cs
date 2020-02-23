using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System.Collections.Generic;

namespace Cam1.Control.Cam
{
    public class ControladorCamara
    {          

        private bool _ExistenDispositivos = false;
        //Variable para la lista de dispositivos
        private FilterInfoCollection DispositivosDeVideo;
        //lista de dispositivos
        public List<Cam> lstCant { private set; get; }
       

        public bool ExistenDispositivos
        {
            get
            {
                return _ExistenDispositivos;
            }
        }

        public ControladorCamara()
        {
            lstCant = new List<Cam>();
        }
            

        public void BuscarDispositivos()
        {
            DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivosDeVideo.Count == 0)
            {
                _ExistenDispositivos = false;
            }
            else
            {
                _ExistenDispositivos = true;
                CargaDispositivos(DispositivosDeVideo);
            }
        }

        private void CargaDispositivos(FilterInfoCollection Dispositivos)
        {
            Cam cam;

            for (int i = 0; i < Dispositivos.Count; i++)
            {
                cam = new Cam();
                cam.NameCam = Dispositivos[i].Name.ToString();
                cam.MonikeCam = Dispositivos[i].MonikerString.ToString();
                lstCant.Add(cam);
            }
            
        }

    }
}
