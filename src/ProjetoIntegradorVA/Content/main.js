const items = Array.from(document.getElementsByClassName("item"));

showOrHideElements("care");

items.forEach((item) => {
	item.addEventListener("click", onItemClick);
});

function onItemClick(event) {
	const selectedAttribute = event.target.getAttribute("data");
	showOrHideElements(selectedAttribute);
}

function showOrHideElements(selectedAttribute) {
	hideElements();

	if (selectedAttribute === "care") {
		careText.style.display = "flex";
	}
	if (selectedAttribute === "mask") {
		maskText.style.display = "flex";
	}
	if (selectedAttribute === "ventilation") {
		ventilationText.style.display = "flex";
	}
	if (selectedAttribute === "distance") {
		distanceText.style.display = "flex";
	}
}

function hideElements() {
	careText.style.display = "none";
	maskText.style.display = "none";
	ventilationText.style.display = "none";
	distanceText.style.display = "none";
}
