using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JavaInterop
{
    public class AutoEvent
    {
        private AutoResetEvent _event = null;
        private static AutoEvent _instance = null;

        private AutoEvent()
        {
            _event = new AutoResetEvent(false);
        }

        public static AutoEvent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AutoEvent();
                }
                return _instance;
            }
        }

        public void Wait()
        {
            _event.WaitOne();
        }

        public void Signal()
        {
            _event.Set();
        }
    }
}
