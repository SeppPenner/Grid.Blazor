## Blazor client-side

# Data annotations

[Index](Documentation.md)

You can customize grid and column settings using data annotations. In other words, you can mark properties of your model class as grid columns, specify column options, call **AutoGenerateColumns** method, and **GridBlazor** will automatically create columns as you describe in your annotations.

There are some attributes for this:

* **GridTableAttribute**: applies to model classes and specify options for the grid (paging options...)
* **GridColumnAttribute**: applies to model public properties and configure a property as a column with a set of properties
* **GridHiddenColumn**: applies to model public properties and configures a property as a hidden column
* **NotMappedColumnAttribute**: applies to model public properties and configures a property as NOT a column. If a property has this attribute, **GridBlazor** will not add that column to the column collection

For example a model class with the following data annotations:
 
```c#
    [GridTable(PagingEnabled = true, PageSize = 20)]
    public class Foo
    {
        [GridColumn(Title = "Name title", SortEnabled = true, FilterEnabled = true)]
        public string Name { get; set; }

        [GridColumn(Title = "Active Foo?")]
        public bool Enabled { get; set; }

        [GridColumn(Title = "Date", Format = "{0:dd/MM/yyyy}")]
        public DateTime FooDate { get; set; }

        [NotMappedColumn]
        public byte[]() Data { get; set; }
    }
```
describes that the grid table must contain 3 columns (**Name**, **Enabled** and **FooDate**) with custom options. It also enables paging for this grid table and page size as 20 rows.

The steps to build a grid razor page using data annotations with **GridBlazor** are:

1. Create a razor page on the client project to render the grid. The page file must have a .razor extension. An example of razor page is:

    ```razor
        @page "/gridsample"
        @inject IUriHelper UriHelper

        @if (_task.IsCompleted)
        {
            <GridComponent T="Foo" Grid="@_grid"></GridComponent>
        }
        else
        {
            <p><em>Loading...</em></p>
        }

        @functions
        {
            private CGrid<Foo> _grid;
            private Task _task;

            protected override async Task OnInitAsync()
            {
                string url = UriHelper.GetBaseUri() + "api/SampleData/GetFooAutoGenerateColumns";

                var query = new QueryDictionary<StringValues>();
                query.Add("grid-page", "2");

                var client = new GridClient<Foo>(url, query, false, "fooGrid", null).AutoGenerateColumns();
                _grid = client.Grid;

                // Set new items to grid
                _task = client.UpdateGrid();
                await _task;
            }
        }
    ```

    **Notes**:
    * The **columns** parameter passed to the **GridClient** constructor must be **null**

    * You must use the **AutoGenerateColumns** method of the **GridClient** object to configure a grid.

2. Create a controller action in the server project. An example of this type of controller action is: 


    ```c#
        [Route("api/[controller]")]
        public class SampleDataController : Controller
        {
            ...

            [HttpGet("[action]")]
            public ActionResult GetFooAutoGenerateColumns()
            {
                var repository = new FooRepository(_context);
                var server = new GridServer<Foo>(repository.GetAll(), Request.Query,
                    true, "fooGrid", null).AutoGenerateColumns();

                // return items to displays
                return Ok(server.ItemsToDisplay);
            }
        }
    ```

    **Notes**:
    * The **columns** parameter passed to the **GridServer** constructor must be **null**

    * You must use the **AutoGenerateColumns** method of the **GridServer**

**GridBlazor** will generate columns based on your data annotations when the **AutoGenerateColumns** method is invoked. 

You can add custom columns after or before this method is called, for example:

```c#
    var server = new GridServer<Foo>(...).AutoGenerateColumns().Columns(columns=>columns.Add(foo=>foo.Child.Price))
```

```c#
    var client = new GridClient<Foo>(...).AutoGenerateColumns().Columns(columns=>columns.Add(foo=>foo.Child.Price))
```

You can also overwrite grid options. For example using the **WithPaging** method:

```c#
    var server = new GridServer<Foo>(...).AutoGenerateColumns().WithPaging(10)
```

[<- Localization](Localization.md) | [Render button, checkbox, etc. in a grid cell ->](Render_button_checkbox_etc_in_a_grid_cell.md)