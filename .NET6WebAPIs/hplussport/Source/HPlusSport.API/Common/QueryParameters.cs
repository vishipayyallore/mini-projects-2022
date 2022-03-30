namespace HPlusSport.API.Common
{

    public class QueryParameters
    {
        private const int _maxSize = 50;

        private int _size = 10;

        public int Page { get; set; }

        public int Size
        {
            get { return _size; }

            set { _size = Math.Min(_maxSize, value); }
        }

    }

}
