using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    public class MatrixByte
    {
        protected byte[,] ByteArray;
        protected uint n;
        protected uint m;
        protected int codeError;
        protected static int num_vec;

        public MatrixByte()
        {
            n = 1;
            m = 1;
            ByteArray = new byte[n, m];
            num_vec++;
        }

        public MatrixByte(uint sizeN, uint sizeM)
        {
            n = sizeN;
            m = sizeM;
            ByteArray = new byte[n, m];
            num_vec++;
        }

        public MatrixByte(uint sizeN, uint sizeM, byte initValue)
        {
            n = sizeN;
            m = sizeM;
            ByteArray = new byte[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ByteArray[i, j] = initValue;
                }
            }
            num_vec++;
        }

        ~MatrixByte()
        {
            Console.WriteLine("MatrixByte object is being destroyed.");
        }

        public void InputElements()
        {
            Console.WriteLine("Enter elements of the matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Element [{i + 1},{j + 1}]: ");
                    byte element;
                    if (byte.TryParse(Console.ReadLine(), out element))
                    {
                        ByteArray[i, j] = element;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid byte value.");
                        j--;
                    }
                }
            }
        }

        public void PrintElements()
        {
            Console.WriteLine("Matrix elements:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{ByteArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void SetElements(byte value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ByteArray[i, j] = value;
                }
            }
        }

        public static int NumMatrices()
        {
            return num_vec;
        }

        public uint Rows
        {
            get { return n; }
        }

        public uint Columns
        {
            get { return m; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public byte this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= n || column < 0 || column >= m)
                {
                    codeError = -1;
                    return 0;
                }
                codeError = 0;
                return ByteArray[row, column];
            }
            set
            {
                if (row < 0 || row >= n || column < 0 || column >= m)
                {
                    codeError = -1;
                    return;
                }
                ByteArray[row, column] = value;
                codeError = 0;
            }
        }

        public byte this[int k]
        {
            get
            {
                if (k < 0 || k >= n * m)
                {
                    codeError = -1;
                    return 0;
                }
                codeError = 0;
                return ByteArray[k / m, k % m];
            }
            set
            {
                if (k < 0 || k >= n * m)
                {
                    codeError = -1;
                    return;
                }
                ByteArray[k / m, k % m] = value;
                codeError = 0;
            }
        }

        public static MatrixByte operator ++(MatrixByte mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    mat[i, j]++;
                }
            }
            return mat;
        }

        public static MatrixByte operator --(MatrixByte mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    mat[i, j]--;
                }
            }
            return mat;
        }

        public static bool operator true(MatrixByte mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    if (mat[i, j] != 0)
                        return true;
                }
            }
            return false;
        }

        public static bool operator false(MatrixByte mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    if (mat[i, j] != 0)
                        return false;
                }
            }
            return true;
        }

        public static bool operator !(MatrixByte mat)
        {
            int zeroCount = 0;

            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    if (mat[i, j] == 0)
                    {
                        zeroCount++;
                    }
                }
            }

            if (zeroCount == mat.Rows * mat.Columns)
            {
                return false;
            }

            return true;
        }

        public static MatrixByte operator ~(MatrixByte mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    mat[i, j] = (byte)~mat[i, j];
                }
            }
            return mat;
        }

        public static MatrixByte operator +(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for addition.");

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] + mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator +(MatrixByte mat, byte scalar)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] + scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator -(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for subtraction.");

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] - mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator -(MatrixByte mat, byte scalar)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] - scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator *(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Columns != mat2.Rows)
                throw new ArgumentException(
                    "Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication."
                );

            MatrixByte result = new MatrixByte(mat1.Rows, mat2.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat2.Columns; j++)
                {
                    for (int k = 0; k < mat1.Columns; k++)
                    {
                        result[i, j] += (byte)(mat1[i, k] * mat2[k, j]);
                    }
                }
            }
            return result;
        }

        public static VectorByte operator *(MatrixByte mat, VectorByte vec)
        {
            if (mat.Columns != vec.Size)
                throw new ArgumentException(
                    "Number of columns in the matrix must be equal to the size of the vector for multiplication."
                );

            VectorByte result = new VectorByte(mat.Rows);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i] += (byte)(mat[i, j] * vec[j]);
                }
            }
            return result;
        }

        public static MatrixByte operator *(MatrixByte mat, byte scalar)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] * scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator /(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for division.");

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat2[i, j] == 0)
                        throw new DivideByZeroException("Division by zero.");

                    result[i, j] = (byte)(mat1[i, j] / mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator /(MatrixByte mat, byte scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("Division by zero.");

            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] / scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator %(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for modulo operation.");

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat2[i, j] == 0)
                        throw new DivideByZeroException("Modulo by zero.");

                    result[i, j] = (byte)(mat1[i, j] % mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator %(MatrixByte mat, byte scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("Modulo by zero.");

            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] % scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator |(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for bitwise OR operation.");

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] | mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator |(MatrixByte mat, byte scalar)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] | scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator ^(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException(
                    "Matrix sizes must be equal for bitwise XOR operation."
                );

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] ^ mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator ^(MatrixByte mat, byte scalar)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] ^ scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator &(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException(
                    "Matrix sizes must be equal for bitwise AND operation."
                );

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] & mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator &(MatrixByte mat, byte scalar)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] & scalar);
                }
            }
            return result;
        }

        public static MatrixByte operator >>(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException(
                    "Matrix sizes must be equal for bitwise right shift operation."
                );

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] >> mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator >>(MatrixByte mat, sbyte shift)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] >> shift);
                }
            }
            return result;
        }

        public static MatrixByte operator <<(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException(
                    "Matrix sizes must be equal for bitwise left shift operation."
                );

            MatrixByte result = new MatrixByte(mat1.Rows, mat1.Columns);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    result[i, j] = (byte)(mat1[i, j] << mat2[i, j]);
                }
            }
            return result;
        }

        public static MatrixByte operator <<(MatrixByte mat, sbyte shift)
        {
            MatrixByte result = new MatrixByte(mat.Rows, mat.Columns);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i, j] = (byte)(mat[i, j] << shift);
                }
            }
            return result;
        }

        public static bool operator ==(MatrixByte mat1, MatrixByte mat2)
        {
            if (ReferenceEquals(mat1, null) || ReferenceEquals(mat2, null))
                return false;

            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                return false;

            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat1[i, j] != mat2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator !=(MatrixByte mat1, MatrixByte mat2)
        {
            return !(mat1 == mat2);
        }

        public static bool operator >(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for comparison.");

            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat1[i, j] <= mat2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator >=(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for comparison.");

            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat1[i, j] < mat2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator <(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for comparison.");

            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat1[i, j] >= mat2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator <=(MatrixByte mat1, MatrixByte mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Columns != mat2.Columns)
                throw new ArgumentException("Matrix sizes must be equal for comparison.");

            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    if (mat1[i, j] > mat2[i, j])
                        return false;
                }
            }

            return true;
        }
    }
}
