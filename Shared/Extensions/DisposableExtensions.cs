using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    public static class DisposableExtensions
    {
        public static T DisposeWith<T>(
            this T disposable,
            ICollection<IAsyncDisposable> disposables,
            params IAsyncDisposable[] thenDispose
        )
            where T : IAsyncDisposable
        {
            disposables.Add(disposable);
            thenDispose?.ForEach(disposables.Add);
            return disposable;
        }

        public static T DisposeWith<T>(
            this T disposable,
            IDisposableBase disposableBase,
            params IDisposable[] thenDispose
        )
            where T : IDisposable
        {
            DisposeWith(
                new AsyncDisposableWrapper(disposable),
                disposableBase.Disposables,
                thenDispose.Select(x => new AsyncDisposableWrapper(x)).Cast<IAsyncDisposable>().ToArray()
            );
            return disposable;
        }

        public static T DisposeWith<T>(
            this T disposable,
            ICollection<IAsyncDisposable> disposables,
            params IDisposable[] thenDispose
        )
            where T : IDisposable
        {
            DisposeWith(
                new AsyncDisposableWrapper(disposable),
                disposables,
                thenDispose.Select(x => new AsyncDisposableWrapper(x)).Cast<IAsyncDisposable>().ToArray()
            );
            return disposable;
        }

        public static T DisposeWith<T>(
            this T disposable,
            IDisposableBase disposableBase
        )
            where T : IAsyncDisposable
        {
            return DisposeWith(disposable, disposableBase.Disposables);
        }

        public static T DisposeWith<T>(
            this T disposable,
            CompositeDisposable compositeDisposable
        )
            where T : IDisposable
        {
            return DisposeWith(disposable, compositeDisposable);
        }
    }

    public class AsyncDisposableWrapper : IAsyncDisposable
    {
        private readonly IDisposable _disposable;

        public AsyncDisposableWrapper(IDisposable disposable)
        {
            _disposable = disposable;
        }

        public ValueTask DisposeAsync()
        {
            _disposable.Dispose();
            return default;
        }
    }
}
