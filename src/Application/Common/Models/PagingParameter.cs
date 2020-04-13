using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Application.Common.Models
{
    public class PagingParameter
    {
        public PagingParameter()
        {
            PageNumber = 0;
            PageSize = 10;
        }

        public PagingParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
