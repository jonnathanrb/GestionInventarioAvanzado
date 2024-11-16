using GestionInventarioAvanzado.Models.ApiResponses;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net;

namespace GestionInventarioAvanzado.Utils
{
    public class Utilities
    {
        public GeneralResponse SuccessResponse(object value = null)
        {
            return new GeneralResponse()
            {
                statusCode = 200,
                Message = "Success",
                Value = value,
                IsSuccess = true,
                ErrorMessages = null
            };
        }

        public GeneralResponse ErrorResponse(List<string> errorMessages = null)
        {
            return new GeneralResponse()
            {
                statusCode = 403,
                Message = "An error was ocurred",
                Value = null,
                IsSuccess = false,
                ErrorMessages = errorMessages
            };
        }

        public GeneralResponse NotFoundResponse(List<string> errorMessages = null)
        {
            return new GeneralResponse()
            {
                statusCode = 404,
                Message = "Item(s) not found",
                Value = null,
                IsSuccess = false,
                ErrorMessages = errorMessages
            };
        }

        public GeneralResponse ForbiddenResponse (List<string> errorMessages = null)
        {
            return new GeneralResponse()
            {
                statusCode = 401,
                Message = "Forbidden",
                Value = null,
                IsSuccess = false,
                ErrorMessages = errorMessages
            };
        }

        public static GeneralResponse ExceptionResponse(Exception e, List<string> errorMessages = null)
        {
            return new GeneralResponse()
            {
                Message = e.Message,
                Value = null,
                IsSuccess = false,
                ErrorMessages = errorMessages
            };
        }
    }
}
