using System;
using System.Collections.Generic;
using System.ComponentModel;
public class ConfigFile
{

    public string senderUUID;
    public DateTime CreationTime;

    public bool global_cpu;
    public bool cpu_error_stop;
    public bool cpu_all_temp;
    public bool cpu_all_fan_speed;
    public bool cpu_detailed_info;

    public bool global_mem;
    public bool mem_error_stop;
    public bool mem_error_address;

    public bool global_disk;
    public bool disk_chkdsk;
    public bool disk_write_test;
    /// <summary>
    /// 指定写入数据类型
    /// 0 : 碎片文件
    /// 1 : <4GB FAT文件系统
    /// 2 : >4GB NTFS文件系统
    /// 备注：暂不支持1，2选项
    /// </summary>
    public int disk_write_type;
    

    public bool global_net;
    public bool net_test;
    /// <summary>
    /// 指定是否执行外网测试
    /// 暂不支持外网访问测试（安全限制）
    /// </summary>
    public bool net_web_test;
    public bool net_mac;

    public bool global_outlet;
    public bool outlet_com;
    public int outlet_pnp_count;
    public bool outlet_usb;
    public bool audio_playback;
    public bool audio_adjust_vol;
    public bool audio_max_vol;

    public bool rtc_test;
    /// <summary>
    /// 设定覆盖测试（自定义测试）
    /// 按照索引顺序
    /// </summary>
    [Flags]
    public enum OVERRIDE_FLAG
    {
        None = 0b_0000_0000,    // 0
        Processor = 0b_0000_0001,     // 1
        PhysicalMemory = 0b_0000_0010,  // 2
        VideoController = 0b_0000_0100,     // 4
        Disk = 0b_0000_1000,    // 8
        NetworkAdapter = 0b_0001_0000,  // 16
        All = Processor | PhysicalMemory | VideoController | Disk | NetworkAdapter // 31
    }
    public OVERRIDE_FLAG override_flag;
    public bool send_wmi_information;

    #region Verify configs
    //Win32_Processor
    public class Processor
    {
        public int id;
        [Category("基本信息"), Description("处理器的名称\n该值来自 SMBIOS 信息中 Processor Information 结构的 Processor Version 成员。"), ReadOnly(false)]
        public string Name { get; set; }
        [Category("基本信息"), Description("处理器系列\n请查看https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor获取更多信息"), ReadOnly(false)]
        public string Family { get; set; }
        [Category("基本信息"), Description("处理器最大时钟频率，单位为MHz"), ReadOnly(false)]
        public string MaxClockSpeed { get; set; }
        [Category("基本信息"), Description("处理器制造商的名称\n示例: GenuineIntel"), ReadOnly(false)]
        public string Manufacturer { get; set; }
        [Category("基本信息"), Description("描述处理器功能的处理器信息\n对于 32位处理器，字段取决于 CPUID 指令的处理器支持\n" +
            "如果支持该指令，则该属性包含 2 (两个) DWORD 格式的值。" +
            "第一个是偏移量 08h-0Bh，这是 CPUID 指令在输入 EAX 设置为 1 时返回的 EAX 值。" +
            "第二个是偏移量 0Ch-0Fh，这是指令返回的 EDX 值。 " +
            "只有属性的前两个字节是有效的，并且包含 CPU 复位时 DX 寄存器的内容——所有其他字节都设置为 0（零），并且内容为 DWORD 格式。"), ReadOnly(false)]
        public string ProcessorId { get; set; }
    }
    public List<Processor> Processors = new List<Processor>();
    //Win32_PhysicalMemory
    public class PhysicalMemory
    {
        public int id;
        [Category("基本信息"), Description("内存设备的名称.\n示例: SK Hynix"), ReadOnly(false)]
        public string Manufacturer { get; set; }
        [Category("设备唯一性标识"), Description("设备序列号，由负责生产或制造设备的制造商分配的设备编号。"), ReadOnly(false)]
        public string PartNumber { get; set; }
        [Category("设备唯一性标识"), Description("设备SN代码，制造商分配的编号，用于标识特定设备"), ReadOnly(false)]
        public string SerialNumber { get; set; }
        [Category("性能"), Description("物理内存的总容量，以字节为单位。"), ReadOnly(false)]
        public string Capacity { get; set; }
        [Category("性能"), Description("物理内存的速度，以纳秒(ns)为单位。"), ReadOnly(false)]
        public string Speed { get; set; }
    }
    public List<PhysicalMemory> PhysicalMemorys = new List<PhysicalMemory>();

