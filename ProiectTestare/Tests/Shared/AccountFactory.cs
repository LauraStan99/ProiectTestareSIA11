using ProiectTestare.PageObjects.Register.InputData;

namespace ProiectTestare.Tests.Shared
{
    public class AccountFactory
    {
        public static NewAccountBo InvalidAccount()
        {
            return new NewAccountBo
            {
                Email = "laurastan1999@gmail.com",
                Password = "something",
                ConfirmPassword = "something else",
                Gender = GenderEnum.Female,
                BirthdayDay = "27",
                BirthdayMonth = MonthEnum.August,
                BirthdayYear = "1999",
                Weight = "57"
            };
        }
    }
}
