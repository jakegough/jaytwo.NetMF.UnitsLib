using System;

namespace jaytwo.NetMF.UnitsLib
{
	public static class MeasurementHelpers
	{
#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static bool AreDoublesEqual(double a, double b)
		{
			return (double.IsNegativeInfinity(a) && double.IsNegativeInfinity(b))
				|| (double.IsPositiveInfinity(a) && double.IsPositiveInfinity(b))
				|| (double.IsNaN(a) && double.IsNaN(b))
				|| (!double.IsNaN(a) && !double.IsNaN(b) && a == b);
		}
#else
		public static bool AreDoublesEqual(double a, double b)
		{
			return (a == b);
		}
#endif

	}
}
