using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Extensions;

namespace BlazorClient.Logic.View
{
    public class ComponentDisposableBase: ComponentBase, IDisposableBase
    {
        public bool IsDisposed { get; private set; }
        public ICollection<IAsyncDisposable> Disposables { get; } = new List<IAsyncDisposable>();

        public async ValueTask DisposeAsync()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        [Obsolete]
        public void Dispose()
        {
            DisposeAsync().AsTask().Wait();
        }

        private ValueTask Dispose(bool disposing)
        {
            if (IsDisposed || !disposing)
                new ValueTask();
            IsDisposed = true;
            return new ValueTask(Disposables.Select(async x => await x.DisposeAsync()).WhenAll());
        }
    }
}