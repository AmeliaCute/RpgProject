using System;
using Discord;

namespace RpgProject.Game
{
    class DiscordRichPresence
    {
        public static Discord.Discord discord;

        public static void Start()
        {
            try
            {
                discord = new(768911365426905159, (UInt64) Discord.CreateFlags.NoRequireDiscord);
                var activityManager = discord.GetActivityManager();
                var activity = new Discord.Activity
                {
                    State = "Testing..",
                    Details = $"Playing on {RpgClass.USER.Values.DisplayName} account"
                };
                activityManager.UpdateActivity(activity, (res) =>
                {
                    if (res == Discord.Result.Ok)
                    {
                        RpgClass.LOGGER.Log("Everything is fine!");
                    }
                });
            }
            catch (Exception e)
            {
                RpgClass.LOGGER.Error(e.ToString());
            }
        }

        public static void UpdatePresence()
        {

        }

        public static void Stop()
        {
            discord?.Dispose();
        }

        public static void Update()
        {
            discord?.RunCallbacks();
        }
    }
}