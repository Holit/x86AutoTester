# x86 自动测试软件 技术文档（使用手册）

[TOC]

## 概要

本文档将精确的介绍项目的各个技术参数和使用说明、规范。

## 运行环境说明

* 您应该将客户端程序、服务器程序运行在同级别局域网中

* 从客户端程序应该能够访问到服务器，即您应该关闭局域网客户端隔离

* 必要情况下，您需要为程序的防火墙提供例外以便信息的传递

* 本程序的通信具体环境如下：

  * 通信协议：
    * 握手阶段：UDP
    * 通信阶段：WebSocket
  * 端口占用：2333、6839

* 运行环境说明

  * 期望用户操作系统：Windows 10 21H2

  * 最低用户操作系统：Windows 10 1809

  * .NET Framework支持：[ .NET Framework 4.7.2](https://dotnet.microsoft.com/zh-cn/download/dotnet-framework/net472)

  * 多语言：不支持

  * UAC权限：管理员权限

  * 其他支持
    * [Windows Management Instrumentation](https://en.wikipedia.org/wiki/Windows_Management_Instrumentation)：至少Windows NT 4.0操作系统
    
    * OpenHardwareMonitor：处理器支持获取温度、风扇数据
    
    * Visual C++ 2022运行时（您可以在安装文件夹下找到VC_redist.x86.exe来安装需要的Visual C++ 运行库）
    
      [Latest supported Visual C++ Redistributable downloads | Microsoft Docs](https://docs.microsoft.com/en-US/cpp/windows/latest-supported-vc-redist?view=msvc-170)

* 开发环境说明

  * NuGet包

    * [Newtonsoft.Json](https://www.newtonsoft.com/json)
    * [statianzo/Fleck: C# Websocket Implementation (github.com)](https://github.com/statianzo/Fleck)
    * [OpenHardwareMonitor](http://openhardwaremonitor.org/)
    * [PowerShell/MMI (github.com)](https://github.com/PowerShell/MMI)

  * 拓展

    * [Microsoft Visual Studio Installer Projects 2022 - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects)
  
  * 编译选项
  
    * 编译
  
      ```
      /permissive- /ifcOutput "Release\" /GS /GL /analyze- /W3 /Gy /Zc:wchar_t /Zi /Gm- /O2 /sdl /Fd"Release\vc143.pdb" /Zc:inline /fp:precise /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_UNICODE" /D "UNICODE" /errorReport:prompt /WX- /Zc:forScope /Gd /Oy- /Oi /MT /FC /Fa"Release\" /EHsc /nologo /Fo"Release\" /Fp"Release\Tester.pch" /diagnostics:column 
      ```
  
    * 连接
  
      ```
      /OUT:"D:\Projects\x86Tester\WinUI\Release\Tester.exe" /MANIFEST /LTCG:incremental /NXCOMPAT /PDB:"D:\Projects\x86Tester\WinUI\Release\Tester.pdb" /DYNAMICBASE "kernel32.lib" "user32.lib" "gdi32.lib" "winspool.lib" "comdlg32.lib" "advapi32.lib" "shell32.lib" "ole32.lib" "oleaut32.lib" "uuid.lib" "odbc32.lib" "odbccp32.lib" /LARGEADDRESSAWARE /DEBUG /MACHINE:X86 /OPT:REF /SAFESEH /INCREMENTAL:NO /PGD:"D:\Projects\x86Tester\WinUI\Release\Tester.pgd" /SUBSYSTEM:CONSOLE /MANIFESTUAC:"level='asInvoker' uiAccess='false'" /ManifestFile:"Release\Tester.exe.intermediate.manifest" /LTCGOUT:"Release\Tester.iobj" /OPT:ICF /ERRORREPORT:PROMPT /ILK:"Release\Tester.ilk" /NOLOGO /TLBID:1 
      ```
  
      
  
  
  * 最低Visual Studio要求：Visual Studio 2019
  
  * 开源项目引用
  
    * [microsoft/diskspd (github.com)](https://github.com/Microsoft/diskspd)

## 安装程序

服务端自带测试端安装包。您在安装服务端结束之后将可以在桌面上看到服务端启动的图标和附带的客户端安装程序。由于不能从一种未知的方法、未知的地址进行数据传递，您需要手动将安装包复制到测试对象上，手动安装并验证UAC、防火墙等设置。请注意：由于操作系统安全限制，这些设置无法自动完成。如不这样做，可能会出现一系列错误。

请注意：服务端已经内置了虚拟机网络检测代码(Server/WebSocket.cs/112)，您在虚拟机上运行的服务端可能会出现无法连接的问题。请知悉。

您可以在安装文件夹下找到VC_redist.x86.exe来安装需要的Visual C++ 运行库

## 服务端

此处将详细介绍服务端的使用、开发、调试场景说明

### 可执行应用程序流程

*无特别说明的情况下，所有内容按照顺序阻塞运行*

*异步流程：异步{流程编号}{子异步流程标识}{可选-异步子流程子操作标识}*

* 启动前
  * 获取本机网卡信息
  * 过滤网卡信息
    * 滤去未启用网卡
    * 滤去非法网卡
      * 虚拟机网卡清单（MAC地址包含）：
        * `00:50:56`
        * `00:1C:14`
        * `00:0C:29`
        * `00:05:69`(VMWare Inc.)
        * `08:00:27`(VirtualBox)
        * `00:15:5D`(Hyper-V)
      * 网络速度为-1的网卡
    * 滤去**非**下述网络类型网卡：
      * `NetworkInterfaceType.Ethernet` 
      * `NetworkInterfaceType.Wireless80211` 
      * `NetworkInterfaceType.GigabitEthernet` 
      * `NetworkInterfaceType.AsymmetricDsl` 
      * `NetworkInterfaceType.BasicIsdn` 
      * `NetworkInterfaceType.Ethernet3Megabit` 
      * `NetworkInterfaceType.FastEthernetFx` 
      * `NetworkInterfaceType.FastEthernetT` 
      * `NetworkInterfaceType.Fddi` 
      * `NetworkInterfaceType.Isdn` 
      * `NetworkInterfaceType.MultiRateSymmetricDsl` 
      * `NetworkInterfaceType.PrimaryIsdn` 
      * `NetworkInterfaceType.RateAdaptDsl` 
      * `NetworkInterfaceType.SymmetricDsl` 
      * `NetworkInterfaceType.Tunnel` 
      * `NetworkInterfaceType.VeryHighSpeedDsl` 
      * `NetworkInterfaceType.Wman` 
      * `NetworkInterfaceType.Wwanpp` 
      * `NetworkInterfaceType.Wwanpp2`
    * 滤去本地地址
      * `169.254.\*.\*`
    * 滤去非IPV4地址簇
  * 根据合法网卡、网络信息建立网络终端数据
  * （异步AA）从合法网络终端发送UDP广播，端口号6839，每次间隔1s
  * 任意错误将指明
  * （异步AB）建立WebSocket：`ws://0.0.0.0:2333`
  * 监听此地址，监听结果返回在Console.Writeline中
  * 任意错误将指明
  * （异步C）执行消息循环
  * （异步ABA）监听连接、执行连接建立、断开消息环
* 显示UI界面
  * 如果存在额外插件则加载（预留功能）
  * 获取本机即插即用设备数量，WMI路径`Win32_PnPEntity`，填入UI
* 生成配置文件
  * 按照各复选框的勾选情况进行配置文件建立
  * 如果校验/校验自定义配置被启用，则按照填入的配置执行写入
  * 如果未被启用，则获取本机配置数据并写入
  * 生成配置文件
    * 配置文件详情
      * 各测试配置的启用情况簇，bool类型
      * Processor信息组
      * PhysicalMemory信息组
      * DiskDrive信息组
      * NetworkAdapter信息组
      * VedioController信息组
    * 执行UTF8编码
    * 执行base64编码
    * 输出到`configfile.jht`
  * 如果有需要，则再次输出到指定位置
* 处理消息循环
  * 初次登陆将向客户端发送服务器地址、UUID以便建立连接
  * 根据消息类型和内容判断回复
  * 初次接收到任务请求时执行任务下发
* 接受日志

### 配置校验

部分配置校验将在服务器端完成

#### 校验项目列表

* RTC校验

  * 客户端时间与服务器时差不超过2秒（包括网络时延）
  * 校验不更变任意端的时间
  * 失败时记录时差

* WMI项目配置校验

  将校验下述数据，数据说明附在后方。

  配置校验方法：字符串比对

  * 处理器
    * ProcessorId
      * 描述处理器功能的处理器信息
      * 对于 32位处理器，字段取决于 CPUID 指令的处理器支持。如果支持该指令，则该属性包含 2 (两个) DWORD 格式的值。第一个是偏移量 08h-0Bh，这是 CPUID 指令在输入 EAX 设置为 1 时返回的 EAX 值。第二个是偏移量 0Ch-0Fh，这是指令返回的 EDX 值。只有属性的前两个字节是有效的，并且包含 CPU 复位时 DX 寄存器的内容——所有其他字节都设置为 0（零），并且内容为 DWORD 格式。
    * Name
      * 处理器的名称
      * 该值来自 SMBIOS 信息中 Processor Information 结构的 Processor Version 成员。
    * Manufacturer
      * 处理器制造商的名称
      * 示例: GenuineIntel
    * Family
      * 处理器系列
      * 请查看https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor获取更多信息
    * MaxClockSpeed
      * 处理器最大时钟频率，单位为MHz
  * 物理内存阵列
    * Manufacturer
      * 内存设备的名称.
      * 示例: SK Hynix
    * PartNumber
      * 设备序列号，由负责生产或制造设备的制造商分配的设备编号。
    * SerialNumber
      * 设备SN代码，制造商分配的编号，用于标识特定设备
    * Capacity
      * 物理内存的总容量，以字节为单位。
    * Speed
      * 物理内存的速度，以纳秒(ns)为单位。
  * 显示适配器
    * Name
      * 显示适配器名称
      * 示例：NVIDIA GeForce RTX 3080 Laptop GPU
    * VideoProcessor
      * 描述图像处理器的自由字符串
    * AdapterCompatibility
      * 该控制器的通用芯片组，用于比较与系统的兼容性
    * AdapterRAM
      * 视频适配器的内存大小
  * 磁盘驱动器
    * Manufacturer
      * 驱动器名称.
      * 示例: (标准磁盘驱动器)
    * MediaType
      * 此设备使用或访问的媒体类型。
      * 为以下四种值之一
        * `External hard disk media`
        * `Removable media`
        * `Fixed hard disk`
        * `Unknown`
    * Model
      * 磁盘驱动器的制造商型号
      * 示例：ST32171W
    * Size
      * 磁盘驱动器的大小。它是通过将柱面总数、每个柱面中的磁道、每个磁道中的扇区以及每个扇区中的字节数相乘来计算的。
    * SerialNumber
      * 设备SN代码，制造商分配的编号，用于标识特定设备
  * 网络适配器
    * Description
      * 设备描述
    * GUID
      * 连接的全局唯一标识符。
    * Speed
      * 适配器速度
      * 以bit/s为单位估计当前带宽。 对于带宽变化的端点或无法进行准确估计的端点，此属性应包含标称带宽。
  * 即插即用设备
    * 数量

#### 示例配置文件

源文件

```
ewogICJzZW5kZXJVVUlEIjogIjc0YWM1ZTdhLTg0YzMtNGFjNy04MTY2LTZhY2FkZjcxZWZmMyIsCiAgIkNyZWF0aW9uVGltZSI6ICIyMDIyLTA0LTA4VDIyOjMxOjM3LjAzNzQ4NDkrMDg6MDAiLAogICJnbG9iYWxfY3B1IjogdHJ1ZSwKICAiY3B1X2Vycm9yX3N0b3AiOiBmYWxzZSwKICAiY3B1X2FsbF90ZW1wIjogZmFsc2UsCiAgImNwdV9hbGxfZmFuX3NwZWVkIjogZmFsc2UsCiAgImNwdV9kZXRhaWxlZF9pbmZvIjogZmFsc2UsCiAgImdsb2JhbF9tZW0iOiB0cnVlLAogICJtZW1fZXJyb3Jfc3RvcCI6IGZhbHNlLAogICJtZW1fZXJyb3JfYWRkcmVzcyI6IGZhbHNlLAogICJnbG9iYWxfZGlzayI6IHRydWUsCiAgImRpc2tfY2hrZHNrIjogZmFsc2UsCiAgImRpc2tfd3JpdGVfdGVzdCI6IGZhbHNlLAogICJkaXNrX3dyaXRlX3R5cGUiOiAwLAogICJnbG9iYWxfbmV0IjogdHJ1ZSwKICAibmV0X3Rlc3QiOiB0cnVlLAogICJuZXRfd2ViX3Rlc3QiOiB0cnVlLAogICJuZXRfbWFjIjogdHJ1ZSwKICAiZ2xvYmFsX291dGxldCI6IGZhbHNlLAogICJvdXRsZXRfY29tIjogdHJ1ZSwKICAib3V0bGV0X3BucF9jb3VudCI6IDE2LAogICJvdXRsZXRfdXNiIjogdHJ1ZSwKICAiYXVkaW9fcGxheWJhY2siOiB0cnVlLAogICJhdWRpb19hZGp1c3Rfdm9sIjogdHJ1ZSwKICAiYXVkaW9fbWF4X3ZvbCI6IGZhbHNlLAogICJydGNfc2V0X2xvY2FsIjogZmFsc2UsCiAgIm92ZXJyaWRlX2ZsYWciOiAwLAogICJzZW5kX3dtaV9pbmZvcm1hdGlvbiI6IGZhbHNlLAogICJQcm9jZXNzb3JzIjogWwogICAgewogICAgICAiaWQiOiAxLAogICAgICAiTmFtZSI6ICIxMXRoIEdlbiBJbnRlbChSKSBDb3JlKFRNKSBpOS0xMTk1MEggQCAyLjYwR0h6IiwKICAgICAgIkZhbWlseSI6ICIyMDciLAogICAgICAiTWF4Q2xvY2tTcGVlZCI6ICIyNjExIiwKICAgICAgIk1hbnVmYWN0dXJlciI6ICJHZW51aW5lSW50ZWwiLAogICAgICAiUHJvY2Vzc29ySWQiOiAiQkZFQkZCRkYwMDA4MDZFMiIKICAgIH0KICBdLAogICJQaHlzaWNhbE1lbW9yeXMiOiBbCiAgICB7CiAgICAgICJpZCI6IDEsCiAgICAgICJNYW51ZmFjdHVyZXIiOiAiU0sgSHluaXgiLAogICAgICAiUGFydE51bWJlciI6ICJITUFBMkdTNkNKUjhOLVhOICAgICIsCiAgICAgICJTZXJpYWxOdW1iZXIiOiAiMDUxNkRDODciLAogICAgICAiQ2FwYWNpdHkiOiAiMDcxNzk4NjkxODQiLAogICAgICAiU3BlZWQiOiAiMzIwMCIKICAgIH0KICBdLAogICJWaWRlb0NvbnRyb2xsZXJzIjogWwogICAgewogICAgICAiaWQiOiAxLAogICAgICAiTmFtZSI6ICJJbnRlbChSKSBVSEQgR3JhcGhpY3MiLAogICAgICAiVmlkZW9Qcm9jZXNzb3IiOiAiSW50ZWwoUikgVUhEIEdyYXBoaWNzIEZhbWlseSIsCiAgICAgICJBZGFwdGVyQ29tcGF0aWJpbGl0eSI6ICJJbnRlbCBDb3Jwb3JhdGlvbiIsCiAgICAgICJBZGFwdGVyUkFNIjogIjEwNzM3NDE4MjQiCiAgICB9CiAgXSwKICAiRGlza3MiOiBbCiAgICB7CiAgICAgICJpZCI6IDEsCiAgICAgICJNYW51ZmFjdHVyZXIiOiAiKOagh+WHhuejgeebmOmpseWKqOWZqCkiLAogICAgICAiTWVkaWFUeXBlIjogIlJlbW92YWJsZSBNZWRpYSIsCiAgICAgICJNb2RlbCI6ICJTRFhDIGNhcmQiLAogICAgICAiU2l6ZSI6ICIxMjgwNDI5MzM3NjAiLAogICAgICAiU2VyaWFsTnVtYmVyIjogIm51bGwiCiAgICB9CiAgXSwKICAiTmV0d29ya0FkYXB0ZXJzIjogWwogICAgewogICAgICAiaWQiOiAxLAogICAgICAiRGVzY3JpcHRpb24iOiAiTWljcm9zb2Z0IEtlcm5lbCBEZWJ1ZyBOZXR3b3JrIEFkYXB0ZXIiLAogICAgICAiR1VJRCI6ICJudWxsIiwKICAgICAgIlNwZWVkIjogIm51bGwiCiAgICB9LAogICAgewogICAgICAiaWQiOiAyLAogICAgICAiRGVzY3JpcHRpb24iOiAiSW50ZWwoUikgRXRoZXJuZXQgQ29udHJvbGxlciAoMykgSTIyNS1MTSIsCiAgICAgICJHVUlEIjogIns3MDBFQzZCNy1DQTU0LTQ4M0MtOTVFMy0wNjk5MDEzNjZCOEF9IiwKICAgICAgIlNwZWVkIjogIjI1MDAwMDAwMDAiCiAgICB9LAogICAgewogICAgICAiaWQiOiAzLAogICAgICAiRGVzY3JpcHRpb24iOiAiSW50ZWwoUikgV2ktRmkgNkUgQVgyMTAgMTYwTUh6IiwKICAgICAgIkdVSUQiOiAiezQ2REMyQ0FCLUY0REMtNDUxOS05RjMxLUZCQjBEQjIyOEU0OX0iLAogICAgICAiU3BlZWQiOiAiNjUwMDAwMDAwIgogICAgfQogIF0KfQ==
```

解码文件

```json
{
  "senderUUID": "74ac5e7a-84c3-4ac7-8166-6acadf71eff3",
  "CreationTime": "2022-04-08T22:31:37.0374849+08:00",
  "global_cpu": true,
  "cpu_error_stop": false,
  "cpu_all_temp": false,
  "cpu_all_fan_speed": false,
  "cpu_detailed_info": false,
  "global_mem": true,
  "mem_error_stop": false,
  "mem_error_address": false,
  "global_disk": true,
  "disk_chkdsk": false,
  "disk_write_test": false,
  "disk_write_type": 0,
  "global_net": true,
  "net_test": true,
  "net_web_test": true,
  "net_mac": true,
  "global_outlet": false,
  "outlet_com": true,
  "outlet_pnp_count": 16,
  "outlet_usb": true,
  "audio_playback": true,
  "audio_adjust_vol": true,
  "audio_max_vol": false,
  "rtc_set_local": false,
  "override_flag": 0,
  "send_wmi_information": false,
  "Processors": [
    {
      "id": 1,
      "Name": "11th Gen Intel(R) Core(TM) i9-11950H @ 2.60GHz",
      "Family": "207",
      "MaxClockSpeed": "2611",
      "Manufacturer": "GenuineIntel",
      "ProcessorId": "BFEBFBFF000806E2"
    }
  ],
  "PhysicalMemorys": [
    {
      "id": 1,
      "Manufacturer": "SK Hynix",
      "PartNumber": "HMAA2GS6CJR8N-XN    ",
      "SerialNumber": "0516DC87",
      "Capacity": "07179869184",
      "Speed": "3200"
    }
  ],
  "VideoControllers": [
    {
      "id": 1,
      "Name": "Intel(R) UHD Graphics",
      "VideoProcessor": "Intel(R) UHD Graphics Family",
      "AdapterCompatibility": "Intel Corporation",
      "AdapterRAM": "1073741824"
    }
  ],
  "Disks": [
    {
      "id": 1,
      "Manufacturer": "(标准磁盘驱动器)",
      "MediaType": "Removable Media",
      "Model": "SDXC card",
      "Size": "128042933760",
      "SerialNumber": "null"
    }
  ],
  "NetworkAdapters": [
    {
      "id": 1,
      "Description": "Microsoft Kernel Debug Network Adapter",
      "GUID": "null",
      "Speed": "null"
    },
    {
      "id": 2,
      "Description": "Intel(R) Ethernet Controller (3) I225-LM",
      "GUID": "{700EC6B7-CA54-483C-95E3-069901366B8A}",
      "Speed": "2500000000"
    },
    {
      "id": 3,
      "Description": "Intel(R) Wi-Fi 6E AX210 160MHz",
      "GUID": "{46DC2CAB-F4DC-4519-9F31-FBB0DB228E49}",
      "Speed": "650000000"
    }
  ]
}
```

### 错误代码说明

服务端和客户端都将按照如下所示的方式报告错误：第一部分将展示错误的具体情况，第二部分为堆栈追溯（如果存在的话），第三部分为错误代码

* 0x00000000

  初始化失败

  * 请检查下述依赖是否完全
  
    ```
      Mode                 LastWriteTime         Length Name
      ----                 -------------         ------ ----
      -a----         2022/4/14     xx:xx           5632 AutoTestMessage.dll
      -a----         2021/4/22     xx:xx          44032 Fleck.dll
      -a----         2021/3/18     xx:xx         701992 Newtonsoft.Json.dll
      -a----         2021/3/18     xx:xx         710224 Newtonsoft.Json.xml
      -a----         2022/4/14     xx:xx          87040 Server.exe
    ```
  
  * 请检查依赖文件是否存在损坏、异常


* 0x80001000

  测试错误：尝试除以零

* 0x8000AE01

  执行`BoardServer()`时发生错误，可能为以下原因之一

  * 非法网卡被添加并试图广播
  * UAC权限丢失
  * 无法从合法信道广播UDP报文
  * 依赖文件缺失

  发生此故障时，请检查您的网络接口的完整性和有效性，确保您的网络适配器可用并正确运行。

* 0x8000AE02

  UDP报文发送失败，可能为以下原因之一

  *  终端IP地址非法（例如为IPv6）
  * 端口6839被占用
  * 此错误可能嵌套发生于0x8000AE01

* 0x8000AE03

  WebSocket侦听失败，可能为以下原因之一

  * 端口2333被占用
  * 系统防火墙限制

* 0x8001EF00

  WMI配置校验出现异常。

* 0x8001EF01

  初始化读取即插即用设备异常

* 0x8002AE00

  生成配置文件失败，可能是以下原因之一：

  * 嵌套0x8001EF00错误
  * Json编码失败
  * UTF8编码失败
  * 文件`configfile.jht`生成失败

* 0x8003001E

  读取配置文件时遇到不可解析的字符或数据，解析文件失败。可能是以下原因之一：

  * 配置文件损坏
  * 读取配置文件时拒绝访问

* 0x8003001F

  存取配置文件失败

### 文件说明

|   文件名称    |                           作用                           |
| :-----------: | :------------------------------------------------------: |
| ConfigFile.cs |             定义配置文件和配置校验的具体内容             |
|  Program.cs   |                应用程序的加载、初始化过程                |
| ServerMain.cs |                      用户界面（UI）                      |
|   Tests.cs    | 定义测试的具体内容、处理客户端消息、定义客户端测试结构体 |
| WebSocket.cs  |                       定义网络内容                       |

## 测试端

此处将详细介绍测试端的使用、开发、调试场景说明

### 前言

* 按照安装程序设定，您需要手动配置UAC项目

* 按照程序设定，您需要手动配置Windows Defender防火墙以允许互联网通信

* (修改于4/17) 由于安全原因，已经禁止测试端自动启动。您需要从桌面启动客户端以便启动测试。

  出于安全原因考虑，您需要手动执行应用程序，而不是从服务器获取应用程序自动执行。

  参见：

  [windows - How to run a process as current user privilege from an admin process - Stack Overflow](https://stackoverflow.com/questions/3939731/how-to-run-a-process-as-current-user-privilege-from-an-admin-process)

  [c# - Visual Studio Installer > How To Launch App at End of Installer - Stack Overflow](https://stackoverflow.com/questions/3168782/visual-studio-installer-how-to-launch-app-at-end-of-installer)

### 可执行应用程序流程

*无特别说明的情况下，所有内容按照顺序阻塞运行*

*异步流程：异步{流程编号}{子异步流程标识}{可选-异步子流程子操作标识}*

* (异步AA)注册UDP服务器，监听端口6839
* 获取服务器UUID、IP
* (异步AB)连接WebSocket
* 加入服务器、注册消息循环
* 解释消息循环
  * 获取消息类型
  * 若为`AutoTestMessage.Message.MessageTypes.TaskResult`，则返回当前完成的任务数+1
  * 若为`AutoTestMessage.Message.MessageTypes.CurrentTask`，则设定当前任务（解包）
* 按需执行测试

### 测试

内存压力、处理器压力测试程序详见后文“独立测试程序”

* RTC校验

  将获取待测机器的系统时间，按照毫秒进行时间戳转换，并发送给服务器。服务器接收后检查时延是否超过**2秒**，若未超过，则通过检测。

  警告：请尽可能保证局域网连接速度合理，以防止传输时延导致测试失败

* USB写入检查

  将执行可移动存储介质的检查，具体将检查其就绪状态

* 串口测试

  ==警告：受限于开发环境，无法对串口检查的代码进行有效性校验==

  将依次打开各个串口，并读写数据。

  您需要在外端外置串口信息读写器，以便进行串口测试

  环回测试由于开发环境限制，无法获知具体解决方案，因此不可行。

  常规错误：“数据不是二维数组”

* 音频接口测试

  将通知音频设备播放声音。您需要手动确认声音的有效性。

* 网络测试

  一旦通讯建立，网络测试自动通过。此测试依赖于通信建立，因此总为真

* SMART测试

  此测试暂不支持
  
* 内存压力测试

  警告：由于32位计算机地址宽度限制，单个程序难以获取超过2GB的内存空间。因此此项目可能会出现异常

  参数说明：

  * 64G保留空间
  * 每个线程将申请512MB
  * 测试时间位6小时
  * 单个线程休眠1分钟

* CPU压力测试

  参数说明：

  *  测试时间6小时

  温度、风扇监视：

  * 要求物理机支持此功能

  * 根据$T_{junction}$和$T_{case}$的上限不同，监测的值不同。

    参见：[Information about Temperature for Intel® Processors](https://www.intel.com/content/www/us/en/support/articles/000005597/processors.html)

* 磁盘读写压力测试

  参数说明

  * 块面积：4KB
  * 8线程，32并发
  * 预热60秒
  * 测试6小时

### 错误代码说明

所有客户端错误都会尝试报告给服务端。对于致命错误，将弹出窗口警告使用者。

* 0x8000AE01

  连接服务器时接收到了错误的JSON消息

* 0x80000E00

  连接服务器产生了WebSocket异常

* 0x80020000

  连接服务器接收数据时产生未知异常。具体位置为接收Socket时故障。

  如果出现问题，请先启动服务端再启动客户端，以排除错误。

  参见：[ClientWebSocket.SendAsync Method (System.Net.WebSockets) | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.net.websockets.clientwebsocket.sendasync?redirectedfrom=MSDN&view=net-6.0#System_Net_WebSockets_ClientWebSocket_SendAsync_System_ArraySegment_System_Byte__System_Net_WebSockets_WebSocketMessageType_System_Boolean_System_Threading_CancellationToken_)

* 0x8001EF00

  读取WMI配置时遇到了某个参数的异常

### 文件说明

|     文件名称     |                   作用                   |
| :--------------: | :--------------------------------------: |
|  ConfigFile.cs   |     定义配置文件和配置校验的具体内容     |
|    Program.cs    |        应用程序的加载、初始化过程        |
|  ServerMain.cs   |              用户界面（UI）              |
|     Tests.cs     | 执行测试、处理外部独立测试程序的程序通讯 |
|   WebSocket.cs   |   定义网络内容、监听UDP网络、建立通讯    |
| UpdateVisitor.cs |        定义温度、风扇监测的接口类        |

## 独立测试程序

受限于C#的严格内存模式等一系列严格的资源调用限制，测试端无法执行有效的测试过程，例如申请、释放内存、CPU等。因此我们开发了一个较为小巧的应用程序，联合开源程序、系统程序一同对计算机的硬件配置执行检查。

### Chkdsk

检查卷的文件系统和文件系统元数据，以查找逻辑错误和物理错误

* 开发者：Microsoft
* 附带：否（系统组件）
* 使用方法：命令行
* 测试端调用逻辑简介
  * 从`Win32_LogicalDisk`中遍历值`DeviceID`，作为参数传递给Chkdsk执行检查

#### 程序运行说明

```
检查磁盘并显示状态报告。
CHKDSK [volume[[path]filename]]] [/F] [/V] [/R] [/X] [/I] [/C] [/L[:size]] [/B] [/scan] [/spotfix]

  volume              指定驱动器号(后面跟一个冒号)、装入点或卷名。
  filename            仅 FAT/FAT32: 指定要检查碎片的文件。
  /F                  修复磁盘上的错误。
  /V                  在 FAT/FAT32 上: 显示磁盘上每个文件的完整路径和名称。在 NTFS 上: 显示清理消息(如果有)。
  /R                  查找坏扇区并恢复可读信息(未指定 /scan 时，隐含 /F)。
  /L:size             仅 NTFS: 将日志文件大小更改为指定的 KB 数。如果未指定大小，则显示当前大小。
  /X                  如果必要，则先强制卸除卷。该卷的所有打开的句柄都将无效 (隐含 /F)。
  /I                  仅 NTFS: 对索引项进行强度较小的检查。
  /C                  仅 NTFS: 跳过文件夹结构内的循环检查。
  /B                  仅 NTFS: 重新评估该卷上的坏簇(隐含 /R)
  /scan               仅 NTFS: 在卷上运行联机扫描
  /forceofflinefix    仅 NTFS: (必须与 "/scan" 一起使用)跳过所有联机修复；找到的所有故障都排队等待脱机修复(即 "chkdsk /spotfix")。
  /perf               仅 NTFS: (必须与 "/scan" 一起使用)使用更多系统资源尽快完成扫描。这可能会对系统中运行的其他任务的性能造成负面影响。
  /spotfix            仅 NTFS: 在卷上运行点修复
  /sdcleanup          仅 NTFS: 回收不需要的安全描述符数据(隐含 /F)。
  /offlinescanandfix  在卷上运行脱机扫描并进行修复。
  /freeorphanedchains 仅 FAT/FAT32/exFAT: 释放所有孤立的簇链而不恢复其内容。
  /markclean          仅 FAT/FAT32/exFAT: 如果未检测到损坏，则将卷标记为干净，即使未指定 /F 也是如此。

/I 或 /C 开关通过跳过对卷的某些检查，
来减少运行 Chkdsk 所需的时间。
```

#### 协议

总是可用

#### 为真判断

将按照Chkdsk的返回值进行数组填充和反馈。

#### 返回值说明

| 退出代码 | 说明                                                         |
| :------- | :----------------------------------------------------------- |
| 0        | 未找到任何错误。                                             |
| 1        | 发现并修复了错误。                                           |
| 2        | 执行磁盘清理 (如垃圾回收) 或未执行清理，因为 **未指定 /f** 。 |
| 3        | 无法检查磁盘、无法修复错误或由于 **未指定 /f** 而未修复错误。 |

#### 参见

[chkdsk | Microsoft Docs](https://docs.microsoft.com/zh-cn/windows-server/administration/windows-commands/chkdsk)

### Diskspd

DiskSpd 是一个高度可定制的 I/O 负载生成工具，可用于针对文件、分区或物理磁盘运行存储性能测试。 DiskSpd 可以生成多种磁盘请求模式，用于分析和诊断存储性能问题，而无需运行完整的端到端工作负载。 您可以模拟 SQL Server I/O 活动或更复杂的不断变化的访问模式，返回详细的 XML 输出以用于自动结果分析。

* 开发者：Microsoft

* 附带：是

* 使用方法：命令行

* 测试端逻辑介绍

  * 按照命令行调用应用程序

    命令行示例：

    ```
    diskspd D:
    ```

#### 程序运行说明

```
version 2.1.0-dev (2021/7/1)

Valid targets:
       file_path
       #<physical drive number>
       <drive_letter>:

Available options:
  -?                    display usage information
  -ag                   group affinity - affinitize threads round-robin to cores in Processor Groups 0 - n.
                          Group 0 is filled before Group 1, and so forth.
                          [default; use -n to disable default affinity]
  -ag#,#[,#,...]>       advanced CPU affinity - affinitize threads round-robin to the CPUs provided. The g# notation
                          specifies Processor Groups for the following CPU core #s. Multiple Processor Groups
                          may be specified, and groups/cores may be repeated. If no group is specified, 0 is assumed.
                          Additional groups/processors may be added, comma separated, or on separate parameters.
                          Examples: -a0,1,2 and -ag0,0,1,2 are equivalent.
                                    -ag0,0,1,2,g1,0,1,2 specifies the first three cores in groups 0 and 1.
                                    -ag0,0,1,2 -ag1,0,1,2 is equivalent.
  -b<size>[KMGT]        block size in bytes or KiB/MiB/GiB/TiB [default=64K]
  -B<offs>[KMGTb]       base target offset in bytes or KiB/MiB/GiB/TiB/blocks [default=0]
                          (offset from the beginning of the file)
  -c<size>[KMGTb]       create files of the given size.
                          Size can be stated in bytes or KiB/MiB/GiB/TiB/blocks
  -C<seconds>           cool down time - duration of the test after measurements finished [default=0s].
  -D<milliseconds>      Capture IOPs statistics in intervals of <milliseconds>; these are per-thread
                          per-target: text output provides IOPs standard deviation, XML provides the full
                          IOPs time series in addition. [default=1000, 1 second].
  -d<seconds>           duration (in seconds) to run test [default=10s]
  -f<size>[KMGTb]       target size - use only the first <size> bytes or KiB/MiB/GiB/TiB/blocks of the file/disk/partition,
                          for example to test only the first sectors of a disk
  -f<rst>               open file with one or more additional access hints
                          r : the FILE_FLAG_RANDOM_ACCESS hint
                          s : the FILE_FLAG_SEQUENTIAL_SCAN hint
                          t : the FILE_ATTRIBUTE_TEMPORARY hint
                          [default: none]
  -F<count>             total number of threads (conflicts with -t)
  -g<value>[i]          throughput per-thread per-target throttled to given value; defaults to bytes per millisecond
                          With the optional i qualifier the value is IOPS of the specified block size (-b).
                          Throughput limits cannot be specified when using completion routines (-x)
                          [default: no limit]
  -h                    deprecated, see -Sh
  -i<count>             number of IOs per burst; see -j [default: inactive]
  -j<milliseconds>      interval in <milliseconds> between issuing IO bursts; see -i [default: inactive]
  -I<priority>          Set IO priority to <priority>. Available values are: 1-very low, 2-low, 3-normal (default)
  -l                    Use large pages for IO buffers
  -L                    measure latency statistics
  -n                    disable default affinity (-a)
  -N<vni>               specify the flush mode for memory mapped I/O
                          v : uses the FlushViewOfFile API
                          n : uses the RtlFlushNonVolatileMemory API
                          i : uses RtlFlushNonVolatileMemory without waiting for the flush to drain
                          [default: none]
  -o<count>             number of outstanding I/O requests per target per thread
                          (1=synchronous I/O, unless more than 1 thread is specified with -F)
                          [default=2]
  -O<count>             number of outstanding I/O requests per thread - for use with -F
                          (1=synchronous I/O)
  -p                    start parallel sequential I/O operations with the same offset
                          (ignored if -r is specified, makes sense only with -o2 or greater)
  -P<count>             enable printing a progress dot after each <count> [default=65536]
                          completed I/O operations, counted separately by each thread
  -r[align[KMGTb]]      random I/O aligned to <align> in bytes/KiB/MiB/GiB/TiB/blocks (overrides -s)
                          [default alignment=block size (-b)]
  -rd<dist>[params]     specify an non-uniform distribution for random IO in the target
                          [default uniformly random]
                           distributions: pct, abs
                           all:  IO% and %Target/Size are cumulative. If the sum of IO% is less than 100% the
                                 remainder is applied to the remainder of the target. An IO% of 0 indicates a gap -
                                 no IO will be issued to that range of the target.
                           pct : parameter is a combination of IO%/%Target separated by : (colon)
                                 Example: -rdpct90/10:0/10:5/20 specifies 90% of IO in 10% of the target, no IO
                                   next 10%, 5% IO in the next 20% and the remaining 5% of IO in the last 60%
                           abs : parameter is a combination of IO/Target Size separated by : (colon)
                                 If the actual target size is smaller than the distribution, the relative values of IO%
                                 for the valid elements define the effective distribution.
                                 Example: -rdabs90/10G:0/10G:5/20G specifies 90% of IO in 10GiB of the target, no IO
                                   next 10GiB, 5% IO in the next 20GiB and the remaining 5% of IO in the remaining
                                   capacity of the target. If the target is only 20G, the distribution truncates at
                                   90/10G:0:10G and all IO is directed to the first 10G (equivalent to -f10G).
  -rs<percentage>       percentage of requests which should be issued randomly. When used, -r may be used to
                          specify IO alignment (applies to both the random and sequential portions of the load).
                          Sequential IO runs will be homogeneous if a mixed ratio is specified (-w), and run
                          lengths will follow a geometric distribution based on the percentage split.
  -R[p]<text|xml>       output format. With the p prefix, the input profile (command line or XML) is validated and
                          re-output in the specified format without running load, useful for checking or building
                          complex profiles.
                          [default: text]
  -s[i][align[KMGTb]]   stride size of <align> in bytes/KiB/MiB/GiB/TiB/blocks, alignment/offset between operations
                          [default=non-interlocked, default alignment=block size (-b)]
                          By default threads track independent sequential IO offsets starting at offset 0 of the target.                          With multiple threads this results in threads overlapping their IOs - see -T to divide
                          them into multiple separate sequential streams on the target.
                          With the optional i qualifier (-si) threads interlock on a shared sequential offset.
                          Interlocked operations may introduce overhead but make it possible to issue a single
                          sequential stream to a target which responds faster than a one thread can drive.
                          (ignored if -r specified, -si conflicts with -p, -rs and -T)
  -S[bhmruw]            control caching behavior [default: caching is enabled, no writethrough]
                          non-conflicting flags may be combined in any order; ex: -Sbw, -Suw, -Swu
  -S                    equivalent to -Su
  -Sb                   enable caching (default, explicitly stated)
  -Sh                   equivalent -Suw
  -Sm                   enable memory mapped I/O
  -Su                   disable software caching, equivalent to FILE_FLAG_NO_BUFFERING
  -Sr                   disable local caching, with remote sw caching enabled; only valid for remote filesystems
  -Sw                   enable writethrough (no hardware write caching), equivalent to FILE_FLAG_WRITE_THROUGH or
                          non-temporal writes for memory mapped I/O (-Sm)
  -t<count>             number of threads per target (conflicts with -F)
  -T<offs>[KMGTb]       starting stride between I/O operations performed on the same target by different threads
                          [default=0] (starting offset = base file offset + (thread number * <offs>)
                          only applies with #threads > 1
  -v                    verbose mode
  -w<percentage>        percentage of write requests (-w and -w0 are equivalent and result in a read-only workload).
                        absence of this switch indicates 100% reads
                          IMPORTANT: a write test will destroy existing data without a warning
  -W<seconds>           warm up time - duration of the test before measurements start [default=5s]
  -x                    use completion routines instead of I/O Completion Ports
  -X<filepath>          use an XML file to configure the workload. Combine with -R, -v and -z to override profile defaults.
                          Targets can be defined in XML profiles as template paths of the form *<integer> (*1, *2, ...).                          When run, specify the paths to substitute for the template paths in order on the command line.                          The first specified target is *1, second is *2, and so on.
                          Example: diskspd -Xprof.xml first.bin second.bin (prof.xml using *1 and *2)
  -z[seed]              set random seed [with no -z, seed=0; with plain -z, seed is based on system run time]

Write buffers:
  -Z                    zero buffers used for write tests
  -Zr                   per IO random buffers used for write tests - this incurrs additional run-time
                         overhead to create random content and shouln't be compared to results run
                         without -Zr
  -Z<size>[KMGb]        use a <size> buffer filled with random data as a source for write operations.
  -Z<size>[KMGb],<file> use a <size> buffer filled with data from <file> as a source for write operations.

  By default, the write buffers are filled with a repeating pattern (0, 1, 2, ..., 255, 0, 1, ...)

Synchronization:
  -ys<eventname>     signals event <eventname> before starting the actual run (no warmup)
                       (creates a notification event if <eventname> does not exist)
  -yf<eventname>     signals event <eventname> after the actual run finishes (no cooldown)
                       (creates a notification event if <eventname> does not exist)
  -yr<eventname>     waits on event <eventname> before starting the run (including warmup)
                       (creates a notification event if <eventname> does not exist)
  -yp<eventname>     stops the run when event <eventname> is set; CTRL+C is bound to this event
                       (creates a notification event if <eventname> does not exist)
  -ye<eventname>     sets event <eventname> and quits

Event Tracing:
  -e<q|c|s>             Use query perf timer (qpc), cycle count, or system timer respectively.
                          [default = q, query perf timer (qpc)]
  -ep                   use paged memory for the NT Kernel Logger [default=non-paged memory]
  -ePROCESS             process start & end
  -eTHREAD              thread start & end
  -eIMAGE_LOAD          image load
  -eDISK_IO             physical disk IO
  -eMEMORY_PAGE_FAULTS  all page faults
  -eMEMORY_HARD_FAULTS  hard faults only
  -eNETWORK             TCP/IP, UDP/IP send & receive
  -eREGISTRY            registry calls


Examples:

Create 8192KB file and run read test on it for 1 second:

  D:\Projects\x86Tester\WinUI\Client\bin\Debug\diskspd.exe -c8192K -d1 testfile.dat

Set block size to 4KB, create 2 threads per file, 32 overlapped (outstanding)
I/O operations per thread, disable all caching mechanisms and run block-aligned random
access read test lasting 10 seconds:

  D:\Projects\x86Tester\WinUI\Client\bin\Debug\diskspd.exe -b4K -t2 -r -o32 -d10 -Sh testfile.dat

Create two 1GB files, set block size to 4KB, create 2 threads per file, affinitize threads
to CPUs 0 and 1 (each file will have threads affinitized to both CPUs) and run read test
lasting 10 seconds:

  D:\Projects\x86Tester\WinUI\Client\bin\Debug\diskspd.exe -c1G -b4K -t2 -d10 -a0,1 testfile1.dat testfile2.dat
```

#### 协议

[MIT Lincence](https://github.com/microsoft/diskspd/blob/master/LICENSE)

#### 为真判断

成功运行程序直至测试结束即为真

#### 参见

[microsoft/diskspd: DISKSPD is a storage load generator / performance test tool from the Windows/Windows Server and Cloud Server Infrastructure Engineering teams (github.com)](https://github.com/microsoft/diskspd)

### Tester

用于执行CPU压力测试、内存压力测试。

* 开发者：自研
* 附带：是
* 使用方法：命令行
* 测试端逻辑介绍：
  * 判断返回值

#### 程序运行说明

```
x86自动测试软件 命令行测试实例工具
此工具默认配置与自动测试套件一同运行，不应该手动运行
=================

对计算机硬件进行一系列压力测试、调用外部软件对计算机硬件进行测试

Tester -operator [opn] <-output> args

-operator       指定测试对象
-output 打开回显
        当前可选对象：cpuTest, memoryTest
         cpuTest: 对计算机中央处理器执行压力测试
         memoryTest：对计算机内存执行压力测试。警告：此测试对于32位计算机可能无效。您可以进行多程序同时运行检查整个内存结构和完整性
args    测试对象所需要的参数
        cpuTest:
         -totalTime     指定执行测试的总时长
         -thread        指定执行测试的线程数，指定为 auto 可自动分配
        memoryTest:
         -reservedMemory        内存测试的总预留内存
         -memoryPerThread       各线程申请的内存，单位为字节
         -sleepTime     各线程保留的时间，超过此时间将释放内存。建议设置等于totalTime
         -totalTime     指定执行测试的总时长
```

命令行示例：

```
start Tester.exe -operator memoyTest -reservedMemory 64000 -memoryPerThread 102400000 -sleepTime 60 -totalTime 60000
```

此命令行将启动内存压力测试，时长为1分钟

```
for /L %i in (1,1,16) do (start Tester.exe -operator memoyTest -reservedMemory 64000 -memoryPerThread 102400000 -sleepTime 60 -totalTime 60000)
```

**此命令行将执行16个孤立的子进程，用于在x86计算机上执行大于4GB的内存测试**

#### 为真判断

将判断返回值

#### 返回值说明

| 退出代码 | 退出代码标识      | 含义                                           |
| -------- | ----------------- | ---------------------------------------------- |
| -2       | FAIL_PASS_TEST    | 测试失败                                       |
| -1       | ARGS_ERROR        | 参数错误                                       |
| 0        | SUCCESS           | 测试成功                                       |
| 其他     | INVALID_EXIT_CODE | 程序以一种不期许的方式退出，给出了错误的返回值 |

#### 可能出现的异常

尽管本程序在编译过程中已经取消了MSVC依赖，但是仍然可能存在如下故障：

* MSVCRUNTIME.DLL没有被指定在 Windows上运行,或者它包含错误。请尝试使用原始安装媒体重新安装程序,或联系您的系统管理员或软件供应商以获取支持。

  请进入安装文件夹:`C:\Program Files\HEU\x86atsc\`删除以下文件：

  * MSVCP140.dll
  * vcruntime140.dll

## AutoTestMessage

AutoTestMessage是简单公有消息动态链接库，用于在两个应用程序间交流相同的代码消息规范。

## 关于

文档更新时间：2022/4/17

## 开发者名录和致谢（排名不分先后）

* 网络工程、压力测试、多线程处理、WMI配置获取：[姜海天](https://github.com/jht3QAQ)

* 用户界面、WMI配置获取、配置校验、文件：[高志睿](https://github.com/Holit)

* 用户界面、资源文件：[王梓旭](https://github.com/Aharrypotter)

* 文档编纂、测试工程：[张皓禹](https://github.com/Hollowwworld)、[吴家驹](https://github.com/wujiaju250)
