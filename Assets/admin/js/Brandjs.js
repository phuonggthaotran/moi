
$(document).ready(function () {

    $('.edit').click(function () {
        $('#modal-default').modal('show');
    });
    $(document).on('click', '#action_button', function () {
        if ($('#action_button').val() == 'Add') {
            var txtName = $('#brandname').val();
            //var txtImage = $('#image').val();
            var txtdescription = $('#description').val();

            var input = document.getElementById("image");
            var file = input.value.split("\\");
            var txtImage = file[file.length - 1];
            var data = {
                name: txtName,
                image: txtImage,
                description: txtdescription
            };
            console.log(data);
            $.ajax({
                url: '/Admin/Brand/Create',
                type: 'POST',
                data: {
                    model: JSON.stringify(data)
                },
                dataType: "json",
                success: function (data) {
                    if (data) {
                        $('#sample_form')[0].reset();
                        $('#action').val('Add');
                        $('#modal-default').modal('hide');
                        $.notify({
                            title: ' Thông báo',
                            message: 'Thêm thành công',
                            url: ''
                        }, {
                            delay: 3000,
                            template: '<div data-notify="container" style="background-color: #32c787;" class="alert alert-dismissible alert-{0} alert--notify" role="alert">' +
                                '<span data-notify="icon"></span> ' +
                                '<span data-notify="title">{1}</span> ' +
                                '<span data-notify="message">{2}</span>' +
                                '<div class="progress" data-notify="progressbar">' +
                                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                                '</div>' +
                                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                                '<button type="button" aria-hidden="true" data-notify="dismiss" class="alert--notify__close">Close</button>' +
                                '</div>'
                        });

                        $("#data-table").load(window.location + " #data-table");
                    }
                    else {
                        $.notify({
                            title: ' Thông báo',
                            message: 'Thêm thất bại'
                        }, {
                            delay: 3000,
                            placement: {
                                from: "top",
                                align: "left"
                            },
                            template: '<div data-notify="container" style="background-color: #ff6b68;;height: 40px;" class="alert alert-dismissible alert-{0} alert--notify" role="alert">' +
                                '<span data-notify="icon"></span> ' +
                                '<span style="font-size: 13px; position: relative; top: -8px;" data-notify="title">{1}</span> ' +
                                '<span style="font-size: 13px;position: relative; top: -8px;" data-notify="message">{2}</span>' +
                                '<div class="progress" data-notify="progressbar">' +
                                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                                '</div>' +
                                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                                // '<button type="button" aria-hidden="true" data-notify="dismiss" class="alert--notify__close">Close</button>' +
                                '</div>'
                        });
                    }
                }
            })
        }


        if ($('#action_button').val() == 'Edit') {
            var txtid = $('#hidden_id').val();
            var txtName = $('#brandname').val();
            var txtdescription = $('#description').val();
            var input = document.getElementById("image");
            var file = input.value.split("\\");
            var txtImage = file[file.length - 1];
            var data = {
                id: txtid,
                name: txtName,
                image: txtImage,
                description: txtdescription
            };
            console.log(data);
            $.ajax({
                url: '/Admin/Brand/Edit',
                type: 'POST',
                data: {
                    model: JSON.stringify(data)
                },
                dataType: "json",
                success: function (data) {
                    if (data) {
                        $('#sample_form')[0].reset();
                        $('#modal-default').modal('hide');
                        $.notify({
                            title: ' Thông báo',
                            message: 'Sửa thành công',
                            url: ''
                        }, {
                            delay: 3000,
                            template: '<div data-notify="container" style="background-color: #32c787;" class="alert alert-dismissible alert-{0} alert--notify" role="alert">' +
                                '<span data-notify="icon"></span> ' +
                                '<span data-notify="title">{1}</span> ' +
                                '<span data-notify="message">{2}</span>' +
                                '<div class="progress" data-notify="progressbar">' +
                                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                                '</div>' +
                                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                                '<button type="button" aria-hidden="true" data-notify="dismiss" class="alert--notify__close">Close</button>' +
                                '</div>'
                        });

                        $("#data-table").load(window.location + " #data-table");
                    }
                    else {
                        $.notify({
                            title: ' Thông báo',
                            message: 'Sửa thất bại'
                        }, {
                            delay: 3000,
                            placement: {
                                from: "top",
                                align: "left"
                            },
                            template: '<div data-notify="container" style="background-color: #ff6b68;;height: 40px;" class="alert alert-dismissible alert-{0} alert--notify" role="alert">' +
                                '<span data-notify="icon"></span> ' +
                                '<span style="font-size: 13px; position: relative; top: -8px;" data-notify="title">{1}</span> ' +
                                '<span style="font-size: 13px;position: relative; top: -8px;" data-notify="message">{2}</span>' +
                                '<div class="progress" data-notify="progressbar">' +
                                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                                '</div>' +
                                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                                // '<button type="button" aria-hidden="true" data-notify="dismiss" class="alert--notify__close">Close</button>' +
                                '</div>'
                        });
                    }
                }
            })
        }

    });

    $(document).on('click', '.edit', function () {
        var id = $(this).attr('id');
        console.log(id);
        $.ajax({
            url: 'GetByID',
            data: {
                id: id
            },
            type: 'GET',
            dataType: "json",
            success: function (html) {
                $('#brandname').val(html.data.name);
                $('#image').text(html.data.image);
                $('#description').val(html.data.description);
                $('#hidden_id').val(html.data.id);
                $('.modal-title').text("Sửa bản ghi");
                $('#action_button').val("Edit");
                $('#action').val("Edit");
                $('#modal-default').modal('show');
            }
        })
    });
    var id;

    $(document).on('click', '.delete', function () {
        id = $(this).attr('id');
        console.log(id);
        $('#confirmModal').modal('show');
    });

    $('#ok_button').click(function () {
        $.ajax({
            url: 'Delete',
            beforeSend: function () {
                $('#ok_button').text('Deleting...');
            },
            data: {
                id: id
            },
            complete: function (result) {
                if (result) {
                    setTimeout(function () {
                        $('#confirmModal').modal('hide');
                    }, 700);
                    $.notify({
                        title: ' Thông báo',
                        message: 'Xoá thành công',
                        url: ''
                    }, {
                        delay: 3000,
                        template: '<div data-notify="container" style="background-color: #32c787;" class="alert alert-dismissible alert-{0} alert--notify" role="alert">' +
                            '<span data-notify="icon"></span> ' +
                            '<span data-notify="title">{1}</span> ' +
                            '<span data-notify="message">{2}</span>' +
                            '<div class="progress" data-notify="progressbar">' +
                            '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                            '</div>' +
                            '<a href="{3}" target="{4}" data-notify="url"></a>' +
                            '<button type="button" aria-hidden="true" data-notify="dismiss" class="alert--notify__close">Close</button>' +
                            '</div>'
                    });
                    //$("#data-table").load(window.location + "#data-table");
                    $("#data-table").load(window.location + " #data-table");
                }
            }
        })
    });
});