namespace Northwind.Api.Data
{
    public record OrderInfo
    {
        public string Id { get; set; } = null!;

        public int InternalId => int.Parse(Id);

        public string? CustomerCode { get; set; }
        public int? EmployeeId { get; set; }

        /// <summary>
        /// The date when the order was placed.
        /// </summary>
        /// <remarks>
        /// This cannot track time, except upon the silent agreement that all date times are utc.
        /// </remarks>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The date at which the shipment should be completed (as per contract/ promisse).
        /// </summary>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// The date at which the shippment has begun.
        /// </summary>
        public DateTime? ShippedDate { get; set; }

        /// <summary>
        /// The target country of the order.
        /// </summary>
        public string? ShipCountry { get; set; }

        /// <summary>
        /// Indicates whether the shipment is an international one.
        /// </summary>
        public bool IsInternationalShipment { get; set; }
    }
}
