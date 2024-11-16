using System.Net;

namespace GestionInventarioAvanzado.Models.ApiResponses
{
    public class GeneralResponse
    {
        public int statusCode;
        public string Message { get; set; }
        public object Value { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }

        public GeneralResponse()
        {
            
        }
    }
}
