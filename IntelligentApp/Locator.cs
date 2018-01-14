using IntelligentApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IntelligentApp
{
    public static class Locator
    {
        private static Dictionary<Type, Type> VIEWS = new Dictionary<Type, Type>();

        public static void Register<TViewModel, TView>() where TViewModel : ViewModel
            => VIEWS.Add(typeof(TViewModel), typeof(TView));

        public static Page GetView<TViewModel>(IList<ViewModel.Parameter> parameters = null)
        {
            var type = typeof(TViewModel);
            if (!VIEWS.TryGetValue(type, out var viewType))
                throw new InvalidOperationException($"Cannot get view type for {type.Name}");

            var view = Activator.CreateInstance(viewType) as Page;
            if (view == null)
                throw new InvalidOperationException($"Cannot create a view instance");

            var viewModel = Activator.CreateInstance(type) as ViewModel;
            if (viewModel == null)
                throw new InvalidOperationException($"Cannot create a viewmodel instance");

            if (parameters != null)
                viewModel.AddParameters(parameters);

            view.BindingContext = viewModel;

            return view;
        }
    }
}
