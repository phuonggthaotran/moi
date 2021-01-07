/// <reference path="../angular.js" />
var app = angular.module('HomeApp', []);
//menu động
app.controller("brand", function ($scope, $http) {
    $http.get("/Home/getThuongHieu").then(function (res) {
        $scope.brand = res.data;
    });
});
//Danh sách sp trang home
app.controller("myctrl", function ($scope, $http, $rootScope) {
    $http.get('/SanPham/getSP').then(function (res) {
        $scope.lisp = res.data;
    });
});
//Lấy chi tiết sản phẩm
app.controller("spdetail", spdetail)
function spdetail($scope, $http, $rootScope) {

    $http.get('/SanPham/chitiet').then(res => {
        $scope.onesp = res.data;
        // get sản phẩm liên quan
        $http.get('/SanPham/getSPLienquan', {
            params: {
                id: $scope.onesp.category_id
            }
        }).then(res => {
            $scope.sanPhamLienQuan = res.data;
        });
    });
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            alert("Đã thêm vào giỏ hàng !");
            if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);
            }
        }, function () { alert("lỗi"); });
    };
    $http.get('/GioHang/GetCarts').then(function (d) {
        $rootScope.dsDonHang = d.data.DSDonHang;
    });
};
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
app.controller("TiviLG", function ($scope, $http) {
    $http.get("/SanPham/TVLG").then(function (res) {
        $scope.tiviLG = res.data;
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