    //Win32_VideoController
    public class VideoController
    {
        public int id;
        [Category("基本信息"), Description("显示适配器名称\n示例：NVIDIA GeForce RTX 3080 Laptop GPU"), ReadOnly(false)]
        public string Name { get; set; }
        [Category("基本信息"), Description("描述图像处理器的自由字符串"), ReadOnly(false)]
        public string VideoProcessor { get; set; }
        [Category("基本信息"), Description("该控制器的通用芯片组，用于比较与系统的兼容性"), ReadOnly(false)]
        public string AdapterCompatibility { get; set; }
        [Category("基本信息"), Description("视频适配器的内存大小"), ReadOnly(false)]
        public string AdapterRAM { get; set; }
    }
    public List<VideoController> VideoControllers = new List<VideoController>();

    public class Disk
    {
        public int id;
        [Category("基本信息"), Description("驱动器名称.\n示例: (标准磁盘驱动器)"), ReadOnly(false)]
        public string Manufacturer { get; set; }
        [Category("基本信息"), Description("此设备使用或访问的媒体类型。\n为以下四种值之一\n\nExternal hard disk media\nRemovable media\nFixed hard disk\nUnknown"), ReadOnly(false)]
        public string MediaType { get; set; }
        [Category("基本信息"), Description("磁盘驱动器的制造商型号\n示例：ST32171W"), ReadOnly(false)]
        public string Model { get; set; }
        [Category("基本信息"), Description("磁盘驱动器的大小。它是通过将柱面总数、每个柱面中的磁道、每个磁道中的扇区以及每个扇区中的字节数相乘来计算的。"), ReadOnly(false)]
        public string Size { get; set; }
        [Category("设备唯一性标识"), Description("设备SN代码，制造商分配的编号，用于标识特定设备"), ReadOnly(false)]
        public string SerialNumber { get; set; }
    }
    public List<Disk> Disks = new List<Disk>();

    public class NetworkAdapter
    {
        public int id;
        [Category("基本信息"), Description("设备描述"), ReadOnly(false)]
        public string Description { get; set; }
        [Category("基本信息"), Description("连接的全局唯一标识符。"), ReadOnly(false)]
        public string GUID { get; set; }
        [Category("基本信息"), Description("适配器速度\n以比特/秒为单位估计当前带宽。 对于带宽变化的端点或无法进行准确估计的端点，此属性应包含标称带宽。"), ReadOnly(false)]
        public string Speed { get; set; }
    }
    public List<NetworkAdapter> NetworkAdapters = new List<NetworkAdapter>();

    public ConfigFile()
    {
        global_cpu = true;
        cpu_error_stop = false;
        cpu_all_fan_speed = false;
        cpu_all_temp = false;
        cpu_detailed_info = false;

        global_mem = true;
        mem_error_address = false;
        mem_error_stop = false;

        global_disk = true;
        disk_chkdsk = true;
        disk_write_test = true;

        disk_write_type = 0;

        global_net = true;
        net_mac = true;
        net_test = true;
        net_web_test = false;

        global_outlet = true;
        outlet_com = true;
        outlet_usb = true;
        outlet_pnp_count = 4;

        audio_playback = true;
        audio_adjust_vol = false;
        audio_max_vol = false;

        rtc_test = true;
        override_flag = OVERRIDE_FLAG.None;
    }
    #endregion
}