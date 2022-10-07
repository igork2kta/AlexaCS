using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FauxmoCS
{
    public sealed class TCPListener
    {
        //readonly List<Device> deviceList;
        readonly Device[] deviceList;
        readonly byte[] lightsJson;
        readonly string localIp;
        const string nomeArquivoLog = "logTcp-";
        TcpListener listener;
        /*
        public TCPListener(ref List<Device> deviceList, string localIp)
        {
            this.deviceList = deviceList;
            lightsJson = GetLightsJson();
            this.localIp = localIp;
        }
        */

        public TCPListener(ref Device[] deviceList, string localIp)
        {
            this.deviceList = deviceList;
            this.localIp = localIp;
            lightsJson = GetLightsJson();
        }
        
        public void Stop() => listener.Stop();
        

        public void Run(CancellationToken ct)
        {
            Byte[] bytes = new Byte[256];
            string data;
            
            GravaLog.Gravar("Iniciando TCP listener...", nomeArquivoLog);

            listener = new(IPAddress.Any, 80);
            listener.Start();
            
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    GravaLog.Gravar("Parando TCP listener...", nomeArquivoLog);
                    listener.Stop();
                    ct.ThrowIfCancellationRequested();
                }

                try
                {
                    NetworkStream stream = listener.AcceptTcpClient().GetStream();
                    GravaLog.Gravar("Conexão aceita.", nomeArquivoLog);

                    byte currentLight = 0;
                    int i;
                    data = "";
                    
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        try
                        {
                            data = Encoding.ASCII.GetString(bytes, 0, i).ToUpper();
                            GravaLog.Gravar(data, nomeArquivoLog);

                            if (String.Equals(data[..3], "GET"))
                            {
                                //Responds to description.xml request
                                if (String.Equals(data.Substring(5, 15), "DESCRIPTION.XML"))
                                {
                                    stream.Write(Encoding.UTF8.GetBytes(GetDescriptionXml()));
                                    continue;
                                }

                                //Responds to single light state request
                                int lightIndex = data.IndexOf("LIGHTS/");

                                if (lightIndex > -1)
                                {
                                    if (!byte.TryParse(data.AsSpan(lightIndex + 7, 2), out currentLight))
                                        _ = byte.TryParse(data.AsSpan(lightIndex + 7, 1), out currentLight);
                                    
                                    if (currentLight < 1) continue;
                                    else currentLight--;    //Subtrai 1 para que seja usado para chamar a instância do dispositivo que começa em 0

                                    stream.Write(Encoding.UTF8.GetBytes(deviceList[currentLight].GetDeviceJson()));
                                    continue;
                                }

                                //Responds to all lights request
                                else if (data.Contains("LIGHTS"))
                                {
                                    stream.Write(lightsJson, 0, lightsJson.Length);
                                    continue;
                                }

                            }

                            //Responds to devicetype request
                            else if (String.Equals(data[..4], "POST"))
                            {
                                if (data.Contains("DEVICETYPE"))
                                {
                                    stream.Write(Device.deviceType);
                                    continue;
                                }
                            }

                            else if (String.Equals(data[..3], "PUT"))
                            {
                                if (data.Contains("STATE"))
                                {
                                    int lightIndex = data.IndexOf("LIGHTS/");

                                    if (lightIndex > -1)
                                    {
                                        if (!byte.TryParse(data.AsSpan(lightIndex + 7, 2), out currentLight))
                                            _ = byte.TryParse(data.AsSpan(lightIndex + 7, 1), out currentLight);
                                        
                                        if (currentLight < 1) continue;
                                        else currentLight--;    //Subtrai 1 para que seja usado para chamar a isntância do dispositivo que começa em 0
                                        
                                        if (data.Contains("TRUE")) Task.Run(() => deviceList[currentLight].State = true);
                                        else Task.Run(() => deviceList[currentLight].State = false);
                                        
                                        /*
                                        if (data.Contains("TRUE")) Task.Run(() => deviceList[currentLight].State = true);
                                        else Task.Run(() => deviceList[currentLight].State = false);
                                        */
                                    }

                                    int briIndex = data.IndexOf("\"BRI\":");

                                    if (briIndex > 0)
                                    {
                                        if (!float.TryParse(data.AsSpan(briIndex + 6, 3), out float nivel))
                                            if (!float.TryParse(data.AsSpan(briIndex + 6, 2), out nivel))
                                                _ = float.TryParse(data.AsSpan(briIndex + 6, 1), out nivel);
                                        
                                        Task.Run(() => deviceList[currentLight].Nivel = nivel);

                                    }

                                    stream.Write(Encoding.UTF8.GetBytes(deviceList[currentLight].GetState()));
                                    continue;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            stream.Write(Encoding.UTF8.GetBytes(Device.GetResponseHeader(e.Message + "\n" + e.StackTrace, "text/plain")));
                        }
                    }
                } 
                catch (Exception e)
                {                    
                    GravaLog.Gravar(e.Message + "\n" + e.StackTrace, nomeArquivoLog);
                }
            }
                // Shutdown and end connection
                //sender.Close();    
        }
               
        private byte[] GetLightsJson()
        {
            string lightsJson = "{";
            /*
            foreach (Device device in deviceList)
            {   
                lightsJson += "\r\n\"" + device.deviceNumber + "\": {\r\n\"type\": \"Extended color light\",\r\n\"name\": \"" + device.deviceName + "\",\r\n\"uniqueid\": \"" + device.uniqueId + "\"\r\n}\r\n";
                if (!(index == deviceList.Count - 1)) lightsJson += ",\r\n";
                index++;
            }
            */
            for (int i = 0; i < deviceList.Length; i++)
            {
                lightsJson += "\r\n\"" + deviceList[i].deviceNumber + "\": {\r\n\"type\": \"Extended color light\",\r\n\"name\": \"" + deviceList[i].deviceName + "\",\r\n\"uniqueid\": \"" + deviceList[i].uniqueId + "\"\r\n}\r\n";
                if (!(i == deviceList.Length - 1)) lightsJson += ",\r\n";
            }
            lightsJson += "}";

            string header = "HTTP/1.1 200 OK\r\n" +
                            $"Content-Type: application/json\r\n" +
                            $"Content-Length: {lightsJson.Length}\r\n" +
                            "Connection: close\r\n\r\n";

            header += lightsJson;

            return Encoding.UTF8.GetBytes(header);
        }

        public string GetDescriptionXml()
        {   
            string descriptionXml =
@$"<?xml version=""1.0"" ?>
<root xmlns=""urn:schemas-upnp-org:device-1-0"">
<specVersion><major>1</major><minor>0</minor></specVersion>
<URLBase>http://{this.localIp}:80/</URLBase> 
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
    }
}