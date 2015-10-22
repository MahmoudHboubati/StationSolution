
var app = angular.module('stationApp', []);

app.controller('stationController', function ($scope, $http, $timeout) {

    $scope.syncEnabled = false;
    $scope.syncBtnName = function () { return $scope.syncEnabled ? "Stop syncing" : "Start syncing"; };
    $scope.loadingText = function () { return $scope.loading ? "Loading..." : ""; }
    $scope.syncEnabledText = function () { return $scope.syncEnabled ? "Syncing enabled" : "Syncing disabled"; }
    $scope.stationStatusList = [];
    $scope.onlineListTitle = function () { return ($scope.stationStatusList.length > 0) ? "On line (" + $scope.stationStatusList.length + ")" : ""; }


    $scope.loadData = function () {

        $scope.loading = true;

        $http({
            method: 'GET',
            url: '/api/Station/GetLiveStations'
        }).then(function successCallback(response) {

            $scope.stationStatusList = response.data;

            $scope.loading = false;

        }, function errorCallback(response) {

            alert(response.data)

            $scope.loading = false;

        });
    };

    $scope.switchSyncing = function () {
        $scope.syncEnabled = !$scope.syncEnabled;
        if ($scope.syncEnabled) $scope.startSync();
    }

    $scope.startSync = function () {

        if ($scope.syncEnabled) {

            var promise = $timeout($scope.loadData, 1000 * $scope.timeIntervalInSec);

            return promise.then(function () {
                $scope.startSync();
            });
        }
    }
});