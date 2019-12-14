using System;
using System.Collections.Generic;
using System.Linq;

namespace FenixAlliance.Tools.Helpers
{
    public class ListPaggingHelpers<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public ListPaggingHelpers(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static ListPaggingHelpers<T> Paginate(List<T> source, int pageIndex, int pageSize)
        {
            return new ListPaggingHelpers<T>(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), source.Count, pageIndex, pageSize);
        }
    }
}
