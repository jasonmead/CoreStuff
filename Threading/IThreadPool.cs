namespace Dwolla.Core.Threading
{
    using System;

    public interface IThreadPool
    {
        Future<TResult> QueueItem<TResult>(Func<TResult> item, params Action[] callbacks);
    }
}
