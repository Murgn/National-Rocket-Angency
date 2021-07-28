using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Murgn;

namespace Murgn
{
    
    public class DiscordController : MonoBehaviour
    {
        #if !UNITY_EDITOR
        public Discord.Discord discord;
        private Discord.ActivityManager activityManager;

        void Start()
        {
D           ontDestroyOnLoad(this.gameObject);

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;

            discord = new Discord.Discord(869670338894651522, (System.UInt64)Discord.CreateFlags.Default);

            activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = "Flying through Space",
                State = "Playing Level 1",
                Timestamps =
                {
                    Start = secondsSinceEpoch
                },
                Assets = 
                {
                    LargeImage = "bigrocket",
                    LargeText = "Playing National Rocket Agency"
                }
            };

            activityManager.UpdateActivity(activity, (res) => 
            {
                if(res == Discord.Result.Ok)
                Debug.Log("Discord RPC Set.");
                else
                Debug.LogError("Discord RPC Failed.");
            });
        }

        void Update()
        {
            discord.RunCallbacks();
        }

        void OnApplicationQuit()
        {
            activityManager.ClearActivity((res) => {});
            discord.Dispose();
        }
        #endif
    }   
}