/// <reference path="../angular.js" />
var myapp = angular.module("MyApp", []);
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