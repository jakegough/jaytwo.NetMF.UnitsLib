using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class AreaMeasurementTests
	{
		[Test]
		public void area_feet_to_meters()
		{
			var foo = AreaMeasurement.FromSquareMeters(0.09290304);
			Assert.AreEqual(1, foo.SquareFeet);
		}

		[Test]
		public void area_feet_to_acres()
		{
			var foo = AreaMeasurement.FromSquareFeet(43560);
			Assert.AreEqual(43560, foo.SquareFeet);
			Assert.AreEqual(1, foo.Acres);
		}

		[Test]
		public void area_inches_feet_yards_miles()
		{
			var fromInches = AreaMeasurement.FromSquareInches(4014489600);
			Assert.AreEqual(4014489600, fromInches.SquareInches);
			Assert.AreEqual(27878400, fromInches.SquareFeet);
			Assert.AreEqual(3097600, fromInches.SquareYards);
			Assert.AreEqual(1, fromInches.SquareMiles);

			var fromFeet = AreaMeasurement.FromSquareFeet(27878400);
			Assert.AreEqual(4014489600, fromFeet.SquareInches);
			Assert.AreEqual(27878400, fromFeet.SquareFeet);
			Assert.AreEqual(3097600, fromFeet.SquareYards);
			Assert.AreEqual(1, fromFeet.SquareMiles);
		}

		[Test]
		public void area_millimeters_centimeters_meters_kilometers()
		{
			var fromMeters = AreaMeasurement.FromSquareMeters(1);
			Assert.AreEqual(1000000, fromMeters.SquareMillimeters);
			Assert.AreEqual(10000, fromMeters.SquareCentimeters);
			Assert.AreEqual(1, fromMeters.SquareMeters);
			Assert.AreEqual(0.000001, fromMeters.SquareKilometers);
		}

		[Test]
		public void area_circle()
		{
			var diameter = LengthMeasurement.FromMeters(2);
			var fromDiameter = AreaMeasurement.FromCircleDiameter(diameter);
			Assert.AreEqual(Math.PI, fromDiameter.SquareMeters);

			var radius = LengthMeasurement.FromMeters(1);
			var fromRadius = AreaMeasurement.FromCircleRadius(radius);
			Assert.AreEqual(Math.PI, fromRadius.SquareMeters);

			var fromRadiusMeters = AreaMeasurement.FromCircleRadiusMeters(1);
			Assert.AreEqual(Math.PI, fromRadiusMeters.SquareMeters);
		}

		[Test]
		public void area_static_members()
		{
			Assert.AreEqual(0, AreaMeasurement.Zero.SquareMeters);
			Assert.AreEqual(0, AreaMeasurement.Zero.SquareMeters * 10);
			Assert.AreEqual(0, AreaMeasurement.Zero.SquareMeters / 10);

			Assert.AreEqual(double.NaN, AreaMeasurement.None.SquareMeters);
			Assert.AreEqual(double.NaN, AreaMeasurement.None.SquareMeters * 10);
			Assert.AreEqual(double.NaN, AreaMeasurement.None.SquareMeters / 10);

			Assert.AreEqual(double.PositiveInfinity, AreaMeasurement.Max.SquareMeters);
			Assert.AreEqual(double.PositiveInfinity, AreaMeasurement.Max.SquareMeters * 10);
			Assert.AreEqual(double.PositiveInfinity, AreaMeasurement.Max.SquareMeters / 10);

			Assert.AreEqual(double.NegativeInfinity, AreaMeasurement.Min.SquareMeters);
			Assert.AreEqual(double.NegativeInfinity, AreaMeasurement.Min.SquareMeters * 10);
			Assert.AreEqual(double.NegativeInfinity, AreaMeasurement.Min.SquareMeters / 10);
		}

		[Test]
		public void area_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = AreaMeasurement.FromSquareMeters(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.SquareMeters, AreaMeasurement.Parse(testString).SquareMeters);
			
			Assert.IsNull(AreaMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, AreaMeasurement.Parse("hello").SquareMeters);
		}

		[Test]
		public void area_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(2) == AreaMeasurement.FromSquareMeters(1));
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(1) == AreaMeasurement.FromSquareMeters(2));
			Assert.IsTrue(AreaMeasurement.FromSquareMeters(1) == AreaMeasurement.FromSquareMeters(1));

			Assert.IsTrue(AreaMeasurement.FromSquareMeters(2) != AreaMeasurement.FromSquareMeters(1));
			Assert.IsTrue(AreaMeasurement.FromSquareMeters(1) != AreaMeasurement.FromSquareMeters(2));
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(1) != AreaMeasurement.FromSquareMeters(1));

			Assert.IsTrue(AreaMeasurement.FromSquareMeters(2) > AreaMeasurement.FromSquareMeters(1));
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(1) > AreaMeasurement.FromSquareMeters(2));
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(1) > AreaMeasurement.FromSquareMeters(1));

			Assert.IsTrue(AreaMeasurement.FromSquareMeters(2) >= AreaMeasurement.FromSquareMeters(1));
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(1) >= AreaMeasurement.FromSquareMeters(2));
			Assert.IsTrue(AreaMeasurement.FromSquareMeters(1) >= AreaMeasurement.FromSquareMeters(1));

			Assert.IsFalse(AreaMeasurement.FromSquareMeters(2) < AreaMeasurement.FromSquareMeters(1));
			Assert.IsTrue(AreaMeasurement.FromSquareMeters(1) < AreaMeasurement.FromSquareMeters(2));
			Assert.IsFalse(AreaMeasurement.FromSquareMeters(1) < AreaMeasurement.FromSquareMeters(1));

			Assert.IsFalse(AreaMeasurement.FromSquareMeters(2) <= AreaMeasurement.FromSquareMeters(1));
			Assert.IsTrue(AreaMeasurement.FromSquareMeters(1) <= AreaMeasurement.FromSquareMeters(2));
			Assert.IsTrue(AreaMeasurement.FromSquareMeters(1) <= AreaMeasurement.FromSquareMeters(1));
		}

		[Test]
		public void area_multiply_divide_add_subtract()
		{
			Assert.AreEqual(AreaMeasurement.FromSquareMeters(100),
				AreaMeasurement.FromSquareMeters(50).Add(AreaMeasurement.FromSquareMeters(50)));

			Assert.AreEqual(AreaMeasurement.FromSquareMeters(50),
				AreaMeasurement.FromSquareMeters(100).Subtract(AreaMeasurement.FromSquareMeters(50)));

			Assert.AreEqual(AreaMeasurement.FromSquareMeters(200),
				AreaMeasurement.FromSquareMeters(100).MultiplyBy(2));

			Assert.AreEqual(AreaMeasurement.FromSquareMeters(50),
				AreaMeasurement.FromSquareMeters(100).DivideBy(2));
		}

		[Test]
		public void area_implicit_double_conversion()
		{
			Assert.AreEqual((double)AreaMeasurement.FromSquareMeters(100), 100d);
			Assert.AreEqual(AreaMeasurement.FromSquareMeters(100), (AreaMeasurement)100d);
		}
	}
}
