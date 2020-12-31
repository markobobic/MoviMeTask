$(document).ready(function () {
    dataTable = $("#filmsTable").DataTable({
        "processing": true,
        "ajax": {
            "url": "/Film/GetData/",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            { 'data': 'id', defaultContent: '' },
            { "data": "Name", "searchable": false },
            { "data": "GenreName", "searchable": false },
            { "data": "DirectorName", "searchable": false },
            { "data": "ProducerName", "searchable": false },
            {
                "data": 'Actors',
                "render": function (value, type, row, meta) {
                    var output = "";
                    for (var i = 0; i < value.length; i++) {
                        output += value[i];
                        if (i < value.length - 1) {
                            output += ", ";
                        }
                    }
                    return output;
                }
            },
            { "data": "Price", "searchable": false },
            { "data": "Amount", "searchable": false }, 
            { "data": "Description", "searchable": false },
            {
                "data": "DateOfRelese", render: function (data) {
                    return moment(data).format("DD.MM.YYYY.")
                }
            },
            { "data": "IMDBRating", "searchable": false },
            {
                "data": "Id", "width": "22%", sortable: false, render: function (data) {

                    return "<a class='btn btn-outline-info btn-block btn-sm'" +
                                    "data-toggle='modal' data-target='#modalAdd'onclick=PopupForm('/Film/Update/" +
                                data + "')><i class='far fa-edit'></i>Update</a><a class='btn btn-outline-success btn-block btn-sm'"  +
                                    "onclick=Delete(" + data + ")><i class='fa fa-trash'></i> Delete</a >";
                }
            }
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

function Delete(id) {
    bootbox.confirm({
        message: "Are you sure you want to delete?",
        buttons: {
            cancel: {
                label: 'No',
                className: 'bot-box-button-decline'
            },
            confirm: {
                label: 'Yes',
                className: 'bot-box-button'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    type: "POST",
                    url: '/Film/Delete/' + id,
                    success: function (data) {
                        if (data.success) {
                            dataTable.ajax.reload();

                        }
                    }
                });

            }
        }


    });
}