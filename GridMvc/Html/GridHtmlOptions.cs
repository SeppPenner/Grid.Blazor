﻿using GridMvc.Pagination;
using GridMvc.Resources;
using GridShared;
using GridShared.Columns;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace GridMvc.Html
{
    /// <summary>
    ///     Grid adapter for html helper
    /// </summary>
    public class GridHtmlOptions<T> : IGridHtmlOptions<T>
    {
        private readonly IHtmlHelper _helper;
        internal readonly SGrid<T> _source;

        public GridHtmlOptions(IHtmlHelper helper, SGrid<T> source, string viewName)
        {
            _helper = helper;
            _source = source;
            GridViewName = viewName;
        }

        public string GridViewName { get; set; }

        #region IGridHtmlOptions<T> Members

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            _helper.PartialAsync(GridViewName, _source).Result.WriteTo(writer, encoder);
        }

        public IGridHtmlOptions<T> WithGridItemsCount()
        {
            return WithGridItemsCount(string.Empty);
        }

        public string Render()
        {
            using (var sw = new StringWriter())
            {
                WriteTo(sw, HtmlEncoder.Default);
                return sw.ToString();
            }
        }

        public IGridHtmlOptions<T> Columns(Action<IGridColumnCollection<T>> columnBuilder)
        {
            columnBuilder(_source.Columns);
            return this;
        }

        public IGridHtmlOptions<T> WithPaging(int pageSize)
        {
            return WithPaging(pageSize, 0);
        }

        public IGridHtmlOptions<T> WithPaging(int pageSize, int maxDisplayedItems)
        {
            return WithPaging(pageSize, maxDisplayedItems, string.Empty);
        }

        public IGridHtmlOptions<T> WithPaging(int pageSize, int maxDisplayedItems, string queryStringParameterName)
        {
            _source.EnablePaging = true;
            _source.Pager.PageSize = pageSize;

            var pager = _source.Pager as GridPager; //This setting can be applied only to default grid pager
            if (pager == null) return this;

            if (maxDisplayedItems > 0)
                pager.MaxDisplayedPages = maxDisplayedItems;
            if (!string.IsNullOrEmpty(queryStringParameterName))
                pager.ParameterName = queryStringParameterName;
            _source.Pager = pager;
            return this;
        }

        public IGridHtmlOptions<T> Sortable()
        {
            return Sortable(true);
        }

        public IGridHtmlOptions<T> Sortable(bool enable)
        {
            _source.DefaultSortEnabled = enable;
            foreach (IGridColumn column in _source.Columns)
            {
                var typedColumn = column as IGridColumn<T>;
                if (typedColumn == null) continue;
                typedColumn.Sortable(enable);
            }
            return this;
        }

        public IGridHtmlOptions<T> Filterable()
        {
            return Filterable(true);
        }

        public IGridHtmlOptions<T> Filterable(bool enable)
        {
            _source.DefaultFilteringEnabled = enable;
            foreach (IGridColumn column in _source.Columns)
            {
                var typedColumn = column as IGridColumn<T>;
                if (typedColumn == null) continue;
                typedColumn.Filterable(enable);
            }
            return this;
        }

        public IGridHtmlOptions<T> Searchable()
        {
            return Searchable(true, true);
        }

        public IGridHtmlOptions<T> Searchable(bool enable)
        {
            return Searchable(enable, true);
        }

        public IGridHtmlOptions<T> Searchable(bool enable, bool onlyTextColumns)
        {
            _source.SearchingEnabled = enable;
            _source.SearchingOnlyTextColumns = onlyTextColumns;
            return this;
        }

        public IGridHtmlOptions<T> Selectable(bool set)
        {
            _source.RenderOptions.Selectable = set;
            return this;
        }

        public IGridHtmlOptions<T> EmptyText(string text)
        {
            _source.EmptyGridText = text;
            return this;
        }

        public IGridHtmlOptions<T> SetLanguage(string lang)
        {
            _source.Language = lang;
            return this;
        }

        public IGridHtmlOptions<T> SetRowCssClasses(Func<T, string> contraint)
        {
            _source.SetRowCssClassesContraint(contraint);
            return this;
        }

        public IGridHtmlOptions<T> Named(string gridName)
        {
            _source.RenderOptions.GridName = gridName;
            return this;
        }

        /// <summary>
        ///     Generates columns for all properties of the model.
        ///     Use data annotations to customize columns
        /// </summary>
        public IGridHtmlOptions<T> AutoGenerateColumns()
        {
            _source.AutoGenerateColumns();
            return this;
        }

        public IGridHtmlOptions<T> WithMultipleFilters()
        {
            _source.RenderOptions.AllowMultipleFilters = true;
            return this;
        }

        /// <summary>
        ///     Set to true if we want to show grid itmes count
        ///     - Author - Jeeva J
        /// </summary>
        public IGridHtmlOptions<T> WithGridItemsCount(string gridItemsName)
        {
            if (string.IsNullOrWhiteSpace(gridItemsName))
                gridItemsName = Strings.Items;

            _source.RenderOptions.GridCountDisplayName = gridItemsName;
            _source.RenderOptions.ShowGridItemsCount = true;
            return this;
        }

        /// <summary>
        ///    Allow grid to show a SubGrid
        /// </summary>
        public IGridHtmlOptions<T> SubGrid(params string[] keys)
        {
            _source.Keys = keys;
            return this;
        }

        public GridRenderOptions RenderOptions
        {
            get { return _source.RenderOptions; }
        }

        public IGridPager Pager
        {
            get { return _source.Pager; }
        }

        public IGridSettingsProvider Settings
        {
            get { return _source.Settings; }
        }

        #endregion
    }
}