using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace FarmGuard_Backend.profile.Domain.Model.Aggregate;

public partial class Profile :IEntityWithCreatedUpdatedDate
{
    [Column("CreateAt")]
    public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdateAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
    
}