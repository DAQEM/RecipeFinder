function Save(id) {
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "/Save/" + id);
    xhr.send();
    xhr.onload = () => {
        if (xhr.status === 200) {
            const saveButton = document.getElementById("save-button-" + id);
            saveButton.setAttribute("onclick", "Unsave('" + id + "')");
            saveButton.style.backgroundColor = "lightskyblue";
        }
    }
}

function Unsave(id) {
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "/Unsave/" + id);
    xhr.send();
    xhr.onload = () => {
        if (xhr.status === 200) {
            const saveButton = document.getElementById("save-button-" + id);
            saveButton.setAttribute("onclick", "Save('" + id + "')");
            saveButton.style.backgroundColor = "white";
        }
    }
}