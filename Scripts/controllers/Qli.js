
/// <reference path="../angular.js" />
/// <reference path="../angular.min.js" />
var myapp = angular.module("MyApp", ['angularUtils.directives.dirPagination', 'ngFileUpload', 'ui.bootstrap']);
//QL đơn hàng
myapp.controller("QLDonHangController", function ($scope, $rootScope, $http) {
    $http.get('/Admin/QLDonHang/GetDonHang').then(function (d) {
        $scope.listdh = d.data;
    });
    $scope.Xoadonhang = function (s) {
        if (confirm("Bạn có muốn Xóa ?") == true) {
            $http({
                method: 'POST',
                url: '/Admin/QLDonHang/xoadonhang',
                datatype: 'Json',
                data: {
                    id: s.id
                }
            }).then(function (d) {
                var vt = $scope.listdh.indexOf(s);
                $scope.listdh.splice(vt, 1);
                alert("Xóa Thành Công !");
            });
        }
    };
    $scope.Timnd = function (Ngay, Thang, Nam) {
        $http({
            method: 'Post',
            url: '/Admin/QLDonHang/getngaydat',
            params: { ngay: Ngay, thang: Thang, nam: Nam }
        }).then(function (d) {
            if (d.data == "") {
                alert("Không Có Đơn Hàng trong ngày: " + Ngay + '/' + Thang + '/' + Nam);
            }
            else {
                $scope.listdh = d.data;
            }
        });
    };
    $scope.Timtt = function (TrangThai) {
        $http({
            method: 'Post',
            url: '/Admin/QLDonHang/gettrangthai',
            params: { trangthai: TrangThai }
        }).then(function (d) {
            if (d.data == "") {
                alert("Không Có Đơn Hàng: " + TrangThai);
            }
            else {
                $scope.listdh = d.data;
            }
        });
    };
    $scope.Suadonhang = function (s) {
        $scope.sp = s;
    };
    $scope.Savedh = function () {
        $scope.sp.total = $scope.sp.quantity * $scope.sp.price;
        $http({
            method: 'Post',
            datatype: 'Json',
            data: JSON.stringify($scope.sp),
            url: '/Admin/QLDonHang/suadonhang'
        }).then(function (d) {
            if (d.data == "") {
                var index = $scope.listdh
                for (var i = 0; i < $scope.listdh.length; i++) { //Sửa thành công thì tiến hành sửa trên $scope
                    if ($scope.listdh[i].id = $scope.sp.id) {
                        $scope.listdh[i].price = $scope.sp.price;
                        $scope.listdh[i].email = $scope.sp.email;
                        $scope.listdh[i].name = $scope.sp.name;
                        $scope.listdh[i].status = $scope.sp.status;
                        $scope.listdh[i].phone_number = $scope.sp.phone_number;
                        $scope.listdh[i].address_shipping = $scope.sp.address_shipping;
                        $scope.listdh[i].total = $scope.sp.quantity * $scope.listdh[i].price;
                        break;
                    }
                }
            }
            alert("Sửa thành công !");
        }, function (e) { alert(e); });
    }
});
//QLi San Pham
myapp.controller("QLProductController", function ($scope, $rootScope, $http, Upload, $timeout, $document, $window) {
    $http.get('/Admin/Product/getSP').then(function (d) {
        $scope.listsp = d.data;
    });
    $http.get('/Admin/Categories/getLoai').then(res => {
        $rootScope.listlsp = res.data;
    });
    $http.get('/Admin/Supplier/getNCC').then(res => {
        $rootScope.dsncc = res.data;
    });
 
    $scope.ThemSP= function () {
        $scope.c = "Thêm";
        $scope.buttex = "Add";
        $scope.pr = null;
    };
    $scope.SuaSP = function (s) {
        $scope.c = "Sửa";
        $scope.buttex = "Update";
        $scope.pr = s;
    };
    $scope.XoaSP = function (s) {
        if (confirm("Bạn có muốn Xóa ?") == true) {

            $http({
                method: 'Post',
                url: '/Admin/Product/Delete',
                datatype: 'Json',
                data: {
                    id: s.id
                }
            }).then(function (d) {
                var vt = $scope.listsp.indexOf(s);
                $scope.listsp.splice(vt, 1);
                alert("Xóa Thành Công !");
            }, function (error) {
                alert("Lỗi...!");
            });
        }
    };
    $scope.SaveSP = function () {
        //Sửa sản phẩm
        if ($scope.buttex != "Add") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.pr),
                url: '/Admin/Product/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.listsp
                    for (var i = 0; i < $scope.listsp.length; i++) { //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.listsp[i].id = $scope.pr.id) {
                            $scope.listsp[i].category_id = $scope.pr.category_id;
                            $scope.listsp[i].supplier_id = $scope.pr.supplier_id;
                            $scope.listsp[i].product_name = $scope.pr.product_name;
                            $scope.listsp[i].price = $scope.pr.price;
                            $scope.listsp[i].image = $scope.pr.image;
                            $scope.listsp[i].quantity = $scope.pr.quantity;
                            $scope.listsp[i].screensize = $scope.pr.screensize;
                            $scope.listsp[i].resolution = $scope.pr.resolution;
                            $scope.listsp[i].number_of_HDMI_ports = $scope.pr.number_of_HDMI_ports;
                            $scope.listsp[i].number_of_USB_ports = $scope.pr.number_of_USB_ports;
                            $scope.listsp[i].voice_control = $scope.pr.voice_control;
                            $scope.listsp[i].wifi = $scope.pr.wifi;
                           
                            $scope.listsp[i].release_date = $scope.pr.release_date;
                            $scope.listsp[i].isContinue = $scope.pr.isContinue;
                            $scope.listsp[i].description = $scope.pr.description;
                          
                            
                            break;
                        }
                    }
                }
                alert("Sửa thành công !");
            }, function (e) { alert(e); });
        }
        else {
            $http({
                method: 'POST',
                datatype: "json",
                url: '/Admin/Product/Insert',
                data: $scope.pr

            }).then(function (d) {
                if (d.data == "") {
                    $scope.listsp.push($scope.pr);
                    $scope.pr = null;
                    alert("Thêm thành công...!");
                } else {
                    
                }
                window.location.reload();
            }, function (error) {
                alert(error);
            });
        }
    };

    $scope.UploadAnh = function (files, anh) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/Admin/Product/Upload',
                data: { files: $scope.SelectedFiles, product_name: $scope.pr.product_name }
            }).then(function (d) {
                if (anh == 'Anh') {
                    $scope.pr.image = d.data[0];
                }
            }, function (error) { alert("Lỗi...!"); });
        }
    };
    $scope.maxSize = 5;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 5; // Maximum number of items per page.  

    $scope.GetSanPhamList = function () {
        $http.get("http://localhost:64769/Admin/Product/GetSanPhamPT?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListSanPham = response.data.SanPhams;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetSanPhamList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetSanPhamList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetSanPhamList();
    };  

});
//QL Thương hiệu
myapp.controller("QLBrandController", function ($scope, $rootScope, $http, Upload, $timeout, $document, $window) {
    $rootScope.Logout = function () {
        $http({
            method: 'POST',
            url: '/Admin/Login/Logout'
        }).then(function () {
            $window.location.href = '/Admin/Login/Index';
        }, function () { });
    };
    $http.get('/Admin/Brand/getThuongHieu').then(function (d) {
        $scope.listthuonghieu = d.data;
    });
    $scope.ThemDTNB = function () {
        $scope.f = "Thêm";
        $scope.buttex = "Add";
        $scope.sp = null;
    };
    $scope.SuaDTNB = function (s) {
        $scope.f = "Sửa";
        $scope.buttex = "Update";
        $scope.sp = s;
    };
    $scope.XoaDTNB = function (s) {
        if (confirm("Bạn có muốn Xóa ?") == true) {

            $http({
                method: 'Post',
                url: '/Admin/Brand/Delete',
                datatype: 'Json',
                data: {
                    id: s.id
                }
            }).then(function (d) {
                var vt = $scope.listthuonghieu.indexOf(s);
                $scope.listthuonghieu.splice(vt, 1);
                alert("Xóa Thành Công !");
            }, function (error) {
                alert("Lỗi...!");
            });
        }
    };
    $scope.SaveDTNB = function () {
        //Sửa sản phẩm
        if ($scope.buttex != "Add") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.sp),
                url: '/Admin/Brand/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.listthuonghieu
                    for (var i = 0; i < $scope.listthuonghieu.length; i++) { //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.listthuonghieu[i].id = $scope.sp.id) {
                            $scope.listthuonghieu[i].image = $scope.sp.image;
                            $scope.listthuonghieu[i].description = $scope.sp.description;
                            $scope.listthuonghieu[i].name = $scope.sp.name;

                            break;
                        }
                    }
                }
                alert("Sửa thành công !");
            }, function (e) { alert(e); });
        }
        else {
            $http({
                method: 'POST',
                datatype: "json",
                url: '/Admin/Brand/Insert',
                data: JSON.stringify($scope.sp)
            }).then(function (d) {
                if (d.data == "") {
                    $scope.listthuonghieu.push($scope.sp);
                    $scope.sp = null;
                    alert("Thêm thành công...!");
                } else {
                    alert("Thêm thành công...!");
                }
            }, function (error) {
                alert(error);
            });
        }
    };
   
     $scope.UploadFiles = function (files, kieu) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/Admin/Brand/Upload',
                data: { files: $scope.SelectedFiles, name: $scope.sp.name }
            }).then(function (d) {
                if (kieu == 'Anh') {
                    $scope.sp.image = d.data[0];
                }
            }, function (error) { alert("Lỗi...!"); });
        }
    };

});
//QL nhà cung cấp
myapp.controller("QLSupplierController", function ($scope, $rootScope, $http, $timeout, $document, $window) {
    $http.get('/Admin/Supplier/getNCC').then(function (d) {
        $scope.listNCC= d.data;
    });
   
    $scope.ThemNCC = function () {
        $scope.b = "Thêm";
        $scope.buttex = "Add";
        $scope.ncc = null;
    };
    $scope.SuaNCC= function (s) {
        $scope.b = "Sửa";
        $scope.buttex = "Update";
        $scope.ncc = s;
    };
    $scope.XoaNCC = function (s) {
        if (confirm("Bạn có muốn Xóa ?") == true) {

            $http({
                method: 'Post',
                url: '/Admin/Supplier/Delete',
                datatype: 'Json',
                data: {
                    id: s.id
                }
            }).then(function (d) {
                var vt = $scope.listNCC.indexOf(s);
                $scope.listNCC.splice(vt, 1);
                alert("Xóa Thành Công !");
            }, function (error) {
                alert("Lỗi...!");
            });
        }
    };
    $scope.SaveNCC = function () {
        //Sửa sản phẩm
        if ($scope.buttex != "Add") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.ncc),
                url: '/Admin/Supplier/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.listNCC
                    for (var i = 0; i < $scope.listNCC.length; i++) { //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.listNCC[i].id = $scope.ncc.id) {
                            $scope.listNCC[i].name = $scope.ncc.name;
                            $scope.listNCC[i].phone_number = $scope.ncc.phone_number;
                            $scope.listNCC[i].email = $scope.ncc.email;
                            $scope.listNCC[i].address = $scope.ncc.address;
                            break;
                        }
                    }
                }
                alert("Sửa thành công !");
            }, function (e) { alert(e); });
        }
        else {
            $http({
                method: 'POST',
                datatype: "json",
                url: '/Admin/Supplier/Insert',
                data: JSON.stringify($scope.ncc)
            }).then(function (d) {
                if (d.data == "") {
                    $scope.listNCC.push($scope.ncc);
                    $scope.ncc = null;
                    alert("Thêm thành công...!");
                } else {
                    alert("Thêm thành công...!");
                }
            }, function (error) {
                alert(error);
            });
        }
    };
});
// QL loại sp
myapp.controller("QLCategoryController", function ($scope, $rootScope, $http, $timeout, $document, $window) {
    $http.get('/Admin/Categories/getLoai').then(function (d) {
        $scope.listloaisp = d.data;
    });
    $http.get('/Admin/Brand/getThuongHieu').then(res => {
        $rootScope.th = res.data;
    });

    $scope.ThemLoai = function () {
        $scope.a = "Thêm";
        $scope.buttex = "Add";
        $scope.loai = null;
    };
    $scope.SuaLoai = function (s) {
        $scope.a = "Sửa";
        $scope.buttex = "Update";
        $scope.loai = s;
    };
    $scope.XoaLoai = function (s) {
        if (confirm("Bạn có muốn Xóa ?") == true) {

            $http({
                method: 'Post',
                url: '/Admin/Categories/Delete',
                datatype: 'Json',
                data: {
                    id: s.id
                }
            }).then(function (d) {
                var vt = $scope.listloaisp.indexOf(s);
                $scope.listloaisp.splice(vt, 1);
                alert("Xóa Thành Công !");
            }, function (error) {
                alert("Lỗi...!");
            });
        }
    };
    $scope.SaveLoai = function () {
        //Sửa sản phẩm
        if ($scope.buttex != "Add") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.loai),
                url: '/Admin/Categories/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.listloaisp
                    for (var i = 0; i < $scope.listloaisp.length; i++) { //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.listloaisp[i].id = $scope.loai.id) {
                            $scope.listloaisp[i].brand_id = $scope.loai.brand_id;
                            $scope.listloaisp[i].name = $scope.loai.name;
                            $scope.listloaisp[i].description = $scope.loai.description;
                          
                            break;
                        }
                    }
                }
                alert("Sửa thành công !");
            }, function (e) { alert(e); });
        }
        else {
            $http({
                method: 'POST',
                datatype: "json",
                url: '/Admin/Categories/Insert',
                data: JSON.stringify($scope.loai)
            }).then(function (d) {
                if (d.data == "") {
                    $scope.listloaisp.push($scope.loai);
                    $scope.loai = null;
                    alert("Thêm thành công...!");
                } else {
                    alert("Thêm thành công...!");
                }
            }, function (error) {
                alert(error);
            });
        }
    };

    //$scope.UploadFiles = function (files, kieu) {
    //    $scope.SelectedFiles = files;
    //    if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
    //        Upload.upload({
    //            url: '/Admin/Categories/Upload',
    //            data: { files: $scope.SelectedFiles, name: $scope.sp.name }
    //        }).then(function (d) {
    //            if (kieu == 'Anh') {
    //                $scope.sp.image = d.data[0];
    //            }
    //        }, function (error) { alert("Lỗi...!"); });
    //    }
    //};

});