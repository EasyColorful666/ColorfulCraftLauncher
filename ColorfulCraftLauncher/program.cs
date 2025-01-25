using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Authenticator;
using System.Security.Principal;
using System.Windows;
using MinecraftLaunch.Classes.Models.Auth;
namespace ColorfulCraftLauncher
{
    public class Program
    {
        public async Task<MicrosoftAccount> MicrosoftLogin()
        {
            MicrosoftAuthenticator authenticator = new("f4c1c237-e68f-4866-a998-82f0db041c55");
            await authenticator.DeviceFlowAuthAsync(dc => {
                //在获取到一次性代码后要执行的代码
                Console.WriteLine(dc.UserCode);
            });

            var userProfile = authenticator.AuthenticateAsync();
            return userProfile.Result;
            
        }
    }
}
