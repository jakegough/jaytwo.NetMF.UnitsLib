using System;

namespace jaytwo.NetMF.UnitsLib
{

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1 && !NET30
	public static class DoubleMetricPrefixExtensions
	{
		public static double FromPico(this double value)
		{
			return DoubleMetricPrefixUtility.FromPico(value);
		}

		public static double ToPico(this double value)
		{
			return DoubleMetricPrefixUtility.ToPico(value);
		}

		public static double FromNano(this double value)
		{
			return DoubleMetricPrefixUtility.FromNano(value);
		}

		public static double ToNano(this double value)
		{
			return DoubleMetricPrefixUtility.ToNano(value);
		}

		public static double FromMicro(this double value)
		{
			return DoubleMetricPrefixUtility.FromMicro(value);
		}

		public static double ToMicro(this double value)
		{
			return DoubleMetricPrefixUtility.ToMicro(value);
		}

		public static double FromMilli(this double value)
		{
			return DoubleMetricPrefixUtility.FromMilli(value);
		}

		public static double ToMilli(this double value)
		{
			return DoubleMetricPrefixUtility.ToMilli(value);
		}

		public static double FromKilo(this double value)
		{
			return DoubleMetricPrefixUtility.FromKilo(value);
		}

		public static double ToKilo(this double value)
		{
			return DoubleMetricPrefixUtility.ToKilo(value);
		}

		public static double FromMega(this double value)
		{
			return DoubleMetricPrefixUtility.FromMega(value);
		}

		public static double ToMega(this double value)
		{
			return DoubleMetricPrefixUtility.ToMega(value);
		}

		public static double FromGiga(this double value)
		{
			return DoubleMetricPrefixUtility.FromGiga(value);
		}

		public static double ToGiga(this double value)
		{
			return DoubleMetricPrefixUtility.ToGiga(value);
		}

		public static double FromTera(this double value)
		{
			return DoubleMetricPrefixUtility.FromTera(value);
		}

		public static double ToTera(this double value)
		{
			return DoubleMetricPrefixUtility.ToTera(value);
		}

		public static double FromPeta(this double value)
		{
			return DoubleMetricPrefixUtility.FromPeta(value);
		}

		public static double ToPeta(this double value)
		{
			return DoubleMetricPrefixUtility.ToPeta(value);
		}
	}
#endif

}
