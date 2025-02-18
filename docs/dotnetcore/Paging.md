## GridMvc for ASP.NET Core MVC

# Paging

[Index](Documentation.md)

You can call the Html helper extension with the **WithPaging** method to enable paging in your view. You can also configure page size and other parameters:

```razor
    @using GridMvc
    @model IEnumerable<Foo>

    @Html.Grid(Model).Columns(columns =>
    {
        columns.Add(foo => foo.Title);
        columns.Add(foo => foo.Description);
    }).WithPaging(10)
```

In complex cases, you can use your own **SGrid** object. Set the **EnablePaging** property to *true* and use the **Pager** object to configure paging options in your grid:

```c#
    public class FooGrid : SGrid<Foo>
    {
        public FooGrid(IQueryable<TestModel> items) : base(items)
        {
            Columns.Add(foo => foo.Title);
	    Columns.Add(foo => foo.Description);

    	    EnablePaging = true;
	    Pager.PageSize = 10;
        }
    }
```

## Pager options

Property name | Property type | Description
------------- | ------------- | -----------
PageSize | Int32 | Setup the page size for displaying items in the grid


[<- Quick start](Quick_start.md) | [Custom columns ->](Custom_columns.md)