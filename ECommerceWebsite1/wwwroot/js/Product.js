var dtable;
$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax": {
            "url": "/Admin/Product/AllProducts",
            "dataSrc": "data"
        },
        "columns": [
            { "data": 'name' },
            { "data": 'description' },
            { "data": 'price' }
        ]
    });
});
