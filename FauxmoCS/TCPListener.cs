using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

namespace FauxmoCS
{
    public sealed class TCPListener
    {
        readonly Device[] deviceList;
        readonly byte[] lightsJson;
        readonly string localIp;
        readonly TcpListener listener;
        const string nomeArquivoLog = "logTcp-";
        

        public TCPListener(ref Device[] deviceList, string localIp)
        {
            this.deviceList = deviceList;
            this.localIp = localIp;
            lightsJson = GetLightsJson();
            listener = new(IPAddress.Any, 80);
        }
        
        public void Stop() => listener.Stop();

        public void Run(CancellationToken ct)
        {
            Byte[] bytes = new Byte[256];
            string data;

            GravaLog.Gravar("Iniciando TCP listener...", nomeArquivoLog);

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

                    //SslStream stream = new SslStream(listener.AcceptTcpClient().GetStream(), false);
                    //X509Certificate2 cert = new X509Certificate2("D:\\Users\\igork\\Desktop\\teste.pfx", "password1234");
                    //stream.AuthenticateAsClient("serverName", new X509Certificate2Collection(cert), SslProtocols.Tls, false);

                    NetworkStream stream = listener.AcceptTcpClient().GetStream();
                    GravaLog.Gravar("Conexão aceita.", nomeArquivoLog);

                    byte currentLight = 0;
                    int i;
                    data = "";
                    while ((i = stream.Read(bytes, 0, bytes.Length)) > 0 )
                    {
                        try
                        {
                            data += Encoding.ASCII.GetString(bytes, 0, i).ToUpper();

                            GravaLog.Gravar(data, nomeArquivoLog);

                            if (String.Equals(data[..3], "GET"))
                            {
                                //Responds to description.xml request
                                if (String.Equals(data.Substring(5, 15), "DESCRIPTION.XML"))
                                {
                                    stream.Write(Encoding.UTF8.GetBytes(Device.GetDescriptionXml(localIp)));
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

                                else if (data.Contains("2WLEDHARDQRI3WHYTHOMCXHGESPSM8ZZRPSKTBQR"))
                                {
                                    byte[] teste = GetLightsJson2();
                                    stream.Write(teste, 0, teste.Length);
                                    continue;
                                }

                                else if (data.Contains("CONFIG"))
                                {
                                    string conf = @"
{
  ""name"": ""FauxmoC#"",
  ""bridgeid"": ""000088FFFE00BBEE"",
  ""mac"": ""30:9C:23:9A:7B:46"",
  ""dhcp"": true,
  ""ipaddress"": ""10.0.0.100"",
  ""netmask"": ""255.255.255.0"",
  ""gateway"": ""10.0.0.1"",
  ""proxyaddress"": """",
  ""proxyport"": 0,
  ""UTC"": ""2022-11-10T16:50:07"",
  ""localtime"": ""2022-11-10T11:50:07"",
  ""timezone"": ""America/Sao_Paulo"",
  ""modelid"": ""BSB001"",
  ""swversion"": ""1.50.2_r30933"",
  ""apiversion"": ""1.50.0"",
  ""linkbutton"": false,
  ""portalservices"": false,
  ""portalstate"": {
    ""signedon"": false,
    ""incoming"": false,
    ""outgoing"": false,
    ""communication"": ""disconnected""
  },
  ""factorynew"": false,
  ""replacesbridgeid"": null,
  ""backup"": {
    ""status"": ""idle"",
    ""errorcode"": 0
  }
}";
                                    stream.Write(Encoding.UTF8.GetBytes(Device.GetResponseHeader(conf, "application/json")));
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
                                        else if (data.Contains("FALSE")) Task.Run(() => deviceList[currentLight].State = false);
                                        
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

                catch (IOException) { }
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

            for (int i = 0; i < deviceList.Length; i++)
            {
                lightsJson += "\r\n\"" + deviceList[i].deviceNumber + "\": {\r\n\"type\": \"Extended color light\",\r\n\"psrtype\": \"WINDOWS_TRIGGER\",\r\n\"name\": \"" + deviceList[i].deviceName + "\",\r\n\"uniqueid\": \"" + deviceList[i].uniqueId + "\"\r\n}\r\n";
                if (i != deviceList.Length - 1) lightsJson += ",\r\n";
            }

            lightsJson += "}";

            string header = "HTTP/1.1 200 OK\r\n" +
                            $"Content-Type: application/json\r\n" +
                            $"Content-Length: {lightsJson.Length}\r\n" +
                            "Connection: close\r\n\r\n";

            header += lightsJson;

            return Encoding.UTF8.GetBytes(header);
        }

        private byte[] GetLightsJson2()
        {
            string lightsJson = 
@"{
    ""lights"":{";

            for (int i = 0; i < deviceList.Length; i++)
            {
                lightsJson += "\"" + Convert.ToString(i+1) + "\":{\r\n\"type\": \"Extended color light\",\r\n\"name\":\"" + deviceList[i].deviceName + "\",\r\n\"uniqueid\": \"" + deviceList[i].uniqueId + "\",\r\n\"modelid\": \"LCT015\",\r\n\"manufacturername\": \"Philips\",\r\n\"productname\": \"E4\",\r\n\"state\": {\r\n\"on\": " + deviceList[i].State.ToString().ToLower() + ",\"mode\": \"homeautomation\",\r\n\"reachable\": true\r\n},\r\n\"capabilities\": {\r\n\"certified\": false,\r\n\"streaming\": {\r\n\"renderer\": true,\r\n\"proxy\": false\r\n}\r\n},\r\n\"swversion\": \"5.105.0.21169\"\r\n}";
                if (i != deviceList.Length - 1) lightsJson += ",\r\n";
            }
            lightsJson += @"},""schedules"": {
        ""1"": {
            ""time"": ""2012-10-29T12:00:00"",
            ""description"": """",
            ""name"": ""schedule"",
            ""command"": {
                ""body"": {
                    ""scene"": null,
                    ""on"": true,
                    ""xy"": null,
                    ""bri"": null,
                    ""transitiontime"": null
                },
                ""address"": ""/api/newdeveloper/groups/0/action"",
                ""method"": ""PUT""
            }
        }
    },
    ""config"": {
        ""portalservices"": false,
        ""gateway"": ""192.168.2.1"",
        ""mac"": ""30:9C:23:9A:7B:46"",
        ""bridgeid"": ""000088FFFE00BBEE"",
        ""modelid"": ""BSB001"",
        ""swversion"": ""01005215"",
        ""linkbutton"": false,
        ""ipaddress"": ""10.0.0.100:80"",
        ""proxyport"": 0,
        ""swupdate"": {
            ""text"": """",
            ""notify"": false,
            ""updatestate"": 0,
            ""url"": """"
        },
        ""netmask"": ""255.255.255.0"",
        ""name"": ""Philips hue"",
        ""dhcp"": true,
        ""proxyaddress"": """",
        ""whitelist"": {
            ""newdeveloper"": {
                ""name"": ""test user"",
                ""last use date"": ""2012-10-29T12:00:00"",
                ""create date"": ""2012-10-29T12:00:00""
            },
            ""2WLEDHardQrI3WHYTHoMcXHgEspsM8ZZRpSKtBQr"": {
                ""name"": ""HOME-ASSISTANT#CASA"",
                ""last use date"": ""2023-03-23T08:46:26"",
                ""create date"": ""2023-03-23T08:46:21""
            }
        },
        ""UTC"": ""2012-10-29T12:05:00""
    },
    ""groups"": {
        ""1"": {
            ""name"": ""Group 1"",
            ""action"": {
                ""on"": true,
                ""bri"": 254,
                ""hue"": 33536,
                ""sat"": 144,
                ""xy"": [
                    0.346,
                    0.3568
                ],
                ""ct"": 201,
                ""alert"": null,
                ""effect"": ""none"",
                ""colormode"": ""xy"",
                ""reachable"": null
            },
            ""lights"": [
                ""1"",
                ""2""
            ]
        }
    },
    ""scenes"": {}";
            lightsJson += "}";

            string header = "HTTP/1.1 200 OK\r\n" +
                            $"Content-Type: application/json\r\n" +
                            $"Content-Length: {lightsJson.Length}\r\n" +
                            "Connection: close\r\n\r\n";

            header += lightsJson;

            return Encoding.UTF8.GetBytes(header);
        }
    }
}