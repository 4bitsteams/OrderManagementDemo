using OrderManagement.DAL.ApplicationDbContext;
using OrderManagement.DAL.Extensions;

namespace OrderManagement.DAL
{
    public  class BaseRepository
    {
        private readonly OrderDbContext _context;
        //private readonly ICacheManager _iCacheManager;
        public BaseRepository(OrderDbContext context/*, ICacheManager iCacheManager*/)
        {
            this._context = context;
            //_iCacheManager = iCacheManager;
        }

        //public BaseRepository(OrderDbContext context)
        //{
        //    this._context = context;
        //}
    }
}
