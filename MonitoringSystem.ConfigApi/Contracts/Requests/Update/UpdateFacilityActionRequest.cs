﻿using MonitoringSystem.Shared.Data.EntityDtos;

namespace MonitoringSystem.ConfigApi.Contracts.Requests.Update; 

public class UpdateFacilityActionRequest {
    public FacilityActionDto FacilityAction { get; set; } = default!;
}

public class UpdateDeviceActionRequest {
    public DeviceActionDto DeviceAction { get; set; } = default!;
}