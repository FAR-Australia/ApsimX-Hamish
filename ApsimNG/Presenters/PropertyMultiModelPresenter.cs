﻿using Models;
using Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Classes;
using UserInterface.Interfaces;
using UserInterface.Presenters;
using UserInterface.Views;

namespace UserInterface.Presenters
{
    public class PropertyMultiModelPresenter: SimplePropertyPresenter
    {
        /// <summary>
        /// The list of child models whose properties are being displayed.
        /// Used with PropertyMultiView and PropertyTreePresenter
        /// </summary>
        private List<object> models = new List<object>();

        /// <summary>
        /// The view.
        /// </summary>
        protected PropertyMultiView view;

        /// <summary>
        /// Attach the model to the view.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="view">The view.</param>
        /// <param name="explorerPresenter">An <see cref="ExplorerPresenter" /> instance.</param>
        public override void Attach(object model, object view, ExplorerPresenter explorerPresenter)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (explorerPresenter == null)
                throw new ArgumentNullException(nameof(explorerPresenter));

            this.model = model as IModel;
            this.view = view as PropertyMultiView;
            this.presenter = explorerPresenter;

            if (this.model != null && !(this.model is IModel))
                throw new ArgumentException($"The model must be an IModel instance");
            if (this.view == null)
                throw new ArgumentException($"The view must be an IPropertyView instance");

            RefreshView(this.model);
            presenter.CommandHistory.ModelChanged += OnModelChanged;
            this.view.PropertyChanged += OnViewChanged;
        }


        /// <summary>
        /// Refresh the view with the model's current state.
        /// </summary>
        public override void RefreshView(IModel model)
        {
            if (model != null)
            {
                models.Clear();
                models.AddRange(this.model.FindAllChildren<IModel>().Where(a => a.GetType() != typeof(Memo)));
                if (models.GroupBy(a => a.GetType()).Count() > 1)
                {
                    throw new ArgumentException($"The models displayed in a PropertyMultiView must all be of the same type");
                }
                if (models.Count() >= 1)
                {
                    view.DisplayProperties(GetProperties(models));
                    return;
                }
                this.model = model;
            }
        }

        /// <summary>
        /// Get a list of properties from the model.
        /// </summary>
        /// <param name="objs">The list of all objects whose properties will be queried.</param>
        private List<PropertyGroup> GetProperties(List<object> objs)
        {
            List<PropertyGroup> propertyGroupList = new List<PropertyGroup>();
            foreach (var item in objs)
            {
                propertyGroupList.Add(GetProperties(item));
            }
            return propertyGroupList;
        }

    }
}
