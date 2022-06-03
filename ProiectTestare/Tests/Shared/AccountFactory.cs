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

        public static NewAccountBo ValidAccount()
        {
            return new NewAccountBo
            {
                Password = "something123456",
                ConfirmPassword = "something123456",
                Gender = GenderEnum.Female,
                BirthdayDay = "28",
                BirthdayMonth = MonthEnum.August,
                BirthdayYear = "1999",
                Weight = "57"
            };
        }
    }
}
