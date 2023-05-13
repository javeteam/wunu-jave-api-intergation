namespace NBUStat.Data.Response
{
    public class SuccessResponse<T> : IResponse<T> {

        public SuccessResponse(T content) {
            Content = content;
        }

        public T Content { get; }
        public string ErrorMessage { get => null; }
       
    }
}