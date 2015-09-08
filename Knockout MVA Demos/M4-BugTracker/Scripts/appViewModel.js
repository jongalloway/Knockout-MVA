define(['knockout-3.3.0'], function (ko) {
	return function appViewModel() {
		this.firstName = ko.observable('Bert');
		this.firstNameCaps = ko.pureComputed(function () {
			return this.firstName().toUpperCase();
		}, this);
	};
});