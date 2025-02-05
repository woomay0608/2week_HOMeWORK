using System.Collections.Generic;

namespace ConsoleApp
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int[] num = [0, 1, 0, 3, 2, 3];
            int[] nums = [1, 3, 2];
            int[] num1 = [4, 10, 4, 3, 8, 9];
            int answer = LengthOfLIS(num);
            Console.WriteLine(answer);
        }
        public static int LengthOfLIS(int[] nums)
        {
            //코드의 순서를 유지해야함
            //가장 긴 오름차순
            //같은 길이 일땐 같은 자리의 숫자가 더 낮은 것 *필수는 아님

            //하나를 넣고 다음 숫자보다 큰지 검사

            //안 크다면 다음 숫자랑 바꿔치기
            // 크다면 리스트에 넣기


            List<int> leng = new List<int>();
            int First;
            int Last;

            int number = 0;

            First = nums[0];
            leng.Add(First);
            

            for (int i = 1; i < nums.Length; i++)
            {
                Last = leng[leng.Count - 1];
                if (First > nums[i])
                {
                    leng.RemoveAt(0);
                    First = nums[i];
                    leng.Add(First);
                }
                else if( Last < nums[i])
                {
                    
                    leng.Add(nums[i]); 
                    
                }
                else if( Last > nums[i])
                {
                    foreach (int s in leng)
                    {
                        if (s < nums[i])
                        {
                            number++;
                        }
                    }
                    if (number == leng.Count - 1)
                    {
                        if (i +1 != nums.Length)
                        {
                            leng.Remove(leng.Count);
                            leng.Add(nums[i]);
                        }
                    }
                }

            }

        foreach(int s in leng)
            { Console.WriteLine(s); }
            return leng.Count();
        }
    }
}
