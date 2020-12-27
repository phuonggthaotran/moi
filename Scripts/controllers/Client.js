
/// <reference path="../angular.min.js" />
/// <reference path="../angular.js" />
var app = angular.module('HomeApp', []);
app.controller("SanPhamCtrl", function ($scope, $rootScope, $http) {
    $http.get('/SanPham/getSP').then(function (d) {
        $scope.dssp = d.data;
    });
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            alert("Đã thêm vào giỏ hàng !");
            ; if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);
            }
        }, function () { alert("lỗi"); });
    };
    $http.get('/GioHang/GetCarts').then(function (d) {
        $rootScope.dsDonHang = d.data.DSDonHang;
    });
    $rootScope.slgiam = function () {
        $scope.SL = $scope.SL - 1;
        $scope.TT = $scope.DG * $scope.SL;

    }
    $rootScope.sltang = function () {
        $scope.SL = $scope.SL + 1;
        $scope.TT = $scope.DG * $scope.SL;

    }
    $rootScope.ThanhToan = function (s) {
        $scope.TSP = s.product_name;
        $scope.DG = s.price;
        $scope.SL = 1;
      //  $scope.TL = s.TenLoai;
        $scope.HA = s.image;
        $scope.TT = $scope.DG * $scope.SL;
    };
    $http.get('/GioHang/GetDonHang').then(function (d) {
        $rootScope.listdh = d.data;
    });
    $rootScope.DatHang = function () {
        $scope.dh.product_name = $scope.TSP;
        $scope.dh.price = $scope.DG;
        $scope.dh.quantity = $scope.SL;
        $scope.dh.total = $scope.TT;
        $scope.dh.status = "Chưa Xác Thực";
        $scope.dh.date = new Date();
        $http({
            method: 'POST',
            datatype: "json",
            url: '/GioHang/themdonhang',
            data: $scope.dh
        }).then(function (d) {
            alert("Đặt hàng thành công!");

        }, function (error) {
            alert(error);
        });
    }
    $rootScope.product_name = "";
    $rootScope.listtimkiem = null;
    $rootScope.Tim = function (Ten) {
        $http({
            method: 'Post',
            url: '/SanPham/timSP',
            params: { product_name: Ten }
        }).then(function (d) {
            if (d.data == "") {
                alert("Không Có Sản phẩm đó");
            }
            else {
                $rootScope.listtimkiem = d.data;
            }
        });
    };
    $scope.sortcolumn = "Gia";
    $scope.reverse = true;
    $scope.dr = "Tăng dần";

    $scope.Chon = function (d) {
        if ($scope.dr == "Tăng dần") {
            $scope.reverse = false;
            $scope.dr = "Giảm dần";
        }
        else {
            $scope.reverse = true;
            $scope.dr = "Tăng dần";
        }
    };
});

app.controller("brand", function ($scope, $http) {
    $http.get("/Home/getThuongHieu").then(function (res) {
        $scope.brand = res.data;
    });
});
app.controller("myctrl", function ($scope, $http) {
    $http.get('/SanPham/getSP').then(function (res) {
        $scope.lisp = res.data;
    });
});
//Lấy chi tiết sản phẩm
//app.controller("spdetail", function ($scope, $http) {
//    $http.get("/SanPham/Chitietsp").then(function (res) {
//        $scope.onesp = res.data;
//    });
//});
const urlParams = new URLSearchParams(window.location.search);
app.controller("spdetail", ($scope, $http) => {
    let id = urlParams.get('id');

    $http.get('/SanPham/chitiet', {
        params: {
            id: id
        }
    }).then(res => {
        $scope.onesp = res.data;
        // get sản phẩm liên quan
        $http.get('/SanPham/getSPLienquan', {
            params: {
                id: $scope.onesp.category_id
            }
        }).then(res => {
            $scope.sanPhamLienQuan = res.data;
        });
        $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            alert("Đã thêm vào giỏ hàng !");
            ; if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);
            }
        }, function () { alert("lỗi"); });
    };
    });
    //
});
app.controller("loaisp", function ($scope, $http) {
    $http.get("/LoaiSanPham/getAllLoaiSP").then(function (res) {
        $scope.loai = res.data;
    });
});
//Lấy sản phẩm theo giá
app.controller("spduoi20", function ($scope, $http) {
    $http.get("/SanPham/duoi20tr").then(function (res) {
        $scope.duoi20 = res.data;
    });
});
app.controller("sptu20den50", function ($scope, $http) {
    $http.get("/SanPham/sptu20den50").then(function (res) {
        $scope.tu20den50 = res.data;
    });
});
app.controller("tren50", function ($scope, $http) {
    $http.get("/SanPham/tren50").then(function (res) {
        $scope.tren50 = res.data;
    });
});
//lấy sản phẩm theo loại
app.controller("tivi4k", function ($scope, $http) {
    $http.get("/SanPham/Tivi4k").then(function (res) {
        $scope.tivi4k = res.data;
    });
});
app.controller("tivi8K", function ($scope, $http) {
    $http.get("/SanPham/tivi8k").then(function (res) {
        $scope.tivi8k = res.data;
    });
});
app.controller("TiviQled", function ($scope, $http) {
    $http.get("/SanPham/TiviQled").then(function (res) {
        $scope.tiviQled = res.data;
    });
});
//Lấy sản phẩm theo kích thước màn hình
app.controller("duoi55inch", function ($scope, $http) {
    $http.get("/SanPham/Duoi55inch").then(function (res) {
        $scope.duoi55 = res.data;
    });
});
app.controller("tren55inch", function ($scope, $http) {
    $http.get("/SanPham/Tren55inch").then(function (res) {
        $scope.tren55 = res.data;
    });
});
