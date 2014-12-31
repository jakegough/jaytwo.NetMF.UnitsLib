using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class WeightMeasurement : OverloadedMeasurementBase
	{
		// as defined in the NSIT Handbook 44
		// http://www.nist.gov/pml/wmd/pubs/upload/2012-hb44-final.pdf
		internal const double KILOGRAMS_PER_POUND = 0.45359237;

		// http://www.elivermore.com/conversions.htm
		internal const double NEWTONS_PER_POUND = 4.4482216152605;
		internal const double NEWTONS_PER_KILOGRAM = 9.80665;

		public static WeightMeasurement FromPressure(PressureMeasurement pressure, AreaMeasurement area)
		{
			var resultNewtons = pressure.Pa * area.SquareMeters;
			return WeightMeasurement.FromNewtons(resultNewtons);
		}

        public static WeightMeasurement FromTorque(MechanicalEnergyMeasurement torque, LengthMeasurement radius)
        {
            var resultNewtons = torque.NewtonMeters / radius.Meters;
            return WeightMeasurement.FromNewtons(resultNewtons);
        }

		public static WeightMeasurement FromPounds(double pounds)
		{
			var kilograms = (pounds * KILOGRAMS_PER_POUND);
			return WeightMeasurement.FromKilograms(kilograms);
		}

        public static WeightMeasurement FromTons(double tons)
        {
            var pounds = (tons * 2000d);
            return WeightMeasurement.FromPounds(pounds);
        }

		public static WeightMeasurement FromKilograms(double kilograms)
		{
			return new WeightMeasurement(kilograms);			
		}

		public static WeightMeasurement FromNewtons(double newtons)
		{
			var kilograms = (newtons / NEWTONS_PER_KILOGRAM);
			return WeightMeasurement.FromKilograms(kilograms);
		}

		public static WeightMeasurement FromBasicUnits(double basicUnits)
		{
			return new WeightMeasurement(basicUnits);
		}

		private WeightMeasurement(double kilograms)
			: base(kilograms)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private WeightMeasurement()
			: base()
		{
		}
#endif

		public double Kilograms { get { return BasicUnits; } }
		
		public double Grams { get { return (DoubleMetricPrefixUtility.FromKilo(Kilograms)); } }
		public double Newtons { get { return (Kilograms * NEWTONS_PER_KILOGRAM);} }
		public double MetricTons { get { return (Kilograms / 1000); } }
		public double Ounces { get { return (Pounds * 16); } }
		public double Pounds { get { return (Kilograms / KILOGRAMS_PER_POUND); } }		
		public double Tons { get { return (Pounds / 2000); } }
		public double Grains { get { return (Pounds * 7000); } }

#if MF_FRAMEWORK_VERSION_V4_2
		public static WeightMeasurement None = new WeightMeasurement(double.NaN);
#else
		public static WeightMeasurement None = new WeightMeasurement();
#endif
		public static WeightMeasurement Zero = new WeightMeasurement(0);
		public static WeightMeasurement Min = new WeightMeasurement(double.NegativeInfinity);
		public static WeightMeasurement Max = new WeightMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public WeightMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new WeightMeasurement(result);
		}

		public WeightMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new WeightMeasurement(result);
		}

		public WeightMeasurement Add(WeightMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new WeightMeasurement(result);
		}

		public WeightMeasurement Subtract(WeightMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new WeightMeasurement(result);
		}

#if MF_FRAMEWORK_VERSION_V4_2
		public static WeightMeasurement Parse(string value)
		{
			return TryParse(value) ?? WeightMeasurement.None;
		}

		public static WeightMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new WeightMeasurement(units);
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

			WeightMeasurement other = obj as WeightMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(WeightMeasurement other)
		{
			return ElectricalPowerMeasurement.IsEqualTo(this, other);
		}

		public static bool operator ==(WeightMeasurement a, WeightMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(WeightMeasurement a, WeightMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(WeightMeasurement a, WeightMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(WeightMeasurement a, WeightMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(WeightMeasurement a, WeightMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(WeightMeasurement a, WeightMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator WeightMeasurement(double value)
		{
			return new WeightMeasurement(value);
		}

		public static implicit operator double(WeightMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
