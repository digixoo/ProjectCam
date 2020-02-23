using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cam1.Control.Cam;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TestingCamara
    {
        [TestMethod]
        public void NoExisteCam_BusquedaRealizada()
        {
            ControladorCamara controladorCamara = new ControladorCamara();
            List<Cam> lstCam;
            Cam cam;

            controladorCamara.BuscarDispositivos();

            lstCam = controladorCamara.lstCant;
            cam = lstCam.Find(x => x.MonikeCam.Contains("camquenoexiste"));

            Assert.IsNull(cam);
        }

        [TestMethod]
        public void NoExisteCam_BusquedaNoRealizada()
        {
            ControladorCamara controladorCamara = new ControladorCamara();
            List<Cam> lstCam;
            Cam cam;

            lstCam = controladorCamara.lstCant;
            cam = lstCam.Find(x => x.MonikeCam.Contains("camquenoexiste"));

            Assert.IsNull(cam);
        }

        [TestMethod]
        public void ExisteCam()
        {
            ControladorCamara controladorCamara = new ControladorCamara();
            List<Cam> lstCam;
            Cam cam;
            string monikeCam = "";
            controladorCamara.BuscarDispositivos();

            lstCam = controladorCamara.lstCant;
            monikeCam = DevuelveMonikeCamValido(lstCam);

            cam = lstCam.Find(x => x.MonikeCam.Contains(monikeCam));

            Assert.IsNotNull(cam);
        }

        private string DevuelveMonikeCamValido(List<Cam> lstCam)
        {
            string monikeCam = "";
            if(lstCam != null)
            {
                if (lstCam.Count > 0)
                {
                    monikeCam = lstCam[0].MonikeCam;
                }
            }

            return monikeCam;
        }
    }
}
