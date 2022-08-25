﻿using MonitoringSystem.Shared.Data.EntityDtos;

namespace MonitoringSystem.ConfigApi.Contracts.Responses.Update; 

public class UpdateAnalogLevelResponse {
    public AnalogLevelDto AnalogLevel { get; set; } = default!;
}

public class UpdateDiscreteLevelResponse{
    public DiscreteLevelDto DiscreteLevel { get; set; } = default!;
}