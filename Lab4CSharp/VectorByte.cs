using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    public class VectorByte
    {
        protected byte[] BArray; // array of bytes
        protected uint n; // number of elements in the vector
        protected int codeError; // error code
        protected static uint num_vec; // number of vectors

        public VectorByte()
        {
            n = 1;
            BArray = new byte[n];
            num_vec++;
        }

        public VectorByte(uint size)
        {
            n = size;
            BArray = new byte[n];
            num_vec++;
        }

        public VectorByte(uint size, byte initValue)
        {
            n = size;
            BArray = new byte[n];
            for (int i = 0; i < n; i++)
            {
                BArray[i] = initValue;
            }
            num_vec++;
        }

        ~VectorByte()
        {
            Console.WriteLine("VectorByte object is being destroyed.");
        }

        public void InputElements()
        {
            Console.WriteLine("Enter elements of the vector:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                byte element;
                if (byte.TryParse(Console.ReadLine(), out element))
                {
                    BArray[i] = element;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid byte value.");
                    i--;
                }
            }
        }

        public void PrintElements()
        {
            Console.WriteLine("Vector elements:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Element {i + 1}: {BArray[i]}");
            }
        }

        public void SetElements(byte value)
        {
            Array.Fill(BArray, value);
        }

        public static uint NumVectors()
        {
            return num_vec;
        }

        public uint Size
        {
            get { return n; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= n)
                {
                    codeError = -1;
                    return 0;
                }
                codeError = 0;
                return BArray[index];
            }
            set
            {
                if (index < 0 || index >= n)
                {
                    codeError = -1;
                    return;
                }
                BArray[index] = value;
                codeError = 0;
            }
        }

        public static VectorByte operator ++(VectorByte vec)
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i]++;
            }
            return vec;
        }

        public static VectorByte operator --(VectorByte vec)
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i]--;
            }
            return vec;
        }

        public static bool operator true(VectorByte vec)
        {
            if (vec.Size == 0)
                return false;

            for (int i = 0; i < vec.Size; i++)
            {
                if (vec[i] != 0)
                    return true;
            }
            return false;
        }

        public static bool operator false(VectorByte vec)
        {
            if (vec.Size == 0)
                return true;

            for (int i = 0; i < vec.Size; i++)
            {
                if (vec[i] != 0)
                    return false;
            }
            return true;
        }

        public static bool operator !(VectorByte vec)
        {
            return vec.Size != 0;
        }

        public static VectorByte operator ~(VectorByte vec)
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] = (byte)~vec[i];
            }
            return vec;
        }

        public static VectorByte operator +(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for addition.");

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] + vec2[i]);
            }
            return result;
        }

        public static VectorByte operator +(VectorByte vec, byte scalar)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] + scalar);
            }
            return result;
        }

        public static VectorByte operator -(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for subtraction.");

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] - vec2[i]);
            }
            return result;
        }

        public static VectorByte operator -(VectorByte vec, byte scalar)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] - scalar);
            }
            return result;
        }

        public static VectorByte operator *(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for multiplication.");

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] * vec2[i]);
            }
            return result;
        }

        public static VectorByte operator *(VectorByte vec, byte scalar)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] * scalar);
            }
            return result;
        }

        public static VectorByte operator /(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for division.");

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                if (vec2[i] == 0)
                    throw new DivideByZeroException("Division by zero.");

                result[i] = (byte)(vec1[i] / vec2[i]);
            }
            return result;
        }

        public static VectorByte operator /(VectorByte vec, byte scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("Division by zero.");

            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] / scalar);
            }
            return result;
        }

        public static VectorByte operator %(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for modulo operation.");

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                if (vec2[i] == 0)
                    throw new DivideByZeroException("Modulo by zero.");

                result[i] = (byte)(vec1[i] % vec2[i]);
            }
            return result;
        }

        public static VectorByte operator %(VectorByte vec, byte scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("Modulo by zero.");

            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] % scalar);
            }
            return result;
        }

        public static VectorByte operator |(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for bitwise OR operation.");

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] | vec2[i]);
            }
            return result;
        }

        public static VectorByte operator |(VectorByte vec, byte scalar)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] | scalar);
            }
            return result;
        }

        public static VectorByte operator ^(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException(
                    "Vector sizes must be equal for bitwise XOR operation."
                );

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] ^ vec2[i]);
            }
            return result;
        }

        public static VectorByte operator ^(VectorByte vec, byte scalar)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] ^ scalar);
            }
            return result;
        }

        public static VectorByte operator &(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException(
                    "Vector sizes must be equal for bitwise AND operation."
                );

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] & vec2[i]);
            }
            return result;
        }

        public static VectorByte operator &(VectorByte vec, byte scalar)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] & scalar);
            }
            return result;
        }

        public static VectorByte operator >>(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException(
                    "Vector sizes must be equal for bitwise right shift operation."
                );

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] >> vec2[i]);
            }
            return result;
        }

        public static VectorByte operator >>(VectorByte vec, byte shift)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] >> shift);
            }
            return result;
        }

        public static VectorByte operator <<(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException(
                    "Vector sizes must be equal for bitwise left shift operation."
                );

            VectorByte result = new VectorByte(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec1[i] << vec2[i]);
            }
            return result;
        }

        public static VectorByte operator <<(VectorByte vec, byte shift)
        {
            VectorByte result = new VectorByte(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (byte)(vec[i] << shift);
            }
            return result;
        }

        public static bool operator ==(VectorByte vec1, VectorByte vec2)
        {
            if (ReferenceEquals(vec1, null) || ReferenceEquals(vec2, null))
                return false;

            if (vec1.Size != vec2.Size)
                return false;

            for (int i = 0; i < vec1.Size; i++)
            {
                if (vec1[i] != vec2[i])
                    return false;
            }

            return true;
        }

        public static bool operator !=(VectorByte vec1, VectorByte vec2)
        {
            return !(vec1 == vec2);
        }

        public static bool operator >(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for comparison.");

            for (int i = 0; i < vec1.Size; i++)
            {
                if (vec1[i] <= vec2[i])
                    return false;
            }

            return true;
        }

        public static bool operator >=(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for comparison.");

            for (int i = 0; i < vec1.Size; i++)
            {
                if (vec1[i] < vec2[i])
                    return false;
            }

            return true;
        }

        public static bool operator <(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for comparison.");

            for (int i = 0; i < vec1.Size; i++)
            {
                if (vec1[i] >= vec2[i])
                    return false;
            }

            return true;
        }

        public static bool operator <=(VectorByte vec1, VectorByte vec2)
        {
            if (vec1.Size != vec2.Size)
                throw new ArgumentException("Vector sizes must be equal for comparison.");

            for (int i = 0; i < vec1.Size; i++)
            {
                if (vec1[i] > vec2[i])
                    return false;
            }

            return true;
        }
    }
}
