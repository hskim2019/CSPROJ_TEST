namespace DotNet.DataStructure.Stack
{
    public class StackTest
    {
        public StackTest() {

        }
        private int[] ele;
    private int top;
    private int max;
    public StackTest(int size)
    {
        ele = new int[size]; // Maximum size of Stack
        top = -1;
        max = size;
    }

    public void push(int item) 
    {
        if (top == max - 1) {
            Console.WriteLine("Stack Overflow");
            return;
        }
        else {
            ele[++top] = item;
            Console.WriteLine("top after Push():" + top);
        }
    }

    public int pop()
    {
        if (top == -1) {
            Console.WriteLine("Stack is Empty");
            return -1;
        }
        else {
            Console.WriteLine("{0} popped from stack ",
                              ele[top]);

            var testValue = ele[top--];
            Console.WriteLine(testValue);
            Console.WriteLine(top);
            return testValue; 
            //return ele[top--];
        }
    }

    public int peek()
    {
        if (top == -1) {
            Console.WriteLine("Stack is Empty");
            return -1;
        }
        else {
            Console.WriteLine("{0} popped from stack ",
                              ele[top]);
            return ele[top];
        }
    }

    public void printStack()
    {
        if (top == -1) {
            Console.WriteLine("Stack is Empty");
            return;
        }
        else {
            for (int i = 0; i <= top; i++) {
                Console.WriteLine("{0} pushed into stack",
                                  ele[i]);
            }
        }
    }

    public void Test() {
   
        StackTest p = new StackTest(5);

        p.push(10);
        p.push(20);
        p.push(30);
        p.printStack();
        var test = p.pop();
        Console.WriteLine("last :" + test);
    
    }
}

// Driver program to test above functions

}