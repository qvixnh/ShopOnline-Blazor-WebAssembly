function MakeUpdateQtyButtonVisible(id, visible) {
    const updateQtybutton = document.querySelector("button[data-itemId='" + id + "']");
    if (visible == true) {
        updateQtybutton.style.display = "inline-block";
    } else {
        updateQtybutton.style.display = "none";
    }
}