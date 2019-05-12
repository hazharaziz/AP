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
                    if (_Input == null)
                    {
                        throw new NullReferenceException();
                    }
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return _Input;
            }
            set
            {
                try
                {
                    if (value == null) 
                    {
                        throw new NullReferenceException();
                    }
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
                _Input = value;
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
            try
            {
                if (_Input == int.MaxValue.ToString())
                {
                    throw new FileNotFoundException();
                }
            }
            catch 
            {
                if (!DoNotThrow)
                {
                    throw;
                }
                ErrorMsg = $"Caught exception {typeof(FileNotFoundException)}";
            }
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                if (_Input == "1")
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch 
            {
                if (!DoNotThrow)
                {
                    throw;
                }
                ErrorMsg = $"Caught exception {typeof(IndexOutOfRangeException)}";
            }
            
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
