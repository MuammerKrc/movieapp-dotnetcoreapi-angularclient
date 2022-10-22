using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class Response<TModel>
    {
        public bool IsSuccess { get; set; }
        public TModel Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public string Message = "";

        public bool ShowError = true;

        public int ErrorStatus = 0;

        public static Response<TModel> SuccessResponse(TModel data, string message = "")
        {
            return new Response<TModel>() { IsSuccess = true, Data = data, Message = message };
        }

        public static Response<NoResponse> SuccessResponse(string message = "")
        {
            return new Response<NoResponse>() { IsSuccess = true, Data = new NoResponse(), Message = message };
        }

        public static Response<NoResponse> ErrorResponse(string error, bool showError = true, int errorStatus = 500)
        {
            return new Response<NoResponse>()
            {
                IsSuccess = false,
                Errors = new List<string>() { error },
                Data = new NoResponse(),
                ErrorStatus = errorStatus,
                ShowError = true,
            };
        }
        public static Response<NoResponse> ErrorResponse(List<string> error, bool showError = true, int errorStatus = 500)
        {
            return new Response<NoResponse>()
            {
                IsSuccess = false,
                Errors = error,
                Data = new NoResponse(),
                ErrorStatus = errorStatus,
                ShowError = true,
            };
        }
    }

    public class NoResponse
    {

    }
}
