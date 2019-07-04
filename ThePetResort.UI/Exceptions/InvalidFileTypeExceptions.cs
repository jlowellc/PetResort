using System;

namespace cStoreMVC.UI.Exceptions
{
    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException()
        {

        }

        public InvalidFileTypeException(string mesaage) : base(mesaage)
        {

        }
    }
}