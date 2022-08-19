﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonitoringConfig.Data.Model;

#nullable disable

namespace MonitoringConfig.Data.Migrations
{
    [DbContext(typeof(MonitorContext))]
    partial class MonitorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MonitoringConfig.Data.Model.ActionOutput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeviceActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiscreteOutputId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OffLevel")
                        .HasColumnType("int");

                    b.Property<int>("OnLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceActionId");

                    b.HasIndex("DiscreteOutputId");

                    b.ToTable("ActionOutputs");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Alert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Bypass")
                        .HasColumnType("bit");

                    b.Property<int>("BypassResetTime")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<Guid>("InputChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InputChannelId")
                        .IsUnique();

                    b.ToTable("Alerts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Alert");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AlertLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Bypass")
                        .HasColumnType("bit");

                    b.Property<int>("BypassResetTime")
                        .HasColumnType("int");

                    b.Property<Guid?>("DeviceActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DeviceActionId");

                    b.ToTable("AlertLevels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AlertLevel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Bypass")
                        .HasColumnType("bit");

                    b.Property<bool>("Connected")
                        .HasColumnType("bit");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Display")
                        .HasColumnType("bit");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModbusDeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SystemChannel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModbusDeviceId");

                    b.ToTable("Channels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Channel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Database")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HubAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReadInterval")
                        .HasColumnType("int");

