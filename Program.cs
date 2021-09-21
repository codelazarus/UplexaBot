using NoobsMuc.Coinmarketcap.Client;
using System;
using System.Net;
using System.Web;
using Telegram.Bot;
namespace UplexaBot
{
    class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("2036722940:AAGUuMMbKqAlv5cuyrGWfpkiZMCJwgzsXwA");

        private static string API_KEY = "43348147-32a2-4328-b64b-bd6e6267cdfc";

        static void Main(string[] args)
        {
            bot.StartReceiving();
            bot.OnMessage += Bot_OnMessage;

            Console.ReadLine();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "/price":
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "$" + GetPrice());
                    break;
                case "/exchanges":
                    string exchanges = "TradeOgre - LTC/UPX - https://tradeogre.com/exchange/LTC-UPX \n" +
                                       "Graviex - BTC/UPX - https://graviex.net/markets/upxbtc \n" +
                                       "STEX - ETH/UPX - https://app.stex.com/en/trading/pair/ETH/UPX/1D \n" +
                                       "PancakeSwap\n" +
                                       "Uniswap - https://app.uniswap.org/#/swap?outputCurrency=0xc3d91ffdf44eafc32a9e4489a4efe188489fc183&inputCurrency=ETH&use=v2";
                    
                    bot.SendTextMessageAsync(e.Message.Chat.Id, exchanges);
                    break;
                case "/android_mining_tutorial":
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "https://youtu.be/2qMDTb562L8");
                    break;
                case "/pc_mining_tutorial":
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.youtube.com/watch?v=1EPLoMkUAhQ");
                    break;
                default:
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Invalid command");
                    break;
            }
        }


        private static string GetPrice()
        {
            ICoinmarketcapClient client = new CoinmarketcapClient(API_KEY);
            Currency currency = client.GetCurrencyBySlug("uplexa");
            return currency.Price.ToString();
        }

    }
}
