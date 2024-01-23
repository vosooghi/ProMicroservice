﻿namespace Ground.Extensions.Events.PollingPublisher.Dal.Dapper.Options
{
    public class PollingPublisherDalRedisOptions
    {
        public string ApplicationName { get; set; }
        public string ConnectionString { get; set; }
        public string SelectCommand { get; set; } = "Select top (@Count) * from ground.OutBoxEventItems where IsProcessed = 0";
        public string UpdateCommand { get; set; } = "Update ground.OutBoxEventItems set IsProcessed = 1 where OutBoxEventItemId in @Ids";
    }
}
