/// <reference path="models.js" />
/// <reference path="knockout-3.3.0.js" />
/// <reference path="require.js" />

define(['knockout-3.3.0'], function (ko) {
	return function AppViewModel() {
		//var self = this;
		console.log('here');
		var developer = new Developer('christopher', 'harrison');
		console.log(developer.firstName);

		this.developers = ko.observableArray([]);
		this.bugs = ko.observableArray([]);

		this.isModifyDeveloper = false;
		this.currentDeveloper = ko.observable(new Developer());

		this.saveDeveloper = function () {
			// add developer
			if (!this.isModifyDeveloper) this.developers.unshift(this.currentDeveloper());
			// reset developer
			this.currentDeveloper(new Developer());
			this.isModifyDeveloper = false;
		}
		this.modifyDeveloper = function (developer) {
			// developer will automatically be the one the user clicked on
			this.currentDeveloper(developer);
			this.isModifyDeveloper = true;
		}

		this.currentBug = ko.observable(new Bug());
		this.saveBug = function () {
			this.bugs.unshift(this.currentBug());
			this.currentBug(new Bug());
		}

		ko.components.register('display-developers', {
			viewModel: function (params) {
				this.developers = params.developers;
				// additional functionality as needed
			},
			template:
				'<ul data-bind="foreach: developers" class="list-group">\
					<li class="list-group-item btn" data-bind="text: fullName, click: $root.modifyDeveloper"></li>\
				</ul>'
		});
	}
});

