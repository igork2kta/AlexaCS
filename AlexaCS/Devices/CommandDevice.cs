using System.Diagnostics;

namespace AlexaCS
{
    public sealed class CommandDevice : Device
    {
        readonly ProcessStartInfo command;
        private bool state;

        public override bool State
        {
            get => state;
            set { state = value; ExecuteState(); }
        }

        public CommandDevice(string deviceName, byte deviceNumber, ProcessStartInfo command):
            base(deviceName, deviceNumber)
        {
            this.command = command;
        }

        public void ExecuteState()
        {
            Process.Start(command);
        }

        public override string GetDeviceJson()
        {
            return GetResponseHeader("{\r\n\"type\": \"Extended color light\",\r\n\"name\":\"" + this.deviceName + "\",\r\n\"uniqueid\": \"" + this.uniqueId + "\",\r\n\"modelid\": \"LCT015\",\r\n\"manufacturername\": \"Philips\",\r\n\"productname\": \"E4\",\r\n\"state\": {\r\n\"on\": " + State.ToString().ToLower() + ",\"mode\": \"homeautomation\",\r\n\"reachable\": true\r\n},\r\n\"capabilities\": {\r\n\"certified\": false,\r\n\"streaming\": {\r\n\"renderer\": true,\r\n\"proxy\": false\r\n}\r\n},\r\n\"swversion\": \"5.105.0.21169\"\r\n}", "application/json");
        }

        public override string GetLight()
        {
            return GetResponseHeader("{\r\n\"1\": {\r\n\"type\": \"Extended color light\",\r\n\"name\": \"" + this.deviceName + "\",\r\n\"uniqueid\": \"" + this.uniqueId + "\"\r\n}\r\n}","application/json");
        }

        public override string GetState()
        {
            return GetResponseHeader("[{\"success\":{\"/lights/" + this.deviceNumber + "/state/on\":" + this.State.ToString().ToLower() + "}}]", "application/json");

        }
    }
}
