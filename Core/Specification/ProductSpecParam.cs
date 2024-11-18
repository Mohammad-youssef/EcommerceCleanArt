using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductSpecParam
    {
        public string Sort { get; set;}
        public int? BrandId { get; set;}
        public int? TypeId { get; set;}
        private const int PageMaxSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > PageMaxSize) ? PageMaxSize : value;
        }
        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
