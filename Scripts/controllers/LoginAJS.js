/// <reference path="../angular.js" />
var myapp = angular.module("Login", []);
myapp.controller("LoginController", function LoginController($rootScope, $window, $http) {

    $rootScope.DangNhap = null;
    $rootScope.US = "";
    $rootScope.PW = "";
    $rootScope.Dn = function (name, pass) {
        $http({
            method: 'POST',
            params: { us: name, pw: pass },
            url: '/Admin/DangNhap/Login'
        }).then(function (d) {
            if (d.data == "") {
                $rootScope.US = "";
                $rootScope.PW = "";
                alert("tài khoản người dùng không đúng");
            }
            else {
                if (d.data.chucvu == "Admin") {
                    $rootScope.DangNhap = d.data;
                    $window.location.href = '/Admin/Brand/Index';
                }
                //if (d.data.chucvu == "KhachHang") {
                //    $rootScope.DangNhap = d.data;
                //    $window.location.href = '/GioHang/Index';
                //    $rootScope.listgiohang2 = null;
                //    $http({
                //        method: 'Post',
                //        url: '/GioHang/getgiohang2',
                //        params: { user: d.data.username }
                //    }).then(function (e) {
                //        if (e.data == "") {
                //            alert("Giỏ Hàng Rỗng");
                //        }
                //        else {
                //            $rootScope.listgiohang2 = e.data;
                //        }
                //    });
            }
        }, function (e) { alert(e); });
    };
    //$http.get('/GioHang/getgiohang').then(function (d) {
    //    $rootScope.listgiohang = d.data;
    //});

});
