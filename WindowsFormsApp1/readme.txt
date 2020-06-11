﻿【注意事项】
------------------------------------
1. 更新设备网络SDK时，SDK开发包【库文件】里的HCNetSDK.dll、HCCore.dll、PlayCtrl.dll、SuperRender.dll、AudioRender.dll、HCNetSDKCom文件夹、ssleay32.dll、libeay32.dll、hlog.dll、hpr.dll、zlib1.dll、log4cxx.properties等文件均要加载到程序里面，【HCNetSDKCom文件夹】（包含里面的功能组件dll库文件）需要和HCNetSDK.dll、HCCore.dll一起加载，放在同一个目录下，且HCNetSDKCom文件夹名不能修改。

2. 如果自行开发软件不能正常实现相应功能，而且程序没有指定加载的dll库路径，请在程序运行的情况下尝试删除HCNetSDK.dll。如果可以删除，说明程序可能调用到系统盘Windows->System32目录下的dll文件，建议删除或者更新该目录下的相关dll文件；如果不能删除，dll文件右键选择属性确认SDK库版本。

3. 如按上述步骤操作后还是不能实现相应功能，请根据NET_DVR_GetLastError返回的错误号判断原因。

4.适用型号：DS-2CD2D15DWD 2.8MM，DS-2CD6424FWD-20 3.7MM，DS-2CD6425FWD-20  2.8MM B