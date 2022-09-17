namespace HPlusSport.API.QueryHelper
{

    public class PagingQueryParameters
    {
        public int Page { get; set; }

        const int _maxSize = 20;

        private int _size = 10;

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }

        public string SortBy { get; set; } = "Id";

        private string _sortOrder = "asc";

        public string SortOrder
        {
            get
            {
                return _sortOrder;
            }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortOrder = value;
                }
            }
        }

    }

}
