using System;

namespace Array2D
{
    class Program
    {
        // Ham nhap mang 2 chieu so nguyen
        static int[,] EnterArrayInt2D()
        {
            Console.WriteLine("Make to array 2D");
            Console.WriteLine("Enter row(r):");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter colum(c):");
            int c = int.Parse(Console.ReadLine());
            int[,] array2D = new int[r, c];
            for (int i=0; i<r; i++)
            {
                for (int j=0; j<c; j++)
                {
                    Console.WriteLine("Enter value at [{0},{1}]", i, j);
                    array2D[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return array2D;
        }
        // Ham nhap mang 2 chieu so thuc
        static float[,] EnterArrayFloat2D()
        {
            Console.WriteLine("Make to array 2D");
            Console.WriteLine("Enter row(r):");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter colum(c):");
            int c = int.Parse(Console.ReadLine());
            float[,] array2D = new float[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.WriteLine("Enter value at [{0},{1}]", i, j);
                    array2D[i, j] = float.Parse(Console.ReadLine());
                }
            }
            return array2D;
        }

        // Ham hien thi mang 2 chieu so nguyen

        static void ShowArrayInt2D(int[,] array2D)
        {
            Console.WriteLine("Value the array 2D:");
            for (int i=0; i<array2D.GetLength(0); i++)
            {
                for (int j=0; j<array2D.GetLength(1); j++)
                {
                    Console.WriteLine("Value at [{0},{1}]: {2}", i, j, array2D[i,j]);
                }
            }


        }
        // ham hien thi mang 2 chieu so thuc
        static void ShowArrayFloat2D(float[,] array2D)
        {
            Console.WriteLine("Value the array 2D:");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.WriteLine("Value at [{0},{1}]: {2}", i, j, array2D[i, j]);
                }
            }


        }

        //Bài 315: Viết hàm tìm giá trị lớn nhất trong ma trận số thực
        static float FindMax(float[,] array2D)
        {
            float max = array2D[0, 0];
            for (int i= 0; i<array2D.GetLength(0); i++)
            {
                for (int j=0; j<array2D.GetLength(1); j++)
                {
                    if (array2D[i,j]>max)
                    {
                        max = array2D[i, j];
                    }
                }

            }
            return max;

        }

        static float FindMin(float[,] array2D)
        {
            float min = array2D[0, 0];
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i, j] < min)
                    {
                        min = array2D[i, j];
                    }
                }

            }
            return min;

        }

        //Bài 317: Viết hàm đếm số lượng số nguyên tố trong ma trận số nguyên
            //Ham kiem tra so nguyen to
        static bool CheckPrime(int num)
        {
            bool isPrime = true;
            if (num<2)
            {
                isPrime = false;
            }
            if (num>2)
            {
                for (int i=2; i<=Math.Sqrt(num); i++)
                {
                    if (num%i==0)
                    {
                        isPrime = false;

                    }
                }

            }
            return isPrime;
        }
            //Ham dem so luong so nguyen to trong ma tran
        static int CountNumberPrime(int[,] array2D)
        {
            int count = 0;
            //duyet mang 2D
            for (int i=0; i<array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (CheckPrime(array2D[i, j]))
                    {
                        count++;
                    }
                }

            }
            return count;
        }

        //Bài 319: Viết hàm sắp xếp ma trận các số thực tăng dần từ trên xuống dưới và từ trái sang phải
        static float[,] SortArrayAscending(float[,] array2D)
        {
            int[] indexMin = new int[2];
            float temp;
            for (int i=0; i<array2D.GetLength(0); i++)
            {
                for (int j=0; j<array2D.GetLength(1); j++)
                {
                    indexMin = FindMinCustom(array2D, i, j);
                    temp = array2D[i, j];
                    array2D[i, j] = array2D[indexMin[0], indexMin[1]];
                    array2D[indexMin[0], indexMin[1]] = temp;
                }
            }
            return array2D;
        }

        static int[] FindMinCustom(float[,] array2D,int r, int c)
        {
            float min = array2D[r, c];
            int[] index = { r, c };
            for (int i = r; i < array2D.GetLength(0); i++)
            {
                for (int j = c; j < array2D.GetLength(1); j++)
                {
                    if ( min > array2D[i, j] )
                    {
                        min = array2D[i, j];
                        index[0] = i;
                        index[1] = j;
                    }
                }
                //important dieu kien de lap toan bo mang
                c = 0;

            }
            return index;

        }



        static void Main(string[] args)
        {
            Console.WriteLine("------------Exercise Array 2D------------ ");
            //enter array 2D.
            //int[,] arrayInt2D = EnterArrayInt2D();
            // show array 2D
            //ShowArray2D(arrayInt2D);
            //Console.WriteLine(CountNumberPrime(arrayInt2D));
            float[,] arrayFloat2D = EnterArrayFloat2D();
            ShowArrayFloat2D(arrayFloat2D);
            arrayFloat2D=SortArrayAscending(arrayFloat2D);
            ShowArrayFloat2D(arrayFloat2D);

           
           

        }
    }
}
