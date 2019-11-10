using CityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities;

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto
                {
                    Id = 1,
                    Name= "Agra",
                    Description = "The one with TajMahal",
                    PointsOfInterests = new List<PointsOfInterestsDto>()
                    {
                        new PointsOfInterestsDto(){
                            PId = 1,
                            Name= "Tajmahal",
                            Description = "Seven wonder"},
                        new PointsOfInterestsDto(
                    ){
                            PId = 2,
                            Name= "Redfort",
                            Description = "Red fort"}
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name= "Bangalore",
                    Description = "The one with IT Hub",
                     PointsOfInterests = new List<PointsOfInterestsDto>(){
                           new PointsOfInterestsDto(){
                            PId = 4,
                            Name= "GE",
                            Description = "R & D"}
                     }
                },
                new CityDto
                {
                    Id = 3,
                    Name= "Kolkata",
                    Description = "Howrah Bridge",
                     PointsOfInterests = new List<PointsOfInterestsDto>(){
                            new PointsOfInterestsDto(){
                            PId = 5,
                            Name= "Aquatica",
                            Description = "Water Sports"}
                     }
                }
            };

        }

        // immutable auto property initializers
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
    }
}
