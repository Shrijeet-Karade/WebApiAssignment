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
        private static List<HotelModel> _HotelDetails = new List<HotelModel>()
        {
            new HotelModel {Id=1,Name="Paradise", CityCode=440027,Address="nagpur",NumberOfRoomsAvailable=2 },
            new HotelModel {Id=2,Name="Ashok", CityCode=4564512,Address="pune", NumberOfRoomsAvailable=5},
            new HotelModel{Id=3,Name="Sun and Sand", CityCode=467832,Address="mumbai", NumberOfRoomsAvailable=10}
        };
        [ HttpGet ]
        public IEnumerable<HotelModel> GetHotelDetails()
        {
            return _HotelDetails;

        }
        [HttpGet]
        public HotelModel SearchHotel(int Id)
        {
            HotelModel objectOfGET = new HotelModel();
            for (int index = 0; index < _HotelDetails.Count; index++)
            {
                if(_HotelDetails[index].Id==Id)
                {
                    objectOfGET.Id = Id;
                    objectOfGET.Name = _HotelDetails[index].Name;
                    objectOfGET.CityCode = _HotelDetails[index].CityCode;
                    objectOfGET.Address = _HotelDetails[index].Address;
                    objectOfGET.NumberOfRoomsAvailable = _HotelDetails[index].NumberOfRoomsAvailable;
                    break;
                }
            }
            return objectOfGET;
        }
        [HttpPost]
        public HotelModel CreateHotel(HotelModel objectOfPOST)
        {
           if(objectOfPOST!=null)
            {
                _HotelDetails.Add(objectOfPOST);
                return objectOfPOST;
            }
            else
            {
                objectOfPOST = null;
                return objectOfPOST;
            }
            
            
        }
        [HttpPut]
        public ReplyOfAPI UpdateHotelDetails(int id, HotelModel hotelModel)
        {
            ReplyOfAPI Reply = new ReplyOfAPI();
            try
            {
                HotelModel findHotelDetails = new HotelModel();
                findHotelDetails = _HotelDetails.Find(HotelName => HotelName.Id.Equals(id));
                if (findHotelDetails != null)
                {
                    findHotelDetails.Id = hotelModel.Id; 
                    findHotelDetails.CityCode = hotelModel.CityCode;
                    findHotelDetails.Address = hotelModel.Address;
                    findHotelDetails.NumberOfRoomsAvailable = hotelModel.NumberOfRoomsAvailable;
                    findHotelDetails.Name = hotelModel.Name;           
                }
            }
            catch (Exception ex)
            {
                Reply.ApiStatus = "Failed";
                Reply.StatusCode = StatusNumber.Failed;
                Reply.Message = ex.Message;
            }
            return Reply;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteHotel(int id)
        {
            HotelModel HotelToBeDeleted = new HotelModel();
            HotelToBeDeleted = _HotelDetails.Find(Hotel => Hotel.Id.Equals(id));
            if (HotelToBeDeleted != null)
            {
                _HotelDetails.RemoveAt(HotelToBeDeleted.Id - 1);
               return Request.CreateResponse(HttpStatusCode.Found, _HotelDetails);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid ID");
            }
        }

    }
        
}
