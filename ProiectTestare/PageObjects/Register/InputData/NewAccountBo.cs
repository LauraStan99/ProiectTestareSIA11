namespace ProiectTestare.PageObjects.Register.InputData
{
    public class NewAccountBo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public GenderEnum Gender { get; set; }
        public string BirthdayDay { get; set; }
        public MonthEnum BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }
        public string Weight { get; set; }

    }
}
