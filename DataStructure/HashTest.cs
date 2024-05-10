using System;
using System.Collections;
namespace DotNet.DataStructure
{
    public class HashTest
    {
        // 생성자
        public HashTest() {

        }

        public void Test() {
         HashTableTest();  
         HashSetTest(); 
        }

        // Key와 Value 를 사용하여 자료를 저장한다.
        // 중복 Key 를 허용하지 않는다.
        // Key 와 Value 둘 다 Object 형식을 사용한다. (박싱 언박싱 발생)
        // Value 가 Object 형식이기 때문에 타입에 상관없이 여러 형태를 저장할 수 있다.
        private void HashTableTest() {
            var hash = new Hashtable();
            hash.Add("A", 1);
            //hash.Remove("A");
            
            //int myNum = (int)hash["A"];
            //Console.WriteLine(myNum);
        }

        // Key 가 별도로 존재하지 않으며 Value 로만 이루어져있다.
        // 순서가 존재하지 않으며 {0,1,2} 는 {2,1,0}과 같다.
        // 각 항목의 중복을 허용하지 않는다.
        private void HashSetTest() {
            HashSet<int> uniqueVals = new HashSet<int>();
            uniqueVals.Add(1);
            uniqueVals.Remove(0);

        }
    }
}