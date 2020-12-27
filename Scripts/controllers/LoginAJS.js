/// <reference path="../angular.js" />

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
});
