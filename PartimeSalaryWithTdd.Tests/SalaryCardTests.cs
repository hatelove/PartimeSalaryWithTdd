using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartimeSalaryWithTdd;

namespace PartimeSalaryWithTdd.Tests
{
    /// <summary>
    /// SalaryCardTests 的摘要描述
    /// </summary>
    [TestClass]
    public class SalaryCardTests
    {
        public SalaryCardTests()
        {
            //
            // TODO:  在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///的相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 其他測試屬性

        //
        // 您可以使用下列其他屬性撰寫您的測試:
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion 其他測試屬性

        [TestMethod]
        public void TestCalculateSalary_沒有加班_正常上班8小時_時薪100乘以8_薪資應為800()
        {
            //Scenario: 沒有加班，正常上班8小時，時薪100乘以8，薪資應為800
            //Given 正常上班一小時薪資為 100
            //And 上班時間時間為 "2014/8/30 08:00:00"
            //And 下班時間為 "2014/8/30 17:00:00"
            //When 呼叫CalculateSalary方法
            //Then 薪資計算結果應為 800

			var target = new SalaryCard();
			target.HourlySalary = 100;
			target.StartTime = new DateTime(2014, 8, 30, 8, 0, 0);
			target.EndTime = new DateTime(2014, 8, 30, 17, 0, 0);

			//act
			var actual = target.CalculateSalary();

			//assert
			var expected = 800;
			Assert.AreEqual(expected, actual);
          
        }

		[TestMethod]
		public void TestCalculateSalary_加班2小時_加班頭2小時比例為1點66_薪資應為1132()
		{
			//Scenario: 加班2小時：
			//    上班8小時，時薪100乘以8，加班2小時，加班費100乘以1.66乘以2，薪資應為1132
			//    Given 正常上班一小時薪資為 100
			//    And 加班薪資頭2小時，時薪比例為 1.66
			//    And 上班時間為 "2014/8/30 08:00:00"
			//    And 下班時間為 "2014/8/30 19:00:00"
			//    When 呼叫CalculateSalary方法
			//    Then 薪資計算結果應為 1132

			var target = new SalaryCard();
			target.HourlySalary = 100;

			//新增property
			target.FirstOverTimeRatio = 1.66;
			target.StartTime = new DateTime(2014, 8, 30, 8, 0, 0);
			target.EndTime = new DateTime(2014, 8, 30, 19, 0, 0);

			//act
			var actual = target.CalculateSalary();

			//assert
			var expected = 1132;
			Assert.AreEqual(expected, actual);
		}

    }
}