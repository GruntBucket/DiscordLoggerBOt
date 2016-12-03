using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class MyBot
    {
        string userMessage;
        DiscordClient discord;
        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '>';
                });
            var commands = discord.GetService<CommandService>();
            commands.CreateCommand("Hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Different floats for different boats");
                    
                    

                });
            discord.MessageReceived += Discord_MessageReceived;
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjUyNjc1NDA5MjI3ODA4NzY4.CyJ8UA.Z9rAh5aO2jeMjhwNQt_T3q8RGWM", TokenType.Bot);
            });
        }

        private void Discord_MessageReceived(object sender, MessageEventArgs e)
        {
            if (!e.Message.IsAuthor)
            {
                var logChannel = e.Server.FindChannels("logs").FirstOrDefault();
                userMessage = ("[" + e.Channel + "]" + System.Environment.NewLine + e.Message + System.Environment.NewLine + DateTime.Now.ToString("HH:mm:ss tt"));
                logChannel.SendMessage(userMessage);
                
                file.WriteLine(userMessage);                
                file.Flush();
            }
            
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            
            Console.WriteLine(e.Message);

        }
        
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\Users\Simon\Desktop\Logsformybot\logs.txt");
    }
}
