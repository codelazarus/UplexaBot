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
            if (e.Message.Text != null)
            {
                if (e.Message.Text.StartsWith("/"))
                {
                    if(e.Message.Text.Contains("/price"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.GetPrice());

                    if(e.Message.Text.Contains("/donate"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.Donate());

                    if (e.Message.Text.Contains("/exchanges"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.GetExchanges());

                    if (e.Message.Text.Contains("/max_supply"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.MaxSupply());

                    if (e.Message.Text.Contains("/volume"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.Volume());

                    if(e.Message.Text.Contains("/whitepaper"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.WhitePaper());

                    if(e.Message.Text.Contains("/android_mining_tutorial"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://youtu.be/2qMDTb562L8");

                    if (e.Message.Text.Contains("/pc_mining_tutorial"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.youtube.com/watch?v=1EPLoMkUAhQ");
                }
            }
        }

        class Uplexa
        {
            static ICoinmarketcapClient client = new CoinmarketcapClient(API_KEY);
            static Currency currency = client.GetCurrencyBySlug("uplexa");

            public static string GetPrice()
            {
                return "$" + currency.Price.ToString("N6");
            }

            public static string GetExchanges()
            {
                return "TradeOgre - LTC/UPX - https://tradeogre.com/exchange/LTC-UPX \n" +
                       "Graviex - BTC/UPX - https://graviex.net/markets/upxbtc \n" +
                       "STEX - ETH/UPX - https://app.stex.com/en/trading/pair/ETH/UPX/1D \n" +
                       "PancakeSwap\n" +
                       "Uniswap - https://app.uniswap.org/#/swap?outputCurrency=0xc3d91ffdf44eafc32a9e4489a4efe188489fc183&inputCurrency=ETH&use=v2";
            }
            public static string Donate()
            {
                return "https://uplexa.com/donations";
            }
            public static string MaxSupply()
            {
                return "Max supply is: 10,500,000,000";
            }

            public static string Volume()
            {
                return "24h Volume: $" + currency.Volume24hUsd.ToString("N2");
            }

            public static string WhitePaper()
            {
                return "Link to Whitepaper:\nhttps://uplexa.com/media/uPlexa-Whitepaper-EN.pdf";
            }
        }
    }
}
