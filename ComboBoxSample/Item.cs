using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;

namespace ComboBoxSample
{
    public class Item
    {
        public ReadOnlyReactivePropertySlim<string> Name { get; }

        public Item(string name)
        {
            Name = Observable.Interval(TimeSpan.FromSeconds(10))
                .Select(_ => $"{name}: {Guid.NewGuid()}")
                .ToReadOnlyReactivePropertySlim(name);
        }
    }

    public class ItemViewModel : IDisposable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public ReadOnlyReactivePropertySlim<string> Name { get; }
        public ItemViewModel(Item item)
        {
            Name = item
                .Name
                .ObserveOnUIDispatcher()
                .ToReadOnlyReactivePropertySlim().AddTo(Disposable);
        }

        public void Dispose() => Disposable.Dispose();
    }
}
