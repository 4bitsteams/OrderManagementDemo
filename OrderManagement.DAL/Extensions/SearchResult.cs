using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DAL.Extensions
{
    public class SearchResult<TValue> : Result
    {
        public TValue Value { get; set; }
        public int TotalRows { get; set; }
        public int PageRows { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public SearchResult(TValue value, int totalRows, bool success, string error) : base(success, error)
        {
            TotalRows = totalRows;
            Value = value;

        }
        public SearchResult(TValue value, int totalRows, int pageRows, bool success = false, string error = "") : base(success, error)
        {
            TotalRows = totalRows;
            PageRows = pageRows;
            Value = value;
        }
    }
}
