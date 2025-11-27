using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AlexaCS
{
    public class TcpListenerHttps
    {
        private readonly TcpListener listener443;
        private readonly X509Certificate2 certificate;

        public TcpListenerHttps(string certPath, string certPassword)
        {
            listener443 = new TcpListener(IPAddress.Any, 443);
            //certificate = new X509Certificate2(certPath, certPassword);
            certificate = new X509Certificate2(certPath);
        }

        public void Start(CancellationToken ct)
        {
            listener443.Start();
            Console.WriteLine("HTTPS listener iniciado na porta 443...");

            _ = Task.Run(async () =>
            {
                while (!ct.IsCancellationRequested)
                {
                    try
                    {
                        TcpClient client = await listener443.AcceptTcpClientAsync();

                        _ = Task.Run(() => HandleClient(client));
                    }
                    catch { }
                }
            });
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using var ssl = new SslStream(client.GetStream(), false);
                ssl.AuthenticateAsServer(certificate, false, false);

                byte[] buffer = new byte[4096];
                int bytes = ssl.Read(buffer, 0, buffer.Length);
                string req = Encoding.UTF8.GetString(buffer, 0, bytes).ToUpper();

                if (req.Contains("/API/") && req.Contains("CONFIG"))
                {
                    Console.WriteLine("[443] Alexa pediu CONFIG via HTTPS.");

                    string json = @"{ ""name"": ""Philips hue"", ""datastoreversion"": ""99"" }";

                    string resp =
                        "HTTP/1.1 200 OK\r\n" +
                        "Content-Type: application/json\r\n" +
                        $"Content-Length: {json.Length}\r\n" +
                        "Connection: close\r\n\r\n" +
                        json;

                    ssl.Write(Encoding.UTF8.GetBytes(resp));
                    ssl.Flush();
                }
                else
                {
                    // resposta mínima para qualquer outra coisa
                    string resp =
                        "HTTP/1.1 200 OK\r\n" +
                        "Content-Length: 0\r\n" +
                        "Connection: close\r\n\r\n";

                    ssl.Write(Encoding.UTF8.GetBytes(resp));
                    ssl.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro HTTPS: " + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
