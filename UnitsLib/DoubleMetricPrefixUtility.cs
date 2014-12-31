using System;

namespace jaytwo.NetMF.UnitsLib
{
	public static class DoubleMetricPrefixUtility
	{
		public static double FromPico(double value)
		{
			return value / 1000000000000;
		}

		public static double ToPico(double value)
		{
			return value * 1000000000000;
		}

		public static double FromNano(double value)
		{
			return value / 1000000000;
		}

		public static double ToNano(double value)
		{
			return value * 1000000000;
		}

		public static double FromMicro(double value)
		{
			return value / 1000000;
		}

		public static double ToMicro(double value)
		{
			return value * 1000000;
		}

		public static double FromMilli(double value)
		{
			return value / 1000;
		}

		public static double ToMilli(double value)
		{
			return value * 1000;
		}

		public static double FromKilo(double value)
		{
			return value * 1000;
		}

		public static double ToKilo(double value)
		{
			return value / 1000;
		}

		public static double FromMega(double value)
		{
			return value * 1000000;
		}

		public static double ToMega(double value)
		{
			return value / 1000000;
		}

		public static double FromGiga(double value)
		{
			return value * 1000000000;
		}

		public static double ToGiga(double value)
		{
			return value / 1000000000;
		}

		public static double FromTera(double value)
		{
			return value * 1000000000000;
		}

		public static double ToTera(double value)
		{
			return value / 1000000000000;
		}

		public static double FromPeta(double value)
		{
			return value * 1000000000000000;
		}

		public static double ToPeta(double value)
		{
			return value / 1000000000000000;
		}
	}
}
