using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorClient.Logic.Services.Communication.HubServices.Base
{
    internal class RetryPolicy : IRetryPolicy
    {
        public TimeSpan? NextRetryDelay(RetryContext retryContext) => TimeSpan.FromSeconds(1);
    }
}