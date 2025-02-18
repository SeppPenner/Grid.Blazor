﻿namespace GridBlazor
{
    public class GridOptions
    {
        public GridOptions(string gridName)
        {
            GridName = gridName;
            Selectable = true;
            AllowMultipleFilters = false;
            ShowGridItemsCount = false;
            RenderRowsOnly = false;
        }

        public GridOptions()
            : this(string.Empty)
        {
        }

        /// <summary>
        ///     Is multiple filters allowed
        /// </summary>
        public bool AllowMultipleFilters { get; set; }

        /// <summary>
        ///     Gets or set grid items selectable
        /// </summary>
        public bool Selectable { get; set; }

        /// <summary>
        ///     Specify grid Id on the client side
        /// </summary>
        public string GridName { get; set; }


        /// <summary>
        ///     Specify to render grid body only
        /// </summary>
        public bool RenderRowsOnly { get; set; }

        /// <summary>
        ///     Does items count need to show
        ///     - Author Jeeva J
        /// </summary>
        public bool ShowGridItemsCount { get; set; }

        /// <summary>
        ///     To show string while show grid items count
        ///     - Author Jeeva J
        /// </summary>
        public string GridCountDisplayName { get; set; }

        public static GridOptions Create(string gridName)
        {
            return new GridOptions(gridName);
        }
    }
}