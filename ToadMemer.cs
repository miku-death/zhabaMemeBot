using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace zhabaMemeBot
{
    class ToadMemer
    {
        public static ITelegramBotClient Bot { get; } = 
            new TelegramBotClient(System.IO.File.ReadAllText("token"));

        public static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellation)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message.Text != null)
                {
                    if(message.Text.ToLower() == "/start")
                    {
                        return;
                    }

                    if (message.Text.ToLower() == "/pic")
                    {
                        DirectoryInfo di = new DirectoryInfo("pics");
                        FileInfo[] files = di.GetFiles();
                        Random r = new Random();
                        FileInfo file = files[r.Next(0, files.Length)];

                        using (Stream stream = System.IO.File.OpenRead(file.FullName))
                        {
                            Console.WriteLine($"[{DateTime.Now.ToString("G")}] user {message.From} requested pic #{file.Name}");
                            var Message = await botClient.SendPhotoAsync(
                                chatId: message.Chat,
                                photo: new Telegram.Bot.Types.InputFiles.InputOnlineFile(content: stream, fileName: file.FullName));
                            Console.WriteLine($"[{DateTime.Now.ToString("G")}] user {message.From} was sent pic #{file.Name}");
                        }
                    }
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(exception));
        }
    }
}