                    b.Property<int>("SaveInterval")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Device");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DeviceAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FacilityActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FirmwareId")
                        .HasColumnType("int");

                    b.Property<Guid>("MonitorBoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacilityActionId");

                    b.HasIndex("MonitorBoxId");

                    b.ToTable("DeviceActions");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.FacilityAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<bool>("EmailEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("EmailPeriod")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FacilityActions");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ModbusChannelRegisterMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlertRegisterType")
                        .HasColumnType("int");

                    b.Property<int>("AlertStart")
                        .HasColumnType("int");

                    b.Property<int>("AlertStop")
                        .HasColumnType("int");

                    b.Property<int>("AnalogRegisterType")
                        .HasColumnType("int");

                    b.Property<int>("AnalogStart")
                        .HasColumnType("int");

                    b.Property<int>("AnalogStop")
                        .HasColumnType("int");

                    b.Property<int>("DiscreteRegisterType")
                        .HasColumnType("int");

                    b.Property<int>("DiscreteStart")
                        .HasColumnType("int");

                    b.Property<int>("DiscreteStop")
                        .HasColumnType("int");

                    b.Property<Guid>("ModbusDeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VirtualRegisterType")
                        .HasColumnType("int");

                    b.Property<int>("VirtualStart")
                        .HasColumnType("int");

                    b.Property<int>("VirtualStop")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModbusDeviceId")
                        .IsUnique();

                    b.ToTable("ModbusChannelRegisterMaps");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ModbusConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Coils")
                        .HasColumnType("int");

                    b.Property<int>("DiscreteInputs")
                        .HasColumnType("int");

                    b.Property<int>("HoldingRegisters")
                        .HasColumnType("int");

                    b.Property<int>("InputRegisters")
                        .HasColumnType("int");

                    b.Property<Guid>("ModbusDeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModbusDeviceId")
                        .IsUnique();

                    b.ToTable("ModbusConfigurations");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.NetworkConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gateway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModbusDeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<int>("SlaveAddress")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModbusDeviceId")
                        .IsUnique();

                    b.ToTable("NetworkConfigurations");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Factor")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Offset")
                        .HasColumnType("float");

                    b.Property<double>("RecordThreshold")
                        .HasColumnType("float");

                    b.Property<double>("Slope")
                        .HasColumnType("float");

                    b.Property<string>("Units")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YAxisMin")
                        .HasColumnType("int");

                    b.Property<int>("YAxitMax")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AnalogAlert", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.Alert");

                    b.HasDiscriminator().HasValue("AnalogAlert");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AnalogLevel", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.AlertLevel");

                    b.Property<Guid>("AnalogAlertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("SetPoint")
                        .HasColumnType("float");

                    b.HasIndex("AnalogAlertId");

                    b.HasDiscriminator().HasValue("AnalogLevel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteAlert", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.Alert");

                    b.HasDiscriminator().HasValue("DiscreteAlert");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteLevel", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.AlertLevel");

                    b.Property<Guid>("DiscreteAlertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TriggerOn")
                        .HasColumnType("int");

                    b.HasIndex("DiscreteAlertId")
                        .IsUnique()
                        .HasFilter("[DiscreteAlertId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("DiscreteLevel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.InputChannel", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.Channel");

                    b.HasDiscriminator().HasValue("InputChannel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ModbusDevice", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.Device");

                    b.HasDiscriminator().HasValue("ModbusDevice");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.OutputChannel", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.Channel");

                    b.HasDiscriminator().HasValue("OutputChannel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AnalogInput", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.InputChannel");

                    b.Property<Guid?>("SensorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("SensorId");

                    b.HasDiscriminator().HasValue("AnalogInput");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteInput", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.InputChannel");

                    b.HasDiscriminator().HasValue("DiscreteInput");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteOutput", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.OutputChannel");

                    b.Property<int>("StartState")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscreteOutput");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.MonitorBox", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.ModbusDevice");

                    b.HasDiscriminator().HasValue("MonitorBox");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.VirtualInput", b =>
                {
                    b.HasBaseType("MonitoringConfig.Data.Model.InputChannel");

                    b.HasDiscriminator().HasValue("VirtualInput");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ActionOutput", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.DeviceAction", "DeviceAction")
                        .WithMany("ActionOutputs")
                        .HasForeignKey("DeviceActionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MonitoringConfig.Data.Model.DiscreteOutput", "DiscreteOutput")
                        .WithMany("ActionOutputs")
                        .HasForeignKey("DiscreteOutputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceAction");

                    b.Navigation("DiscreteOutput");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Alert", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.InputChannel", "InputChannel")
                        .WithOne("Alert")
                        .HasForeignKey("MonitoringConfig.Data.Model.Alert", "InputChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MonitoringConfig.Data.Model.ModbusAddress", "ModbusAddress", b1 =>
                        {
                            b1.Property<Guid>("AlertId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Address")
                                .HasColumnType("int");

                            b1.Property<int>("RegisterLength")
                                .HasColumnType("int");

                            b1.Property<int>("RegisterType")
                                .HasColumnType("int");

                            b1.HasKey("AlertId");

                            b1.ToTable("Alerts");

                            b1.WithOwner()
                                .HasForeignKey("AlertId");
                        });

                    b.Navigation("InputChannel");

                    b.Navigation("ModbusAddress");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AlertLevel", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.DeviceAction", "DeviceAction")
                        .WithMany("AlertLevels")
                        .HasForeignKey("DeviceActionId");

                    b.Navigation("DeviceAction");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Channel", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.ModbusDevice", "ModbusDevice")
                        .WithMany("Channels")
                        .HasForeignKey("ModbusDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MonitoringConfig.Data.Model.ModbusAddress", "ModbusAddress", b1 =>
                        {
                            b1.Property<Guid>("ChannelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Address")
                                .HasColumnType("int");

                            b1.Property<int>("RegisterLength")
                                .HasColumnType("int");

                            b1.Property<int>("RegisterType")
                                .HasColumnType("int");

                            b1.HasKey("ChannelId");

                            b1.ToTable("Channels");

                            b1.WithOwner()
                                .HasForeignKey("ChannelId");
                        });

                    b.OwnsOne("MonitoringConfig.Data.Model.ChannelAddress", "ChannelAddress", b1 =>
                        {
                            b1.Property<Guid>("ChannelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Channel")
                                .HasColumnType("int");

                            b1.Property<int>("ModuleSlot")
                                .HasColumnType("int");

                            b1.HasKey("ChannelId");

                            b1.ToTable("Channels");

                            b1.WithOwner()
                                .HasForeignKey("ChannelId");
                        });

                    b.Navigation("ChannelAddress");

                    b.Navigation("ModbusAddress");

                    b.Navigation("ModbusDevice");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DeviceAction", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.FacilityAction", "FacilityAction")
                        .WithMany("DeviceActions")
                        .HasForeignKey("FacilityActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MonitoringConfig.Data.Model.MonitorBox", "MonitorBox")
                        .WithMany("DeviceActions")
                        .HasForeignKey("MonitorBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacilityAction");

                    b.Navigation("MonitorBox");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ModbusChannelRegisterMap", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.ModbusDevice", "ModbusDevice")
                        .WithOne("ChannelRegisterMap")
                        .HasForeignKey("MonitoringConfig.Data.Model.ModbusChannelRegisterMap", "ModbusDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModbusDevice");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ModbusConfiguration", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.ModbusDevice", "ModbusDevice")
                        .WithOne("ModbusConfiguration")
                        .HasForeignKey("MonitoringConfig.Data.Model.ModbusConfiguration", "ModbusDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModbusDevice");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.NetworkConfiguration", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.ModbusDevice", "ModbusDevice")
                        .WithOne("NetworkConfiguration")
                        .HasForeignKey("MonitoringConfig.Data.Model.NetworkConfiguration", "ModbusDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModbusDevice");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AnalogLevel", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.AnalogAlert", "AnalogAlert")
                        .WithMany("AlertLevels")
                        .HasForeignKey("AnalogAlertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnalogAlert");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteLevel", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.DiscreteAlert", "DiscreteAlert")
                        .WithOne("AlertLevel")
                        .HasForeignKey("MonitoringConfig.Data.Model.DiscreteLevel", "DiscreteAlertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DiscreteAlert");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AnalogInput", b =>
                {
                    b.HasOne("MonitoringConfig.Data.Model.Sensor", "Sensor")
                        .WithMany("AnalogInputs")
                        .HasForeignKey("SensorId");

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DeviceAction", b =>
                {
                    b.Navigation("ActionOutputs");

                    b.Navigation("AlertLevels");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.FacilityAction", b =>
                {
                    b.Navigation("DeviceActions");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.Sensor", b =>
                {
                    b.Navigation("AnalogInputs");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.AnalogAlert", b =>
                {
                    b.Navigation("AlertLevels");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteAlert", b =>
                {
                    b.Navigation("AlertLevel");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.InputChannel", b =>
                {
                    b.Navigation("Alert");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.ModbusDevice", b =>
                {
                    b.Navigation("ChannelRegisterMap");

                    b.Navigation("Channels");

                    b.Navigation("ModbusConfiguration");

                    b.Navigation("NetworkConfiguration");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.DiscreteOutput", b =>
                {
                    b.Navigation("ActionOutputs");
                });

            modelBuilder.Entity("MonitoringConfig.Data.Model.MonitorBox", b =>
                {
                    b.Navigation("DeviceActions");
                });
#pragma warning restore 612, 618
        }
    }
}
