using System;
using System.Collections.Generic;

namespace FenixAlliance.ABS.SDK.Models.Interop
{
	public partial class SupportedInstruments
	{
		public Uri SupportedMethods { get; set; }
	}

	public partial class PaymentDetails
	{
		public Total Total { get; set; }
		public List<Total> DisplayItems { get; set; }
		public List<ShippingOption> ShippingOptions { get; set; }
	}

	public partial class Total
	{
		public string Label { get; set; }
		public Amount Amount { get; set; }
	}

	public partial class Amount
	{
		public string Currency { get; set; }
		public string Value { get; set; }
	}

	public partial class ShippingOption
	{
		public string Id { get; set; }
		public string Label { get; set; }
		public Amount Amount { get; set; }
		public bool Selected { get; set; }
	}
}
