namespace Domain.Models
{
	public static class ModelConstants
	{
        public class TaxData
        {
            public const int MinFullNameLength = 2;
            public const int MaxFullNameLength = 30;
            public const string FullNameRegularExpression = @"^[A-Z][a-z]+\s[A-Z][a-z]+$";

            public const string SSNRegularExpression = @"^[0-9]{5,10}$";
        }
    }
}
