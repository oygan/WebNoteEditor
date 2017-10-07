angular.module('GoodNoteApp', [])
    .controller('NotesScriptController',
        function ($scope, $http) {
            $scope.note = new Object();
            $scope.note.title = "loading notes...";
            $scope.note.text = "";
            $scope.contents = [];
        })
    .controller('NotesScriptController',
        function($scope, $http) {
            $scope.loadNote = function (noteId) {
                $scope.note = new Object();
                $scope.note.Title = "loading notes...";
                $scope.contents = [];

                $http.get("/api/Note/" + noteId).success(function (data, status, headers, config) {
                    $scope.note = data;
                    $scope.editing = data.IsEdit;

                    $http.get("/api/Note").success(function (data, status, headers, config) {
                        $scope.contents = data;
                    }).error(function (data, status, headers, config) {
                        $scope.errorHint = "Oops... something went wrong on the titles loding";
                    });

                }).error(function (data, status, headers, config) {
                    $scope.errorHint = "Oops... something went wrong on the note loding";
                });
            }
            $scope.saveNote = function (note) {
                $http.post("/api/Note", note).success(function (data, status, headers, config) {
                    $scope.editing = true;

                    $scope.loadNote(note.Id);

                }).error(function (data, status, headers, config) {
                    $scope.errorHint = "Oops... something went wrong on the note post";
                });
            }
            $scope.removeNote = function (note) {
                $http.delete("/api/Note/" + note.Id).success(function (data, status, headers, config) {
                    $scope.editing = true;
                    $scope.loadNote(-1);

                }).error(function (data, status, headers, config) {
                    $scope.errorHint = "Oops... something went wrong on the note delete";
                });
            }
        })

