using System;

namespace HotelManagementSystem.Tests
{
    internal class GivenAttribute : Attribute
    {
        private string v;

        public GivenAttribute(string v)
        {
            this.v = v;
        }
    }
}