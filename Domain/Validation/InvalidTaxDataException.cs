namespace Domain.Validation
{
    public class InvalidTaxDataException : BaseDomainException
    {
        public InvalidTaxDataException()
        {
        }

        public InvalidTaxDataException(string error) => this.Error = error;
    }
}
