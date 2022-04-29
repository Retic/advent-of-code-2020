using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day4
{

    public class Passport
    {
        public string BirthYear { get; set; } //byr
        public string IssueYear { get; set; } //iyr
        public string ExpirationYear { get; set; } //eyr
        public string Height { get; set; } //hgt
        public string HairColor { get; set; } //hcl
        public string EyeColor { get; set; } //ecl
        public string PassportId { get; set; } //pid
        public string CountryId { get; set; } //cid


    }

    public class PassportService
    {
        public List<Passport> ParsePassportFromString(string rawData)
        {
            var rawPassports = PopulatePasswordFields(GetRawPassports(rawData));
            var passports = new List<List<KeyValuePair<string, string>>>();
            var lsPassports = new List<Passport>();

            foreach (var rawPassport in rawPassports)
            {
                var passKvp = rawPassport.SelectMany(l => l.Split(' ').Select(y => new KeyValuePair<string, string>(y.Split(':').First(), y.Split(':').Last()))).ToList();
                var passport = new Passport();

                foreach (var kvp in passKvp)
                {
                    switch (kvp.Key)
                    {
                        case "byr":
                            passport.BirthYear = kvp.Value;
                            break;
                        case "iyr":
                            passport.IssueYear = kvp.Value;
                            break;
                        case "eyr":
                            passport.ExpirationYear = kvp.Value;
                            break;
                        case "hgt":
                            passport.Height = kvp.Value;
                            break;
                        case "hcl":
                            passport.HairColor = kvp.Value;
                            break;
                        case "ecl":
                            passport.EyeColor = kvp.Value;
                            break;
                        case "pid":
                            passport.PassportId = kvp.Value;
                            break;
                        case "cid":
                            passport.CountryId = kvp.Value;
                            break;
                        default:
                            break;
                    }
                }

                lsPassports.Add(passport);
            }

            return lsPassports;
        }

        public List<string> GetRawPassports(string rawData)
        {
            var res = rawData.Split("\n\n").ToList();
            return res;
        }

        public List<string[]> PopulatePasswordFields(List<string> data)
        {
            var res = data.Select(l => l.Split("\n")).ToList();
            return res;
        }

        public bool IsValid(Passport p)
        {

            List<Func<Passport, bool>> validations = new List<Func<Passport, bool>>
            {
                (p => p.PassportId?.Count() == 9),
                (p => p.BirthYear?.Count() == 4 && int.Parse(p.BirthYear) >= 1920 && int.Parse(p.BirthYear) <= 2002),
                (p => p.IssueYear?.Count() == 4 && int.Parse(p.IssueYear) >= 2010 && int.Parse(p.IssueYear) <= 2020),
                (p => p.ExpirationYear?.Count() == 4 && int.Parse(p.ExpirationYear) >= 2020 && int.Parse(p.ExpirationYear) <= 2030),
                (p => ValidateHeight(p.Height)),
                (p => ValidateHairColor(p.HairColor)),
                (p => ValidateEyeColor(p.EyeColor)),
            };


            var isValid = !validations.Select(f => f.Invoke(p)).Any(b => !b);


            var hasRequiredFields = (!string.IsNullOrEmpty(p.BirthYear)
            && !string.IsNullOrEmpty(p.IssueYear)
            && !string.IsNullOrEmpty(p.ExpirationYear)
            && !string.IsNullOrEmpty(p.Height)
            && !string.IsNullOrEmpty(p.HairColor)
            && !string.IsNullOrEmpty(p.EyeColor)
            && !string.IsNullOrEmpty(p.PassportId)) && (!string.IsNullOrEmpty(p.CountryId) || string.IsNullOrEmpty(p.CountryId));

            Console.WriteLine($"Status: {hasRequiredFields} [{p.BirthYear},{p.IssueYear},{p.ExpirationYear},{p.Height},{p.HairColor},{p.EyeColor},{p.PassportId},{p.CountryId}]");




            return hasRequiredFields && isValid;
        }

        public bool ValidateHeight(string heightStr)
        {
            if (string.IsNullOrEmpty(heightStr))
                return false;  

            var unit = heightStr.Substring(heightStr.Length - 2);
            var hasValidUnit = unit == "cm" || unit == "in";
            var validHeight = false;


            if(hasValidUnit && unit == "in")
            {
                var height = int.Parse(heightStr.Substring(0, heightStr.Length - 2));
                validHeight = height >= 59 && height <= 76;
            }

            if (hasValidUnit && unit == "cm")
            {
                var height = int.Parse(heightStr.Substring(0, heightStr.Length - 2));
                validHeight = height >= 150 && height <= 193;
            }

            return hasValidUnit && validHeight;
        }

        public bool ValidateHairColor(string hairColor)
        {
            if (string.IsNullOrEmpty(hairColor))
                return false;

            return Regex.IsMatch(hairColor, "^#(?:[0-9a-f]{6})$");
        }

        public bool ValidateEyeColor(string eyeColor)
        {
            if (string.IsNullOrEmpty(eyeColor) || eyeColor.Length != 3)
                return false;

            var validHairColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return validHairColors.Contains(eyeColor);
        }

    }
}
