function Follow(id) {
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "/Follow/" + id);
    xhr.send();
    xhr.onload = () => {
        if (xhr.status === 200) {
            const button = document.getElementById("button-" + id);
            button.innerText = "Unfollow";
            button.setAttribute("onclick", "Unfollow('" + id + "')");
            button.classList.add("button-secondary");
        }
    }
}

function Unfollow(id) {
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "/Unfollow/" + id);
    xhr.send();
    xhr.onload = () => {
        if (xhr.status === 200) {
            const button = document.getElementById("button-" + id);
            button.innerText = "Follow";
            button.setAttribute("onclick", "Follow('" + id + "')");
            button.classList.remove("button-secondary");
        }
    }
}