var col = [
    {
        title: 'Name', data: 'Name', render: function (data, type, row) {
            return `<a id="btnDelete" class="me-2" data-id="${row.Id}"><i class="fa fa-trash"></i></a>${data}`;
        }, className: 'text-nowrap'
    },
    {
        title: 'Employee Count', data: 'Employees', render: function (data, type, row) {
            return data.length;
        }
    }
];

var table;
var data = {
    PopulateURL: PopulateURL,
    DeleteURL: DeleteURL,
    ColumnIndex: 0,
    IsAsc: true,
    ColumnData: col,
    Data: undefined,
    PageLength: 10
};

$(document).ready(function () {
    LoadDatatable();
    LoadEvents();
});

function LoadDatatable() {
    data.Data = function (e) {
        e.Name = $('#txtName').val();
    };

    table = LoadTable(data);
}

function LoadEvents() {
    $('#txtName').keyup(function (e) {
        if (e.keyCode === 13) {
            table.draw();
        }
    });
}

function Save() {
    $.post(SaveURL).done(function () {
        table.draw();
    });
}