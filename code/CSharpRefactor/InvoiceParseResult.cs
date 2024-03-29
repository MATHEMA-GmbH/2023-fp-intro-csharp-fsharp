namespace CSharpRefactor
{
    public class InvoiceParseResult
    {
        public readonly int Id;
        public readonly decimal? Amount;
        public readonly decimal? DiscountedAmount;
        public readonly string ErrorText;

        public InvoiceParseResult(int id, decimal? amount, decimal? discountedAmount)
        {
            Id = id;
            Amount = amount;
            DiscountedAmount = discountedAmount;
            ErrorText = null;
        }

        public InvoiceParseResult(int id, string errorText)
        {
            Id = id;
            Amount = null;
            DiscountedAmount = null;
            ErrorText = errorText;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();

                // Suitable nullity checks etc, of course :)
                if (Amount.HasValue)
                {
                    hash = hash * 23 + Amount.Value.GetHashCode();
                }

                if (DiscountedAmount.HasValue)
                {
                    hash = hash * 23 + DiscountedAmount.Value.GetHashCode();
                }

                if (ErrorText != null)
                {
                    hash = hash * 23 + ErrorText.GetHashCode();
                }
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is not InvoiceParseResult item)
            {
                return false;
            }

            return
                Id.Equals(item.Id)
                && (Amount.HasValue && item.Amount.HasValue && Amount.Equals(item.Amount))
                || (!Amount.HasValue && !item.Amount.HasValue)
                && (DiscountedAmount.HasValue && item.DiscountedAmount.HasValue && DiscountedAmount.Equals(item.DiscountedAmount))
                || (!DiscountedAmount.HasValue && !item.DiscountedAmount.HasValue)
                && ErrorText.Equals(item.ErrorText);
        }
    }
}