using ToDoList.Models;

namespace ToDoList.Services
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public Result(bool success, T? data, string errorMessage) { 
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public Result() { }

        public static Result<T> SuccessResult(T data)
        { 
            return new Result<T> { Success = true, Data = data, ErrorMessage = string.Empty };
        }

        public static Result<T> ErrorResult(string errorMessage) 
        {
            return new Result<T> { Success = false, Data = default, ErrorMessage = errorMessage };
                
        }
    }
}
