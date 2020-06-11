using System;
using System.IO;
using System.Runtime.InteropServices;


namespace WindowsFormsApp1
{
    class Cam
    {
        private bool initSDK = false;
        private uint lastErr = 0;
        private string debugMessage = "";
        private bool err = false;
        private Int32 userID = -1;
        public bool Isconnected { get; private set; }
        UInt32 dwReturn = 0;
        Int32 nSize = 0;
        IntPtr ptrPicCfg;
        private CHCNetSDK.NET_DVR_CAMERAPARAMCFG_EX camPara = new CHCNetSDK.NET_DVR_CAMERAPARAMCFG_EX();
        private CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
        private Int32 realPlayHandle = -1;
        public bool ConnectCamera(string deviceIP, int port, string userName, string password)
        {

            initSDK = CHCNetSDK.NET_DVR_Init();
            if (initSDK == false)
            {
                lastErr = CHCNetSDK.NET_DVR_GetLastError();
                debugMessage = "初始化过程失败, 错误码： " + lastErr;

                err = true;
                return false;
            }
            else
            {

                CHCNetSDK.NET_DVR_SetLogToFile(3, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SdkLog\\"), true);
            }

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();


            userID = CHCNetSDK.NET_DVR_Login_V30(deviceIP, port, userName, password, ref DeviceInfo);
            if (userID < 0)
            {
                lastErr = CHCNetSDK.NET_DVR_GetLastError();
                debugMessage = "注册失败, 错误码：" + lastErr;
                err = true;

                return false;
            }


            Isconnected = true;
            return true;
        }
        public void AdjustMirrorPara(byte type)
        {
            dwReturn = 0;
            nSize = Marshal.SizeOf(camPara);
            ptrPicCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(camPara, ptrPicCfg, false);
            if (CHCNetSDK.NET_DVR_GetDVRConfig(userID, 3368, DeviceInfo.byStartChan, ptrPicCfg, (uint)nSize, ref dwReturn))
            {
                camPara = (CHCNetSDK.NET_DVR_CAMERAPARAMCFG_EX)Marshal.PtrToStructure(ptrPicCfg, typeof(CHCNetSDK.NET_DVR_CAMERAPARAMCFG_EX));
                Marshal.FreeHGlobal(ptrPicCfg);
                camPara.byMirror = type;

                ptrPicCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(camPara, ptrPicCfg, false);


                if (!CHCNetSDK.NET_DVR_SetDVRConfig(userID, 3369, DeviceInfo.byStartChan, ptrPicCfg, (uint)nSize))
                {
                    lastErr = CHCNetSDK.NET_DVR_GetLastError();
                    debugMessage = "设置镜像关闭失败, 错误码：" + lastErr;
                    err = true;

                }
            }
            else
            {
                lastErr = CHCNetSDK.NET_DVR_GetLastError();
                debugMessage = "获取参数失败, 错误码：" + lastErr;
                err = true;

            }
            Marshal.FreeHGlobal(ptrPicCfg);
        }
        public void Preview(IntPtr handle)
        {
            CHCNetSDK.NET_DVR_PREVIEWINFO previewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            previewInfo.hPlayWnd = handle;//预览窗口
            previewInfo.lChannel = 1;//(int)DeviceInfo.byStartChan;//预览的设备通道
            previewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            previewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            previewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            previewInfo.dwDisplayBufNum = 0; //播放库播放缓冲区最大缓冲帧数

            //CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
            realPlayHandle = CHCNetSDK.NET_DVR_RealPlay_V40(userID, ref previewInfo, null/*RealData*/, pUser);
            if (realPlayHandle < 0)
            {
                lastErr = CHCNetSDK.NET_DVR_GetLastError();
                debugMessage = "预览失败, 错误码： " + lastErr; //预览失败，输出错误号
                err = true;
                //MessageBox.Show(str);
                return;
            }
        }
    }
}
