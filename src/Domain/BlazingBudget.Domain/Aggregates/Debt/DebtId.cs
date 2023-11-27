using StronglyTypedIds;

// TODO: Not working...
//[assembly: StronglyTypedIdDefaults(converters:
//    StronglyTypedIdConverter.TypeConverter
//    | StronglyTypedIdConverter.SystemTextJson
////| StronglyTypedIdConverter.EfCoreValueConverter
//)]

namespace BlazingBudget.Domain.Aggregates.Debt
{
    [StronglyTypedId]
    public partial struct DebtId { }
}
