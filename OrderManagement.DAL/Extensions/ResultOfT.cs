using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DAL.Extensions
{
    public class Result<TValue> : Result
    {
        public TValue Value { get; set; }

        protected internal Result(TValue value, bool success, string message)
            : base(success, message)
        {
            Value = value;
        }
        protected internal Result(TValue value, bool success, string message, object data)
            : base(success, message, data)
        {
            Value = value;
        }
        protected internal Result(TValue value, bool success, string message, string redirectUrl)
            : base(success, message, redirectUrl)
        {
            Value = value;
        }
        protected internal Result(TValue value, bool success, bool hasRecord, string message)
        : base(success, hasRecord, message)
        {
            Value = value;
        }
        protected internal Result(TValue value, bool success, bool hasRecord, string message, string resultId)
        : base(success, hasRecord, message, resultId)
        {
            Value = value;
        }
        protected internal Result(TValue value, bool success, string message, int resultCount)
            : base(success, message, resultCount)
        {
            Value = value;
        }
        protected internal Result(TValue value, bool success, string message, int resultCount, string resultId)
            : base(success, message, resultCount, resultId)
        {
            Value = value;
        }
    }
    public class Result<TValue, TSrcResult> : Result
    {
        public TValue Value { get; set; }
        public TSrcResult SrcResult { get; set; }

        protected internal Result(TValue value, TSrcResult srcResult, bool success, string message)
            : base(success, message)
        {
            Value = value;
            SrcResult = srcResult;
        }
    }
}
