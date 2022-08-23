﻿namespace MonitoringSystem.Shared.Data.EntityDtos; 

public class ModbusConfigDto {
    public Guid Id { get; set; }
    public int DiscreteInputs { get; set; }
    public int InputRegisters { get; set; }
    public int HoldingRegisters { get; set; }
    public int Coils { get; set; }
    public int SlaveAddress { get; set; }
}

public class NetworkConfigDto {
    public Guid Id { get; set; }
    public string? IpAddress { get; set; }
    public string? Dns { get; set; }
    public string? Mac { get; set; }
    public string? Gateway { get; set; }
    public int Port { get; set; }
}

public class ChannelMappingConfigDto {
    public Guid Id { get; set; }
    public ModbusRegister AlertRegisterType { get; set; }
    public int AlertStart { get; set; } = 0;
    public int AlertStop { get; set; } = 0;
    public ModbusRegister AnalogRegisterType { get; set; }
    public int AnalogStart { get; set; } = 0;
    public int AnalogStop { get; set; } = 0;
    public ModbusRegister DiscreteRegisterType { get; set; }
    public int DiscreteStart { get; set; } = 0;
    public int DiscreteStop { get; set; } = 0;
    public ModbusRegister VirtualRegisterType { get; set; }
    public int VirtualStart { get; set; } = 0;
    public int VirtualStop { get; set; } = 0;
}

public class ChannelAddress {
    public int Channel { get; set; }
    public int ModuleSlot { get; set; }
}

public class ModbusAddress {
    public int Address { get; set; }
    public int RegisterLength { get; set; }
    public ModbusRegister RegisterType { get; set; }
}