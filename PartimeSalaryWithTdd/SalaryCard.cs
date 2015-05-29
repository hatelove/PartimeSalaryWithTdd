using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartimeSalaryWithTdd
{
	public class SalaryCard
	{
		public int HourlySalary { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public int CalculateSalary()
		{
			var workingHour = this.GetWorkingHour();
			var result = workingHour * this.HourlySalary;

			return result;
		}

		private double GetWorkingHour()
		{
			throw new NotImplementedException();
		}
	}
}
