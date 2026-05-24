using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SharedModels;

Console.WriteLine("Сервер запущен!");

TcpListener listener = new TcpListener(IPAddress.Any, 8888);
listener.Start();
Console.WriteLine("Ожидание подключения клиента...");

TcpClient client = await listener.AcceptTcpClientAsync();
Console.WriteLine("Клиент подключен.");

NetworkStream stream = client.GetStream();
byte[] buffer = new byte[4096];
int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
Book? receivedBook = JsonSerializer.Deserialize<Book>(json);
if (receivedBook != null)
{
    Console.WriteLine($"Получена книга: {receivedBook}");
}
else
{
    Console.WriteLine("Ошибка десериализации");
}

client.Close();
listener.Stop();
Console.WriteLine("Сервер остановлен");