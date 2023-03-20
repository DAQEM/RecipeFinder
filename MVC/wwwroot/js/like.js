function Like(id) {
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "/Like/" + id);
    xhr.send();
    xhr.onload = () => {
        if (xhr.status === 200) {
            const likeButton = document.getElementById("like-button-" + id);
            likeButton.setAttribute("onclick", "Unlike('" + id + "')");
            likeButton.style.backgroundColor = "indianred";
        }
    }
}

function Unlike(id) {
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "/Unlike/" + id);
    xhr.send();
    xhr.onload = () => {
        if (xhr.status === 200) {
            const likeButton = document.getElementById("like-button-" + id);
            likeButton.setAttribute("onclick", "Like('" + id + "')");
            likeButton.style.backgroundColor = "white";
        }
    }
}