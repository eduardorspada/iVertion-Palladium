using iVertion.Application.Validation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace iVertion.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ICollection<ErrorValidation>? Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation {Field = e.PropertyName, Message = e.ErrorMessage}).ToList()
            };
        }
        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation {Field = e.PropertyName, Message = e.ErrorMessage}).ToList()
            };
        }

        public static ResultService Fail(string message) => new() { IsSuccess = false, Message = message};
        public static ResultService<T> Fail<T>(string message) => new() { IsSuccess = false, Message = message};

        public static ResultService OK(string message) => new() { IsSuccess = true, Message = message};
        public static ResultService<T> OK<T>(T data) => new() { IsSuccess = true, Data = data};
    }
    public class ResultService<T> : ResultService
    {
        public T? Data { get; set; }
    }
}