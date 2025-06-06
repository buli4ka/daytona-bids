using Application.DTOs.Vehicle;
using Application.DTOs.Vehicle.Commands;
using Application.DTOs.Vehicle.Queries;
using AutoMapper;
using Core.Entities.Models.Vehicle;

namespace Application.Mappers;

public class AutoMapperProfile: Profile
{
    
    // CreateMap<SourceT ---> DestinationT>();

    
    public AutoMapperProfile()
    {
        // Vehicle
        CreateMap<Vehicle, VehicleQuery>();
        CreateMap<CreateVehicleCommand, Vehicle>();
    }
    

}