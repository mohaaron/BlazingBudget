using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(converters:
    StronglyTypedIdConverter.TypeConverter
    | StronglyTypedIdConverter.SystemTextJson
    //| StronglyTypedIdConverter.EfCoreValueConverter
)]

namespace BlazingBudget.Domain.Aggregates.Debt
{
    [StronglyTypedId(converters: 
        StronglyTypedIdConverter.TypeConverter
        | StronglyTypedIdConverter.SystemTextJson
        //| StronglyTypedIdConverter.EfCoreValueConverter
    )]
    public partial struct DebtId { }
}
