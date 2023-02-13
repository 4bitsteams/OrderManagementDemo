using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.Common
{
    public class SearchModel
    {
        public string SearchText { get; set; }

        public int Page { get; set; }

        public int Rows { get; set; }

        public bool ShowPageSizes { get; set; }

        public string Sort { get; set; }

        public string SortColumn
        {
            get
            {
                if (!string.IsNullOrEmpty(Sort))
                {
                    return Sort.Split(' ').ToList().First();
                }
                return "CreatedDate";
            }
        }


        public string SortOrder
        {
            get
            {
                if (!string.IsNullOrEmpty(Sort))
                {
                    return Sort.Split(' ').ToList().Skip(1).First().ToLower();
                }
                else
                {
                    return "desc";
                }
            }
        }

        public bool IsDescending
        {
            get
            {
                return SortOrder == "desc";
            }
        }


        public int GetCurrentPage()
        {
            if (Page < 1)
                return 1;
            return Page;
        }
    }
}
