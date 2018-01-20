using IntelligentApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static IntelligentApp.ViewModels.ViewModel;

namespace IntelligentApp
{
    public static class Locator
    {
        private static Dictionary<Type, Type> VIEWS = new Dictionary<Type, Type>();

        public static void Register<TViewModel, TView>() where TViewModel : ViewModel
            => VIEWS.Add(typeof(TViewModel), typeof(TView));

        public static Page GetView<TViewModel>(Parameters parameters = null)
        {
            var type = typeof(TViewModel);
            if (!VIEWS.TryGetValue(type, out var viewType))
                throw new InvalidOperationException($"Cannot get view type to {type.Name}");

            var view = Activator.CreateInstance(viewType) as Page;
            if (view == null)
                throw new InvalidOperationException($"Cannot create a view instance");

            ViewModel viewModel;

            if (parameters != null)
                viewModel = Activator.CreateInstance(type, new object[] { parameters }) as ViewModel;
            else
                viewModel = Activator.CreateInstance(type) as ViewModel;

            view.BindingContext = viewModel ?? throw new InvalidOperationException($"Cannot create a viewmodel instance");

            return view;
        }
    }
}
