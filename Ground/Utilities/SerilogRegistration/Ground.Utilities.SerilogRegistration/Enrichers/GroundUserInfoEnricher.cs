﻿using Ground.Extensions.UsersManagement.Abstractions;
using Serilog.Core;
using Serilog.Events;

namespace Ground.Utilities.SerilogRegistration.Enrichers
{
    public class GroundUserInfoEnricher : ILogEventEnricher
    {
        private readonly IUserInfoService _userInfoService;

        public GroundUserInfoEnricher(IUserInfoService userInfoService)
        {
            this._userInfoService = userInfoService;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory factory)
        {
            string userName;
            string UserId;
            string UserIp;
            string clientId;

            userName = _userInfoService.GetUsername();
            if (string.IsNullOrEmpty(userName))
                userName = "Unknown";
            UserId = _userInfoService.UserIdOrDefault();
            UserIp = _userInfoService.GetUserIp();
            clientId = _userInfoService.GetClaim("client_id");
            if (string.IsNullOrEmpty(clientId))
                clientId = "Unknown";

            var userNameProperty = factory.CreateProperty("UserName", userName);
            var userIdProperty = factory.CreateProperty("UserId", UserId);
            var userIpProperty = factory.CreateProperty("UserIp", UserIp);
            var clientIdProperty = factory.CreateProperty("ClientId", clientId);

            logEvent.AddPropertyIfAbsent(userNameProperty);
            logEvent.AddPropertyIfAbsent(userIdProperty);
            logEvent.AddPropertyIfAbsent(userIpProperty);
            logEvent.AddPropertyIfAbsent(clientIdProperty);
        }
    }
}
