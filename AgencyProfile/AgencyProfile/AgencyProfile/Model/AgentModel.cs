using System.Collections.Generic;

namespace AgencyProfile.Model
{
    public class AgentDetails
    {
        public int Id { get; set; }
        public int AgentUserId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgencyName { get; set; }
        public string AgentNumber { get; set; }
        public string AgentUserName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressModel Address { get; set; }
        public string EmailAddress { get; set; }
        public string Languages { get; set; }
        public int TotalEmployees { get; set; }
        public int NoOfStaffAllLocation { get; set; }
        public string Awards { get; set; }
        public string Expertise { get; set; }
        public string Service { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GooglePlusUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string PictureUrl { get; set; }
        public List<BusinessHour> BusinessHours { get; set; }
        public AgentProfileData AgentProfile { get; set; }
        //public List<AwardModel> AwardLists { get; set; }
        //public List<ServiceModel> ServiceLists { get; set; }
        //public List<SpecializationsModel> ExpertiseLists { get; set; }

        public AgentDetails()
        {
            BusinessHours = new List<BusinessHour>();
            Address = new AddressModel();
            BusinessHours = new List<BusinessHour>();
            AgentProfile = new AgentProfileData();
            //AwardLists = new List<AwardModel>();
            //ServiceLists = new List<ServiceModel>();
            //ExpertiseLists = new List<SpecializationsModel>();
        }
    }

    public class AddressModel
    {
        public string Address1 { get; set; }

        //[Display(Name = "Address 2")]
        public string Address2 { get; set; }

        //[Required]
        public string City { get; set; }

        //[Required]
        public string State { get; set; }

        //[Display(Name = "ZIP Code")]
        //[Required]
        public string ZipCode { get; set; }
    }


    public class BusinessHour
    {
        public string DayOfTheWeek { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public bool IsAppointmentInd { get; set; }
        public bool IsClosedInd { get; set; }
        public bool LateHours { get; set; }
    }

    public class AgentProfileData
    {
        public int YearsExperience { get; set; }
        public string Expertise { get; set; }
        public string Expertise1 { get; set; }
        public string Expertise2 { get; set; }
        public string Expertise3 { get; set; }
        public string Awards { get; set; }
        public string Award1 { get; set; }
        public string Award2 { get; set; }
        public string Award3 { get; set; }
        public string Services { get; set; }
        public string Service1 { get; set; }
        public string Service2 { get; set; }
        public string Service3 { get; set; }
        public int DifferentiatorCode1 { get; set; }
        public int DifferentiatorCode2 { get; set; }
        public int DifferentiatorCode3 { get; set; }

        public List<TestimonialModel> Testimonials { get; set; }
        public List<DifferentiatorModel> Differentiators { get; set; }

        public byte[] ProfileImage { get; set; }

        public AgentProfileData()
        {

            Testimonials = new List<TestimonialModel>();
            Differentiators = new List<DifferentiatorModel>();
        }
    }

    public class TestimonialModel
    {
        public string Text { get; set; }
        public string From { get; set; }
    }

    public class DifferentiatorModel
    {
        public bool IsSelected { get; set; }
        public int TypeCode { get; set; }
        public string Description { get; set; }
    }
}