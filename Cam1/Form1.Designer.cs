namespace Cam1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.cboDispositivos = new System.Windows.Forms.ComboBox();
            this.Estado = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_spy = new System.Windows.Forms.Button();
            this.txt_lvl_detection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar camara";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(285, 376);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // cboDispositivos
            // 
            this.cboDispositivos.FormattingEnabled = true;
            this.cboDispositivos.Location = new System.Drawing.Point(113, 351);
            this.cboDispositivos.Name = "cboDispositivos";
            this.cboDispositivos.Size = new System.Drawing.Size(293, 21);
            this.cboDispositivos.TabIndex = 3;
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.Location = new System.Drawing.Point(6, 386);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(50, 13);
            this.Estado.TabIndex = 4;
            this.Estado.Text = "Detenido";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_spy);
            this.groupBox1.Controls.Add(this.txt_lvl_detection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.videoSourcePlayer1);
            this.groupBox1.Controls.Add(this.Estado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.cboDispositivos);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 428);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txt_spy
            // 
            this.txt_spy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_spy.Image = ((System.Drawing.Image)(resources.GetObject("txt_spy.Image")));
            this.txt_spy.Location = new System.Drawing.Point(366, 378);
            this.txt_spy.Name = "txt_spy";
            this.txt_spy.Size = new System.Drawing.Size(40, 40);
            this.txt_spy.TabIndex = 9;
            this.txt_spy.UseVisualStyleBackColor = true;
            this.txt_spy.Click += new System.EventHandler(this.txt_spy_Click);
            // 
            // txt_lvl_detection
            // 
            this.txt_lvl_detection.Location = new System.Drawing.Point(306, 12);
            this.txt_lvl_detection.Name = "txt_lvl_detection";
            this.txt_lvl_detection.Size = new System.Drawing.Size(100, 20);
            this.txt_lvl_detection.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nivel de detección:";
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(6, 42);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(400, 300);
            this.videoSourcePlayer1.TabIndex = 6;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "#Ca";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 433);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "powerByMolina";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ComboBox cboDispositivos;
        private System.Windows.Forms.Label Estado;
        private System.Windows.Forms.GroupBox groupBox1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.TextBox txt_lvl_detection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button txt_spy;
    }
}

