namespace BlazingBudget.Domain.Enums;
public abstract class CreditCard : Enumeration<CreditCard>
{
    public static readonly CreditCard Discover = new DiscoverCard();
    public static readonly CreditCard Mastercard = new MastercardCard();
    public static readonly CreditCard Visa = new VisaCard();

    private CreditCard(int value, string name)
        : base(value, name)
    {
        //
    }

    public abstract double Discount { get; }

    private sealed class DiscoverCard : CreditCard
    {
        public DiscoverCard() : base(1, "Discover Card") { }

        public override double Discount => 0.10;
    }

    private sealed class MastercardCard : CreditCard
    {
        public MastercardCard() : base(2, "Mastercard") { }

        public override double Discount => 0.10;
    }

    private sealed class VisaCard : CreditCard
    {
        public VisaCard() : base(3, "Visa") { }

        public override double Discount => 0.10;
    }
}
