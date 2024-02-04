using FluentValidation.Results;

namespace application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException() : base("one or more validations oocurred")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        public ValidationErrorException(List<ValidationFailure> validationErrorExceptions) : this()
        {
            foreach (var error in validationErrorExceptions)
            {
                Errors.Add(error.ErrorMessage);
            }
        }


    }
}
