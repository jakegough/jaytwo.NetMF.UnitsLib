using System;

namespace jaytwo.NetMF.UnitsLib
{
	public abstract class OverloadedMeasurementBase : IOverloadedMeasurement
	{
#if !MF_FRAMEWORK_VERSION_V4_2
		private bool _HasValue;
		public bool HasValue
		{
			get
			{
				return _HasValue;
			}
		}
#endif

		private double _BasicUnits;
		public double BasicUnits
		{
			get
			{
				return _BasicUnits;
			}
		}

		protected OverloadedMeasurementBase(double baseUnits)
		{
			_BasicUnits = baseUnits;
#if !MF_FRAMEWORK_VERSION_V4_2
			_HasValue = true;
#endif
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		protected OverloadedMeasurementBase()
		{
			_HasValue = false;
		}
#endif

		public static bool IsEqualTo(IOverloadedMeasurement a, IOverloadedMeasurement b)
		{
			if (System.Object.ReferenceEquals(a, b))
			{
				return true;
			}
			else if (((object)a == null) || ((object)b == null))
			{
				return false;
			}
			else
			{
#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
				return MeasurementHelpers.AreDoublesEqual(a.BasicUnits, b.BasicUnits);
#else
				return (a.HasValue == b.HasValue) && MeasurementHelpers.AreDoublesEqual(a.BasicUnits, b.BasicUnits);
#endif
			}
		}


		public static bool IsGreaterThan(IOverloadedMeasurement a, IOverloadedMeasurement b)
		{
			return a.BasicUnits > b.BasicUnits;
		}

		public static bool IsGreaterThanOrEqual(IOverloadedMeasurement a, IOverloadedMeasurement b)
		{
			return a.BasicUnits >= b.BasicUnits;
		}

		public static bool IsLessThan(IOverloadedMeasurement a, IOverloadedMeasurement b)
		{
			return a.BasicUnits < b.BasicUnits;
		}

		public static bool IsLessThanOrEqual(IOverloadedMeasurement a, IOverloadedMeasurement b)
		{
			return a.BasicUnits <= b.BasicUnits;
		}

		public static int GetHashCode(IOverloadedMeasurement value)
		{
#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
			return value.BasicUnits.GetHashCode();
#else
			return value.HasValue.GetHashCode() + value.BasicUnits.GetHashCode();
#endif
		}
	}
}
