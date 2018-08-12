using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<int> ids = new List<int>();
        private int count = 0;
       

        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        [Given(@"User calls AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
            if(hotels!=null)
            {
                ids.Add(hotels[0].id);
            }
        }
       // [Given(@"Hotel with name '(.*)' should be present in the response")]
        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }

        [Given(@"User enters id '(.*)' for getting the result hotel and calls GetHotelById")]
        [When(@"User enters id '(.*)' for getting the result hotel and calls GetHotelById")]
        public void WhenUserEntersIdForGettingTheResultHotelAndCallsGetHotelById(int ID)
        {
           hotel = HotelsApiCaller.GetHotelById(ID);
        }

        [Then(@"Verify if all hotels are present")]
        public void ThenVerifyIfAllHotelsArePresent()
        {
            hotels = HotelsApiCaller.GetAllHotels();
            foreach(Hotel obj in hotels)
            {
                 foreach(int id in ids)
                {
                    if(id==obj.id)
                    {
                        count++;
                    }
                }
            }
            count.Should().Equals(ids.Count);
        }

       

        [When(@"User gets all hotels by GetAllHotels method")]
        public void WhenUserGetsAllHotelsByGetAllHotelsMethod()
        {
            HotelsApiCaller.GetAllHotels();
        }


        [Then(@"User gets the hotel By ID '(.*)'")]
        public void ThenUserGetsTheHotelByID(int ID)
        {
            hotel.Id.Should().Equals(ID);
        }

        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
