function LoadTable(item) {
    var colDirection = item.IsAsc === true ? "asc" : "desc";
    return $(".table").DataTable(
        {
            serverSide: true,
            pageLength: item.PageLength,
            "bFilter": false,
            "processing": false,
            "order": [[item.ColumnIndex, colDirection]],
            ajax: {
                url: item.PopulateURL,
                data: item.Data,
                type: "POST"
            },
            columns: item.ColumnData
        })
        .on('click', '#btnDelete', function () {
            var id = $(this).data("id");
            DeleteItem(item.DeleteURL, id);
        });
}

function DeleteItem(url, id) {
    if (confirm('Are you sure you want to delete this item?')) {
        $.post(url, { id: id }).done(function (e) {
            if (e.success === true) {
                $('.table').DataTable().draw(false);
            }

            // alert
        });
    }
}