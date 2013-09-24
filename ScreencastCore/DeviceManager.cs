using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.android.ddmlib;
using java.awt.image;
using java.io;
using javax.imageio;

namespace JavaInterop
{
    public class DeviceManager:com.android.ddmlib.AndroidDebugBridge.IDeviceChangeListener
    {
        private IDevice _device = null;
        public void deviceChanged(IDevice id, int i)
        {
            
        }

        public void deviceConnected(IDevice device)
        {
            java.lang.System.@out.println("Device: " + device.getSerialNumber());
            java.lang.System.@out.println("Device State: " + device.getState().name());
            _device = device;

            Application.AutoEvent.Signal();
        }

        public void deviceDisconnected(IDevice id)
        {
            
        }

        public IDevice GetDevice()
        {
            return _device;
        }
    }
}
