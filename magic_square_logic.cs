namespace magic_square
{
    internal class Program
    {
        static void FillTheMatrix(int[,] matrix, int n)
        {
            int row = n - 1, col = (n - 1) / 2;
            matrix[row, col] = 1;

            for (int i = 2; i <= n * n; i++)
            {
                int nextRow = (row + 1 > n - 1) ? 0 : row + 1;
                int nextCol = (col - 1 < 0) ? n - 1 : col - 1;

                //check if already filled
                if (matrix[nextRow, nextCol] == 0)
                {
                    row = nextRow; col = nextCol;
                }
                else
                {
                    row = (row - 1) % n;
                }
                matrix[row, col] = i;
            }
        }
        static void Main()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            //make the matrix
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            //fill the matrix
            FillTheMatrix(matrix, n);
            Console.WriteLine("\nThe Magic Square: ");
            //print the matrix

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            //check the sum of each row
            int sum;
            Console.WriteLine("\nSum of each row: ");
            for (int row = 0; row< n; row++)
            {
                sum = 0;
                for(int col=0;col<n; col++)
                {
                    sum += matrix[row, col];
                    Console.Write(matrix[row, col]);
                    if (col < n - 1)
                        Console.Write("+");
                }
                Console.WriteLine("="+sum);
            }
            Console.WriteLine("\nSum of each column: ");
            for (int col = 0; col < n; col++)
            {
                sum = 0;
                for (int row = 0; row < n; row++)
                {
                    sum += matrix[row, col];
                    Console.Write(matrix[row, col]);
                    if (row < n - 1)
                        Console.Write("+");
                }
                Console.WriteLine("=" + sum);
            }
            Console.WriteLine("\nSum of each diagonal: ");
            sum = 0;
            for (int row = 0; row < n; row++)
            {
                
                sum += matrix[row, row];
                Console.Write(matrix[row, row]);
                if (row < n - 1)
                    Console.Write("+");
            }
            Console.WriteLine("=" + sum);
            sum = 0;
            for (int row = n-1; row >= 0; row--)
            {

                sum += matrix[row, row];
                Console.Write(matrix[row, row]);
                if (row >0)
                    Console.Write("+");
            }
            Console.WriteLine("=" + sum);
        }
    }
}
