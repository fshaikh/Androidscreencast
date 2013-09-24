using com.android.ddmlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaInterop
{
    public class Application
    {
        private static AutoEvent _autoEvent;
        private static DeviceManager _deviceManager;

        static Application()
        {
            _autoEvent = AutoEvent.Instance;
            _deviceManager = new DeviceManager();
            
        }

        public static bool Init()
        {
            AndroidDebugBridge.init(false);
            AndroidDebugBridge.addDeviceChangeListener(Application.DeviceManager);

            var bridge = AndroidDebugBridge.createBridge();
            System.Threading.Thread.Sleep(2000);
            if (!bridge.isConnected())
            {
                return false;
            }
            return true;
        }

        public static AutoEvent AutoEvent
        {
            get
            {
                return _autoEvent;
            }
        }

        public static DeviceManager DeviceManager
        {
            get
            {
                return _deviceManager;
            }
        }

    }
}
