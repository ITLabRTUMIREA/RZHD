namespace RZHD.Models.Responses
{
    public class Response<T>
    {
        // True - is ok
        public bool Status { get; set; }
        // if false - error
        public string Error { get; set; }
        // content
        public T Content { get; set; }
    }
}
