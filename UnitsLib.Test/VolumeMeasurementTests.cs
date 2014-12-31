using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class VolumeMeasurementTests
	{
		[Test]
		public void volume_liters_to_gallons()
		{
			var fromGallons = VolumeMeasurement.FromGallons(1);
			Assert.AreEqual(1, fromGallons.Gallons);
			Assert.AreEqual(3.785411784, fromGallons.Liters);

			var fromLiters = VolumeMeasurement.FromLiters(3.785411784);
			Assert.AreEqual(1, fromLiters.Gallons);
			Assert.AreEqual(3.785411784, fromLiters.Liters);
		}

		[Test]
		public void volume_cubicinches_ounces_gallons()
		{
			var fromGallons = VolumeMeasurement.FromGallons(1);
			Assert.AreEqual(231, fromGallons.CubicInches);
			Assert.AreEqual(128, fromGallons.Ounces);
			Assert.AreEqual(1, fromGallons.Gallons);			
		}

		[Test]
		public void volume_liters_milliliters()
		{
			var fromLiters = VolumeMeasurement.FromLiters(1);
			Assert.AreEqual(1000, fromLiters.Milliliters);
			Assert.AreEqual(1, fromLiters.Liters);
		}

		[Test]
		public void volume_static_members()
		{
			Assert.AreEqual(0, VolumeMeasurement.Zero.Liters);
			Assert.AreEqual(0, VolumeMeasurement.Zero.Liters * 10);
			Assert.AreEqual(0, VolumeMeasurement.Zero.Liters / 10);

			Assert.AreEqual(double.NaN, VolumeMeasurement.None.Liters);
			Assert.AreEqual(double.NaN, VolumeMeasurement.None.Liters * 10);
			Assert.AreEqual(double.NaN, VolumeMeasurement.None.Liters / 10);

			Assert.AreEqual(double.PositiveInfinity, VolumeMeasurement.Max.Liters);
			Assert.AreEqual(double.PositiveInfinity, VolumeMeasurement.Max.Liters * 10);
			Assert.AreEqual(double.PositiveInfinity, VolumeMeasurement.Max.Liters / 10);

			Assert.AreEqual(double.NegativeInfinity, VolumeMeasurement.Min.Liters);
			Assert.AreEqual(double.NegativeInfinity, VolumeMeasurement.Min.Liters * 10);
			Assert.AreEqual(double.NegativeInfinity, VolumeMeasurement.Min.Liters / 10);
		}

		[Test]
		public void volume_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = VolumeMeasurement.FromLiters(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Liters, VolumeMeasurement.Parse(testString).Liters);

			Assert.IsNull(VolumeMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, VolumeMeasurement.Parse("hello").Liters);
		}

		[Test]
		public void volume_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(VolumeMeasurement.FromLiters(2) == VolumeMeasurement.FromLiters(1));
			Assert.IsFalse(VolumeMeasurement.FromLiters(1) == VolumeMeasurement.FromLiters(2));
			Assert.IsTrue(VolumeMeasurement.FromLiters(1) == VolumeMeasurement.FromLiters(1));

			Assert.IsTrue(VolumeMeasurement.FromLiters(2) != VolumeMeasurement.FromLiters(1));
			Assert.IsTrue(VolumeMeasurement.FromLiters(1) != VolumeMeasurement.FromLiters(2));
			Assert.IsFalse(VolumeMeasurement.FromLiters(1) != VolumeMeasurement.FromLiters(1));

			Assert.IsTrue(VolumeMeasurement.FromLiters(2) > VolumeMeasurement.FromLiters(1));
			Assert.IsFalse(VolumeMeasurement.FromLiters(1) > VolumeMeasurement.FromLiters(2));
			Assert.IsFalse(VolumeMeasurement.FromLiters(1) > VolumeMeasurement.FromLiters(1));

			Assert.IsTrue(VolumeMeasurement.FromLiters(2) >= VolumeMeasurement.FromLiters(1));
			Assert.IsFalse(VolumeMeasurement.FromLiters(1) >= VolumeMeasurement.FromLiters(2));
			Assert.IsTrue(VolumeMeasurement.FromLiters(1) >= VolumeMeasurement.FromLiters(1));

			Assert.IsFalse(VolumeMeasurement.FromLiters(2) < VolumeMeasurement.FromLiters(1));
			Assert.IsTrue(VolumeMeasurement.FromLiters(1) < VolumeMeasurement.FromLiters(2));
			Assert.IsFalse(VolumeMeasurement.FromLiters(1) < VolumeMeasurement.FromLiters(1));

			Assert.IsFalse(VolumeMeasurement.FromLiters(2) <= VolumeMeasurement.FromLiters(1));
			Assert.IsTrue(VolumeMeasurement.FromLiters(1) <= VolumeMeasurement.FromLiters(2));
			Assert.IsTrue(VolumeMeasurement.FromLiters(1) <= VolumeMeasurement.FromLiters(1));
		}

		[Test]
		public void volume_multiply_divide_add_subtract()
		{
			Assert.AreEqual(VolumeMeasurement.FromLiters(100),
				VolumeMeasurement.FromLiters(50).Add(VolumeMeasurement.FromLiters(50)));

			Assert.AreEqual(VolumeMeasurement.FromLiters(50),
				VolumeMeasurement.FromLiters(100).Subtract(VolumeMeasurement.FromLiters(50)));

			Assert.AreEqual(VolumeMeasurement.FromLiters(200),
				VolumeMeasurement.FromLiters(100).MultiplyBy(2));

			Assert.AreEqual(VolumeMeasurement.FromLiters(50),
				VolumeMeasurement.FromLiters(100).DivideBy(2));
		}

		[Test]
		public void volume_implicit_double_conversion()
		{
			Assert.AreEqual((double)VolumeMeasurement.FromLiters(100), 100d);
			Assert.AreEqual(VolumeMeasurement.FromLiters(100), (VolumeMeasurement)100d);
		}
	}
}
