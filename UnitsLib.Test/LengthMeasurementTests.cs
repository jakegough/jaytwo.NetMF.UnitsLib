using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class LengthMeasurementTests
	{
		[Test]
		public void length_meters_to_inches()
		{
			var foo = LengthMeasurement.FromMeters(0.0254);
			Assert.AreEqual(0.0254, foo.Meters);
			Assert.AreEqual(2.54, foo.Centimeters);
			Assert.AreEqual(25.4, foo.Millimeters);
			Assert.AreEqual(1, foo.Inches);
		}

		[Test]
		public void length_millimeters_centimeters_meters_kilometers()
		{
			var fromMeters = LengthMeasurement.FromMeters(1000);
			Assert.AreEqual(1000, fromMeters.Meters);
			Assert.AreEqual(100000, fromMeters.Centimeters);
			Assert.AreEqual(1000000, fromMeters.Millimeters);
			Assert.AreEqual(1, fromMeters.Kilometers);

			var fromMillimeters = LengthMeasurement.FromMillimeters(1000000);
			Assert.AreEqual(1000, fromMillimeters.Meters);
			Assert.AreEqual(100000, fromMillimeters.Centimeters);
			Assert.AreEqual(1000000, fromMillimeters.Millimeters);
			Assert.AreEqual(1, fromMillimeters.Kilometers);			
		}

		[Test]
		public void length_inches_feet_yards_miles()
		{
			var fromFeet = LengthMeasurement.FromFeet(5280);
			Assert.AreEqual(5280, fromFeet.Feet);
			Assert.AreEqual(1760, fromFeet.Yards);
			Assert.AreEqual(63360, fromFeet.Inches);
			Assert.AreEqual(1, fromFeet.Miles);

			var fromInches = LengthMeasurement.FromInches(63360);
			Assert.AreEqual(5280, fromInches.Feet);
			Assert.AreEqual(1760, fromInches.Yards);
			Assert.AreEqual(63360, fromInches.Inches);
			Assert.AreEqual(1, fromInches.Miles);
		}

		[Test]
		public void length_static_members()
		{
			Assert.AreEqual(0, LengthMeasurement.Zero.Meters);
			Assert.AreEqual(0, LengthMeasurement.Zero.Meters * 10);
			Assert.AreEqual(0, LengthMeasurement.Zero.Meters / 10);

			Assert.AreEqual(double.NaN, LengthMeasurement.None.Meters);
			Assert.AreEqual(double.NaN, LengthMeasurement.None.Meters * 10);
			Assert.AreEqual(double.NaN, LengthMeasurement.None.Meters / 10);

			Assert.AreEqual(double.PositiveInfinity, LengthMeasurement.Max.Meters);
			Assert.AreEqual(double.PositiveInfinity, LengthMeasurement.Max.Meters * 10);
			Assert.AreEqual(double.PositiveInfinity, LengthMeasurement.Max.Meters / 10);

			Assert.AreEqual(double.NegativeInfinity, LengthMeasurement.Min.Meters);
			Assert.AreEqual(double.NegativeInfinity, LengthMeasurement.Min.Meters * 10);
			Assert.AreEqual(double.NegativeInfinity, LengthMeasurement.Min.Meters / 10);
		}

		[Test]
		public void length_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = LengthMeasurement.FromMeters(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Meters, LengthMeasurement.Parse(testString).Meters);

			Assert.IsNull(LengthMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, LengthMeasurement.Parse("hello").Meters);
		}

		[Test]
		public void length_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(LengthMeasurement.FromMeters(2) == LengthMeasurement.FromMeters(1));
			Assert.IsFalse(LengthMeasurement.FromMeters(1) == LengthMeasurement.FromMeters(2));
			Assert.IsTrue(LengthMeasurement.FromMeters(1) == LengthMeasurement.FromMeters(1));

			Assert.IsTrue(LengthMeasurement.FromMeters(2) != LengthMeasurement.FromMeters(1));
			Assert.IsTrue(LengthMeasurement.FromMeters(1) != LengthMeasurement.FromMeters(2));
			Assert.IsFalse(LengthMeasurement.FromMeters(1) != LengthMeasurement.FromMeters(1));

			Assert.IsTrue(LengthMeasurement.FromMeters(2) > LengthMeasurement.FromMeters(1));
			Assert.IsFalse(LengthMeasurement.FromMeters(1) > LengthMeasurement.FromMeters(2));
			Assert.IsFalse(LengthMeasurement.FromMeters(1) > LengthMeasurement.FromMeters(1));

			Assert.IsTrue(LengthMeasurement.FromMeters(2) >= LengthMeasurement.FromMeters(1));
			Assert.IsFalse(LengthMeasurement.FromMeters(1) >= LengthMeasurement.FromMeters(2));
			Assert.IsTrue(LengthMeasurement.FromMeters(1) >= LengthMeasurement.FromMeters(1));

			Assert.IsFalse(LengthMeasurement.FromMeters(2) < LengthMeasurement.FromMeters(1));
			Assert.IsTrue(LengthMeasurement.FromMeters(1) < LengthMeasurement.FromMeters(2));
			Assert.IsFalse(LengthMeasurement.FromMeters(1) < LengthMeasurement.FromMeters(1));

			Assert.IsFalse(LengthMeasurement.FromMeters(2) <= LengthMeasurement.FromMeters(1));
			Assert.IsTrue(LengthMeasurement.FromMeters(1) <= LengthMeasurement.FromMeters(2));
			Assert.IsTrue(LengthMeasurement.FromMeters(1) <= LengthMeasurement.FromMeters(1));
		}

		[Test]
		public void length_multiply_divide_add_subtract()
		{
			Assert.AreEqual(LengthMeasurement.FromMeters(100),
				LengthMeasurement.FromMeters(50).Add(LengthMeasurement.FromMeters(50)));

			Assert.AreEqual(LengthMeasurement.FromMeters(50),
				LengthMeasurement.FromMeters(100).Subtract(LengthMeasurement.FromMeters(50)));

			Assert.AreEqual(LengthMeasurement.FromMeters(200),
				LengthMeasurement.FromMeters(100).MultiplyBy(2));

			Assert.AreEqual(LengthMeasurement.FromMeters(50),
				LengthMeasurement.FromMeters(100).DivideBy(2));
		}

		[Test]
		public void length_implicit_double_conversion()
		{
			Assert.AreEqual((double)LengthMeasurement.FromMeters(100), 100d);
			Assert.AreEqual(LengthMeasurement.FromMeters(100), (LengthMeasurement)100d);
		}
	}
}
