using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.People
{

    public class BaseResult 
    {
        public int StatusCode { get; set; }
        public string  Message { get; set; }
    }

    public class GetPersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int IranCityId { get; set; }
        public string? IranCityName { get; set; }

        public int IranStateId { get; set; }
        public string? IranStateName { get; set; }

    }
    public class SendPersonResponseDto
    {
        public int Id { get; set; }
    }
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IranCityId { get; set; }
        public int IranStateId { get; set; }
    }

}
