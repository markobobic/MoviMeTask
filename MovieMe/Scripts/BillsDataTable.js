$(document).ready(function () {

    aync: true
    dataTable = $("#billsTable").DataTable({
        "ajax": {
            "url": "/Bill/GetData/",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            { 'data': 'id', defaultContent: '' },
            { "data": "FilmName" },
            {
                "data": "TimeOfPurchase", render: function (data) {
                    return moment(data).format("DD.MM.YYYY.")
                }
            },
            { "data": "TotalPrice", "searchable": true },
        ],
        "lengthMenu": [[10, 50, 100, 200, 300], [10, 50, 100, 200, 300]
        ],
        "responsive": true,
        "dom": 'Bfrtlip',
        initComplete: function () {
            let btns = $('.paginate_button');
            btns.addClass('btn btn-info btn-sm');
            btns.removeClass('paginate_button');
            let searchButton = $("input[type='search']");
            searchButton.addClass('form-control');
            searchButton.attr("placeholder", "Search..");
        },
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0

            },
        ],
        "language": {
            search: "",
            "emptyTable": "No data found"
        },
        "responsive": "true"
    });

    dataTable.on('order.dt search.dt', function () {
        dataTable.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    dataTable.columns().every(function () {
        var datatableColumn = this;

        $(this.footer()).find('input').on('keyup change', function () {
            datatableColumn.search(this.value).draw();
        });
    })
});