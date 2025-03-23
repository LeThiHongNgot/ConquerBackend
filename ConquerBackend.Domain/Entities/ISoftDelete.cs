using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
    public interface IHasDeleted : ISoftDelete
    {
        DateTime? DeleteDate { get; } // thời gian xóa được thiết lập từ hệ thông nên ko có set
    }
    public interface IDeleteFullAudited : IHasDeleted, ISoftDelete
    {
        string? DeletedBy { get; }
    }
}
