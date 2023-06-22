using System;

namespace BMES_API_Project.Models.Shared
{
    public class BaseObject
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
