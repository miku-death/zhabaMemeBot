using Telegram.Bot;
using Telegram.Bot.Polling;

namespace zhabaMemeBot
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Bot has been started: {ToadMemer.Bot.GetMeAsync().Result.FirstName}");

			var cts = new CancellationTokenSource();
			var cancellationToken = cts.Token;
			var receiverOptions = new ReceiverOptions
			{
				AllowedUpdates = { },
			};

			ToadMemer.Bot.StartReceiving(
				ToadMemer.HandleMessageAsync,
				ToadMemer.HandleErrorAsync,
				receiverOptions,
				cancellationToken
			);

			Console.ReadLine();
		}
	}
}
