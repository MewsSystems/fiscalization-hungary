using System;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class ErrorResult
    {
        internal ErrorResult(string message, ResultErrorCode errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public string Message { get; }

        public ResultErrorCode ErrorCode { get; }

        internal static ErrorResult Map(Dto.GeneralErrorResponse response)
        {
            return new ErrorResult(
                message: response.result.message,
                errorCode: MapErrorCode(response.result.errorCode)
            );
        }

        internal static ResultErrorCode MapErrorCode(string errorCode)
        {
            switch (errorCode)
            {
                case "INVALID_SECURITY_USER":
                case "NOT_REGISTERED_CUSTOMER":
                case "INVALID_CUSTOMER":
                    return ResultErrorCode.InvalidCredentials;
                case "MAINTENANCE_MODE":
                    return ResultErrorCode.MaintenanceMode;
                default:
                    throw new NotImplementedException($"Error code: {errorCode} is not implemented.");
            }
        }
    }
}
