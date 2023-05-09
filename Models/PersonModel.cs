using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcard.Models;

public record PersonModel(string first, string last, string FullName, string NickName, DateTime BirthDay, DateTime CreatedDate, string Email, string Phone, string Street, string City, int PostCode, string Country);
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dob
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }


    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int postcode { get; set; }
    }


    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Registered
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }

    public class Result
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Dob dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
    }

    public class Root
    {
        public List<Result> results { get; set; }
    }

    public class Street
    {
        public int number { get; set; }
        public string name { get; set; }
    }
