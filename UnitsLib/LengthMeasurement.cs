using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class LengthMeasurement : OverloadedMeasurementBase
	{
		// as defined in the NSIT Handbook 44
		// http://www.nist.gov/pml/wmd/pubs/upload/2012-hb44-final.pdf
		internal const double METERS_PER_FOOT = 0.3048;

		internal const double KILOMETERS_PER_MILE = METERS_PER_FOOT * FEET_PER_MILE / 1000;

		internal const double CENTIMETERS_PER_INCH = 2.54;
		internal const double INCHES_PER_FOOT = 12;
		internal const double FEET_PER_YARD = 3;
		internal const double FEET_PER_MILE = 5280;

		public static LengthMeasurement FromMeters(double meters)
		{
			return new LengthMeasurement(meters);
		}

		public static LengthMeasurement FromMillimeters(double millimeters)
		{
			var meters = DoubleMetricPrefixUtility.FromMilli(millimeters);
			return LengthMeasurement.FromMeters(meters);
		}

		public static LengthMeasurement FromInches(double inches)
		{
			var meters = (inches / INCHES_PER_FOOT) * METERS_PER_FOOT;
			return LengthMeasurement.FromMeters(meters);
		}

		public static LengthMeasurement FromFeet(double feet)
		{
			var meters = (feet * METERS_PER_FOOT);
			return LengthMeasurement.FromMeters(meters);
		}

		public static LengthMeasurement FromBasicUnits(double basicUnits)
		{
			return new LengthMeasurement(basicUnits);
		}

		private LengthMeasurement(double meters)
			: base(meters)
		{
		}

#if MF_FRAMEWORK_VERSION_V3_0 || MF_FRAMEWORK_VERSION_V4_0 || MF_FRAMEWORK_VERSION_V4_1
		private LengthMeasurement()
			: base()
		{
		}
#endif

		public double Meters { get { return BasicUnits; } }

		public double Millimeters { get { return (DoubleMetricPrefixUtility.ToMilli(Meters)); } }
		public double Centimeters { get { return (Meters * 100); } }
		public double Kilometers { get { return (DoubleMetricPrefixUtility.ToKilo(Meters)); } }
		public double Inches { get { return (Feet * INCHES_PER_FOOT); } }
		public double Feet { get { return (Meters / METERS_PER_FOOT); } }
		public double Yards { get { return (Feet / FEET_PER_YARD); } }
		public double Miles { get { return (Feet / FEET_PER_MILE); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static LengthMeasurement None = new LengthMeasurement(double.NaN);
#else
		public static LengthMeasurement None = new LengthMeasurement();
#endif
		public static LengthMeasurement Zero = new LengthMeasurement(0);
		public static LengthMeasurement Min = new LengthMeasurement(double.NegativeInfinity);
		public static LengthMeasurement Max = new LengthMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public LengthMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new LengthMeasurement(result);
		}

		public LengthMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new LengthMeasurement(result);
		}

		public LengthMeasurement Add(LengthMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new LengthMeasurement(result);
		}

		public LengthMeasurement Subtract(LengthMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new LengthMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static LengthMeasurement Parse(string value)
		{
			return TryParse(value) ?? LengthMeasurement.None;
		}

		public static LengthMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new LengthMeasurement(units);
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

			LengthMeasurement other = obj as LengthMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(LengthMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(LengthMeasurement a, LengthMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(LengthMeasurement a, LengthMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(LengthMeasurement a, LengthMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(LengthMeasurement a, LengthMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(LengthMeasurement a, LengthMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(LengthMeasurement a, LengthMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator LengthMeasurement(double value)
		{
			return new LengthMeasurement(value);
		}

		public static implicit operator double(LengthMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
