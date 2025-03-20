using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCHotel.Models;
using Bogus;

namespace HotelManagement.Bogus
{
    class ReservationFaker : Faker<Reservation>
    {
        public ReservationFaker() { }

        public static List<Reservation> GenerateData(int count = 10)
        {
            var faker = new Faker<Reservation>()
                //.RuleFor(r => r.Id, f => f.IndexFaker + 1)
                .RuleFor(r => r.FirstName, f => f.Name.FirstName())
                .RuleFor(r => r.LastName, f => f.Name.LastName())
                .RuleFor(r => r.BirthDay, f => f.Date.Past(30, DateTime.Now.AddYears(-18)).ToString("MM-dd-yyyy"))
                .RuleFor(r => r.Gender, f => f.PickRandom("Male", "Female"))
                .RuleFor(r => r.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.EmailAddress, f => f.Internet.Email())
                .RuleFor(r => r.NumberGuest, f => f.Random.Int(1, 5))
                .RuleFor(r => r.StreetAddress, f => f.Address.StreetAddress())
                .RuleFor(r => r.AptSuite, f => f.Random.Bool() ? f.Random.Int(1, 100).ToString() : "")
                .RuleFor(r => r.City, f => f.Address.City())
                .RuleFor(r => r.State, f => f.Address.StateAbbr())
                .RuleFor(r => r.ZipCode, f => f.Address.ZipCode())
                .RuleFor(r => r.RoomType, f => f.PickRandom("Single", "Double", "Suite"))
                .RuleFor(r => r.RoomFloor, f => f.Random.Int(1, 10).ToString())
                .RuleFor(r => r.RoomNumber, f => f.Random.Int(100, 999).ToString())
                .RuleFor(r => r.TotalBill, f => f.Random.Double(100, 5000))
                .RuleFor(r => r.PaymentType, f => f.PickRandom("Card", "Cash"))
                .RuleFor(r => r.CardType, f => f.PickRandom("Visa", "MasterCard", "Amex"))
                .RuleFor(r => r.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(r => r.CardExp, f => f.Date.Future(3).ToString("MM/yy"))
                .RuleFor(r => r.CardCvc, f => f.Random.Int(100, 999).ToString())
                .RuleFor(r => r.ArrivalTime, f => f.Date.Future(1))
                .RuleFor(r => r.LeavingTime, (f, r) => r.ArrivalTime.AddDays(f.Random.Int(1, 14)))
                .RuleFor(r => r.CheckIn, f => f.Random.Bool())
                .RuleFor(r => r.BreakFast, f => f.Random.Int(0, 3))
                .RuleFor(r => r.Lunch, f => f.Random.Int(0, 3))
                .RuleFor(r => r.Dinner, f => f.Random.Int(0, 3))
                .RuleFor(r => r.Cleaning, f => f.Random.Bool())
                .RuleFor(r => r.Towel, f => f.Random.Bool())
                .RuleFor(r => r.SSurprise, f => f.Random.Bool())
                .RuleFor(r => r.SupplyStatus, f => f.Random.Bool())
                .RuleFor(r => r.FoodBill, f => f.Random.Int(0, 300));

            return faker.Generate(count);
        }

    }
}
