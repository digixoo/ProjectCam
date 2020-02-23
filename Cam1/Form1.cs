
using Cam1.Control.Cam;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cam1
{
    public partial class Form1 : Form
    {
        private float NivelDeDeteccion;

        //Sobrecargas para la captura de estado de Windows
        private SessionSwitchEventHandler sseh;
        private ControladorCamara ControladorCamara;
        Cam cam;
        public Form1()
        {
            InitializeComponent();
            ControladorCamara = new ControladorCamara();
            ControladorCamara.BuscarDispositivos();

            cboDispositivos.DataSource = ControladorCamara.lstCant;
            cboDispositivos.ValueMember = "MonikeCam";
            cboDispositivos.DisplayMember = "NameCam";

            //===================================================
            //Sobrecargas para la captura de estado de Windows(Bloqueado o desbloqueado)
            sseh = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += sseh;
            //===================================================
        }


        private void btnIniciar_Click(object sender, System.EventArgs e)
        {
            cam = ControladorCamara.lstCant.Find(x => x.MonikeCam.Contains(cboDispositivos.SelectedValue.ToString()));
            if (btnIniciar.Text == "Iniciar")
            {
                if (ControladorCamara.ExistenDispositivos)
                {

                    videoSourcePlayer1.VideoSource = cam.ActivarCam();
                    videoSourcePlayer1.Start();
                    Estado.Text = "Ejecutando dispositivo " + cboDispositivos.SelectedItem.ToString();
                    btnIniciar.Text = "Detener";
                    cboDispositivos.Enabled = false;
                }
                else
                {
                    Estado.Text = "Error: No se encuentran dispositivos";
                }
            }
            else
            {
                if (cam != null)
                {
                    if (cam.FuenteDeVideo.IsRunning)
                    {
                        videoSourcePlayer1.SignalToStop();
                        Estado.Text = "Dispositivo detenido";
                        btnIniciar.Text = "Iniciar";
                        cboDispositivos.Enabled = true;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tab in TabCam.TabPages)
            {
                AForge.Controls.VideoSourcePlayer video = (AForge.Controls.VideoSourcePlayer)tab.Controls["VideoCam"];
                if (video.VideoSource.IsRunning)
                {
                    video.SignalToStop();
                }
            }



            if (btnIniciar.Text == "Detener")
            {
                btnIniciar_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            NivelDeDeteccion = 0;
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                NivelDeDeteccion = cam.Detector.ProcessFrame(image);
            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            Cam camara;
            AForge.Controls.VideoSourcePlayer video;
            TextBox TxtNivel;
            string nivelDeDeteccion;

            foreach (TabPage tab in TabCam.TabPages)
            {
                nivelDeDeteccion = "";
                video = (AForge.Controls.VideoSourcePlayer)tab.Controls["VideoCam"];
                TxtNivel = (TextBox)tab.Controls["txtNivelDeteccion"];
                
                camara = (Cam)video.Tag;
                TxtNivel.Text = string.Format("{0:00.0000}", camara.NivelDeDeteccion);
                
            }



            txt_lvl_detection.Text = string.Format("{0:00.0000}", NivelDeDeteccion);
            //txt_lvl_detection.Text = NivelDeDeteccion.ToString(); ;


            //Variable para la imagen
            Bitmap img = videoSourcePlayer1.GetCurrentVideoFrame();
            if (img != null)
            {
                if (NivelDeDeteccion > 0.02)
                {
                    string ruta = System.Configuration.ConfigurationManager.AppSettings["sourceImg"].ToString() + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpeg";

                    //Guardar imagen en la ruta
                    img.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);

                }
                //borramos imagen de memoria
                img.Dispose();
            }




        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            string s = DateTime.Now.ToString();
            s = s + " " + e.Reason.ToString();
            //richTextBox1.AppendText(s + "\n");
            //if (e.Reason == SessionSwitchReason.SessionLogon)
            //{
            //    eLog("Start();");
            //}
            //if (e.Reason == SessionSwitchReason.SessionLogoff)
            //{
            //    eLog("Stop();");
            //}
            if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                btnIniciar_Click(sender, e);
            }
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                if (btnIniciar.Text != "Detener")
                {
                    btnIniciar_Click(sender, e);
                }
            }
            //if (e.Reason == SessionSwitchReason.ConsoleConnect)
            //{
            //    eLog("Unlock();");
            //}
            //if (e.Reason == SessionSwitchReason.ConsoleDisconnect)
            //{
            //    eLog("Lock();");
            //}
        }


        public void eLog(string mensaje)
        {

            string fecha = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            String ArchLog = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"" + DateTime.Parse(fecha).ToString("yyyyMMdd") + "ProcesoAutomatico.log";

            mensaje = fecha + "; " + mensaje + ";";

            Console.WriteLine(mensaje);

            System.IO.StreamWriter sw = new System.IO.StreamWriter(ArchLog, true);
            sw.WriteLine(mensaje);
            sw.Close();


        }

        private void txt_spy_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            TabPage TabCamPage = new TabPage();
            Cam Camara;
            Control.Tab.ControladorTabs controladorTabs;

            Camara = ControladorCamara.lstCant.Find(x => x.MonikeCam.Contains(cboDispositivos.SelectedValue.ToString()));

            if (Camara != null)
            {
                if (!Camara.Activo)
                {
                    try
                    {
                        controladorTabs = new Control.Tab.ControladorTabs(Camara);
                        TabCamPage.Text = Camara.NameCam;
                        TabCamPage.Controls.Add(controladorTabs.LblNivelDeteccion);
                        TabCamPage.Controls.Add(controladorTabs.txtNivelDeteccion);
                        TabCamPage.Controls.Add(controladorTabs.PantallaCam);
                        TabCam.TabPages.Add(TabCamPage);

                        controladorTabs.PantallaCam.VideoSource = Camara.ActivarCam();
                        controladorTabs.PantallaCam.Start();
                    }
                    catch(NullReferenceException )
                    {
                        MessageBox.Show("Problema para mostrar la camara seleccionada");
                    }
                  
                }
                else
                {
                    MessageBox.Show("La camara seleccionada ya se encuentra activa");
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una camra valida");
            }
        }
    }
}
