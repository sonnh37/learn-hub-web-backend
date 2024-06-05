namespace Smart_Thrive.ResponseModel
{
    public class BaseReponse
    {
      
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
