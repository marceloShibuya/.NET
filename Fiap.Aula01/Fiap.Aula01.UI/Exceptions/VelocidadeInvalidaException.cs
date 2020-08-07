using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.UI.Exceptions
{
    //exception -> tab tab


    [Serializable]
    public class VelocidadeInvalidaException : Exception
    {
        public VelocidadeInvalidaException() { }
        public VelocidadeInvalidaException(string message) : base(message) { }
        public VelocidadeInvalidaException(string message, Exception inner) : base(message, inner) { }
        protected VelocidadeInvalidaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
