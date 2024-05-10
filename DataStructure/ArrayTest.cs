namespace DotNet.DataStructure
{
    public class ArrayTest
    {
        public ArrayTest() {

        }

        public void Test() {
            // if the array elements are of object type then the default value is null
            // 순서가 있고 중복을 허용
            // 인덱스로 접근 가능
            // 크기가 가변적이다
            List<int> array = new List<int>();
            Console.WriteLine(array.Count); // 0
            // array.Add(1);
            foreach(int p in array) {
                Console.Write(p + " ,"); // Count 가 0 이므로 아무것도 출력되지 않는다.
            }
            
            Console.WriteLine("");

            int[] array2 = new int[5];
            foreach(int p in array2) {
                Console.Write(p + ", "); // 0, 0, 0, 0, 0,
            }
            int[] x = new int[3] {1,2,3};
            int[] y = new int[] {2};
            Console.WriteLine("");
            var rv = Calculate(x, x.Length, y, y.Length);
            var rv2 = Calculate2(x, x.Length, y, y.Length);
            Console.WriteLine("result : " + rv + " result2 : " + rv2);

            x = new int[] {4,5,1,2,3};
            y = new int[] {4,2};
            rv = Calculate(x, x.Length, y, y.Length);
            rv2 = Calculate2(x, x.Length, y, y.Length);
            Console.WriteLine("result : " + rv + " result2 : " + rv2);

            x = new int[] {4,5,1,2,3,7,10};
            y = new int[] {1,2,3,4,5,6,7};
            rv = Calculate(x, x.Length, y, y.Length);
            rv2 = Calculate2(x, x.Length, y, y.Length);
            Console.WriteLine("result : " + rv + " result2 : " + rv2);
        }

        private static int Calculate(int[] a, int n, int[] b, int m) {
            
            //Console.WriteLine(a.Length);
            
            // 차집합
            var exceptLeft = a.Except(b);

            var result = 0;
            result = b.Length + exceptLeft.Count();
            return result;
        }

        private static int Calculate2(int[] a, int n, int[]b, int m) {
            var result = a.Length + b.Length;
            // 요소가 있으면 -1
            // 요소가 없으면 아무것도 하지 않는다
            foreach(int value in b) 
            {
                if(Array.Exists(a, x => x == value)) 
                {
                    result -= 1;
                }
            }

            return result;
        }
    }
}