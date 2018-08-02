using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AlphaController : ApiController
    {
        List<HotelModel> HotelDetails = new List<HotelModel>()
        {
            new HotelModel {Id=1,Name="Paradise", CityCode=440027,Address="nagpur",NumberOfRoomsAvailable=2 },
            new HotelModel {Id=2,Name="Ashok", CityCode=4564512,Address="pune", NumberOfRoomsAvailable=5},
            new HotelModel{Id=3,Name="Sun and Sand", CityCode=467832,Address="mumbai", NumberOfRoomsAvailable=10}
        };
        [ HttpGet ]
        public IEnumerable<HotelModel> GetHotelDetails()
        {
            return HotelDetails;
        }
        public HotelModel SearchHotel(int Id)
        {
            HotelModel object1 = new HotelModel();
            for (int index = 0; index < HotelDetails.Count; index++)
            {
                if(HotelDetails[index].Id==Id)
                {
                    object1.Id = Id;
                    object1.Name = HotelDetails[index].Name;
                    object1.CityCode = HotelDetails[index].CityCode;
                    object1.Address = HotelDetails[index].Address;
                    object1.NumberOfRoomsAvailable = HotelDetails[index].NumberOfRoomsAvailable;
                    break;
                }
            }
            return object1;
        }
        [HttpPost]
        public HotelModel CreateHotel(int Id)
        {
            HotelModel object2 = new HotelModel();
            

            return object2;
        }

    }
        
}
