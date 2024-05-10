using System;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Vivox;

namespace DemoScripts
{
    public class RoomController : MonoBehaviour
    {
        async void Start()
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            await VivoxService.Instance.InitializeAsync();
            await LoginToVivoxAsync();
            await JoinEchoChannelAsync();
        }


        public async Task LoginToVivoxAsync()
        {
            LoginOptions options = new LoginOptions();
            options.DisplayName = "TEST DISPLAYED NAME";
            options.EnableTTS = true;
            await VivoxService.Instance.LoginAsync(options);
        }

        public async Task JoinEchoChannelAsync()
        {
            string channelToJoin = "Lobby";
            await VivoxService.Instance.JoinEchoChannelAsync(channelToJoin, ChatCapability.AudioOnly);
        }

        public async Task JoinGroupChannelAsync()
        {
            string channelToJoin = "Lobby";
            await VivoxService.Instance.JoinGroupChannelAsync(channelToJoin, ChatCapability.AudioOnly);
        }
    }
}