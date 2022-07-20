using Nito.AsyncEx;

namespace Dramankadeh.Core.Helper;

public static class GigAsyncHelpers
{
    public static void RunSync(Func<Task> task)
    {
        AsyncContext.Run(task);
    }

    public static T RunSync<T>(Func<Task<T>> task)
    {
        return AsyncContext.Run(task);
    }

    // public static void RunSync(Func<Task> task)
    // {
    //     var oldContext = SynchronizationContext.Current;
    //     var synch = new ExclusiveSynchronizationContext();
    //     SynchronizationContext.SetSynchronizationContext(synch);
    //     synch.Post(async _ =>
    //     {
    //         try
    //         {
    //             await task();
    //         }
    //         catch (Exception e)
    //         {
    //             synch.InnerException = e;
    //         }
    //         finally
    //         {
    //             synch.EndMessageLoop();
    //         }
    //     }, null);
    //     synch.BeginMessageLoop();
    //
    //     SynchronizationContext.SetSynchronizationContext(oldContext);
    //     if (synch.InnerException != null)
    //     {
    //         throw synch.InnerException;
    //     }
    // }
    //
    //  public static T RunSync<T>(Func<Task<T>> task)
    // {
    //     var oldContext = SynchronizationContext.Current;
    //     var synch = new ExclusiveSynchronizationContext();
    //     SynchronizationContext.SetSynchronizationContext(synch);
    //     T ret = default;
    //     synch.Post(async _ =>
    //     {
    //         try
    //         {
    //             ret = await task();
    //         }
    //         catch (Exception e)
    //         {
    //             synch.InnerException = e;
    //         }
    //         finally
    //         {
    //             synch.EndMessageLoop();
    //         }
    //     }, null);
    //     synch.BeginMessageLoop();
    //     SynchronizationContext.SetSynchronizationContext(oldContext);
    //     if (synch.InnerException != null)
    //     {
    //         throw synch.InnerException;
    //     }
    //     return ret;
    // }
    //
    // private class ExclusiveSynchronizationContext : SynchronizationContext
    // {
    //     private bool done;
    //     public Exception InnerException { get; set; }
    //     readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
    //     readonly Queue<Tuple<SendOrPostCallback, object>> items =
    //         new Queue<Tuple<SendOrPostCallback, object>>();
    //
    //     public override void Send(SendOrPostCallback d, object state)
    //     {
    //         throw new NotSupportedException("We cannot send to our same thread");
    //     }
    //
    //     public override void Post(SendOrPostCallback d, object state)
    //     {
    //         lock (items)
    //         {
    //             items.Enqueue(Tuple.Create(d, state));
    //         }
    //         workItemsWaiting.Set();
    //     }
    //
    //     public void EndMessageLoop()
    //     {
    //         Post(_ => done = true, null);
    //     }
    //
    //     public void BeginMessageLoop()
    //     {
    //         while (!done)
    //         {
    //             Tuple<SendOrPostCallback, object> task = null;
    //             lock (items)
    //             {
    //                 if (items.Count > 0)
    //                 {
    //                     task = items.Dequeue();
    //                 }
    //             }
    //             if (task != null)
    //             {
    //                 task.Item1(task.Item2);
    //                 if (InnerException != null) // the method threw an exeption
    //                 {
    //                     throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
    //                 }
    //             }
    //             else
    //             {
    //                 workItemsWaiting.WaitOne(TimeSpan.FromSeconds(10));
    //             }
    //         }
    //     }
    //
    //     public override SynchronizationContext CreateCopy()
    //     {
    //         return this;
    //     }
    // }
}