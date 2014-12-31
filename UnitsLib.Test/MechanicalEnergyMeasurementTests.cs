using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class MechanicalEnergyMeasurementTests
	{
		[Test]
		public void mech_energy_kilogrammeters_newtonmeters()
		{
			var fromNewtonMeters = MechanicalEnergyMeasurement.FromNewtonMeters(9.80665);
			Assert.AreEqual(1, fromNewtonMeters.KilogramMeters);
			Assert.AreEqual(9.80665, fromNewtonMeters.NewtonMeters);
		}

        [Test]
        public void mech_energy_from_force()
        {
            Assert.AreEqual(10d, MechanicalEnergyMeasurement.FromForce(
                WeightMeasurement.FromNewtons(10),
                LengthMeasurement.FromMeters(1)).NewtonMeters);

            Assert.AreEqual(10d, MechanicalEnergyMeasurement.FromForce(
                WeightMeasurement.FromNewtons(5),
                LengthMeasurement.FromMeters(2)).NewtonMeters);

            Assert.AreEqual(10d, MechanicalEnergyMeasurement.FromForce(
                WeightMeasurement.FromNewtons(20),
                LengthMeasurement.FromMeters(.5)).NewtonMeters);
        }

		[Test]
		public void mech_energy_footpounds_newtonmeters()
		{
			const double footPoundsPerNewtonMeter = 4.4482216152605 * 0.3048;

			var fromFootPounds = MechanicalEnergyMeasurement.FromFootPounds(1);
			Assert.AreEqual(1, fromFootPounds.FootPounds);
			Assert.AreEqual(footPoundsPerNewtonMeter, fromFootPounds.NewtonMeters);

			var fromNewtonMeters = MechanicalEnergyMeasurement.FromNewtonMeters(footPoundsPerNewtonMeter);
			Assert.AreEqual(1, fromNewtonMeters.FootPounds);
			Assert.AreEqual(footPoundsPerNewtonMeter, fromNewtonMeters.NewtonMeters);
		}

		[Test]
		public void mech_energy_footpounds_inchpounds()
		{
			var fromFootPounds = MechanicalEnergyMeasurement.FromFootPounds(1);
			Assert.AreEqual(1, fromFootPounds.FootPounds);
			Assert.AreEqual(12, fromFootPounds.InchPounds);

			var fromInchPounds = MechanicalEnergyMeasurement.FromInchPounds(12);
			Assert.AreEqual(1, fromInchPounds.FootPounds);
			Assert.AreEqual(12, fromInchPounds.InchPounds);
		}

		[Test]
		public void mech_energy_static_members()
		{
			Assert.AreEqual(0, MechanicalEnergyMeasurement.Zero.NewtonMeters);
			Assert.AreEqual(0, MechanicalEnergyMeasurement.Zero.NewtonMeters * 10);
			Assert.AreEqual(0, MechanicalEnergyMeasurement.Zero.NewtonMeters / 10);

			Assert.AreEqual(double.NaN, MechanicalEnergyMeasurement.None.NewtonMeters);
			Assert.AreEqual(double.NaN, MechanicalEnergyMeasurement.None.NewtonMeters * 10);
			Assert.AreEqual(double.NaN, MechanicalEnergyMeasurement.None.NewtonMeters / 10);

			Assert.AreEqual(double.PositiveInfinity, MechanicalEnergyMeasurement.Max.NewtonMeters);
			Assert.AreEqual(double.PositiveInfinity, MechanicalEnergyMeasurement.Max.NewtonMeters * 10);
			Assert.AreEqual(double.PositiveInfinity, MechanicalEnergyMeasurement.Max.NewtonMeters / 10);

			Assert.AreEqual(double.NegativeInfinity, MechanicalEnergyMeasurement.Min.NewtonMeters);
			Assert.AreEqual(double.NegativeInfinity, MechanicalEnergyMeasurement.Min.NewtonMeters * 10);
			Assert.AreEqual(double.NegativeInfinity, MechanicalEnergyMeasurement.Min.NewtonMeters / 10);
		}

		[Test]
		public void mech_energy_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = MechanicalEnergyMeasurement.FromNewtonMeters(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.NewtonMeters, MechanicalEnergyMeasurement.Parse(testString).NewtonMeters);

			Assert.IsNull(MechanicalEnergyMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, MechanicalEnergyMeasurement.Parse("hello").NewtonMeters);
		}

		[Test]
		public void mech_energy_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(2) == MechanicalEnergyMeasurement.FromNewtonMeters(1));
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(1) == MechanicalEnergyMeasurement.FromNewtonMeters(2));
			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(1) == MechanicalEnergyMeasurement.FromNewtonMeters(1));

			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(2) != MechanicalEnergyMeasurement.FromNewtonMeters(1));
			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(1) != MechanicalEnergyMeasurement.FromNewtonMeters(2));
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(1) != MechanicalEnergyMeasurement.FromNewtonMeters(1));

			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(2) > MechanicalEnergyMeasurement.FromNewtonMeters(1));
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(1) > MechanicalEnergyMeasurement.FromNewtonMeters(2));
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(1) > MechanicalEnergyMeasurement.FromNewtonMeters(1));

			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(2) >= MechanicalEnergyMeasurement.FromNewtonMeters(1));
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(1) >= MechanicalEnergyMeasurement.FromNewtonMeters(2));
			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(1) >= MechanicalEnergyMeasurement.FromNewtonMeters(1));

			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(2) < MechanicalEnergyMeasurement.FromNewtonMeters(1));
			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(1) < MechanicalEnergyMeasurement.FromNewtonMeters(2));
			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(1) < MechanicalEnergyMeasurement.FromNewtonMeters(1));

			Assert.IsFalse(MechanicalEnergyMeasurement.FromNewtonMeters(2) <= MechanicalEnergyMeasurement.FromNewtonMeters(1));
			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(1) <= MechanicalEnergyMeasurement.FromNewtonMeters(2));
			Assert.IsTrue(MechanicalEnergyMeasurement.FromNewtonMeters(1) <= MechanicalEnergyMeasurement.FromNewtonMeters(1));
		}

		[Test]
		public void mech_energy_multiply_divide_add_subtract()
		{
			Assert.AreEqual(MechanicalEnergyMeasurement.FromNewtonMeters(100),
				MechanicalEnergyMeasurement.FromNewtonMeters(50).Add(MechanicalEnergyMeasurement.FromNewtonMeters(50)));

			Assert.AreEqual(MechanicalEnergyMeasurement.FromNewtonMeters(50),
				MechanicalEnergyMeasurement.FromNewtonMeters(100).Subtract(MechanicalEnergyMeasurement.FromNewtonMeters(50)));

			Assert.AreEqual(MechanicalEnergyMeasurement.FromNewtonMeters(200),
				MechanicalEnergyMeasurement.FromNewtonMeters(100).MultiplyBy(2));

			Assert.AreEqual(MechanicalEnergyMeasurement.FromNewtonMeters(50),
				MechanicalEnergyMeasurement.FromNewtonMeters(100).DivideBy(2));
		}

		[Test]
		public void mech_energy_implicit_double_conversion()
		{
			Assert.AreEqual((double)MechanicalEnergyMeasurement.FromNewtonMeters(100), 100d);
			Assert.AreEqual(MechanicalEnergyMeasurement.FromNewtonMeters(100), (MechanicalEnergyMeasurement)100d);
		}
	}
}
