using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class CurrentMeasurement : OverloadedMeasurementBase
	{
		public static CurrentMeasurement FromAmps(double amps)
		{
			return new CurrentMeasurement(amps);
		}

		public static CurrentMeasurement FromMilliamps(double milliamps)
		{
			var amps = DoubleMetricPrefixUtility.FromMilli(milliamps);
			return CurrentMeasurement.FromAmps(amps);
		}

		public static CurrentMeasurement FromBasicUnits(double basicUnits)
		{
			return new CurrentMeasurement(basicUnits);
		}

		private CurrentMeasurement(double amps)
			: base(amps)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private CurrentMeasurement()
			: base()
		{
		}
#endif

		public double Amps { get { return BasicUnits; } }

		public double Milliamps { get { return DoubleMetricPrefixUtility.ToMilli(Amps); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static CurrentMeasurement None = new CurrentMeasurement(double.NaN);
#else
		public static CurrentMeasurement None = new CurrentMeasurement();
#endif

		public static CurrentMeasurement Zero = new CurrentMeasurement(0);
		public static CurrentMeasurement Min = new CurrentMeasurement(double.NegativeInfinity);
		public static CurrentMeasurement Max = new CurrentMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public CurrentMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new CurrentMeasurement(result);
		}

		public CurrentMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new CurrentMeasurement(result);
		}

		public CurrentMeasurement Add(CurrentMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new CurrentMeasurement(result);
		}

		public CurrentMeasurement Subtract(CurrentMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new CurrentMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static CurrentMeasurement Parse(string value)
		{
			return TryParse(value) ?? CurrentMeasurement.None;
		}

		public static CurrentMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new CurrentMeasurement(units);
			}
			else
			{
				return null;
			}
		}
#endif

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			CurrentMeasurement other = obj as CurrentMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(CurrentMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(CurrentMeasurement a, CurrentMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(CurrentMeasurement a, CurrentMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(CurrentMeasurement a, CurrentMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(CurrentMeasurement a, CurrentMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(CurrentMeasurement a, CurrentMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(CurrentMeasurement a, CurrentMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator CurrentMeasurement(double value)
		{
			return new CurrentMeasurement(value);
		}

		public static implicit operator double(CurrentMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
