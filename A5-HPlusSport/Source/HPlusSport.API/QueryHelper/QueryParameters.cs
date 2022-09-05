namespace HPlusSport.API.QueryHelper
{

    public class QueryParameters
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
    }

}
