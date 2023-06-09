﻿using MassTransit;
using MassTransit.Configuration;
using MassTransit.Mediator;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonitoringData.Infrastructure.Events;
using MonitoringData.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringData.DataLoggingService {
    public class MonitorDBChanges : BackgroundService {
        private readonly IMediator _mediator;
        private readonly MonitorDatabaseSettings _settings;

        public MonitorDBChanges(IMediator mediator,IOptions<MonitorDatabaseSettings> options) {
            this._mediator = mediator;
            this._settings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            var client = new MongoClient(this._settings.ConnectionString);
            var database = client.GetDatabase(this._settings.DatabaseName);
            using(var cursor=await database.WatchAsync()) {
                foreach(var change in cursor.ToEnumerable()) {
                    Console.WriteLine(change.ToString());
                    await this._mediator.Publish<ReloadConsumer>(new ReloadConsumer());
                }
            }
        }
    }
}
