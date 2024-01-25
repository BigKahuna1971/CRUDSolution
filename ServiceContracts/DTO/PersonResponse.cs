using Entities;
using ServiceContracts.Enums;
namespace ServiceContracts.DTO

{

    /// Represents DTO class that is used as return
    /// type of most methods of Persons Service
    /// </summary>

    /// <summary>
    /// Compares the current object data with the parameter object
    /// </summary>
    /// <param name="obj">The PersonResponse Object to compare</param>
    /// <returns>True or false, indicating weather
    /// all person details are matched with the 
    /// specified parameter object</returns>


    public class PersonResponse
    {
        public Guid PersonID { get; set; }

        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public Guid? CountryID { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }

        public bool RecieveNewsLetters { get; set; }

        public double? Age { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(PersonResponse)) return false;

            PersonResponse person = (PersonResponse)obj;
            return PersonID == person.PersonID && PersonName ==
                person.PersonName && Email == person.Email && DateOfBirth ==
                person.DateOfBirth && Gender == person.Gender && CountryID ==
                person.CountryID && Address == person.Address &&
                RecieveNewsLetters == person.RecieveNewsLetters;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Person ID: {PersonID}, Person Name: {PersonName}, " +
                $"Email: {Email}, Date of Birth: {DateOfBirth?.ToString("dd mm yyyy")}, Gender: {Gender}, Country ID:" +
                $"{Country}, Address: {Address}, Recieve News Letters: {RecieveNewsLetters}";
        }

        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest()
            {
                PersonID = PersonID,
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
                Address = Address,
                CountryID = CountryID,
                ReceiveNewsLetters = RecieveNewsLetters
            };
        }

        public static object ReceiveNewsLetters()
        {
            throw new NotImplementedException();
        }
    }

    public static class PersonExtensions
    {
        /// <summary>
        /// An extension method to convert an object of Person class
        /// into PersonResponse class
        /// </summary>
        /// <param name="person">Returns object to convert</param>
        /// /// <returns>Returns the converted PersonResponse 
        /// object</param>


        public static PersonResponse ToPersonResponse(this Person person)
        {
            //person =>PersonResponse
            return new PersonResponse()
            {
                PersonID = person.PersonID,
                PersonName = person.PersonName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                RecieveNewsLetters = person.RecieveNewsLetters,
                Address = person.Address,
                CountryID = person.CountryID,
                Gender = person.Gender,
                Age =
                 (person.DateOfBirth != null) ? Math.Round((DateTime.Now -
                 person.DateOfBirth.Value).TotalDays / 365.25) : null
            };
        }
    }
}

