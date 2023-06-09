﻿using MongoDB.Bson;
using MonitoringSystem.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringData.Infrastructure.Model {
    public class MonitorItem {
        public int _id { get; set; }
        public string identifier { get; set; }
        public bool display { get; set; }
        public ObjectId deviceId { get; set; }
    }

    public class AnalogChannel : MonitorItem {
        public int factor { get; set; }
    }

    public class DiscreteChannel : MonitorItem {

    }

    public class OutputItem : MonitorItem {

    }

    public class VirtualChannel : MonitorItem {

    }

    public class ActionItem : MonitorItem {
        public ActionType actionType { get; set; }
        public bool EmailEnabled { get; set; }
        public int EmailPeriod { get; set; }
    }
}
