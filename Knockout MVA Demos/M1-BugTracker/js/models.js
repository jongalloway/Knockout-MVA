/// <reference path="../lib/knockout/dist/knockout.debug.js" />
/// <reference path="../lib/knockout/dist/knockout.js" />

var Developer = function (first, last) {
    var self = this;
    self.firstName = ko.observable(first);
    self.lastName = ko.observable(last);

    self.fullName = ko.pureComputed(function () {
        return self.firstName() + " " + self.lastName();
    });
};

var Bug = function () {
    var self = this;
    self.description = ko.observable();
    self.status = ko.observable();
    self.assignedTo = ko.observable();
    self.dateClosed = ko.observable();
}

var Project = function () {
    var self = this;
    self.name = ko.observable();
    self.bugs = ko.observableArray([]);
}