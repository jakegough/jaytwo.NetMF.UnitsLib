using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class VoltageMeasurement : OverloadedMeasurementBase
	{
		public static VoltageMeasurement FromVolts(double volts)
		{
			return new VoltageMeasurement(volts);
		}

		public static VoltageMeasurement FromMillivolts(double millivolts)
		{
			var volts = DoubleMetricPrefixUtility.FromMilli(millivolts);
			return VoltageMeasurement.FromVolts(volts);
		}

		public static VoltageMeasurement FromBasicUnits(double basicUnits)
		{
			return new VoltageMeasurement(basicUnits);
		}

		private VoltageMeasurement(double volts)
			: base(volts)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private VoltageMeasurement()
			: base()
		{
		}
#endif

		public double Volts { get { return BasicUnits; } }

		public double Millivolts { get { return DoubleMetricPrefixUtility.ToMilli(Volts); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static VoltageMeasurement None = new VoltageMeasurement(double.NaN);
#else
		public static VoltageMeasurement None = new VoltageMeasurement();
#endif
		public static VoltageMeasurement Zero = new VoltageMeasurement(0);
		public static VoltageMeasurement Min = new VoltageMeasurement(double.NegativeInfinity);
		public static VoltageMeasurement Max = new VoltageMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public VoltageMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new VoltageMeasurement(result);
		}

		public VoltageMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new VoltageMeasurement(result);
		}

		public VoltageMeasurement Add(VoltageMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new VoltageMeasurement(result);
		}

		public VoltageMeasurement Subtract(VoltageMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new VoltageMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static VoltageMeasurement Parse(string value)
		{
			return TryParse(value) ?? VoltageMeasurement.None;
		}

		public static VoltageMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new VoltageMeasurement(units);
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

			VoltageMeasurement other = obj as VoltageMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(VoltageMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(VoltageMeasurement a, VoltageMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(VoltageMeasurement a, VoltageMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(VoltageMeasurement a, VoltageMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(VoltageMeasurement a, VoltageMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(VoltageMeasurement a, VoltageMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(VoltageMeasurement a, VoltageMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator VoltageMeasurement(double value)
		{
			return new VoltageMeasurement(value);
		}

		public static implicit operator double(VoltageMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
