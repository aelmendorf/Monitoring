﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringData.Infrastructure.Services.SignalR {

    public class ItemStatus {
        public string Item { get; set; }
        public string State { get; set; }
        public string Value { get; set; }
    }

    public interface IMonitorHub {
        Task ShowCurrent(IList<ItemStatus> items);
    }

    public class MonitorHub : Hub<IMonitorHub> {
        public async Task SendDataToClients(IList<ItemStatus> items) {
            await Clients.All.ShowCurrent(items);
        }
    }
}
