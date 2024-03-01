﻿using Ground.Utilities.SerilogRegistration.Options;
using Microsoft.Extensions.Options;
using Serilog.Core;
using Serilog.Events;

namespace Ground.Utilities.SerilogRegistration.Sample.SampleEnrichers
{
    public class Sample02Enricher : ILogEventEnricher
    {
        private readonly SerilogApplicationEnricherOptions _options;
        public Sample02Enricher(IOptions<SerilogApplicationEnricherOptions> options)
        {
            _options = options.Value;
        }
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var BirthDate = propertyFactory.CreateProperty("BirthDate", "2100-01-01");
            logEvent.AddPropertyIfAbsent(BirthDate);

        }
    }
}
