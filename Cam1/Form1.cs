
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
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            Cam camara;
            AForge.Controls.VideoSourcePlayer video;
            TextBox TxtNivel;

            foreach (TabPage tab in TabCam.TabPages)
            {                
                video = (AForge.Controls.VideoSourcePlayer)tab.Controls["VideoCam"];
                TxtNivel = (TextBox)tab.Controls["txtNivelDeteccion"];

                camara = (Cam)video.Tag;
                TxtNivel.Text = string.Format("{0:00.0000}", camara.NivelDeDeteccion);

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
                //btnIniciar_Click(sender, e);
            }
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //if (btnIniciar.Text != "Detener")
                //{
                //    btnIniciar_Click(sender, e);
                //}
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
                if (!BuscaCam(Camara))
                {
                    try
                    {
                        controladorTabs = new Control.Tab.ControladorTabs(Camara, TabCamPage);
                        TabCamPage.Text = Camara.NameCam;
                        TabCamPage.Controls.Add(controladorTabs.LblNivelDeteccion);
                        TabCamPage.Controls.Add(controladorTabs.txtNivelDeteccion);
                        TabCamPage.Controls.Add(controladorTabs.PantallaCam);
                        TabCamPage.Controls.Add(controladorTabs.BtnApagarCam);
                        TabCamPage.Controls.Add(controladorTabs.BtnCerrarTab);
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

        private bool BuscaCam(Cam Camara)
        {
            Cam CamaraAux;
            bool existe = false;

            foreach (TabPage tab in TabCam.TabPages)
            {
                AForge.Controls.VideoSourcePlayer video = (AForge.Controls.VideoSourcePlayer)tab.Controls["VideoCam"];
                CamaraAux = (Cam)video.Tag;
                if(Camara.NameCam == CamaraAux.NameCam)
                {
                    existe = true;
                    break;
                }
            }

            return existe;
        }
    }
}
