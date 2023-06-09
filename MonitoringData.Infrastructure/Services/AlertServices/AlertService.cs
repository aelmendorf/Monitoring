﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using MonitoringData.Infrastructure.Model;
using MonitoringData.Infrastructure.Services.DataAccess;
using MonitoringData.Infrastructure.Services.AlertServices;
using MonitoringSystem.Shared.Data;
using Microsoft.Extensions.Logging;
using MassTransit;
using MonitoringSystem.Shared.Contracts;
using Microsoft.Extensions.Options;

namespace MonitoringData.Infrastructure.Services {
    public enum AlertAction {
        Clear,
        ChangeState,
        Start,
        Resend,
        Nothing
    }
    public interface IAlertService {
        Task ProcessAlerts(IList<AlertRecord> items,DateTime now);
        Task Initialize();
    }

    public class AlertService : IAlertService {
        private readonly IAlertRepo _alertRepo;
        private readonly ILogger<AlertService> _logger;
        private readonly MonitorDatabaseSettings _settings;
        private IEmailService _emailService;
        private List<AlertRecord> _activeAlerts = new List<AlertRecord>();


        public AlertService(IAlertRepo alertRepo,ILogger<AlertService> logger,IOptions<MonitorDatabaseSettings> options) {
            this._alertRepo = alertRepo;
            this._logger = logger;
            this._emailService = new EmailService();
            this._settings = options.Value;
        }

        public AlertService(string connName,string databaseName,string actionCol, string alertCol) {
            this._alertRepo = new AlertRepo(connName, databaseName, actionCol, alertCol,"alert_readings");
            this._emailService = new EmailService();
        }

        public async Task ProcessAlerts(IList<AlertRecord> alerts,DateTime now) {
            IMessageBuilder messageBuilder = new MessageBuilder();
            messageBuilder.StartMessage();
            ConsoleTable statusTable = new ConsoleTable("Alert","Status","Reading");
            ConsoleTable newAlertTable = new ConsoleTable("Alert", "Status", "Reading");
            ConsoleTable newStateTable = new ConsoleTable("Alert", "Status", "Reading");
            ConsoleTable activeTable = new ConsoleTable("Alert", "Status", "Reading");
            ConsoleTable resendTable = new ConsoleTable("Alert", "Status", "Reading");
            bool sendEmail = false;     
            foreach (var alert in this.Process(alerts)) {
                if (alert.Enabled) {
                    switch (alert.AlertAction) {
                        case AlertAction.Clear: {
                                this._activeAlerts.RemoveAll(e=>e.AlertId==alert.AlertId);
                                break;
                            }
                        case AlertAction.ChangeState: {
                                var activeAlert = this._activeAlerts.FirstOrDefault(e => e.AlertId == alert.AlertId);
                                if (activeAlert != null) {
                                    activeAlert.CurrentState = alert.CurrentState;
                                    activeAlert.ChannelReading = alert.ChannelReading;
                                    activeAlert.AlertAction = alert.AlertAction;
                                } else {
                                    //Log Error
                                }
                                newStateTable.AddRow(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                                messageBuilder.AppendChanged(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                                sendEmail = true;
                                break;
                            }
                        case AlertAction.Start: {
                                this._activeAlerts.Add(alert.Clone());
                                sendEmail = true;
                                break;
                            }
                        case AlertAction.Resend: {
                                resendTable.AddRow(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                                sendEmail = true;
                                break;
                            }
                    }
                    statusTable.AddRow(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                    messageBuilder.AppendStatus(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                }
            }

            if (this._activeAlerts.Count > 0) {
                foreach (var alert in this._activeAlerts) {
                    activeTable.AddRow(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                    messageBuilder.AppendAlert(alert.DisplayName, alert.CurrentState.ToString(), alert.ChannelReading.ToString());
                }
                if (sendEmail) {
                    await this._emailService.SendMessageAsync(this._settings.EmailSubject, messageBuilder.FinishMessage());
                    var alertReadings = alerts.Select(e => new AlertReading() {
                        itemid = e.AlertId,
                        reading = e.ChannelReading,
                        state = e.CurrentState
                    });
                    await this._alertRepo.LogAlerts(new AlertReadings() { readings = alertReadings.ToArray(), timestamp = now });
                }
            }
            Console.Clear();
            Console.WriteLine("New Alerts:");
            Console.WriteLine(newAlertTable.ToMinimalString());
            Console.WriteLine();
            Console.WriteLine("Active Alerts");
            Console.WriteLine(activeTable.ToMinimalString());
            Console.WriteLine();
            Console.WriteLine("Resend Alerts");
            Console.WriteLine(resendTable.ToMinimalString());
            Console.WriteLine();
            Console.WriteLine("ChangeState Alerts");
            Console.WriteLine(newStateTable.ToMinimalString());
            Console.WriteLine();
            Console.WriteLine("Status");
            Console.WriteLine(statusTable.ToMinimalString());
            Console.WriteLine();
        }
        private IEnumerable<AlertRecord> Process(IList<AlertRecord> alertRecords) {
            var now = DateTime.Now;
            foreach (var alert in alertRecords) {
                var activeAlert = this._activeAlerts.FirstOrDefault(e => e.AlertId == alert.AlertId);
                var actionItem = this._alertRepo.ActionItems.FirstOrDefault(e => e.actionType == alert.CurrentState);
                switch (alert.CurrentState) {
                    case ActionType.Okay: {
                            if (activeAlert != null) {
                                alert.AlertAction = AlertAction.Clear;
                            } else {
                                alert.AlertAction = AlertAction.Nothing;
                            }
                            break;
                        }
                    case ActionType.Alarm:
                    case ActionType.Warning:
                    case ActionType.SoftWarn: {
                            if (activeAlert != null) {
                                if (activeAlert.CurrentState != alert.CurrentState) {
                                    alert.LastAlert = now;
                                    alert.AlertAction = AlertAction.ChangeState;
                                } else {
                                    if (actionItem != null) {
                                        if ((now - activeAlert.LastAlert).TotalMinutes >= actionItem.EmailPeriod) {
                                            alert.AlertAction = AlertAction.Resend;
                                            alert.LastAlert = now;
                                        }//
                                        //else do nothing
                                        alert.AlertAction = AlertAction.Nothing;
                                    } else {
                                        //log error-ActionItem not found
                                        alert.AlertAction = AlertAction.Nothing;
                                    }
                                }
                            } else {
                                alert.AlertAction = AlertAction.Start;
                                alert.LastAlert = now;
                            }
                            break;
                        }
                    case ActionType.Maintenance:
                    case ActionType.Custom:
                    default:
                        alert.AlertAction = AlertAction.Nothing;
                        break;
                }
                yield return alert;
            }
        }   

        private bool CheckBypassReset(AlertRecord alert,DateTime now) {
            return (now - alert.TimeBypassed).Minutes >= alert.BypassResetTime;
        }

        public async Task Initialize() {
            await this._alertRepo.Load();
        }
    }
}
