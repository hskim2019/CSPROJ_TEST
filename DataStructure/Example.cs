using System;
namespace DotNet.DataStructure
{
    public class Example
    {
        public Example() {

        }

        public void Test() {
           DateTime now = DateTime.Now;
           var testNum = 3;
           testNum = Convert.ToInt32(testNum);
           var startDate = now.AddMonths(-15).ToString("yyyy-MM-dd");

           Console.WriteLine("startDate = " + startDate);
        } 

        

        
    }
}