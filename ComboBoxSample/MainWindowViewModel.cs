using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ComboBoxSample
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Item> Source { get; }
        public ReadOnlyReactiveCollection<ItemViewModel> Items { get; }

        public ReactivePropertySlim<ItemViewModel> SelectedItem { get; }

        public MainWindowViewModel()
        {
            Source = new ObservableCollection<Item>(new[] { "Tanaka", "Kimura", "Sakata", "Inoue" }
                .Select(x => new Item(x)));
            Items = Source.ToReadOnlyReactiveCollection(x => new ItemViewModel(x));
            SelectedItem = new ReactivePropertySlim<ItemViewModel>(Items.First());
        }
    }
}
