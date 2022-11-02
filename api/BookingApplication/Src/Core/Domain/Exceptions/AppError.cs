
namespace Domain.Exceptions
{
    public class AppError
    {
        public string Error { get; set; }

        public AppError(string error)
        {
            this.Error = error;
        }
    }
}
