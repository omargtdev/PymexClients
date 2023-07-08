function sendRequest(path, method, body) {
    return new Promise((res, rej) => {
        fetch(path, {
            method,
            body: body ? JSON.stringify(body) : null
        })
            .then(response => response.json())
            .then(response => res(response))
            .catch(err => rej(err));
    });
}

function createRowResult(result, tableBodyContainer) {
    const tr = document.createElement("tr");
    tr.dataset.selected = false;

    tr.innerHTML = `<td class="d-none">${result.id}</td>`; // Always receive an id to hide it
    delete result.id;
    for (let property in result) {  
        tr.innerHTML += `<td>${result[property]}</td>`;
    }
    tr.addEventListener("click", function (e) {
        const selected = this.dataset.selected === "true";
        if (selected)
            return;

        for (let i = 0; i < tableBodyContainer.childElementCount; i++) {
            const row = tableBodyContainer.rows[i];
            if (row.dataset.selected === "true") {
                row.dataset.selected = false;
                row.classList.remove("bg-primary", "text-light");
                break;
            }
        }

        this.dataset.selected = true;
        this.classList.add("bg-primary", "text-light");
    });


    return tr;
}

function makeWaitSpinner() {
    // You need to import the style of spinner to use it
    // (~/Content/utils/spinner)
    const spinner = document.createElement("div");
    spinner.className = "spinner";
    spinner.innerHTML = `
        <div class="rect1"></div>
        <div class="rect2"></div>
        <div class="rect3"></div>
        <div class="rect4"></div>
        <div class="rect5"></div>
    `;

    return spinner
}

function createButton(icon, style, dataset = {}) {
    const btn = document.createElement("button");           
    btn.className = `btn btn-${style} btn-sm`
    btn.style.fontSize = "10px";
    btn.style.marginRight = "2px";
    btn.style.padding = "3px";
    btn.innerHTML = `<i class="fas fa-${icon}"></i>`;
    return btn;
}

function createTableInput(settings = {}, isHide = false) {
    const td = document.createElement("td");
    td.className = isHide ? "d-none" : "";

    const input = document.createElement("input");

    for (let property in settings) {
        input[property] = settings[property];
    }
    
    td.appendChild(input);
    return td;
}

function isNotNullOrEmpty(text) {
    return text && text.trim() !== "";
}

function showMessage(message, style, container) {
    const alert = document.createElement("div");
    alert.className = `alert alert-${style} alert-dismissible mb-0`;
    alert.innerHTML = `
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        ${message}
    `;

    while (container.hasChildNodes())
        container.removeChild(container.firstChild)

    container.appendChild(alert);
}
