/// <reference path="knockout-3.3.0.js" />

var Developer = function (first, last, id) {
	var self = this;

	self.firstName = ko.observable(first);
	self.lastName = ko.observable(last);
	self.id = id;

	self.fullName = ko.pureComputed(function () {
		return self.firstName() + ' ' + self.lastName();
	});
};

var Bug = function (description, id, status, assignedTo, dateClosed) {
	var self = this;
	self.description = ko.observable(description);
	self.id = id;
	self.status = ko.observable(status);
	self.assignedTo = ko.observable(assignedTo);
	self.dateClosed = ko.observable(dateClosed);

	self.inProgress = ko.pureComputed(function () {
		return (typeof self.dateClosed()) === 'undefined';
	});
}