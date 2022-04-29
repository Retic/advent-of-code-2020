using System.Collections;
using System.Collections.Generic;
using Xunit;
using static day4.PassportService;

namespace day4.tests
{

    public static class GetPassportCases
    {
        public static Passport GetPassport1()
        {
            return new Passport
            {
                BirthYear = "1937",
                PassportId = "860033327",
                CountryId = "147",
                ExpirationYear = "2020",
                EyeColor = "gry",
                HairColor = "#fffffd",
                Height = "183cm",
                IssueYear = "2017"
            };
        }

        public static Passport GetPassport2()
        {
            return new Passport
            {
                BirthYear = "1929",
                PassportId = "028048884",
                CountryId = "350",
                ExpirationYear = "2023",
                EyeColor = "amb",
                HairColor = "#cfa07d",
                IssueYear = "2013"
            };
        }

        public static Passport GetPassport3()
        {
            return new Passport
            {
                BirthYear = "1931",
                PassportId = "760753108",
                CountryId = "350",
                ExpirationYear = "2024",
                EyeColor = "brn",
                HairColor = "#ae17e1",
                IssueYear = "2013",
                Height = "179cm"
            };
        }

        public static Passport GetPassport4()
        {
            return new Passport
            {
                PassportId = "166559648",
                ExpirationYear = "2025",
                EyeColor = "brn",
                HairColor = "#cfa07d",
                IssueYear = "2011",
                Height = "59in"
            };
        }

    }

    public class PassportValidationTests
    {
        [Fact]
        public void TestValidPassports()
        {
            var passportService = new PassportService();

            Assert.True(passportService.IsValid(GetPassportCases.GetPassport1()));
            Assert.True(passportService.IsValid(GetPassportCases.GetPassport3()));
        }

        [Fact]
        public void TestInvalidPassports()
        {
            var passportService = new PassportService();

            Assert.False(passportService.IsValid(GetPassportCases.GetPassport2()));
            Assert.False(passportService.IsValid(GetPassportCases.GetPassport4()));
        }
    }
}