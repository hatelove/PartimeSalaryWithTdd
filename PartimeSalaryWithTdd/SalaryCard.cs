using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PartimeSalaryWithTdd.Utility;

namespace PartimeSalaryWithTdd
{
	public class SalaryCard
	{
		private double normalWorkingHourLimit = 8;

		public int HourlySalary { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public double CalculateSalary()
		{
			var workingHour = this.GetWorkingHour();


			if (workingHour <= normalWorkingHourLimit)
			{
				var result = workingHour * this.HourlySalary;

				return result;
			}
			else
			{
				var normalPay = normalWorkingHourLimit * this.HourlySalary;

				var overTimePay = GetOverTimePay(workingHour);

				var result = normalPay + overTimePay;

				return result;
			}
		}

		private double GetOverTimePay(double workingHour)
		{
			var overTimeHour = GetOverTimeHours(workingHour);

			// separate two phase of overtime hour
			var firstOverTime = overTimeHour <= 2 ? overTimeHour : 2;
			var secondOverTime = overTimeHour > 2 ? overTimeHour - firstOverTime : 0;
			
			var firstOverTimePay = firstOverTime * this.FirstOverTimeRatio * this.HourlySalary;
			var secondOverTimePay = secondOverTime * this.SecondOverTimeRatio * this.HourlySalary;

			var overTimePay = firstOverTimePay + secondOverTimePay;
			return overTimePay;
		}

		private double GetOverTimeHours(double workingHour)
		{
			var overTimeHour = workingHour - normalWorkingHourLimit;

			// 加班最多只能報4hr
			var result = overTimeHour > 4 ? 4 : overTimeHour;
			return result;
		}

		private double GetWorkingHour()
		{
			var moringEnd = new DateTime(this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, 12, 0, 0);
			var afternoonStart = new DateTime(this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, 13, 0, 0);

			var morningWorkhour = DateTimeHelper.TotalHours(this.StartTime, moringEnd);
			var afternoonWorkhour = DateTimeHelper.TotalHours(afternoonStart, this.EndTime);

			var workingHour = morningWorkhour + afternoonWorkhour;

			return workingHour;
		}

		public double FirstOverTimeRatio { get; set; }

		public int SecondOverTimeRatio { get; set; }
	}
}
