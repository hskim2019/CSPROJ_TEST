

using System;
using DotNet.DataStructure;
using DotNet.DataStructure.LinkedList;
using DotNet.DataStructure.Stack;
namespace DotNet {

    class Program {

        static void Main(string[] args) { 
            
            ExecuteTest(); 
            
        }

        private static void ExecuteTest() {
            //HashTest hashTest = new HashTest();
            //hashTest.Test();

            //ArrayTest arrayTest = new ArrayTest();
            //arrayTest.Test();

            //Example exampleTest = new Example();
            //exampleTest.Test(); 

            //FindTheMiddle findTheMiddle = new FindTheMiddle();
            //findTheMiddle.Test();

            //CircularTest circularTest = new CircularTest();
            //circularTest.Test();

            //ExchangeCircularNodeTest exchangeCircular = new ExchangeCircularNodeTest();
            //exchangeCircular.Test();

            // StackTest stackTest = new StackTest();
            // stackTest.Test();

            ParenthesisChecker parenthesisChecker= new ParenthesisChecker();    
            parenthesisChecker.Test();

        }
    }
}
