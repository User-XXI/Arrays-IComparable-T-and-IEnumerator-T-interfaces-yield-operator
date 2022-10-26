using System;


namespace Task1
{
    class MyMatrix
    {
        double[,] matrix;
        int _row = 0;
        int _col = 0;
        int _min = 0;
        int _max = 0;
        public MyMatrix( int row, int col, int min, int max )
        {
            _row = row;
            _col = col;
            _min = min;
            _max = max;

            Random random = new Random();
            matrix = new double[row, col];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    matrix[i, j] = random.Next( min, max + 1 );

        }
        public void print()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                    Console.Write( matrix[i, j] + "\t" );
                Console.WriteLine();
            }

        }
        public double this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }

        public static MyMatrix operator +( MyMatrix matrix1, MyMatrix matrix2 )
        {
            if (matrix1._row == matrix2._row && matrix1._col == matrix2._col)
            {
                MyMatrix Result = new MyMatrix(matrix1._row, 
                                               matrix1._col, 
                                               matrix1._min, 
                                               matrix1._max);

                for (int i = 0; i < matrix1._row; i++)
                {
                    for (int j = 0; j < matrix1._col; j++)
                    {
                        Result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return Result;
            }
            else
            {
                MyMatrix ERROR = new MyMatrix(0, 0, 0, 0);
                Console.WriteLine( "SUM_ERROR" );
                return ERROR;
            }
        }

        public static MyMatrix operator -( MyMatrix matrix1, MyMatrix matrix2 )
        {
            if (matrix1._row == matrix2._row && matrix1._col == matrix2._col)
            {
                MyMatrix Result = new MyMatrix(matrix1._row, 
                                               matrix1._col, 
                                               matrix1._min, 
                                               matrix1._max);

                for (int i = 0; i < matrix1._row; i++)
                {
                    for (int j = 0; j < matrix1._col; j++)
                    {
                        Result[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                return Result;
            }
            else
            {
                MyMatrix ERROR = new MyMatrix(0, 0, 0, 0);
                Console.WriteLine( "RES_ERROR" );
                return ERROR;
            }
        }

        public static MyMatrix operator *( MyMatrix matrix1, MyMatrix matrix2 )
        {
            if (matrix1._col == matrix2._row)
            {
                MyMatrix ResResult = new MyMatrix(matrix1._row, matrix2._col, 0, 0);
                for (int i = 0; i < matrix1._row; i++)
                {
                    for (int j = 0; j < matrix2._col; j++)
                    {
                        for (int k = 0; k < matrix1._col; k++)
                        {
                            ResResult[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
                return ResResult;
            }
            else
            {
                MyMatrix ERROR = new MyMatrix(0, 0, 0, 0);
                Console.WriteLine( "RES_ERROR" );
                return ERROR;
            }
        }

        public static MyMatrix operator *( MyMatrix matrix1, int num )
        {
            MyMatrix Result = new MyMatrix(matrix1._row, 
                                           matrix1._col, 
                                           matrix1._min, 
                                           matrix1._max);

            for (int i = 0; i < matrix1._row; i++)
            {
                for (int j = 0; j < matrix1._col; j++)
                {
                    Result[i, j] = matrix1[i, j] * num;
                }
            }
            return Result;
        }
        public static MyMatrix operator /( MyMatrix matrix1, int num )
        {
            if (num != 0)
            {
                MyMatrix Result = new MyMatrix(matrix1._row, 
                                               matrix1._col, 
                                               matrix1._min, 
                                               matrix1._max);

                for (int i = 0; i < matrix1._row; i++)
                {
                    for (int j = 0; j < matrix1._col; j++)
                    {
                        Result[i, j] = matrix1[i, j] / num;
                    }
                }
                return Result;
            }
            else
            {
                MyMatrix ERROR = new MyMatrix(0, 0, 0, 0);
                Console.WriteLine( "RES_ERROR" );
                return ERROR;
            }
        }
    }
    class Task1
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Martix[a, b]" );
            Console.Write( "a = " );
            int row = Int32.Parse(Console.ReadLine());
            Console.Write( "b = " );
            int col = Int32.Parse(Console.ReadLine());
            Console.Write( "min = " );
            int min = Int32.Parse(Console.ReadLine());
            Console.Write( "max = " );
            int max = Int32.Parse(Console.ReadLine());
            MyMatrix matr1 = new MyMatrix(row, col, min, max);
            Console.WriteLine();

            Console.WriteLine( "Martix[a, b]" );
            Console.Write( "a = " );
            row = Int32.Parse( Console.ReadLine() );
            Console.Write( "b = " );
            col = Int32.Parse( Console.ReadLine() );
            Console.Write( "min = " );
            min = Int32.Parse( Console.ReadLine() );
            Console.Write( "max = " );
            max = Int32.Parse( Console.ReadLine() );
            MyMatrix matr2 = new MyMatrix(row, col, min, max);
            Console.WriteLine();

            Console.WriteLine( "Matrix 1" );
            matr1.print();
            Console.WriteLine();

            Console.WriteLine( "Matrix 1 [0, 0] = 1111" );
            matr1[0, 0] = 1111;
            matr1.print();
            Console.WriteLine();

            Console.WriteLine( "Matrix 2" );
            matr2.print();
            Console.WriteLine();

            MyMatrix matr3 = matr1 + matr2;
            Console.WriteLine( "Matrix 1 + Matrix 2" );
            matr3.print();
            Console.WriteLine();

            MyMatrix matr4 = matr1 - matr2;
            Console.WriteLine( "Matrix 1 - Matrix 2" );
            matr4.print();
            Console.WriteLine();

            MyMatrix matr5 = matr1 * 10;
            Console.WriteLine( "Matrix 1 * 10" );
            matr5.print();
            Console.WriteLine();

            MyMatrix matr6 = matr1 / 10;
            Console.WriteLine( "Matrix 1 / Matrix 2" );
            matr6.print();
            Console.WriteLine();

            MyMatrix matr7 = matr1 * matr2;
            Console.WriteLine( "Matrix 1 * Matrix 2" );
            matr7.print();
        }
    }
}
