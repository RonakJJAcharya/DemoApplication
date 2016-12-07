var app;

(function () {
    app = angular.module("EmployeeTotalIncomeModule", ['ngAnimate']);
})();

app.controller("EmployeeTotalIncomeController", function ($scope, $http) {
    $scope.Name = "Ronak";

    CalculateTotalIncomeInYear();

    function CalculateTotalIncomeInYear() {

        $http.get('/api/EmployeeIncome/').success(function (data) {
            debugger
            $scope.EmployeeIncome = data.totalIncome;
            $scope.AverageEmployeeIncome = data.averageIncome;
            $scope.EmployeeIncomeList = true;
            $scope.AverageEmployeeIncomeList = true;
        })
        .error(function () {
            $scope.error = "An error has occurred while loading data!";
        });
    }
});