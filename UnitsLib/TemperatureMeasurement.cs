using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class TemperatureMeasurement : OverloadedMeasurementBase
	{
		public const double ZERO_C_AS_KELVIN = 273.15;

		public static TemperatureMeasurement FromFahrenheit(double value)
		{
			var celsius = FarenheitToCelsius(value);
			return TemperatureMeasurement.FromCelsius(celsius);
		}

		public static TemperatureMeasurement FromCelsius(double value)
		{
			return new TemperatureMeasurement(value);
		}

		public static TemperatureMeasurement FromKelvin(double value)
		{
			var celsius = KelvinToCelsius(value);
			return TemperatureMeasurement.FromCelsius(celsius);
		}

		public static double CelsiusToKelvin(double celsius)
		{
			var result = (celsius + ZERO_C_AS_KELVIN);
			return result;
		}

		public static double KelvinToCelsius(double kelvin)
		{
			var result = (kelvin - ZERO_C_AS_KELVIN);
			return result;
		}

		public static double CelsiusToFarenheit(double celsius)
		{
			var result = ((celsius * 1.8) + 32);
			return result;
		}

		public static double FarenheitToCelsius(double farenheit)
		{
			var result = ((farenheit - 32) / 1.8);
			return result;
		}

		public static TemperatureMeasurement FromBasicUnits(double basicUnits)
		{
			return new TemperatureMeasurement(basicUnits);
		}

		private TemperatureMeasurement(double celsius)
			: base(celsius)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private TemperatureMeasurement()
			: base()
		{
		}
#endif

		public double Celsius { get { return BasicUnits; } }
		public double Fahrenheit { get { return CelsiusToFarenheit(Celsius); } }
		public double Kelvin { get { return (CelsiusToKelvin(Celsius)); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static TemperatureMeasurement None = new TemperatureMeasurement(double.NaN);
#else
		public static TemperatureMeasurement None = new TemperatureMeasurement();
#endif
		public static TemperatureMeasurement Min = new TemperatureMeasurement(double.NegativeInfinity);
		public static TemperatureMeasurement Max = new TemperatureMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public TemperatureMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new TemperatureMeasurement(result);
		}

		public TemperatureMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new TemperatureMeasurement(result);
		}

		public TemperatureMeasurement Add(TemperatureMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new TemperatureMeasurement(result);
		}

		public TemperatureMeasurement Subtract(TemperatureMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new TemperatureMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static TemperatureMeasurement Parse(string value)
		{
			return TryParse(value) ?? TemperatureMeasurement.None;
		}

		public static TemperatureMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new TemperatureMeasurement(units);
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

			TemperatureMeasurement other = obj as TemperatureMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(TemperatureMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(TemperatureMeasurement a, TemperatureMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(TemperatureMeasurement a, TemperatureMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(TemperatureMeasurement a, TemperatureMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(TemperatureMeasurement a, TemperatureMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(TemperatureMeasurement a, TemperatureMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(TemperatureMeasurement a, TemperatureMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator TemperatureMeasurement(double value)
		{
			return new TemperatureMeasurement(value);
		}

		public static implicit operator double(TemperatureMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}