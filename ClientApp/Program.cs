using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SharedModels;

Console.WriteLine("Клиент запущен");

// Ввод данных с консоли
Console.Write("Введите Id книги: ");
int id = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Введите название книги: ");
string title = Console.ReadLine() ?? "";

Console.Write("Введите автора книги: ");
string author = Console.ReadLine() ?? "";

Console.Write("Введите год издания: ");
int year = int.Parse(Console.ReadLine() ?? "0");

Book book = new Book
{
    Id = id,
    Title = title,
    Author = author,
    Year = year
};

string json = JsonSerializer.Serialize(book);
Console.WriteLine($"Отправляем: {json}");

// Подключение и отправка
TcpClient client = new TcpClient();
await client.ConnectAsync("127.0.0.1", 8888);

NetworkStream stream = client.GetStream();
byte[] data = Encoding.UTF8.GetBytes(json);
await stream.WriteAsync(data, 0, data.Length);

Console.WriteLine("Данные отправлены");
client.Close();