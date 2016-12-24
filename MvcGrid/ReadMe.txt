

<link href="http://cdn-na.infragistics.com/igniteui/2016.2/latest/css/themes/infragistics/infragistics.theme.css" rel="stylesheet" />
<link href="http://cdn-na.infragistics.com/igniteui/2016.2/latest/css/structure/infragistics.css" rel="stylesheet" />

<script src="http://ajax.aspnetcdn.com/ajax/modernizr/modernizr-2.8.3.js"></script>
<script src="http://code.jquery.com/jquery-1.11.3.min.js"></script>
<script src="http://code.jquery.com/ui/1.11.1/jquery-ui.min.js"></script>

<!-- Ignite UI Required Combined JavaScript Files -->
<script src="http://cdn-na.infragistics.com/igniteui/2016.2/latest/js/infragistics.core.js"></script>
<script src="http://cdn-na.infragistics.com/igniteui/2016.2/latest/js/infragistics.lob.js"></script>

<script src="~/Scripts/jquery-1.10.2.js"></script>


@Html.Infragistics().Loader().ScriptPath("/js/").CssPath("/css").Render()


@using Infragistics.Web.Mvc;
@model IEnumerable<MvcGrid.Models.Customer>


    <!-- Ignite UI Required Combined CSS Files -->


@(Html.Infragistics()
    .Grid<MvcGrid.Models.Customer>(Model)
    .ID("igGrid")
    .Width("600px")
    .Height("600px")
    .AutoGenerateColumns(false)
    .Columns(column =>
    {
        column.For(x => x.CustomerId).HeaderText("CustomerId");
        column.For(x => x.Name).HeaderText("Name");
        column.For(x => x.Address).HeaderText("Address");
    })
    .Features(f =>
    {
        f.ColumnMoving()
            .Mode(MovingMode.Immediate);
        f.GroupBy();
        f.Hiding();
    })
    .DataBind()
    .Render())