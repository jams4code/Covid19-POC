using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Application.Common.Models
{
    public class Page
    {
        private int size = 10;

        public int Size
        {
            get => size;
            set
            {
                if (value == -1)
                {
                    size = 100;
                }
                else
                {
                    size = value;
                }
            }
        }

        public int TotalElements { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
        public int PageNumber { get; set; } = 0;

        public int GetSkip()
        {
            return PageNumber * Size;
        }
        public int GetTake()
        {
            return Size;
        }
        public void SetMetadata(int TotalContextElements)
        {
            TotalElements = TotalContextElements;
            TotalPages = TotalElements / Size;
        }
    }
}