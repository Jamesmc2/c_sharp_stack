using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // for(int i=1; i<256; i++){
            //     Console.WriteLine(i);
            // }
            // for(int j=1; j<101; j++){
            //     if(j%3==0 && j%5==0){

            //     }
            //     else if (j%3==0 || j%5==0)
            //     {
            //         Console.WriteLine(j);
            //     }
            // }
            for(int j=1; j<101; j++){
                if(j%3==0 && j%5==0){
                    Console.WriteLine(j + " FizzBuzz");

                }
                else if (j%3==0)
                {
                    Console.WriteLine(j + " Fizz");
                }
                else if (j%5==0)
                {
                    Console.WriteLine(j + " Buzz");
                }
            }

            
        }
    }
}
