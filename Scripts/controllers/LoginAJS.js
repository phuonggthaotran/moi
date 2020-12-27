/// <reference path="../angular.js" />
//var myapp = angular.module("Login", []);
//myapp.controller("LoginController", function LoginController($rootScope, $window, $http) {

//    $rootScope.DangNhap = null;
//    $rootScope.US = "";
//    $rootScope.PW = "";
//    $rootScope.Dn = function (name, pass) {
//        $http({
//            method: 'POST',
//            params: { us: name, pw: pass },
//            url: '/Admin/DangNhap/Login'
//        }).then(function (d) {
//            if (d.data == "") {
//                $rootScope.US = "";
//                $rootScope.PW = "";
//                alert("tài khoản người dùng không đúng");
//            }
//            else {
//                if (d.data.chucvu == "Admin") {
//                    $rootScope.DangNhap = d.data;
//                    $window.location.href = '/Admin/Brand/Index';
//                }
//                //if (d.data.chucvu == "KhachHang") {
//                //    $rootScope.DangNhap = d.data;
//                //    $window.location.href = '/GioHang/Index';
//                //    $rootScope.listgiohang2 = null;
//                //    $http({
//                //        method: 'Post',
//                //        url: '/GioHang/getgiohang2',
//                //        params: { user: d.data.username }
//                //    }).then(function (e) {
//                //        if (e.data == "") {
//                //            alert("Giỏ Hàng Rỗng");
//                //        }
//                //        else {
//                //            $rootScope.listgiohang2 = e.data;
//                //        }
//                //    });
//            }
//        }, function (e) { alert(e); });
//    };
//    //$http.get('/GioHang/getgiohang').then(function (d) {
//    //    $rootScope.listgiohang = d.data;
//    //});

//});
var myapp = angular.module("Login", []);



myapp.controller("LoginController", function LoginController($rootScope, $window, $http) {

    $rootScope.Users = null;
    $rootScope.UN = "";
    $rootScope.PW = "";

    $rootScope.Login = function (un, pw) {

        $http({
            method: 'POST',
            params: { us: un, pw: pw },
            url: '/Admin/Login/DangNhap'
        }).then(function (d) {
            if (d.data == "") {
                alert("Tài khoản người dùng không đúng");
                $rootScope.UN = "";
                $rootScope.PW = "";
            }
            else {
                $rootScope.Users = d.data;
                $window.location.href = '/Admin/Brand/Index';
            }
        }, function (e) { });
    };
};
myapp.controller("UserController", UserController);
function UserController($scope, $rootScope, $http, $window) {

    $scope.Signup = function () {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/Admin/Signup/Signup',
            data: JSON.stringify($scope.us)
        }).then(function (d) {
            //alert($scope.s.MaSP);
            if (d.data == "") {
                $scope.ListUser.push($scope.us);
                $scope.us = null;
                alert("Đăng ký thành công...!");
            }
            else {
                alert(d.data);
            }
        }, function (e) {
            alert("Lỗi nhập...!");
        });
    };

    //Danh sách user
    $http.get('/Admin/QLUser/GetUsers').then(function (d) {
        $rootScope.ListUser = d.data;
    }, function (error) { alert('Failed'); });

    $scope.Them = function () {
        $scope._function = "Thêm";
        $scope.buttext = "Save";
        $scope.s = null;
    };


};
