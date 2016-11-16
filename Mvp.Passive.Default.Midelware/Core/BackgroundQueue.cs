using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mvp.Passive.Default.Midelware.Core
{
    public class BackgroundQueue
    {
        private readonly object lockObject = new object();

        private Task previousTask = FromResult(true);

        public bool IsIdle { get { return previousTask.IsCompleted; } }

        public Task QueueTask(Action action)
        {
            lock (lockObject)
            {
                previousTask = previousTask.ContinueWith(t => action(), CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
                return previousTask;
            }
        }

        public Task<T> QueueTask<T>(Func<T> work)
        {
            lock (lockObject)
            {
                var task = previousTask.ContinueWith(t => work(), CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
                previousTask = task;
                return task;
            }
        }

        public static Task<T> FromResult<T>(T value)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(value);
            return tcs.Task;
        }
    }
}
