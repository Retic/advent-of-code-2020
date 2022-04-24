namespace day2
{

    public class PasswordData
    {
        public PasswordData(string input)
        {
            Policy = input.Split(":").First();
            Password = input.Split(":").Last().Trim();
            Digit1 = int.Parse(Policy.Split("-").First());
            Digit2 = int.Parse(Policy.Split("-").Last().Split(" ").First());
            RequiredChar = Policy.Split("-").Last().Split(" ").Last();
        }

        public string? Policy { get; set; }
        public string? Password { get; set; }
        public int Digit1 { get; set; }
        public int Digit2 { get; set; }
        public string? RequiredChar { get; set; }
    }

    public interface IValidator
    {
        bool Validate(string input);
    }

    public class Policy1Validator : IValidator
    {
        public bool Validate(string input)
        {
            var passwordData = new PasswordData(input);

            return passwordData.Password?.Count(x => x.ToString() == passwordData.RequiredChar) >= passwordData.Digit1
                && passwordData.Password?.Count(x => x.ToString() == passwordData.RequiredChar) <= passwordData.Digit2;
        }
    }

    public class Policy2Validator : IValidator
    {
        public bool Validate(string input)
        {
            var passwordData = new PasswordData(input);

            return passwordData.Password?[passwordData.Digit1 - 1].ToString() == passwordData.RequiredChar
                ^ passwordData.Password?[passwordData.Digit2 - 1].ToString() == passwordData.RequiredChar;
        }
    }

    public class Solutions
    {
        public static int Solve1(List<string> passwords)
        {
            //Valid Example 1-3 a: abcde
            var lsPasswordChecks = passwords
                .Select(p =>
                {

                    var policy = p.Split(":").First();
                    var password = p.Split(":").Last().Trim();
                    var minNuber = int.Parse(policy.Split("-").First());
                    var maxNumber = int.Parse(policy.Split("-").Last().Split(" ").First());
                    var requiredChar = policy.Split("-").Last().Split(" ").Last();

                    return new
                    {
                        Policy = policy,
                        Password = password,
                        Valid = password.Count(x => x.ToString() == requiredChar) >= minNuber && password.Count(x => x.ToString() == requiredChar) <= maxNumber
                    };
                });

            return lsPasswordChecks.Where(x => x.Valid).Count();
        }


        public static int Solve2(List<string> passwords)
        {
            //Valid Example 1-3 a: abcde
            var lsPasswordChecks = passwords
                .Select(p =>
                {

                    var policy = p.Split(":").First();
                    var password = p.Split(":").Last().Trim();
                    var matchedLocation = int.Parse(policy.Split("-").First());
                    var unMatchedLocation = int.Parse(policy.Split("-").Last().Split(" ").First());
                    var requiredChar = policy.Split("-").Last().Split(" ").Last();

                    return new
                    {
                        Policy = policy,
                        Password = password,
                        Valid = (password[matchedLocation - 1].ToString() == requiredChar || password[unMatchedLocation - 1].ToString() == requiredChar) &&
                        !(password[matchedLocation - 1].ToString() == requiredChar && password[unMatchedLocation - 1].ToString() == requiredChar)
                    };
                });

            return lsPasswordChecks.Where(x => x.Valid).Count();
        }
    }
}