using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }

        public string FinallyBlockStringOut { get; set; }

        public void FinallyBlockMethod(string keyword)
        {
            throw new NotImplementedException();
        }

        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    throw new NullReferenceException();
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            try
            {
                checked
                {
                }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
			try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
 
        }

        public void IndexOutOfRangeExceptionMethod()
        {
 
        }

        public void OutOfMemoryExceptionMethod()
        {
            int[] a = new int[int.MaxValue];
        }

        public void MultiExceptionMethod()
        {
            try
            {
            }
            catch (IndexOutOfRangeException e)
            {
            }
            catch (OutOfMemoryException e)
            {
            }
        }

        public void NestedMethods()
        {
            throw new NotImplementedException();
        }

        public static void ThrowIfOdd(int v)
        {
            if (v % 2 != 0)
            {
                throw new InvalidDataException();
            }
        }
    }
}
