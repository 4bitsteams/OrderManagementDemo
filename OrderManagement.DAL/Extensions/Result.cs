using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DAL.Extensions
{
    public class Result
    {
        public bool Success { get; }

        public bool HasRecord { get; }

        public string Message { get; }

        public object Data { get; }

        public int ResultCount { get; }

        public string ResultId { get; }

        public string RedirectUrl { get; }

        protected Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        protected Result(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        protected Result(bool success, bool hasRecord, string message)
        {
            Success = success;
            Message = message;
            HasRecord = hasRecord;
        }
        protected Result(bool success, bool hasRecord, string message, string resultId)
        {
            Success = success;
            Message = message;
            HasRecord = hasRecord;
            ResultId = resultId;
        }
        protected Result(bool success, string message, string redirectUrl)
        {
            Success = success;
            Message = message;
            RedirectUrl = redirectUrl;
        }
        protected Result(bool success, string message, int resultCount)
        {
            Success = success;
            Message = message;
            ResultCount = resultCount;
        }
        protected Result(bool success, string message, int resultCount, string resultId)
        {
            Success = success;
            Message = message;
            ResultCount = resultCount;
            ResultId = resultId;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }
        public static Result<TValue> Ok<TValue>(string message)
        {
            return new Result<TValue>(default, true, message);
        }
        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, null);
        }
        public static Result<TValue> Ok<TValue>(TValue value, string message)
        {
            return new Result<TValue>(value, true, message);
        }
        public static Result<TValue> Ok<TValue>(TValue value, string message, object data)
        {
            return new Result<TValue>(value, true, message, data);
        }
        public static Result<TValue> Ok<TValue>(TValue value, string message, string redirectUrl)
        {
            return new Result<TValue>(value, true, message, redirectUrl);
        }
        public static Result<TValue> Ok<TValue>(TValue value, string message, int resultCount, string resultId)
        {
            return new Result<TValue>(value, true, message, resultCount, resultId);
        }
        public static Result<TValue> Fail<TValue>(string message)
        {
            return new Result<TValue>(default, false, message);
        }
        public static Result<TValue> Fail<TValue>(TValue value, string message, object data)
        {
            return new Result<TValue>(value, false, message, data);
        }
        public static Result<TValue> Fail<TValue>(TValue value, string message)
        {
            return new Result<TValue>(value, false, message);
        }
        public static Result<TValue> Fail<TValue>(TValue value, string message, string redirectUrl)
        {
            return new Result<TValue>(value, false, message, redirectUrl);
        }
        public static Result<TValue, TSrcResult> Fail<TValue, TSrcResult>(TValue value, TSrcResult srcResult, string message)
        {
            return new Result<TValue, TSrcResult>(value, srcResult, true, message);
        }
        public static Result<TValue, TSrcResult> Ok<TValue, TSrcResult>(TValue value, TSrcResult srcResult, string message)
        {
            return new Result<TValue, TSrcResult>(value, srcResult, true, message);
        }


        public static Result<bool> Update()
        {
            return new Result<bool>(true, true, "Execution has been created successfully.");
        }
        public static Result<TValue> Update<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, "Record has been updated successfully.");
        }
        public static Result<TValue> Update<TValue>(TValue value, string message)
        {
            return new Result<TValue>(value, true, message);
        }
        public static Result<bool> Create()
        {
            return new Result<bool>(true, true, "Execution has been created successfully.");
        }
        public static Result<TValue> Create<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, "Record has been created successfully.");
        }
        public static Result<TValue> Create<TValue>(TValue value, string message)
        {
            return new Result<TValue>(value, true, message);
        }
        public static Result<bool> Exists()
        {
            return new Result<bool>(true, true, "Record already exists.");
        }
        public static Result<TValue> Exists<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, "Record already exists.");
        }
        public static Result<TValue> Exists<TValue>(TValue value, string message)
        {
            return new Result<TValue>(value, true, message);
        }
        public static Result<TValue> Exists<TValue>(TValue value, bool success, string message)
        {
            return new Result<TValue>(value, success, true, message);
        }
        public static Result<TValue> Exists<TValue>(TValue value, bool success, string message, string resultId)
        {
            return new Result<TValue>(value, success, true, message, resultId);
        }
        public static Result<TValue> Exists<TValue>(TValue value, bool success, bool hasRecord, string message)
        {
            return new Result<TValue>(value, success, hasRecord, message);
        }

        public static Result<TValue> Exists<TValue>(TValue value, bool success, bool hasRecord, string message, string resultId)
        {
            return new Result<TValue>(value, success, hasRecord, message, resultId);
        }
        public static Result<bool> Cancelled()
        {
            return new Result<bool>(true, true, "Execution has been cancelled.");
        }
        public static Result<TValue> Cancelled<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, "Execution has been cancelled.");
        }
        public static Result<TValue> Cancelled<TValue>(TValue value, string message)
        {
            return new Result<TValue>(value, true, message);
        }
    }
}
