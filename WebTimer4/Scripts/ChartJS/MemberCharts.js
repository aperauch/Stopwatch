var data = [
	{
	    value: 30,
	    color: "#F38630"
	},
	{
	    value: 50,
	    color: "#E0E4CC"
	},
	{
	    value: 100,
	    color: "#69D2E7"
	}
]

//Get context with jQuery - using jQuery's .get() method.
var ctx = $("#MemberChart").get(0).getContext("2d");
//This will get the first returned node in the jQuery collection.
var myNewChart = new Chart(ctx);

//Pie Chart
new Chart(ctx).Pie(data);