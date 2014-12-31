using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class TemperatureMeasurementTests
	{
		[Test]
		public void temperature_from_celsius()
		{
			var freezing = TemperatureMeasurement.FromCelsius(0);
			Assert.AreEqual(0, freezing.Celsius);
			Assert.AreEqual(32, freezing.Fahrenheit);
			Assert.AreEqual(273.15, freezing.Kelvin);

			var boiling = TemperatureMeasurement.FromCelsius(100);
			Assert.AreEqual(100, boiling.Celsius);
			Assert.AreEqual(212, boiling.Fahrenheit);
			Assert.AreEqual(373.15, boiling.Kelvin);
		}

		[Test]
		public void temperature_from_farenheit()
		{
			var freezing = TemperatureMeasurement.FromFahrenheit(32);
			Assert.AreEqual(32, freezing.Fahrenheit);
			Assert.AreEqual(0, freezing.Celsius);
			Assert.AreEqual(273.15, freezing.Kelvin);

			var boiling = TemperatureMeasurement.FromFahrenheit(212);
			Assert.AreEqual(212, boiling.Fahrenheit);
			Assert.AreEqual(100, boiling.Celsius);
			Assert.AreEqual(373.15, boiling.Kelvin);
		}

		[Test]
		public void temperature_static_members()
		{
			Assert.AreEqual(double.NaN, TemperatureMeasurement.None.Celsius);
			Assert.AreEqual(double.NaN, TemperatureMeasurement.None.Celsius * 10);
			Assert.AreEqual(double.NaN, TemperatureMeasurement.None.Celsius / 10);

			Assert.AreEqual(double.PositiveInfinity, TemperatureMeasurement.Max.Celsius);
			Assert.AreEqual(double.PositiveInfinity, TemperatureMeasurement.Max.Celsius * 10);
			Assert.AreEqual(double.PositiveInfinity, TemperatureMeasurement.Max.Celsius / 10);

			Assert.AreEqual(double.NegativeInfinity, TemperatureMeasurement.Min.Celsius);
			Assert.AreEqual(double.NegativeInfinity, TemperatureMeasurement.Min.Celsius * 10);
			Assert.AreEqual(double.NegativeInfinity, TemperatureMeasurement.Min.Celsius / 10);
		}

		[Test]
		public void temperature_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = TemperatureMeasurement.FromCelsius(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Celsius, TemperatureMeasurement.Parse(testString).Celsius);

			Assert.IsNull(TemperatureMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, TemperatureMeasurement.Parse("hello").Celsius);
		}

		[Test]
		public void temperature_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(2) == TemperatureMeasurement.FromCelsius(1));
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(1) == TemperatureMeasurement.FromCelsius(2));
			Assert.IsTrue(TemperatureMeasurement.FromCelsius(1) == TemperatureMeasurement.FromCelsius(1));

			Assert.IsTrue(TemperatureMeasurement.FromCelsius(2) != TemperatureMeasurement.FromCelsius(1));
			Assert.IsTrue(TemperatureMeasurement.FromCelsius(1) != TemperatureMeasurement.FromCelsius(2));
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(1) != TemperatureMeasurement.FromCelsius(1));

			Assert.IsTrue(TemperatureMeasurement.FromCelsius(2) > TemperatureMeasurement.FromCelsius(1));
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(1) > TemperatureMeasurement.FromCelsius(2));
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(1) > TemperatureMeasurement.FromCelsius(1));

			Assert.IsTrue(TemperatureMeasurement.FromCelsius(2) >= TemperatureMeasurement.FromCelsius(1));
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(1) >= TemperatureMeasurement.FromCelsius(2));
			Assert.IsTrue(TemperatureMeasurement.FromCelsius(1) >= TemperatureMeasurement.FromCelsius(1));

			Assert.IsFalse(TemperatureMeasurement.FromCelsius(2) < TemperatureMeasurement.FromCelsius(1));
			Assert.IsTrue(TemperatureMeasurement.FromCelsius(1) < TemperatureMeasurement.FromCelsius(2));
			Assert.IsFalse(TemperatureMeasurement.FromCelsius(1) < TemperatureMeasurement.FromCelsius(1));

			Assert.IsFalse(TemperatureMeasurement.FromCelsius(2) <= TemperatureMeasurement.FromCelsius(1));
			Assert.IsTrue(TemperatureMeasurement.FromCelsius(1) <= TemperatureMeasurement.FromCelsius(2));
			Assert.IsTrue(TemperatureMeasurement.FromCelsius(1) <= TemperatureMeasurement.FromCelsius(1));
		}

		[Test]
		public void temperature_multiply_divide_add_subtract()
		{
			Assert.AreEqual(TemperatureMeasurement.FromCelsius(100),
				TemperatureMeasurement.FromCelsius(50).Add(TemperatureMeasurement.FromCelsius(50)));

			Assert.AreEqual(TemperatureMeasurement.FromCelsius(50),
				TemperatureMeasurement.FromCelsius(100).Subtract(TemperatureMeasurement.FromCelsius(50)));

			Assert.AreEqual(TemperatureMeasurement.FromCelsius(200),
				TemperatureMeasurement.FromCelsius(100).MultiplyBy(2));

			Assert.AreEqual(TemperatureMeasurement.FromCelsius(50),
				TemperatureMeasurement.FromCelsius(100).DivideBy(2));
		}

		[Test]
		public void temperature_implicit_double_conversion()
		{
			Assert.AreEqual((double)TemperatureMeasurement.FromCelsius(100), 100d);
			Assert.AreEqual(TemperatureMeasurement.FromCelsius(100), (TemperatureMeasurement)100d);
		}
	}
}
