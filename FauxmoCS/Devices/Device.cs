using System.Net.NetworkInformation;
using System.Text;

namespace FauxmoCS
{
    public abstract class Device
    {
        public readonly string deviceName;
        public readonly string uniqueId;
        public byte deviceNumber;
        public virtual bool State { get; set; } 
        public virtual float Nivel { get; set; }

        readonly public static byte[] deviceType =Encoding.UTF8.GetBytes(GetResponseHeader("[{\"success\":{\"username\": \"2WLEDHardQrI3WHYTHoMcXHgEspsM8ZZRpSKtBQr\"}}]", "application/json"));

        public Device(string deviceName, byte deviceNumber)
        {
            this.deviceName = deviceName;
            this.deviceNumber = deviceNumber;
            uniqueId = GerarUniqueId(deviceNumber);
        }

        private static string GerarUniqueId(int number)
        {
            string? id =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();

            if (id == null) throw new Exception("Falha ao obter endereço MAC para gerar OS unique ID's");

            //Insere : a cada par de caracteres do MAC (Obrigatório)
            for (int i = 2; i < id.Length; i += 3)
                id = id.Insert(i, ":");

            id += ":00:00-" + number.ToString("00");
            return id;
        }
        public static string GetResponseHeader(string response, string contentType)
        {
            string header = "HTTP/1.1 200 OK\r\n" +
                            $"Content-Type: {contentType}\r\n" +
                            $"Content-Length: {response.Length}\r\n"+
                            "Connection: close\r\n\r\n";

            return header + response;
        }

        public abstract string GetDeviceJson();
        public abstract string GetLight();
        public abstract string GetState();

    }
}
