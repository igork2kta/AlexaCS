using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;

namespace FauxmoCS
{
    public sealed class KeyDevice : Device
    {
        readonly VirtualKeyCode key;
        readonly VirtualKeyCode key2;
        readonly VirtualKeyCode key3;
        private bool state;
        readonly InputSimulator keyboard = new();
        
        public override bool State
        {
            get => state;
            set { state = value; ExecuteState(); }
        }

        public KeyDevice(string deviceName, byte deviceNumber, VirtualKeyCode key, VirtualKeyCode key2, VirtualKeyCode key3) :
            base(deviceName, deviceNumber)
        {
            this.key = key;
            this.key2 = key2;
            this.key3 = key3;
        }

        public void ExecuteState()
        {
            ; keyboard.Keyboard.KeyDown(key);
            if (key2 != null) keyboard.Keyboard.KeyDown(key2);
            if (key3 != null) keyboard.Keyboard.KeyDown(key3);

            if (key3 != null) keyboard.Keyboard.KeyUp(key3);
            if (key2 != null) keyboard.Keyboard.KeyUp(key2);
            keyboard.Keyboard.KeyUp(key);
            
        }

        public override string GetDeviceJson()
        {
            return GetResponseHeader("{\r\n\"type\": \"Extended color light\",\r\n\"name\":\"" + this.deviceName + "\",\r\n\"uniqueid\": \"" + this.uniqueId + "\",\r\n\"modelid\": \"LCT015\",\r\n\"manufacturername\": \"Philips\",\r\n\"productname\": \"E4\",\r\n\"state\": {\r\n\"on\": " + State.ToString().ToLower() + ",\"mode\": \"homeautomation\",\r\n\"reachable\": true\r\n},\r\n\"capabilities\": {\r\n\"certified\": false,\r\n\"streaming\": {\r\n\"renderer\": true,\r\n\"proxy\": false\r\n}\r\n},\r\n\"swversion\": \"5.105.0.21169\"\r\n}", "application/json");
        }

        public override string GetLight()
        {
            return GetResponseHeader("{\r\n\"1\": {\r\n\"type\": \"Extended color light\",\r\n\"name\": \"" + this.deviceName + "\",\r\n\"uniqueid\": \"" + this.uniqueId + "\"\r\n}\r\n}", "application/json");
        }

        public override string GetState()
        {
            return GetResponseHeader("[{\"success\":{\"/lights/" + this.deviceNumber + "/state/on\":" + this.State.ToString().ToLower() + "}}]", "application/json");

        }


    }
}
