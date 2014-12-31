using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class VolumeMeasurement : OverloadedMeasurementBase
	{
		internal const double CUBIC_INCHES_PER_GALLON = 231;
		internal const double OUNCES_PER_GALLON = 128;
		internal const double CUBIC_CENTIMETERS_PER_CUBIC_INCH = LengthMeasurement.CENTIMETERS_PER_INCH * LengthMeasurement.CENTIMETERS_PER_INCH * LengthMeasurement.CENTIMETERS_PER_INCH;
		internal const double LITERS_PER_GALLON = (CUBIC_CENTIMETERS_PER_CUBIC_INCH * CUBIC_INCHES_PER_GALLON) / (1000);

		public static VolumeMeasurement FromGallons(double gallons)
		{
			var liters = (gallons * LITERS_PER_GALLON);
			return VolumeMeasurement.FromLiters(liters);
		}

		public static VolumeMeasurement FromLiters(double liters)
		{
			return new VolumeMeasurement(liters);
		}

		public static VolumeMeasurement FromMilliliters(double milliliters)
		{
			var liters = (milliliters / 1000);
			return VolumeMeasurement.FromLiters(liters);
		}

		public static VolumeMeasurement FromBasicUnits(double basicUnits)
		{
			return new VolumeMeasurement(basicUnits);
		}

		private VolumeMeasurement(double liters)
			: base(liters)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private VolumeMeasurement()
			: base()
		{
		}
#endif

		public double Liters { get { return BasicUnits; } }
		public double Milliliters { get { return (Liters * 1000); } }
		public double Gallons { get { return (Liters / LITERS_PER_GALLON); } }
		public double CubicInches { get { return (Gallons * CUBIC_INCHES_PER_GALLON); } }
		public double Ounces { get { return (Gallons * OUNCES_PER_GALLON); } }

#if MF_FRAMEWORK_VERSION_V4_2
		public static VolumeMeasurement None = new VolumeMeasurement(double.NaN);
#else
		public static VolumeMeasurement None = new VolumeMeasurement();
#endif
		public static VolumeMeasurement Zero = new VolumeMeasurement(0);
		public static VolumeMeasurement Min = new VolumeMeasurement(double.NegativeInfinity);
		public static VolumeMeasurement Max = new VolumeMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public VolumeMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new VolumeMeasurement(result);
		}

		public VolumeMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new VolumeMeasurement(result);
		}

		public VolumeMeasurement Add(VolumeMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new VolumeMeasurement(result);
		}

		public VolumeMeasurement Subtract(VolumeMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new VolumeMeasurement(result);
		}

#if MF_FRAMEWORK_VERSION_V4_2
		public static VolumeMeasurement Parse(string value)
		{
			return TryParse(value) ?? VolumeMeasurement.None;
		}

		public static VolumeMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new VolumeMeasurement(units);
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

			VolumeMeasurement other = obj as VolumeMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(VolumeMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(VolumeMeasurement a, VolumeMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(VolumeMeasurement a, VolumeMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(VolumeMeasurement a, VolumeMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(VolumeMeasurement a, VolumeMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(VolumeMeasurement a, VolumeMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(VolumeMeasurement a, VolumeMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator VolumeMeasurement(double value)
		{
			return new VolumeMeasurement(value);
		}

		public static implicit operator double(VolumeMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
