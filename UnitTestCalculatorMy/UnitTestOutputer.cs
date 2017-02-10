using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculator;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace UnitTestCalculatorMy
{
    [TestClass]
    public class UnitTestOutputer
    {
        // private variables
        private Calculator calculator_for_test; // reference on trash


        [TestInitialize]
        public void TestInitialize()
        {

            // create calculator instanse
            //Calculator calculator_for_test = new Calculator(); local

            this.calculator_for_test = new Calculator(); // this.calculator_for_test   reference on real data

            Debug.WriteLine("Calculator created");


        }

        // final action after test
        [TestCleanup]
        public void TestCleanup()
        {

            Debug.WriteLine("All test finished");
            // this.calculator_for_test.Dispose(); error in calculator cannot free memory
        }


        [TestMethod]
        public void TestSum()
        {
            float x = 4;
            float y = 5;

            float expected_result = 9;

            float real_result = x + y;


            Assert.AreEqual(expected_result, real_result, "Sum is tested");

            Debug.WriteLine("Sum test is finished");
        }

        [TestMethod]
        public void TestSub()
        {
            float x = 4;
            float y = 5;

            float expected_result = -1;

            float real_result = x - y;


            Assert.AreEqual(expected_result, real_result, "Dub is tested");
            Debug.WriteLine("Sub test is finished");
        }

        //test string------------------------------------------

        //StringAssert

        [TestMethod]
        public void TestStringContainSubstring()
        {
            string str_1 = "Hello Mike";

            string str_2 = "Hello Miike";
            // contains substring
            StringAssert.Contains(str_1, "kes");
        }

        [TestMethod]
        public void TestStringEquals()
        {
            string str_1 = "Hello aaabbbb223 Mike";

            string str_2 = "1Hello Mike";
            // ok if equal types
            StringAssert.Equals(str_1, str_2);

            //ok if correct regular expression

            StringAssert.Matches(str_1, new Regex("(a){3}(b){3}(\\d){3}"));
        }


        [TestMethod]
        public void TestStringStartWith()
        {

            string str_1 = "Hell1o aaabbbb223 Mike";

            string str_2 = "1Hello Mike";



            StringAssert.StartsWith(str_1, "Hello");
        }

        [TestMethod]
        public void TestStringEndWith()
        {

            string str_1 = "Hell1o aaabbbb223 Mike";

            string str_2 = "1Hello Mike";


            StringAssert.EndsWith(str_1, "Mike");
        }

        [TestMethod]
        public void TestCollectionClassMyelemetExist()
        {

            // Object type of all data

            List<MyElement> list_of_myelements = new List<MyElement>();

            MyElement elm_1 = new MyElement();
            MyElement elm_2 = new MyElement();
            MyElement elm_3 = new MyElement();


            list_of_myelements.Add(elm_1);
            list_of_myelements.Add(elm_3);

            string x = "some text";

            x.GetType();

            // object.GetType() return type of element
            CollectionAssert.AllItemsAreInstancesOfType(list_of_string, elm_1.GetType());
        }

             [TestMethod]
        public void TestCollectionClass()
        {

            // Object type of all data

            List<string> list_of_string = new List<string>();
            list_of_string.Add("Ivanov");
            list_of_string.Add("Petrov");
            list_of_string.Add("Ivanov2");

            List<string> list_of_string_expected = new List<string>();


            list_of_string_expected.Add("Ivanov");
            list_of_string_expected.Add("Petrov");
            list_of_string_expected.Add("Abrasha");



            CollectionAssert.AreEquivalent(list_of_string_expected, list_of_string_test);
        }


        string x = "some text";

            'x.GetType'();

            // object.GetType() return type of element

         [TestMethod]
        public void TestCollectionEqualToOtherOrder()
        {
            List<string> list_of_string_test = new List<string>();

            list_of_string_test.Add("Abrasha");
            list_of_string_test.Add("Ivanov");
            list_of_string_test.Add("Petrov");


            List<string> list_of_string_expected = new List<string>();

            list_of_string_expected.Add("Abrasha");
            list_of_string_expected.Add("Ivanov");
            list_of_string_expected.Add("Petrov");




            CollectionAssert.AreEqual(list_of_string_expected, list_of_string_test);
        }
        [TestMethod]
        public void TestCollectionIsOnePartOfOther()
        {
            List<string> list_of_string = new List<string>();

            list_of_string.Add("Abrasha"); //0
            list_of_string.Add("Ivanov");  //1
            list_of_string.Add("Petrov");  //2


            List<string> list_of_string_subset = new List<string>();


            list_of_string_subset.Add("Ivanov");
            list_of_string_subset.Add("Petrov1");


            // get element by its position

            //list_of_string[position] index from 0!!!!!

            string x = list_of_string[1];

            CollectionAssert.IsSubsetOf(list_of_string_subset, list_of_string);

        }



    }
}
}