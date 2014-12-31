using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class SpeedMeasurementTests
	{
		[Test]
		public void speed_mph_kph()
		{
			var fromKph = SpeedMeasurement.FromKilometersPerHour(10d);
			Assert.AreEqual(6.21371, fromKph.MilesPerHour, .00001);
			Assert.AreEqual(10, fromKph.KilometersPerHour);

			var fromMph = SpeedMeasurement.FromMilesPerHour(6.21371);
			Assert.AreEqual(6.21371, fromMph.MilesPerHour);
			Assert.AreEqual(10, fromMph.KilometersPerHour, .00001);
		}

		[Test]
		public void speed_static_members()
		{
			Assert.AreEqual(0, SpeedMeasurement.Zero.KilometersPerHour);
			Assert.AreEqual(0, SpeedMeasurement.Zero.KilometersPerHour * 10);
			Assert.AreEqual(0, SpeedMeasurement.Zero.KilometersPerHour / 10);

			Assert.AreEqual(double.NaN, SpeedMeasurement.None.KilometersPerHour);
			Assert.AreEqual(double.NaN, SpeedMeasurement.None.KilometersPerHour * 10);
			Assert.AreEqual(double.NaN, SpeedMeasurement.None.KilometersPerHour / 10);

			Assert.AreEqual(double.PositiveInfinity, SpeedMeasurement.Max.KilometersPerHour);
			Assert.AreEqual(double.PositiveInfinity, SpeedMeasurement.Max.KilometersPerHour * 10);
			Assert.AreEqual(double.PositiveInfinity, SpeedMeasurement.Max.KilometersPerHour / 10);

			Assert.AreEqual(double.NegativeInfinity, SpeedMeasurement.Min.KilometersPerHour);
			Assert.AreEqual(double.NegativeInfinity, SpeedMeasurement.Min.KilometersPerHour * 10);
			Assert.AreEqual(double.NegativeInfinity, SpeedMeasurement.Min.KilometersPerHour / 10);
		}

		[Test]
		public void speed_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = SpeedMeasurement.FromKilometersPerHour(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.KilometersPerHour, SpeedMeasurement.Parse(testString).KilometersPerHour);

			Assert.IsNull(SpeedMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, SpeedMeasurement.Parse("hello").KilometersPerHour);
		}

		[Test]
		public void speed_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(2) == SpeedMeasurement.FromKilometersPerHour(1));
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(1) == SpeedMeasurement.FromKilometersPerHour(2));
			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(1) == SpeedMeasurement.FromKilometersPerHour(1));

			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(2) != SpeedMeasurement.FromKilometersPerHour(1));
			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(1) != SpeedMeasurement.FromKilometersPerHour(2));
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(1) != SpeedMeasurement.FromKilometersPerHour(1));

			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(2) > SpeedMeasurement.FromKilometersPerHour(1));
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(1) > SpeedMeasurement.FromKilometersPerHour(2));
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(1) > SpeedMeasurement.FromKilometersPerHour(1));

			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(2) >= SpeedMeasurement.FromKilometersPerHour(1));
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(1) >= SpeedMeasurement.FromKilometersPerHour(2));
			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(1) >= SpeedMeasurement.FromKilometersPerHour(1));

			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(2) < SpeedMeasurement.FromKilometersPerHour(1));
			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(1) < SpeedMeasurement.FromKilometersPerHour(2));
			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(1) < SpeedMeasurement.FromKilometersPerHour(1));

			Assert.IsFalse(SpeedMeasurement.FromKilometersPerHour(2) <= SpeedMeasurement.FromKilometersPerHour(1));
			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(1) <= SpeedMeasurement.FromKilometersPerHour(2));
			Assert.IsTrue(SpeedMeasurement.FromKilometersPerHour(1) <= SpeedMeasurement.FromKilometersPerHour(1));
		}

		[Test]
		public void speed_multiply_divide_add_subtract()
		{
			Assert.AreEqual(SpeedMeasurement.FromKilometersPerHour(100),
				SpeedMeasurement.FromKilometersPerHour(50).Add(SpeedMeasurement.FromKilometersPerHour(50)));

			Assert.AreEqual(SpeedMeasurement.FromKilometersPerHour(50),
				SpeedMeasurement.FromKilometersPerHour(100).Subtract(SpeedMeasurement.FromKilometersPerHour(50)));

			Assert.AreEqual(SpeedMeasurement.FromKilometersPerHour(200),
				SpeedMeasurement.FromKilometersPerHour(100).MultiplyBy(2));

			Assert.AreEqual(SpeedMeasurement.FromKilometersPerHour(50),
				SpeedMeasurement.FromKilometersPerHour(100).DivideBy(2));
		}

		[Test]
		public void speed_implicit_double_conversion()
		{
			Assert.AreEqual((double)SpeedMeasurement.FromKilometersPerHour(100), 100d);
			Assert.AreEqual(SpeedMeasurement.FromKilometersPerHour(100), (SpeedMeasurement)100d);
		}
	}
}
