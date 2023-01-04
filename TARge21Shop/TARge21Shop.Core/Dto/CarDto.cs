﻿using Microsoft.AspNetCore.Http;
using TARge21Shop.Core.Domain;

namespace TARge21Shop.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int CargoWeight { get; set; }
        public int FullTripsCount { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int EnginePower { get; set; }

    }
}