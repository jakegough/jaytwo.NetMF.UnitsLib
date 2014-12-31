using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class ElectricalPowerMeasurementTests
	{
		[Test]
		public void elec_power_volts_amps()
		{
			var volts = VoltageMeasurement.FromVolts(10);
			var amps = CurrentMeasurement.FromAmps(.1);
			var power = ElectricalPowerMeasurement.FromVoltsCurrent(volts, amps);
			Assert.AreEqual(1, power.Watts);

			var calculatedAmps = power.GetCurrent(volts);
			Assert.AreEqual(amps.Amps, calculatedAmps.Amps);

			var calculatedVolts = power.GetVoltage(amps);
			Assert.AreEqual(volts.Volts, calculatedVolts.Volts);
		}

		[Test]
		public void elec_power_watts_milliwatts()
		{
			var fromWatts = ElectricalPowerMeasurement.FromWatts(1);
			Assert.AreEqual(1, fromWatts.Watts);
			Assert.AreEqual(1000, fromWatts.Milliwatts);

			var fromMilliwatts = ElectricalPowerMeasurement.FromMilliwatts(1000);
			Assert.AreEqual(1, fromMilliwatts.Watts);
			Assert.AreEqual(1000, fromMilliwatts.Milliwatts);
		}

		[Test]
		public void elec_power_static_members()
		{
			Assert.AreEqual(0, ElectricalPowerMeasurement.Zero.Watts);
			Assert.AreEqual(0, ElectricalPowerMeasurement.Zero.Watts * 10);
			Assert.AreEqual(0, ElectricalPowerMeasurement.Zero.Watts / 10);

			Assert.AreEqual(double.NaN, ElectricalPowerMeasurement.None.Watts);
			Assert.AreEqual(double.NaN, ElectricalPowerMeasurement.None.Watts * 10);
			Assert.AreEqual(double.NaN, ElectricalPowerMeasurement.None.Watts / 10);

			Assert.AreEqual(double.PositiveInfinity, ElectricalPowerMeasurement.Max.Watts);
			Assert.AreEqual(double.PositiveInfinity, ElectricalPowerMeasurement.Max.Watts * 10);
			Assert.AreEqual(double.PositiveInfinity, ElectricalPowerMeasurement.Max.Watts / 10);

			Assert.AreEqual(double.NegativeInfinity, ElectricalPowerMeasurement.Min.Watts);
			Assert.AreEqual(double.NegativeInfinity, ElectricalPowerMeasurement.Min.Watts * 10);
			Assert.AreEqual(double.NegativeInfinity, ElectricalPowerMeasurement.Min.Watts / 10);
		}

		[Test]
		public void elec_power_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = ElectricalPowerMeasurement.FromWatts(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Watts, ElectricalPowerMeasurement.Parse(testString).Watts);

			Assert.IsNull(ElectricalPowerMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, ElectricalPowerMeasurement.Parse("hello").Watts);
		}

		[Test]
		public void elec_power_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(2) == ElectricalPowerMeasurement.FromWatts(1));
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(1) == ElectricalPowerMeasurement.FromWatts(2));
			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(1) == ElectricalPowerMeasurement.FromWatts(1));

			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(2) != ElectricalPowerMeasurement.FromWatts(1));
			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(1) != ElectricalPowerMeasurement.FromWatts(2));
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(1) != ElectricalPowerMeasurement.FromWatts(1));

			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(2) > ElectricalPowerMeasurement.FromWatts(1));
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(1) > ElectricalPowerMeasurement.FromWatts(2));
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(1) > ElectricalPowerMeasurement.FromWatts(1));

			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(2) >= ElectricalPowerMeasurement.FromWatts(1));
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(1) >= ElectricalPowerMeasurement.FromWatts(2));
			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(1) >= ElectricalPowerMeasurement.FromWatts(1));

			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(2) < ElectricalPowerMeasurement.FromWatts(1));
			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(1) < ElectricalPowerMeasurement.FromWatts(2));
			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(1) < ElectricalPowerMeasurement.FromWatts(1));

			Assert.IsFalse(ElectricalPowerMeasurement.FromWatts(2) <= ElectricalPowerMeasurement.FromWatts(1));
			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(1) <= ElectricalPowerMeasurement.FromWatts(2));
			Assert.IsTrue(ElectricalPowerMeasurement.FromWatts(1) <= ElectricalPowerMeasurement.FromWatts(1));
		}

		[Test]
		public void elec_power_multiply_divide_add_subtract()
		{
			Assert.AreEqual(ElectricalPowerMeasurement.FromWatts(100),
				ElectricalPowerMeasurement.FromWatts(50).Add(ElectricalPowerMeasurement.FromWatts(50)));

			Assert.AreEqual(ElectricalPowerMeasurement.FromWatts(50),
				ElectricalPowerMeasurement.FromWatts(100).Subtract(ElectricalPowerMeasurement.FromWatts(50)));

			Assert.AreEqual(ElectricalPowerMeasurement.FromWatts(200),
				ElectricalPowerMeasurement.FromWatts(100).MultiplyBy(2));

			Assert.AreEqual(ElectricalPowerMeasurement.FromWatts(50),
				ElectricalPowerMeasurement.FromWatts(100).DivideBy(2));
		}

		[Test]
		public void elec_power_implicit_double_conversion()
		{
			Assert.AreEqual((double)ElectricalPowerMeasurement.FromWatts(100), 100d);
			Assert.AreEqual(ElectricalPowerMeasurement.FromWatts(100), (ElectricalPowerMeasurement)100d);
		}
	}
}
