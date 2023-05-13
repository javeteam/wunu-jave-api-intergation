namespace NBUStat.Data.Response {
    public class ErrorResponse<T> : IResponse<T> {

        public ErrorResponse(string errorMessage) {
            ErrorMessage = errorMessage;
        }

        public T Content {
            get => default;
        }

        public string ErrorMessage {
            get;
        }
    }
}