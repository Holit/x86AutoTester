using OpenHardwareMonitor.Hardware;

namespace Client
{
    //这个类是调用OpenHardwareMonitor专用的，不要修改。

    /// <summary>
    /// OpenHardwareMonitor应用程序IVisitor专用接口
    /// </summary>
    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware)
                subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }
}
