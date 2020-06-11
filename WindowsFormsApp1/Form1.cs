using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ConnectCamera(2);
            init();
            labelCamera1Status.Visible = false;
            labelCamera2Status.Visible = false;
        }
        public IntPtr PictureDev1Cam { get { return pictureBox1.Handle; } }
        public IntPtr PictureDev2Cam { get { return pictureBox2.Handle; } }
        IntPtr Cam1Handle = IntPtr.Zero;
        IntPtr Cam2Handle = IntPtr.Zero;
        //Camera Camera1 = new Camera();
        //Camera Camera2 = new Camera();
        Cam Camera1 = new Cam();
        Cam Camera2 = new Cam();
        static private string Cam1IP = "192.168.1.64";
        static private string Cam2IP = "192.168.1.61";
        void init()
        {
            Cam1Handle = PictureDev1Cam;
            Cam2Handle = PictureDev2Cam;
        }
        private void ConnectCamera(int whitch)
        {
            string userName = "admin";
            string password = "a123456.";
            int PortCamera = 8000;
            if (whitch == 1)
            {
                //ChangeLabelText($"摄像头连接中...", imageControl.labelCamera1Status);
                //labelCamera1Status.Text = "摄像头连接中...";

                Task.Run(() =>
                {

                    if (!Camera1.ConnectCamera(Cam1IP, PortCamera, userName, password))
                    {
                        //ChangeLabelText("摄像头未连接", imageControl.labelCamera1Status);
                        MessageBox.Show("摄像头未连接");
                    }
                    else
                    {
                        //ChangeControlVisibility(false, imageControl.labelCamera1Status);
                        //labelCamera1Status.Text = "";
                        Camera1.Preview(Cam1Handle);
                        Camera1.AdjustMirrorPara(1);
                        Cam1ReconnectTimer.Stop();
                    }
                });
            }
            else
            {
                //ChangeLabelText($"摄像头连接中...", imageControl.labelCamera2Status);
                //labelCamera2Status.Text = "摄像头连接中...";
                Task.Run(() =>
                {
                    if (!Camera2.ConnectCamera(Cam2IP, PortCamera, userName, password))
                    {
                        //ChangeLabelText("摄像头未连接", imageControl.labelCamera2Status);
                    }
                    else
                    {
                        //ChangeControlVisibility(false, imageControl.labelCamera2Status);
                        //labelCamera2Status.Text = "";
                        Camera2.Preview(Cam2Handle);
                        Camera2.AdjustMirrorPara(1);
                        Cam2ReconnectTimer.Stop();
                    }
                });
            }
        }

        private void Cam1ReconnectTimer_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(3000);
            ConnectCamera(1);

        }

        private void Cam2ReconnectTimer_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(3000);
            ConnectCamera(2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
