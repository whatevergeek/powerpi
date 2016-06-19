using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace PowerPiLib
{
    public enum GpioValue
    {
        High,
        Low
    };

    public class GpioHelper
    {
        private const int LED_PIN = 5;
        private GpioPin pin;

        public GpioHelper()
        {
            InitGPIO();
        }

        public GpioValue Pin
        {
            get
            {
                return (pin.Read() == GpioPinValue.High) ? GpioValue.High : GpioValue.Low;
            }

            set
            {
                pin.Write((value == GpioValue.High) ? GpioPinValue.High : GpioPinValue.Low);
            }
        }

        private void InitGPIO()
        {
            pin = GpioController.GetDefault().OpenPin(LED_PIN);
            pin.Write(GpioPinValue.Low);
            pin.SetDriveMode(GpioPinDriveMode.Output);
        }


    }
}
