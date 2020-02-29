namespace GroceryExpressCart.Common.SeedWork
{
    public class PageParams
    {
        const int MAX_PAGE_SIZE = 50;
        private int pageSize = 10;
        public int PageNumber { get; } = 1;
        public PageParams()
        {

        }
        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
        }
        public PageParams(int pageSize, int pageNumber)
        {
            PageNumber = pageNumber == 0 ? PageNumber : pageNumber;
            PageSize = pageSize == 0 ? this.pageSize : pageSize;
        }
    }
}
