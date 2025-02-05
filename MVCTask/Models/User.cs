using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MobileNo {  get; set; }
        public string Country { get; set; }
        public string State {  get; set; }
        public string City { get; set; }

        public int CountryId {  get; set; }
        public int StateId {  get; set; }
        public int CityId { get; set; }
        public string address { get; set;}

        public List<User> lstUser { get; set; }
        
    }
}