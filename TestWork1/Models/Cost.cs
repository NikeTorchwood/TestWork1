using LinqToDB.Mapping;

namespace TestWork1.Models;

[Table("costs")]
public class Cost
{
    [Column("ID")]
    public Guid Id { get; set; }
    [Column("StartDate")]
    public DateOnly StartDate { get; set; }
    [Column("EndDate")]
    public DateOnly EndDate { get; set; }
    [Column("AdultsMainWeekday")]
    public decimal AdultsMainWeekday { get; set; }
    [Column("AdultsMainWeekend")]
    public decimal AdultsMainWeekend { get; set; }
    public decimal ChildrenMainWeekday { get; set; }
    public decimal ChildrenMainWeekend { get; set; }
    public decimal AdultsAdditionalWeekday { get; set; }
    public decimal AdultsAdditionalWeekend { get; set; }
    public decimal ChildrenAdditionalWeekday { get; set; }
    public decimal ChildrenAdditionalWeekend { get; set; }
}