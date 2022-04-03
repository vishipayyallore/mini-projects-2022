namespace HPlusSport.API.Common
{

    /// <summary>
    /// 
    /// </summary>
    public class QueryParameters
    {
        private const int _maxSize = 50;

        private int _size = 10;

        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Size
        {
            get { return _size; }

            set { _size = Math.Min(_maxSize, value); }
        }

    }

}
