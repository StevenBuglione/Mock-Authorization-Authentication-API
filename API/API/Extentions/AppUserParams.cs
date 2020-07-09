using System;
namespace API.Extentions
{
    public class AppUserParams
    {

        private const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
