// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;
using PowerPiLib;

namespace PowerPiApp
{
    public sealed class StartupTask : IBackgroundTask
    {
        BackgroundTaskDeferral deferral;
        private ThreadPoolTimer timer;
        private GpioHelper ioHelper;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferral = taskInstance.GetDeferral();
            ioHelper = new GpioHelper();
            timer = ThreadPoolTimer.CreatePeriodicTimer(Timer_Tick, TimeSpan.FromMilliseconds(500));
            
        }

        private void Timer_Tick(ThreadPoolTimer timer)
        {
            ioHelper.Pin = (ioHelper.Pin == GpioValue.High) ? GpioValue.Low : GpioValue.High;
        }
    }
}
