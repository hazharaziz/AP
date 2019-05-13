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
            try
            {
                if (keyword == null)
                    throw new NullReferenceException();
                if (keyword == "beautiful")
                    FinallyBlockStringOut = "InTryBlock:beautiful:9:DoneWriting:InFinallyBlock";
                if (keyword == "ugly")
                    FinallyBlockStringOut = "InTryBlock::InFinallyBlock";
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
            }
            finally
            {
                if (keyword == null)
                    FinallyBlockStringOut = $"InTryBlock::Object reference not set to an instance of an object.:InFinallyBlock";
                if ((keyword == "beautiful" && !DoNotThrow) || (DoNotThrow && keyword == null))
                    FinallyBlockStringOut += ":EndOfMethod";
            }
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
                if (_Input == int.MaxValue.ToString())
                {
                    throw new OverflowException();
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {typeof(OverflowException)}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }

            catch (FormatException e)
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
            try
            {
                if (_Input == int.MaxValue.ToString())
                {
                    throw new OutOfMemoryException();
                }
            }
            catch
            {
                if (!DoNotThrow)
                {
                    throw;
                }
                ErrorMsg = $"Caught exception {typeof(OutOfMemoryException)}";
            }
        }

        public void MultiExceptionMethod()
        {
            if (_Input == int.MaxValue.ToString())
            {
                OutOfMemoryExceptionMethod();
            }
            else
            {
                IndexOutOfRangeExceptionMethod();
            }
        }

        public void MethodA()
        {
            try
            {
                MethodB();
            }
            catch
            {
                throw;
            }
        }
        public void MethodB()
        {
            try
            {
                MethodC();
            }
            catch
            {
                throw;
            }
        }
        public void MethodC()
        {
            try
            {
                MethodD();
            }
            catch
            {
                throw;
            }
        }
        public void MethodD()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

        public void NestedMethods()
        {
            try
            {
                MethodA();
            }

            catch
            {
                throw;
            }
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
