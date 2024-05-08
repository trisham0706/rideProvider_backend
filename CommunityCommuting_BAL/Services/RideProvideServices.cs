using CommunityCommuting_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Result;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using CommunityCommuting_DAL.Repository;



namespace CommunityCommuting_BAL.Service
{
    public class RideProvideService : IRideProvideService
    {

        private readonly IRideProvide _rideProvideRepository;
        private readonly ISmile _smile;
        public RideProvideService(IRideProvide rideProvideRepository, ISmile smile)
        {
            _rideProvideRepository = rideProvideRepository;
            _smile = smile;
        }


        public async Task<Output> CreateNewRideProvider(RideProvideDTO rideProviderDTO)
        {
            try
            {
                if (ValidateAge(rideProviderDTO.BirthDate) == false)
                {
                    return new Output()
                    {
                        Result = false,
                        errorMessage = "Age must be minimum of 18."
                    };
                }
                if (!IsValidPhoneNumber(rideProviderDTO.Phone))
                {
                    return new Output()
                    {
                        Result = false,
                        errorMessage = "Phone number must be 10 digits."
                    };
                }
                if (!IsValidEmail(rideProviderDTO.EmailId))
                {
                    return new Output()
                    {
                        Result = false,
                        errorMessage = "Email address should always have @cognizant.com"
                    };
                }
                if (!IsValidName(rideProviderDTO.FirstName, rideProviderDTO.LastName))
                {
                    return new Output()
                    {
                        Result = false,
                        errorMessage = "First name and last name should only have alphabets and last name must be minimum 3 characters long."
                    };
                }
                if (!IsValidDLNo(rideProviderDTO.DlNo))
                {
                    return new Output()
                    {
                        Result = false,
                        errorMessage = "drivingLicenceNumber must be 16 characters long it should including three  hypen(-)"
                    };
                }
                if (!ValidateAadharNumber(rideProviderDTO.Adharcard))
                {
                   return new Output()
                    {
                        Result = false,
                        errorMessage = "Aadhar No number should be 12 digit"
                    };
                }

                RideProvide actualModel = new RideProvide
                {
                    rpId = GeneratePPId(rideProviderDTO.LastName, rideProviderDTO.BirthDate),
                    firstName = rideProviderDTO.FirstName,
                    lastName = rideProviderDTO.LastName,
                    birthDate = rideProviderDTO.BirthDate,
                    phone = rideProviderDTO.Phone,
                    emailId = rideProviderDTO.EmailId,
                    adharcard = rideProviderDTO.Adharcard,
                    dlNo = rideProviderDTO.DlNo,
                    age = CalculateAge(rideProviderDTO.BirthDate),
                    validUpto = rideProviderDTO.ValidUpto,
                    status = "Registered"
                };

                var changes = await _rideProvideRepository.AddRider(actualModel);

                return new Output()
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<Output> UpdateNewRideProvider(string providerId, UpdateRideProvideDTO rideProviderDTO)
        {
            try
            {

                var obj = await _rideProvideRepository.FindRideProviderById(providerId);
                obj.status = rideProviderDTO.status;

                var changes = await _rideProvideRepository.UpdateRider(obj);

                return new Output()
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RideDTO?> GetRiderById(string rpId)
        {
            List<RideProvide> ans = await _rideProvideRepository.GetRiderDetails(rpId);
            RideDTO? l = null;
            foreach (RideProvide i in ans)
            {
                if (i.rpId == rpId)
                {
                    l = new RideDTO
                    {
                        rpId = i.rpId,
                        adharcard = i.adharcard,
                        birthDate = i.birthDate,
                        firstName = i.firstName,
                        lastName = i.lastName,
                        dlNo = i.dlNo,
                        emailId = i.emailId,
                        age = i.age,
                        status = i.status,
                        phone = i.phone,
                        validUpto = i.validUpto
                    };
                    break;
                }
            }
            return l;
        }



        private string GeneratePPId(string lastName, DateOnly birthDate)
        {
            string birthYear = birthDate.Year.ToString();
            return $"RP{lastName.Substring(0, 2)}{birthYear.Substring(birthYear.Length - 2)}";
        }

        private bool IsValidPhoneNumber(long phone) => phone.ToString().Length == 10;


        private bool ValidateAge(DateOnly birthDate)
        {
            // Calculate age based on birth date
            int currentYear = DateOnly.FromDateTime(DateTime.Today).Year;
            int birthYear = birthDate.Year;
            int age = currentYear - birthYear;
   
            if (age >= 18) return true;
            return false;
        }


        private bool IsValidEmail(string email)
        {
            return email.EndsWith("@cognizant.com");
        }
        private bool IsValidName(string firstName, string lastName)
        {
            return firstName.All(char.IsLetter) && lastName.All(char.IsLetter) && lastName.Length >= 3;
        }
        private bool IsValidDLNo(string dlNo)
        {
            return dlNo.Length == 16 && dlNo.Count(c => c == '-') == 3;
        }
        private bool ValidateAadharNumber(long aadharcard)
        {

            return aadharcard.ToString().Length == 12;
        }
        private bool IsValidStatus(string status)
        {
            return status == "Registered" || status == "Un-Registered";
        }

        private int CalculateAge(DateOnly birthDate)
        {
            // Calculate age based on birth date
            int currentYear = DateOnly.FromDateTime(DateTime.Today).Year;
            int birthYear = birthDate.Year;
            int age = currentYear - birthYear;
            return age;
        }
        private bool IsRegistered(string status)
        {
            if (status == "Registered")
            {
                Console.WriteLine("Ride provider has already scheduled a ride on the same date and time.");
                return false;
            }
            return true;
        }

    }
}
