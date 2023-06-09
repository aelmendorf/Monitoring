﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonitoringData.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitoringData.Infrastructure.Services.DataAccess {
    public interface IAlertRepo {
        IList<ActionItem> ActionItems { get; }
        Task<MonitorAlert> GetAlert(int alertId);
        Task LogAlerts(AlertReadings alerts);
        Task UpdateAlert(int alertId, UpdateDefinition<MonitorAlert> update);
        Task Load();
    }

    public class AlertRepo : IAlertRepo {
        private IMongoCollection<ActionItem> _actionItems;
        private IMongoCollection<MonitorAlert> _monitorAlerts;
        private IMongoCollection<AlertReadings> _alertReadings;
        private readonly MonitorDatabaseSettings _settings;
        public IList<ActionItem> ActionItems { get; private set; }
        public AlertRepo(IOptions<MonitorDatabaseSettings> databaseSettings) {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            this._settings = databaseSettings.Value;
            this._actionItems = database.GetCollection<ActionItem>(this._settings.ActionItemCollection);
            this._monitorAlerts = database.GetCollection<MonitorAlert>(this._settings.AlertItemCollection);
            this._alertReadings = database.GetCollection<AlertReadings>(this._settings.AlertReadingCollection);
        }

        public AlertRepo(string connectionName,string databaseName,string actionColName,string alertCollName,string alertReadCol) {
            var client = new MongoClient(connectionName);
            var database = client.GetDatabase(databaseName);
            this._actionItems = database.GetCollection<ActionItem>(actionColName);
            this._monitorAlerts = database.GetCollection<MonitorAlert>(alertCollName);
            this._alertReadings = database.GetCollection<AlertReadings>(alertReadCol);
        }

        public async Task LogAlerts(AlertReadings alerts) {
            await this._alertReadings.InsertOneAsync(alerts);
        }

        public async Task<MonitorAlert> GetAlert(int alertId) {
            return await this._monitorAlerts.Find(e => e._id == alertId).FirstOrDefaultAsync();
        }

        public async Task UpdateAlert(int alertId,UpdateDefinition<MonitorAlert> update) {
            await this._monitorAlerts.FindOneAndUpdateAsync(e => e._id == alertId, update);
        }

        public async Task Load() {
            this.ActionItems = await this._actionItems.Find(_ => true).ToListAsync();
        }
    }
}
