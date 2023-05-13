namespace NBUStat.Data.Response {
    public interface IResponse<T> {
        T Content { get; }
        string ErrorMessage { get; }
    }
}