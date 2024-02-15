using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaCS
{
    public sealed class VolumeDevice : Device
    {
        private float nivel;
        public override float Nivel 
        { get => nivel = VolumeControl.GetSystemVolume(VolumeControl.VolumeUnit.Scalar) * 255;

          set { nivel = value; 
                VolumeControl.SetSystemVolume(value / 255, VolumeControl.VolumeUnit.Scalar); }
        }

        public VolumeDevice(string deviceName, byte deviceNumber) :
            base(deviceName, deviceNumber)
        {
        }

        public override string GetDeviceJson()
        {
            return GetResponseHeader("{\r\n\"type\": \"Extended color light\",\r\n\"name\":\"" + this.deviceName + "\",\r\n\"uniqueid\": \"" + this.uniqueId + "\",\r\n\"modelid\": \"LCT015\",\r\n\"manufacturername\": \"Philips\",\r\n\"productname\": \"E4\",\r\n\"state\": {\r\n\"bri\": " + Math.Round(this.Nivel) + ",\r\n\"mode\": \"homeautomation\",\r\n\"reachable\": true\r\n},\r\n\"capabilities\": {\r\n\"certified\": false,\r\n\"streaming\": {\r\n\"renderer\": true,\r\n\"proxy\": false\r\n}\r\n},\r\n\"swversion\": \"5.105.0.21169\"\r\n}", "application/json");
        }

        public override string GetLight()
        {
            return GetResponseHeader("{\r\n\"1\": {\r\n\"type\": \"Extended color light\",\r\n\"name\": \"" + this.deviceName + "\",\r\n\"uniqueid\": \"" + this.uniqueId + "\"\r\n}\r\n}", "application/json");
        }

        public override string GetState()
        {
            return GetResponseHeader("[{\"success\":{\"/lights/" + this.deviceNumber + "/state/bri\":" + Math.Round(this.Nivel) + "} }]", "application/json");
        }



    }
}
