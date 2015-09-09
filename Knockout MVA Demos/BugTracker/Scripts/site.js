/// <reference path="models.js" />

var AppViewModel = function () {
	var self = this;

	self.developers = ko.observableArray([]);
	self.bugs = ko.observableArray([]);

	self.isModifyDeveloper = false;
	self.currentDeveloper = ko.observable(new Developer());

	self.saveDeveloper = function () {
		// add developer
		if(!self.isModifyDeveloper) self.developers.unshift(self.currentDeveloper());
		// reset developer
		self.currentDeveloper(new Developer());
		self.isModifyDeveloper = false;
	}

	self.modifyDeveloper = function(developer) {
		// developer will automatically be the one the user clicked on
		self.currentDeveloper(developer);
		self.isModifyDeveloper = true;
	}

	self.currentBug = ko.observable(new Bug());
	self.saveBug = function () {
		self.bugs.unshift(self.currentBug());
		self.currentBug(new Bug());
	}

	ko.components.register('developers-display', {
		template: ' <ul data-bind="foreach: developers" class="list-group"> \
						<li class="list-group-item btn" data-bind="text: fullName, click:$root.modifyDeveloper"></li> \
					</ul>',
		viewModel: function (params) {
			this.developers = params.developers;
		}
	});
}

// Bind up the view model
ko.applyBindings(new AppViewModel());