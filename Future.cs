namespace Dwolla.Core
{
    using System;
    using System.Threading;

    public class Future<T>
    {
        public Func<T> Expression { get; private set; }
        public bool Complete { get; private set; }

        private T _value;
        public T Value
        {
            get {
                if (!Complete)
                {
                    Thread.Sleep(10);
                }
                return _value;
            }
            private set { _value = value; }
        }

        protected Exception Error { get; set; }

        public Future(Func<T> expression)
        {
            Expression = expression;

            Expression.BeginInvoke(CompleteCallback, null);
        }

        private void CompleteCallback(IAsyncResult ar)
        {
            try
            {
                Value = Expression.EndInvoke(ar);
            } 
            catch (Exception ex)
            {
                Error = ex;
            }
            Complete = true;
        }

        public static implicit operator T(Future<T> future)
        {
            return future.Value;
        }

        public static implicit operator Future<T>(T value)
        {
            return new Future<T>(() => value);
        }

        public static implicit operator Future<T>(Func<T> expression)
        {
            return new Future<T>(expression);
        }

        public static implicit operator Func<T>(Future<T> future)
        {
            return () => future.Value;
        }
    }
}
