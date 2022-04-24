namespace day2
{
    public class Solutions
    {
        public static int Solve1(List<string> passwords)
        {
            //Valid Example 1-3 a: abcde
            var lsPasswordChecks = passwords
                .Select(p => {

                    var policy = p.Split(":").First();
                    var password = p.Split(":").Last().Trim();
                    var minNuber = int.Parse(policy.Split("-").First());
                    var maxNumber = int.Parse(policy.Split("-").Last().Split(" ").First());
                    var requiredChar = policy.Split("-").Last().Split(" ").Last();

                    return new { 
                        Policy = policy, 
                        Password = password, 
                        Valid = password.Count(x => x.ToString() == requiredChar) >= minNuber && password.Count(x => x.ToString() == requiredChar) <=  maxNumber };
                }); 

            return lsPasswordChecks.Where(x => x.Valid).Count();
        }


        public static int Solve2(List<string> passwords)
        {
            //Valid Example 1-3 a: abcde
            var lsPasswordChecks = passwords
                .Select(p => {

                    var policy = p.Split(":").First();
                    var password = p.Split(":").Last().Trim();
                    var matchedLocation = int.Parse(policy.Split("-").First());
                    var unMatchedLocation = int.Parse(policy.Split("-").Last().Split(" ").First());
                    var requiredChar = policy.Split("-").Last().Split(" ").Last();

                    return new { 
                        Policy = policy, 
                        Password = password, 
                        Valid = (password[matchedLocation - 1].ToString() == requiredChar  || password[unMatchedLocation - 1].ToString() == requiredChar) && 
                        !(password[matchedLocation - 1].ToString() == requiredChar  && password[unMatchedLocation - 1].ToString() == requiredChar) };
                }); 

            return lsPasswordChecks.Where(x => x.Valid).Count();
        }
    }
}