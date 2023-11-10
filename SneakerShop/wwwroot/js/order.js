var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#orderTable').DataTable({
        "ajax": { url: '/admin/order/getall' },
        "columns": [         
            { "data": "id", "width": "10%" },       
            { "data": "name", "width": "10%" }, 
            { "data": "phoneNumber", "width": "10%" }, 
            { "data": "applicationUser.email", "width": "15%" },    
            { "data": "orderStatus", "width": "15%" },  
            { "data": "orderTotal", "width": "15%" }, 
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-50 btn-group" role="group">
                     <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Detail</a>                                  
                    </div>`
                },
                "width": "20%"
            }
        ]
    });
}

