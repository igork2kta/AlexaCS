using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AlexaCS
{
    public sealed class UDPListener
    {
        const string nomeArquivoLog = "logUdp-";
        public static void StartListener(string localIp, CancellationToken ct)
        {
            //Socket sock = new (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localEndPoint = new (IPAddress.Any, 1900);
            IPEndPoint groupEP = new(IPAddress.Any, 0);

            byte[] msearch_response = Encoding.ASCII.GetBytes(
                            "HTTP/1.1 200 OK\r\n" +
                            "EXT:\r\n" +
                            "CACHE-CONTROL: max-age=100\r\n" + // SSDP_INTERVAL
                            $"LOCATION: http://{localIp}:80/description.xml\r\n" +
                            "SERVER: FreeRTOS/6.0.5, UPnP/1.0, IpBridge/1.17.0\r\n" +// _modelName, _modelNumber
                            "hue-bridgeid: e8db84962384s\r\n" +
                            "ST: urn:schemas-upnp-org:device:basic:1\r\n" + // _deviceType
                            "USN: uuid:2f402f80-da50-11e1-9b23--e8db84962384::upnp:rootdevice\r\n" +// _uuid::_deviceType
                            "\r\n"
             );

            GravaLog.Gravar("Iniciando UDP listener...", nomeArquivoLog);

            while (true)
            {
                UdpClient listener = new();

                try
                {
                    if (ct.IsCancellationRequested)
                    {
                        GravaLog.Gravar("Parando UDP listener...", nomeArquivoLog);
                        ct.ThrowIfCancellationRequested();
                    }

                          
                    listener.Client.Bind(localEndPoint);
                    listener.JoinMulticastGroup(IPAddress.Parse("239.255.255.250"), IPAddress.Parse(localIp));
                    listener.Client.ReceiveTimeout = 200;

                
                    
                    //var bytes = listener.Receive(ref groupEP);
                    //string recebido = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    string recebido = Encoding.ASCII.GetString(listener.Receive(ref groupEP));

                    string[] ip = groupEP.ToString().Split(':');

                    if (recebido.Contains("M-SEARCH"))
                    {
                        GravaLog.Gravar($"Received broadcast from {ip[0]} :\n {recebido}\n", nomeArquivoLog);
                        IPAddress serverAddr = IPAddress.Parse(ip[0]);

                        IPEndPoint endPoint = new(serverAddr, Convert.ToInt32(ip[1]));

                        listener.Send(msearch_response, msearch_response.Length, endPoint);
                    }
                }
                catch (SocketException) { }
                catch (OperationCanceledException) { return; }
                catch (Exception ex)
                {
                    GravaLog.Gravar(ex.ToString(), nomeArquivoLog);
                }
                finally
                {
                    listener.Close();
                }
            }
        }
    }
}
