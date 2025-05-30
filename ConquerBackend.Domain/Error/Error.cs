namespace ConquerBackend.Domain.Error
{
    public sealed class Errors : ErrorType
    {
        private Errors(string code, string message, int statusCode)
            : base(code, message, statusCode) { }

        public static readonly Errors NotFound = new("ERR_NOT_FOUND", "Không tìm thấy dữ liệu", 404);
        public static readonly Errors Validation = new("ERR_VALIDATION", "Dữ liệu không hợp lệ", 400);
        public static readonly Errors Unauthorized = new("ERR_UNAUTHORIZED", "Chưa xác thực", 401);
        public static readonly Errors Forbidden = new("ERR_FORBIDDEN", "Không có quyền truy cập", 403);
        public static readonly Errors Conflict = new("ERR_CONFLICT", "Dữ liệu bị trùng", 409);
        public static readonly Errors Unknown = new("ERR_UNKNOWN", "Lỗi không xác định", 500);
    }

    public abstract class ErrorType
    {
        public string Code { get; }
        public string Message { get; }
        public int StatusCode { get; }

        protected ErrorType(string code, string message, int statusCode)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }

        public override string ToString() => $"{Code}: {Message}";
    }


}
