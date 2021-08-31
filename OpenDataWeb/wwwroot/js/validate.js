function Check(x) {
	switch (x) {
		case 'Default': UpdateInput(false); break;
		case 'Nome': UpdateInput(true); break;
		case 'Regione': UpdateInput(true); break;
		case 'Provincia': UpdateInput(true); break;
		case 'Lettera': UpdateInput(true); break;
	}
}

function UpdateInput(isRequired = false) {
	if (document.getElementById('parameter').value == "" && isRequired == true) {
		var oldDiv = document.getElementById('parameter');
		oldDiv.remove();

		var x = document.createElement("INPUT");
		x.setAttribute("type", "text");
		x.setAttribute("id", "parameter");
		x.setAttribute("name", "parameter");
		x.setAttribute("required", "true");
		x.setAttribute("class", "input");

		document.getElementById('user-input').appendChild(x);
	}
	else if (document.getElementById('parameter').value == "" && isRequired == false) {
		var oldDiv = document.getElementById('parameter');
		oldDiv.remove();

		var x = document.createElement("INPUT");
		x.setAttribute("type", "text");
		x.setAttribute("id", "parameter");
		x.setAttribute("name", "parameter");
		x.setAttribute("class", "input");

		document.getElementById('user-input').appendChild(x);
	}
}