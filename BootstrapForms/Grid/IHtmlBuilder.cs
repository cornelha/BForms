﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapForms.Grid
{
    public interface IHtmlBuilder
    {
        MvcHtmlString Render();
    }

    public interface IComponent: IHtmlString
    {
        string Render();
    }

    public abstract class BaseComponent : IComponent
    {
        private ViewContext _viewContext;

        public BaseComponent() { }

        public BaseComponent(ViewContext viewContext)
        {
            this._viewContext = viewContext;
        }

        public abstract string Render();

        public virtual string ToHtmlString()
        {
            var writer = new System.IO.StringWriter();
            this._viewContext.Writer.Write(this.Render());
            return writer.ToString();
        }
    }
}