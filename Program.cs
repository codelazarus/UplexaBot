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
                    ICoinmarketcapClient client = new CoinmarketcapClient(API_KEY);
                    Currency currency = client.GetCurrencyBySlug("uplexa");

                    if (e.Message.Text.Contains("/price"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "$" + currency.Price.ToString("N6"));

                    if(e.Message.Text.Contains("/donate"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.Donate());

                    if (e.Message.Text.Contains("/exchanges"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.GetExchanges());

                    if (e.Message.Text.Contains("/max_supply"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.MaxSupply());

                    if (e.Message.Text.Contains("/volume"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "24h Volume: $" + currency.Volume24hUsd.ToString("N2"));

                    if(e.Message.Text.Contains("/whitepaper"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.WhitePaper());

                    if(e.Message.Text.Contains("/android_mining_tutorial"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://youtu.be/2qMDTb562L8");

                    if (e.Message.Text.Contains("/pc_mining_tutorial"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.youtube.com/watch?v=1EPLoMkUAhQ");
                    if (e.Message.Text.Contains("/support_uplexa"))
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Uplexa.SupportUplexa());
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
                       "STEX - ETH/UPX - https://app.stex.com/en/trading/pair/ETH/UPX/1D";
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

            public static string SupportUplexa()
            { 
                return @"🚨DAILY TASKS FOR UPLEXA KINGS! 

                https://coinmarketcap.com/currencies/uplexa/
                ✅Scroll down and VOTE GOOD
                ✅Add UPLEXA to your Watchlist

                https://www.coingecko.com/en/coins/uplexa
                ✅VOTE GOOD

                https://www.google.com/search?q=uplexa+upx
                ✅CLICK FOR ALGORITHM

                https://m.youtube.com/results?sp=mAEA&search_query=uplexa+upx
                ✅CLICK FOR ALGORITHM

                https://uplexa.com
                ✅CLICK FOR ALGORITHM

                ✅Go to Twitter search for #uplexa and $UPX like and retweet last 10 comments 


                🚀 🚀 🚀 ⚔️ ⚔️ ⚔️ 🚀 🚀 🚀";
            }
        }
    }
}
