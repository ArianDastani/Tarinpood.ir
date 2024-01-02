

$("#btnAddFeatures").on("click", function () {

    var txtDisplayName = $("#txtDisplayName").val();
    var txtValue = $("#txtValue").val();

    if (txtDisplayName == "" || txtValue == "") {
        swal.fire(
            'هشدار!',
            "نام و مقدار را باید وارد کنید",
            'warning'
        );
    }
    else {
        $('#tbl_Features tbody').append('<tr> <td>' + txtDisplayName + '</td>  <td>' + txtValue + '</td> <td> <a class="idFeatures btnDelete btn btn-danger"> حذف </a> </td> </tr>');
        $("#txtDisplayName").val('');
        $("#txtValue").val('');
    }
});

$("#tbl_Features").on('click', '.idFeatures', function () {
    $(this).closest('tr').remove();
});



$('#btnAddProduct').on('click', function () {

    var data = new FormData();

    var Name = $("#Name").val();
    var Description = $("#Description").val();
    var Id = $("#Id").val();

    if (Name == "") {
        swal.fire(
            'هشدار!',
            "نام محصول را باید وارد کنید",
            'warning'
        );
    } else if (Description == "") {
        swal.fire(
            'هشدار!',
            "توضیحات محصول را باید وارد کنید",
            'warning');
    } else {

        //دریافت مقادیر از تکس باکس ها و....
        data.append("Name", $("#Name").val());
        data.append("Description", $("#Description").val());
        data.append("Id", $("#Id").val());




        // دریافت عکس های انتخاب شده توسط کاربر و قرار دادن عکس ها در متغیر data
        var fileUpload = $("#imageproduct").get(0);
        var files = fileUpload.files;

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        } 



        //دریافت ویژگی های محصول از جدول
        var dataFeaturesViewModel = $('#tbl_Features tr:gt(0)').map(function () {
            return {
                DisplayName: $(this.cells[0]).text(),
                Value: $(this.cells[1]).text(),
            };
        }).get();

        $.each(dataFeaturesViewModel, function (i, val) {
            data.append('[' + i + '].DisplayName', val.DisplayName);
            data.append('[' + i + '].Value', val.Value);

        });

        // ارسال اطلاعات بع کنترلر
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/admin/product/AddNewProduct",
            contentType: false,
            processData: false,
            data: data,
            success: function (data) {

                if (data.isSuccess == true) {

                    swal.fire(
                        'موفق!',
                        data.message,
                        'success'
                    ).then(function (isConfirm) {
                        window.location.href = "/Admin/Product/AddNewProduct";

                    });
                }
                else {

                    swal.fire(
                        'هشدار!',
                        data.message,
                        'warning'
                    );
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('1');
                alert('2');
            }

        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Do other operation
        });


    }
});
