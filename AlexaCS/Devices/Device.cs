using System.Net.NetworkInformation;
using System.Text;

namespace AlexaCS
{
    public abstract class Device
    {
        public readonly string deviceName;
        public readonly string uniqueId;
        public readonly string usuario;
        public byte deviceNumber;
        public virtual bool State { get; set; } 
        public virtual float Nivel { get; set; }

        public static byte[] deviceType;
        //readonly public static byte[] deviceType =Encoding.UTF8.GetBytes(GetResponseHeader("[{\"success\":{\"username\": \"2WLEDHardQrI3WHYTHoMcXHgEspsM8ZZRpSKtBQr\"}}]", "application/json").Replace("2WLEDHardQrI3WHYTHoMcXHgEspsM8ZZRpSKtBQr", usuario));

        public Device(string deviceName, byte deviceNumber)
        {
            this.deviceName = deviceName;
            this.deviceNumber = deviceNumber;
            uniqueId = GerarUniqueId(deviceNumber);
            usuario = GerarUsuario(deviceNumber);
            deviceType = GerarDeviceType(usuario);
        }

        private static string GerarUsuario(int deviceNumber)
        {
            return "2WLEDHardQrI3WHYTHoMcXHgEspsM8ZZRpSKtBQr" + deviceNumber;
        }
        private static byte[] GerarDeviceType(string usuario)
        {
            
            return Encoding.UTF8.GetBytes( GetResponseHeader($"[{{\"success\":{{\"username\": \"{usuario}\"}}}}]", "application/json"));

        }

        private static string GerarUniqueId(int deviceNumber)
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

            id += ":00:00-" + deviceNumber.ToString("00");
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

        public static string GetDescriptionXml(string ip)
        {
            string descriptionXml =
@$"<?xml version=""1.0"" ?>
<root xmlns=""urn:schemas-upnp-org:device-1-0"">
<specVersion><major>1</major><minor>0</minor></specVersion>
<URLBase>http://{ip}:80/</URLBase> 
<device>
<deviceType>urn:schemas-upnp-org:device:Basic:1</deviceType> 
<friendlyName>FauxmoC#</friendlyName> 
<manufacturer>Royal Philips Electronics</manufacturer>
<manufacturerURL>http://www.philips.com</manufacturerURL> 
<modelDescription>Philips hue Personal Wireless Lighting</modelDescription>
<modelName>Philips hue bridge 2012</modelName>
<modelNumber>929000226503</modelNumber>
<modelURL>http://www.meethue.com</modelURL>
<serialNumber>e8db84962384</serialNumber>
<UDN>uuid:Socket-1_0-88183111109321</UDN>
<presentationURL>index.html</presentationURL>
</device>
</root>";
            string header = "HTTP/1.1 200 OK\r\n" +
                           $"Content-Type: text/xml\r\n" +
                           $"Content-Length: {descriptionXml.Length}\r\n" +
                           "Connection: close\r\n\r\n" + descriptionXml;

            return header;
        }

        public abstract string GetDeviceJson();
        public abstract string GetLight();
        public abstract string GetState();

    }
}
