using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartimeSalaryWithTdd.Utility;

namespace PartimeSalaryWithTdd.Tests
{
    /// <summary>
    /// DateTimeHelperTests 的摘要描述
    /// </summary>
    [TestClass]
    public class DateTimeHelperTests
    {
        public DateTimeHelperTests()
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
        #endregion

        [TestMethod]
        public void TestTotalHours_傳入8點到17點_應回傳9()
        {
            var start = new DateTime(2014, 8, 30, 8, 0, 0);
            var end = new DateTime(2014, 8, 30, 17, 0, 0);

            var actual = DateTimeHelper.TotalHours(start, end);

            var expected = 9;
            Assert.AreEqual(expected, actual);
        }
    }
}
