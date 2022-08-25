﻿using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MonitoringConfig.Data.Model;
using MonitoringSystem.ConfigApi.Contracts.Requests.Get;
using MonitoringSystem.ConfigApi.Contracts.Responses.Get;
using MonitoringSystem.ConfigApi.Mapping;

namespace MonitoringSystem.ConfigApi.Endpoints; 

[HttpGet("channels/analog/{id:guid}"),AllowAnonymous]
public class GetAnalogChannelsEndpoint:Endpoint<GetDeviceChannelsRequest,GetAnalogChannelsResponse> {
    private readonly MonitorContext _context;

    public GetAnalogChannelsEndpoint(MonitorContext context) {
        this._context = context;
    }

    public override async Task HandleAsync(GetDeviceChannelsRequest req, CancellationToken ct) {
        /*var analogChannels = await this._context.Channels.OfType<AnalogInput>()
            .Include(e => e.Sensor)
            .Include(e => e.Alert)
            .ThenInclude(e => ((AnalogAlert)e).AlertLevels)
            .ThenInclude(e => e.DeviceAction)
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);*/
        var analogChannels = await this._context.Channels.OfType<AnalogInput>()
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e=>e.ToDto())
            .ToListAsync(ct);
        var response = new GetAnalogChannelsResponse() {
            AnalogInputs = analogChannels
        };
        await SendOkAsync(response, ct);
    }
}

[HttpGet("channels/discrete/{id:guid}"),AllowAnonymous]
public class GetDiscreteChannelsEndpoint:Endpoint<GetDeviceChannelsRequest,GetDiscreteChannelsResponse> {
    private readonly MonitorContext _context;

    public GetDiscreteChannelsEndpoint(MonitorContext context) {
        this._context = context;
    }

    public override async Task HandleAsync(GetDeviceChannelsRequest req, CancellationToken ct) {
        /*var discreteChannels = await this._context.Channels.OfType<DiscreteInput>()
            .Include(e => e.Alert)
            .ThenInclude(e => ((DiscreteAlert)e).AlertLevel)
            .ThenInclude(e => e.DeviceAction)
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);*/
        var discreteChannels = await this._context.Channels.OfType<DiscreteInput>()
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);
        var response = new GetDiscreteChannelsResponse() {
            DiscreteInputs=discreteChannels
        };
        await SendOkAsync(response, ct);
    }
}

[HttpGet("channels/virtual/{id:guid}"),AllowAnonymous]
public class GetVirtualChannelsEndpoint:Endpoint<GetDeviceChannelsRequest,GetVirtualChannelsResponse> {
    private readonly MonitorContext _context;

    public GetVirtualChannelsEndpoint(MonitorContext context) {
        this._context = context;
    }

    public override async Task HandleAsync(GetDeviceChannelsRequest req, CancellationToken ct) {
        /*var virtualChannels = await this._context.Channels.OfType<VirtualInput>()
            .Include(e => e.Alert)
            .ThenInclude(e => ((DiscreteAlert)e).AlertLevel)
            .ThenInclude(e => e.DeviceAction)
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);*/
        var virtualChannels = await this._context.Channels.OfType<VirtualInput>()
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);
        var response = new GetVirtualChannelsResponse() {
            VirtualInputs = virtualChannels
        };
        await SendOkAsync(response, ct);
    }
}

[HttpGet("channels/output/{id:guid}"),AllowAnonymous]
public class GetOutputChannelsEndpoint:Endpoint<GetDeviceChannelsRequest,GetOutputChannelsResponse> {
    private readonly MonitorContext _context;

    public GetOutputChannelsEndpoint(MonitorContext context) {
        this._context = context;
    }

    public override async Task HandleAsync(GetDeviceChannelsRequest req, CancellationToken ct) {
        /*var outputs = await this._context.Channels.OfType<DiscreteOutput>()
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);*/
        var outputChannels = await this._context.Channels.OfType<DiscreteOutput>()
            .Where(e => e.ModbusDeviceId == req.Id)
            .Select(e => e.ToDto())
            .ToListAsync(ct);
        var response = new GetOutputChannelsResponse() {
            OutputChannels = outputChannels
        };
        await SendOkAsync(response, ct);
    }
}


