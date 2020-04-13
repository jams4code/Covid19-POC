using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Application.Common.Models
{
    public class PagedData<T>
    {
        public ICollection<T> Data { get; set; }
        public Page Page { get; set; }
        public PagedData()
        {
            Data = new List<T>();
        }
    }
}
