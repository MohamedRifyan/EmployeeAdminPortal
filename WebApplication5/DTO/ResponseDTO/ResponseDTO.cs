namespace WebApplication5.DTO.ResponseDTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        // Constructor to set Success and Message
        public ResponseDTO(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
            Data = null; // Default data is null
        }

        // Constructor to set Data
        public ResponseDTO(object data)
        {
            Success = true; // Success is true by default when data is provided
            Message = null; // Message is null by default when data is provided
            Data = data;
        }
    }
}
