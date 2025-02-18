﻿using GridShared;
using GridShared.Utility;
using System;

namespace GridMvc.Server
{
    /// <summary>
    ///     Grid options for html helper
    /// </summary>
    public interface IGridServer<T>
    {
        IGridServer<T> Columns(Action<IGridColumnCollection<T>> columnBuilder);

        /// <summary>
        ///     Enable paging for grid
        /// </summary>
        /// <param name="pageSize">Setup the page size of the grid</param>
        IGridServer<T> WithPaging(int pageSize);

        /// <summary>
        ///     Enable paging for grid
        /// </summary>
        /// <param name="pageSize">Setup the page size of the grid</param>
        /// <param name="maxDisplayedItems">Setup max count of displaying pager links</param>
        IGridServer<T> WithPaging(int pageSize, int maxDisplayedItems);

        /// <summary>
        ///     Enable paging for grid
        /// </summary>
        /// <param name="pageSize">Setup the page size of the grid</param>
        /// <param name="maxDisplayedItems">Setup max count of displaying pager links</param>
        /// <param name="queryStringParameterName">Query string parameter name</param>
        IGridServer<T> WithPaging(int pageSize, int maxDisplayedItems, string queryStringParameterName);

        /// <summary>
        ///     Enable sorting for all columns
        /// </summary>
        IGridServer<T> Sortable();

        /// <summary>
        ///     Enable or disable sorting for all columns
        /// </summary>
        IGridServer<T> Sortable(bool enable);

        /// <summary>
        ///     Enable filtering for all columns
        /// </summary>
        IGridServer<T> Filterable();

        /// <summary>
        ///     Enable or disable filtering for all columns
        /// </summary>
        IGridServer<T> Filterable(bool enable);

        /// <summary>
        ///     Enable searching for text columns
        /// </summary>
        IGridServer<T> Searchable();

        /// <summary>
        ///     Enable or disable searching for text columns
        /// </summary>
        IGridServer<T> Searchable(bool enable);

        /// <summary>
        ///     Enable or disable searching for all columns
        /// </summary>
        IGridServer<T> Searchable(bool enable, bool onlyTextColumns);

        /// <summary>
        ///     Enable or disable client grid items selectable feature
        /// </summary>
        IGridServer<T> Selectable(bool set);

        /// <summary>
        ///     Setup the text, which will displayed with empty items collection in the grid
        /// </summary>
        /// <param name="text">Grid empty text</param>
        IGridServer<T> EmptyText(string text);

        /// <summary>
        ///     Setup the language of Grid.Mvc
        /// </summary>
        /// <param name="lang">SetLanguage string (example: "en", "ru", "fr" etc.)</param>
        IGridServer<T> SetLanguage(string lang);

        /// <summary>
        ///     Setup specific row css classes
        /// </summary>
        IGridServer<T> SetRowCssClasses(Func<T, string> contraint);

        /// <summary>
        ///     Specify Grid client name
        /// </summary>
        IGridServer<T> Named(string gridName);

        /// <summary>
        ///     Generates columns for all properties of the model.
        ///     Use data annotations to customize columns
        /// </summary>
        IGridServer<T> AutoGenerateColumns();

        /// <summary>
        ///     Allow grid to use multiple filters
        /// </summary>
        IGridServer<T> WithMultipleFilters();

        /// <summary>
        ///    Allow grid to show Grid items count
        /// </summary>
        IGridServer<T> WithGridItemsCount(string gridItemsName);

        /// <summary>
        ///    Allow grid to show Grid items count
        /// </summary>
        IGridServer<T> WithGridItemsCount();

        /// <summary>
        ///    Allow grid to show a SubGrid
        /// </summary>
        IGridServer<T> SubGrid(params string[] keys);

        /// <summary>
        ///     Items, displaying in the grid view
        /// </summary>
        ItemsDTO<T> ItemsToDisplay { get; }

        /// <summary>
        ///     Grid object
        /// </summary>
        SGrid<T> Grid { get; }
    }
}